using SvclogViewer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvclogViewer
{
    public class AnalyzeEventArgs : EventArgs
    {
        public string CurrentFileName { get; set; }
        public FileAccess CurrentOperation { get; set; }
        public long CurrentPosition { get; set; }
        public long FileSize { get; set; }
    }

    public class SvcAnalyzer
    {
        public event EventHandler<AnalyzeEventArgs> Progress;

        private string _currentFile;
        private FileAccess _currentOperation;

        public void Analyze(string[] contentFilters, params string[] files)
        {
            var indexer = new SvcIndexer();
            indexer.Progress += HandleIndexerProgress;

            foreach (var file in files)
            {
                OnProgress(file, FileAccess.Read, 1, 0);
                var reader = new StreamReader(file);

                // Filters, empty for now.
                string[] filters = contentFilters ?? new string[] { };

                // Read file
                IEnumerable<TraceEvent> events = indexer.Index(reader);
                List<long> occurrences = new List<long>();
                if (filters.Length > 0)
                {
                    foreach (var filter in filters)
                    {
                        occurrences.AddRange(indexer.FindOccurrences(reader, filter));
                    }
                }

                // Only use Transport
                events = events.Where(e => e.Source == "Transport");

                string outputfile = files.First() + ".csv";
                OnProgress(outputfile, FileAccess.Write, 1, 0);
                using (StreamWriter sw = new StreamWriter(outputfile, true))
                {
                    sw.WriteLine("Date;DurationInMs;Method;URL");
                    foreach (var pair in events.GroupBy(e => e.ActivityID))
                    {
                        var first = pair.OrderBy(p => p.TimeCreated).First();
                        var last = pair.OrderBy(p => p.TimeCreated).Last();

                        // If there is a filter but the first/last pair do not match, skip this pair.
                        if (filters.Length > 0 && !occurrences.Where(o => first.ContainsPosition(o) || last.ContainsPosition(o)).Any())
                        {
                            continue;
                        }

                        var duration = last.TimeCreated - first.TimeCreated;
                        string date = first.TimeCreated.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string durationInMs = first == last ? "N/A" : ((long)duration.TotalMilliseconds).ToString();
                        string method = first.Method;
                        string url = first.To;
                        sw.WriteLine(string.Format("{0};{1};{2};{3}",
                            "\"" + date.Replace("\"", "\"\"") + "\"",
                            "\"" + durationInMs.Replace("\"", "\"\"") + "\"",
                            "\"" + method.Replace("\"", "\"\"") + "\"",
                            "\"" + url.Replace("\"", "\"\"") + "\""
                        ));
                    }
                }
                OnProgress(outputfile, FileAccess.Write, 1, 1);
            }
        }

        private void HandleIndexerProgress(object sender, ProgressEventArgs e)
        {
            OnProgress(_currentFile, _currentOperation, e.FileSize, e.CurrentPosition);
        }

        private void OnProgress(string currentFile, FileAccess currentOperation, long fileSize, long currentPosition)
        {
            _currentFile = currentFile;
            _currentOperation = currentOperation;
            var handler = Progress;
            if (handler != null)
                handler(this, new AnalyzeEventArgs
                {
                    CurrentFileName = currentFile,
                    CurrentOperation = currentOperation,
                    FileSize = fileSize,
                    CurrentPosition = currentPosition
                });
        }
    }
}
