using SvclogViewer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SvclogViewer
{
    public class ProgressEventArgs : EventArgs
    {
        public long CurrentPosition { get; set; }
        public long FileSize { get; set; }
    }

    public class SvcIndexer
    {
        public const string RecordStart = "<MessageLogTraceRecord ";
        public const string RecordEnd = "</MessageLogTraceRecord>";

        public event EventHandler<ProgressEventArgs> Progress;

        protected void OnProgress(long curpos, long size)
        {
            var handler = Progress;
            if (handler != null)
                handler(this, new ProgressEventArgs { CurrentPosition = curpos, FileSize = size });
        }

        public List<TraceEvent> Index(StreamReader reader)
        {
            List<TraceEvent> events = new List<TraceEvent>();
            long curPos = 0;
            while (true)
            {
                TraceEvent evt = new TraceEvent();

                evt.PositionStart = FindStringInStream(reader, RecordStart, curPos);
                if (evt.PositionStart == -1)
                    break; // No new tracerecord found
                ReadActivityID(reader, evt, evt.PositionStart, 300);
                ReadTimeAndSource(reader, evt, evt.PositionStart, 120);
                evt.PositionEnd = FindStringInStream(reader, RecordEnd, evt.PositionStart);
                if (evt.PositionEnd == -1)
                    break; // A tracerecord was found, but the ending was not found
                evt.PositionEnd = evt.PositionEnd + RecordEnd.Length;
                evt.Method = FindMethod(reader, evt.PositionStart, evt.PositionEnd);

                // Start searching from the endposition again
                curPos = evt.PositionEnd;

                events.Add(evt);
            }

            OnProgress(reader.BaseStream.Length, reader.BaseStream.Length);
            return events;
        }

        private string FindMethod(StreamReader reader, long startPos, long endPos)
        {
            long pos = FindStringInStream(reader, "Body", startPos, endPos);
            if (pos == -1)
                return string.Empty;
            reader.BaseStream.Seek(pos, SeekOrigin.Begin);
            reader.DiscardBufferedData();
            char[] buffer = new char[200];
            int charsRead = reader.ReadBlock(buffer, 0, buffer.Length);
            string str = new string(buffer, 0, charsRead);
            Match m = Regex.Match(str, @".*?<(.*?) .*", RegexOptions.IgnoreCase);
            if (m != null && m.Success)
            {
                string method = m.Groups[1].Value;
                if (method.Contains(":"))
                {
                    method = method.Split(':')[1];
                }
                return method;
            }
            return string.Empty;
        }

        public List<long> FindOccurrences(StreamReader reader, string needle)
        {
            List<long> occurrences = new List<long>();
            long curPos = 0;
            while (true)
            {
                curPos = FindStringInStream(reader, needle, curPos);
                if (curPos == -1)
                    break;
                occurrences.Add(curPos);
                curPos += needle.Length;
            }

            OnProgress(reader.BaseStream.Length, reader.BaseStream.Length);
            return occurrences;
        }

        private void ReadTimeAndSource(StreamReader reader, TraceEvent evt, long fromPosition, long sizeToScan)
        {
            reader.BaseStream.Seek(fromPosition, SeekOrigin.Begin);
            reader.DiscardBufferedData();
            char[] buffer = new char[sizeToScan];
            int charsRead = reader.ReadBlock(buffer, 0, buffer.Length);
            string str = new string(buffer, 0, charsRead);
            Match m = Regex.Match(str, @"Time=""(.*?)"".*?Source=""(.*?)""", RegexOptions.IgnoreCase);
            if (m != null && m.Success)
            {
                string dt = m.Groups[1].Value;
                DateTime parsedDt;
                if (DateTime.TryParse(dt, out parsedDt))
                    evt.TimeCreated = parsedDt;
                evt.Source = m.Groups[2].Value;
                evt.Source = evt.Source.Replace("SendRequest", "").Replace("ReceiveReply", "").Replace("Send", "").Replace("Receive", "");
            }
        }

        private void ReadActivityID(StreamReader reader, TraceEvent evt, long fromPosition, long sizeToScan)
        {
            reader.BaseStream.Seek(fromPosition - sizeToScan, SeekOrigin.Begin);
            reader.DiscardBufferedData();
            char[] buffer = new char[sizeToScan];
            int charsRead = reader.ReadBlock(buffer, 0, buffer.Length);
            string str = new string(buffer, 0, charsRead);
            Match m = Regex.Match(str, ".*?ActivityID=\"{(.*?)}.*", RegexOptions.IgnoreCase);
            if (m != null && m.Success)
            {
                string guid = m.Groups[1].Value;
                Guid parsedGuid;
                if (Guid.TryParse(guid, out parsedGuid))
                    evt.ActivityID = parsedGuid;
            }
        }

        private long FindStringInStream(StreamReader reader, string needle, long fromPosition, long maxPosition = -1)
        {
            reader.BaseStream.Seek(fromPosition, SeekOrigin.Begin);
            reader.DiscardBufferedData();
            char[] buffer = new char[4096];
            int charsRead;
            int count = 0;
            while ((charsRead = reader.Read(buffer, 0, buffer.Length)) > 0)
            {
                OnProgress(fromPosition, reader.BaseStream.Length);
                for (int c = 0; c < charsRead; c++)
                {
                    // Max reached?
                    if (maxPosition != -1 && maxPosition < fromPosition + c)
                        return -1;

                    // Part of our needle?
                    if (buffer[c] == needle[count])
                        count++;
                    else
                        count = 0;

                    // Needle complete?
                    if (count == needle.Length)
                        return fromPosition + (c+1) - needle.Length;
                }
                fromPosition += charsRead;
            }
            return -1;
        }
    }
}
