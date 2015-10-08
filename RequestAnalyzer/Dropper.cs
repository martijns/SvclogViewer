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

namespace RequestAnalyzer
{
    public partial class Dropper : Form
    {
        public Dropper()
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
                    Program.Analyze(filenames);
                }).Start();
            }
        }
    }
}
