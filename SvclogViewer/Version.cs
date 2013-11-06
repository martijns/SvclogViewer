using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApplicationDeployment = System.Deployment.Application.ApplicationDeployment;

namespace SvclogViewer
{
    public static class Version
    {
        public static string GetVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                return ToVersionString(ApplicationDeployment.CurrentDeployment.CurrentVersion);
            }
            return "0.0.0.0";
        }

        public static void CheckForUpdateAsync()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment.CurrentDeployment.CheckForUpdateCompleted += HandleCheckForUpdateCompleted;
                ApplicationDeployment.CurrentDeployment.CheckForUpdateAsync();
            }
        }

        static void HandleCheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            if (e.UpdateAvailable)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("An update is available. It will be downloaded and installed the next time you run the application.");
                sb.AppendLine();
                sb.AppendLine("Current version: " + GetVersion());
                sb.AppendLine("New version: " + ToVersionString(e.AvailableVersion));
                sb.AppendLine("Update size: " + e.UpdateSizeBytes + " bytes");
                sb.AppendLine();
                sb.AppendLine("Do you want to restart the application now?");

                // Get a form so we can invoke on the thread
                Form form = Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null;
                if (form != null)
                {
                    form.Invoke((Action)(() => {
                        if (MessageBox.Show(form, sb.ToString(), "Update available!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            Application.Restart();
                    }));
                }
            }
        }

        private static string ToVersionString(System.Version version)
        {
            return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
        }
    }
}
