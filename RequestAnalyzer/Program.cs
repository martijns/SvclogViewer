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
                var analyzer = new SvcAnalyzer();
                analyzer.Progress += HandleAnalyzerProgress;
                analyzer.Analyze(null, args);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SvcAnalyzerDropper());
            }
        }

        static int LastPercentage;
        private static void HandleAnalyzerProgress(object sender, AnalyzeEventArgs e)
        {
            int percentage = (int)((double)e.CurrentPosition / e.FileSize * 100);
            if (percentage != LastPercentage)
            {
                LastPercentage = percentage;
                Console.Write(string.Format("File: {0}, Mode: {1}, Progress: {2}% ({1,15} / {2})", Path.GetFileName(e.CurrentFileName), e.CurrentOperation, percentage, e.CurrentPosition, e.FileSize));
            }
        }
    }
}
