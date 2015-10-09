using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SvclogViewer
{
    public partial class SvcAnalyzerDropper : Form
    {
        public SvcAnalyzerDropper()
        {
            InitializeComponent();
        }

        private void HandleDragEnter(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null && data is string[])
            {
                string[] filenames = data as string[];
                if (filenames.Length == 0)
                    return;
                foreach (var filename in filenames)
                {
                    if (!File.Exists(filename))
                        return;
                }
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void HandleDragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null && data is string[])
            {
                string[] filenames = data as string[];
                if (filenames.Length == 0)
                    return;
                new Thread(() =>
                {
                    var analyzer = new SvcAnalyzer();
                    analyzer.Progress += HandleAnalyzerProgress;
                    analyzer.Analyze(null, filenames);
                    UpdateLabel("Done, waiting...");
                }).Start();
            }
        }

        private int _lastPercentage;

        private void HandleAnalyzerProgress(object sender, AnalyzeEventArgs e)
        {
            int percentage = (int)((double)e.CurrentPosition / e.FileSize * 100);
            if (percentage != _lastPercentage)
            {
                _lastPercentage = percentage;
                string msg = string.Format("File: {0}, Mode: {1}, Progress: {2}% ({3} / {4})", Path.GetFileName(e.CurrentFileName), e.CurrentOperation, percentage, e.CurrentPosition, e.FileSize);
                UpdateLabel(msg);
            }
        }

        private void UpdateLabel(string msg)
        {
            if (InvokeRequired)
            {
                Invoke((Action<string>)UpdateLabel, msg);
                return;
            }

            lbStatus.Text = msg;
            Application.DoEvents();
        }
    }
}
