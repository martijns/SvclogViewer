using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace SvclogViewer
{

    public partial class SwitchableTextBox : UserControl
    {
        public SwitchableTextBox()
        {
            InitializeComponent();
            Controls.Add(GetRegularTextBox());
        }

        public bool EnableSyntaxColoring
        {
            get
            {
                return Controls.OfType<Control>().Any(c => c is FastColoredTextBox);
            }
            set
            {
                if (value && !EnableSyntaxColoring)
                {
                    string current = Text;
                    Controls.Clear();
                    Controls.Add(GetFastColoredTextBox());
                    Text = current;
                }
                if (!value && EnableSyntaxColoring)
                {
                    string current = Text;
                    Controls.Clear();
                    Controls.Add(GetRegularTextBox());
                    Text = current;
                }
            }
        }

        public override string Text
        {
            get
            {
                return Controls.OfType<Control>().Select(c => c.Text).FirstOrDefault();
            }
            set
            {
                Control ctrl = Controls.OfType<Control>().FirstOrDefault();
                if (ctrl != null)
                    ctrl.Text = value;
            }
        }

        private FastColoredTextBox GetFastColoredTextBox()
        {
            FastColoredTextBox fctb = new FastColoredTextBox();
            fctb.Dock = DockStyle.Fill;
            fctb.Location = new Point(0, 0);
            fctb.Margin = new Padding(2);
            fctb.Name = "FastColoredTextBox";
            fctb.Multiline = true;
            fctb.ReadOnly = true;
            fctb.Size = new Size(761, 458);
            fctb.TabIndex = 0;
            fctb.WordWrap = false;
            //fctb.Language = Language.HTML;
            fctb.DescriptionFile = "xmlDesc.xml";
            fctb.SyntaxHighlighter = new SyntaxHighlighter();
            //fctb.Font = Control.DefaultFont;
            fctb.Font = new Font("Consolas", 9.0f);
            fctb.DefaultStyle = new TextStyle(Brushes.Black, null, FontStyle.Bold);
            fctb.CaretVisible = false;
            fctb.AutoIndent = false;
            fctb.AutoIndentExistingLines = false;
            return fctb;
        }

        private TextBox GetRegularTextBox()
        {
            TextBox tb = new TextBox();
            tb.Dock = DockStyle.Fill;
            tb.Location = new Point(0, 0);
            tb.Margin = new Padding(2);
            tb.Name = "TextBox";
            tb.Multiline = true;
            tb.ReadOnly = true;
            tb.Size = new Size(761, 458);
            tb.TabIndex = 0;
            tb.WordWrap = false;
            tb.ScrollBars = ScrollBars.Both;
            return tb;
        }
    }
}
