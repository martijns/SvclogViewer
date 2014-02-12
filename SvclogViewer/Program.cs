using System;
using System.Collections.Generic;
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
        static void Main(string[] args)
        {
            string file = null;

            // Check if this is a "MakeDefault" call
            if (args != null && args.Length > 0 && args[0] == "MakeDefault")
            {
                if (DefaultAssociationHelper.MakeDefaultInternal(null))
                {
                    Environment.ExitCode = 101;
                }
                return;
            }

            // Try the regular way of passing arguments
            try
            {
                if (args != null)
                {
                    //MessageBox.Show("Args: " + string.Join(" -|- ", args));
                    file = args.Where(s => File.Exists(s)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                // Don't bother with handling
                //MessageBox.Show("Exception: " + ex.ToString());
            }

            // Try the clickonce way of passing arguments
            try
            {
                if (AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData != null)
                {
                    //MessageBox.Show("ActivationData: " + string.Join(" -|- ", AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData));
                    file = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData.Where(s => File.Exists(s)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                // Don't bother with handling
                //MessageBox.Show("Exception: " + ex.ToString());
            }

            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(file));
        }

        static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex == null)
                return;

            try
            {
                new ReportBugForm(ex).ShowDialog();
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Proper error handling failed (" + ex2.Message + "). Please show the following message to the developer:\r\n\r\n" + ex, "Whoops!");
            }
        }
    }
}
