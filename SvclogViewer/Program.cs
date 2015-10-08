using MsCommon.ClickOnce;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SvclogViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arguments)
        {
            Action<string[]> method = (args) =>
            {
                // Check if this is a "MakeDefault" call
                if (args != null && args.Length > 0 && args[0] == "MakeDefault")
                {
                    if (DefaultAssociationHelper.MakeDefaultInternal(null))
                    {
                        Environment.ExitCode = 101;
                    }
                    return;
                }

                string file = null;
                if (args != null)
                {
                    file = args.Where(s => File.Exists(s)).FirstOrDefault();
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(file));
            };

            AppProgram.Start(
                applicationName: "SvclogViewer",
                authorName: "Martijn Stolk",
                reportBugEndpoint: "http://martijn.tikkie.net/reportbug.php",
                args: arguments,
                mainMethod: method);
        }
    }
}
