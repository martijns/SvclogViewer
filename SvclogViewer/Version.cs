using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

        private static void HandleCheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            if (e.UpdateAvailable)
            {
                ApplicationDeployment.CurrentDeployment.Update();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("An update was found and installed. The application needs to be restarted to use the new version.");
                sb.AppendLine();
                sb.AppendLine("Current version: " + GetVersion());
                sb.AppendLine("New version: " + ToVersionString(e.AvailableVersion));
                sb.AppendLine("Update size: " + e.UpdateSizeBytes + " bytes");
                sb.AppendLine();
                sb.AppendLine("Do you want to restart the application to update now?");

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

        public static void DisplayAbout()
        {
            MessageBox.Show("SvclogViewer v" + GetVersion() + " by Martijn Stolk");
        }

        public static void DisplayChanges()
        {
            string changes = string.Empty;
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(Assembly.GetExecutingAssembly().GetManifestResourceNames().First(e => e.ToLower().Contains("changes.txt"))))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    changes = sr.ReadToEnd();
                }
            }

            Button b = new Button();
            b.Text = "Close";
            b.Dock = DockStyle.Bottom;
            b.Click += (src, evt) =>
            {
                ((Form)b.Parent).Close();
            };

            TextBox tb = new TextBox();
            tb.Text = changes;
            tb.Dock = DockStyle.Fill;
            tb.ReadOnly = true;
            tb.Multiline = true;
            tb.Select(0, 0);
            tb.ScrollBars = ScrollBars.Both;
            tb.WordWrap = true;

            Form f = new Form();
            f.Size = new Size(400, 400);
            f.Text = "Changelog";
            f.Controls.Add(tb);
            f.Controls.Add(b);
            f.ShowDialog();
        }
    }
}
