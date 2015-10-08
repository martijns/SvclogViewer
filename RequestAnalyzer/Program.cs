using SvclogViewer;
using SvclogViewer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RequestAnalyzer
{
    public class Program
    {
        //static string[] filters = new[] { ">AB-011161@customer.dmz.local<", ">1033469<" };
        static string[] filters = new string[] { };

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                foreach (var filename in args)
                {
                    if (!File.Exists(filename))
                    {
                        Console.WriteLine("File " + filename + " does not exist");
                        return;
                    }
                }
                Analyze(args);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Dropper());
            }
        }

        public static void Analyze(params string[] files)
        {
            var indexer = new SvcIndexer();
            indexer.Progress += Indexer_Progress;

            foreach (var file in files)
            {
                var reader = new StreamReader(file);

                // Read file
                Console.WriteLine("Reading file: " + file);
                IEnumerable<TraceEvent> events = indexer.Index(reader);
                List<long> occurrences = new List<long>();
                if (filters.Length > 0)
                {
                    foreach (var filter in filters)
                    {
                        occurrences.AddRange(indexer.FindOccurrences(reader, filter));
                    }
                }

                // \r\n to end indexing lines
                Console.WriteLine();

                // Only use Transport
                events = events.Where(e => e.Source == "Transport");

                string outputfile = files.First() + ".csv";
                Console.WriteLine("Writing file: " + outputfile);
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
            }
        }

        static int LastPercentage;
        private static void Indexer_Progress(object sender, ProgressEventArgs e)
        {
            int percentage = (int)((double)e.CurrentPosition / e.FileSize * 100);
            if (percentage != LastPercentage)
            {
                LastPercentage = percentage;
                Console.Write(string.Format("\rIndexing: {0,3}% - {1,15} / {2}", percentage, e.CurrentPosition, e.FileSize));
            }
        }
    }
}
