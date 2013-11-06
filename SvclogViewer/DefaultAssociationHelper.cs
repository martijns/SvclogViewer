using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace SvclogViewer
{
    public static class DefaultAssociationHelper
    {
        public static bool EqualsIgnoreCase(this object source, string target)
        {
            if (!(source is string))
                throw new ArgumentException("source must be of type string", "source");
            string src = source as string;
            if (src != null && target != null)
                return src.ToLower().Equals(target.ToLower());
            return false;
        }

        public static bool IsDefaultProgram()
        {
            try
            {
                var key = Registry.ClassesRoot.OpenSubKey(".svclog");
                if (key == null)
                    return false;
                var value = key.GetValue("");
                if (value == null || !(value is string) || !value.EqualsIgnoreCase("Tikkie.SvcLogViewer"))
                    return false;

                //key = Registry.ClassesRoot.OpenSubKey("Tikkie.SvcLogViewer");
                //if (key == null)
                //    return false;
                //value = key.GetValue("");
                //if (value == null || !(value is string) || !value.Equals("Tikkie.SvcLogViewer"))
                //    return false;

                //string associationcmd = GetFileAssociationCommandString();
                //key = Registry.ClassesRoot.OpenSubKey("Tikkie.SvcLogViewer\\shell\\Open\\command");
                //if (key == null)
                //    return false;
                //value = key.GetValue("");
                //if (value == null || !(value is string) || !((string)value).Contains(associationcmd))
                //    return false;

                key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\.svclog");
                if (key != null)
                {
                    value = key.GetValue("");
                    if (value != null && value is string && !value.EqualsIgnoreCase("") && !value.EqualsIgnoreCase("Tikkie.SvcLogViewer"))
                        return false;
                }

                key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\.svclog");
                if (key == null)
                    return false;
                value = key.GetValue("");
                if (value != null && value is string && !value.EqualsIgnoreCase("") && !value.EqualsIgnoreCase("Tikkie.SvcLogViewer"))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public static bool PresentMakeDefaultQuestion(IWin32Window parent)
        {
            var result = MessageBox.Show(parent, "This application is not the default application to handle .svclog files. Do you want to make this application the default?\r\n\r\nIf you choose 'no', you can later make this application the default via the menu.\r\n", "Default file association", MessageBoxButtons.YesNo);
            return result == DialogResult.Yes;
        }

        public static bool MakeDefault(IWin32Window parent)
        {
            if (IsAdministrator())
            {
                return MakeDefaultInternal(parent);
            }
            else
            {
                string myexecutable = Assembly.GetEntryAssembly().Location; // For process.start we need the actual .exe
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    FileName = myexecutable + " ",
                    Arguments = "MakeDefault",
                    Verb = "runas"
                };
                if (!p.Start())
                {
                    MessageBox.Show(parent, "Error spawning a process as administrator in order to make this application the default...");
                    return false;
                }
                p.WaitForExit();
                if (p.ExitCode != 101)
                {
                    MessageBox.Show(parent, "Spawned a process as administrator to make the application default, but somehow failed.");
                    return false;
                }
                return true;
            }
        }

        public static bool MakeDefaultInternal(IWin32Window parent)
        {
            try
            {
                var key = Registry.ClassesRoot.CreateSubKey(".svclog");
                key.SetValue("", "Tikkie.SvcLogViewer");
                //var key2 = Registry.ClassesRoot.CreateSubKey("Tikkie.SvcLogViewer");
                //key2.SetValue("", "Tikkie.SvcLogViewer");
                //var key3 = Registry.ClassesRoot.CreateSubKey("Tikkie.SvcLogViewer\\shell\\Open\\command");
                //key3.SetValue("", GetFileAssociationCommandString());
                Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Classes\\.svclog", false);
                key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.svclog");
                key.SetValue("", "Tikkie.SvcLogViewer");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(parent, "Failed to set this application as the default startup applicaton:\r\n" + ex);
                return false;
            }
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static string GetApplicationPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs),
                "Tikkie",
                "SvcLogViewer.appref-ms");
            //if (ApplicationDeployment.IsNetworkDeployed)
            //{
            //    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs),
            //        "Tikkie",
            //        "SvcLogViewer.appref-ms");
            //}
            //else
            //{
            //    return Assembly.GetEntryAssembly().Location;
            //}
        }

        //public static string GetFileAssociationCommandString()
        //{
        //    string myexecutable = GetApplicationPath();
        //    string cmd = "\"cmd\" \"/c\" \"" + myexecutable + "\"" + " \"%1\" \"%1\""; // Somehow the first %1 isn't actually passed as parameter
        //    return cmd;
        //}
    }
}
