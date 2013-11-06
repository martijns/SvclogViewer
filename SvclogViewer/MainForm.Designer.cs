using FastColoredTextBoxNS;
namespace SvclogViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblFilename = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRequestAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAppAsDefaultForsvclogFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitLeftRight = new System.Windows.Forms.SplitContainer();
            this.splitFilterResult = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSouce = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitMessageButtons = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkAutoFormat = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new SvclogViewer.SwitchableTextBox();
            this.checkSyntaxColoring = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeftRight)).BeginInit();
            this.splitLeftRight.Panel1.SuspendLayout();
            this.splitLeftRight.Panel2.SuspendLayout();
            this.splitLeftRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitFilterResult)).BeginInit();
            this.splitFilterResult.Panel1.SuspendLayout();
            this.splitFilterResult.Panel2.SuspendLayout();
            this.splitFilterResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMessageButtons)).BeginInit();
            this.splitMessageButtons.Panel1.SuspendLayout();
            this.splitMessageButtons.Panel2.SuspendLayout();
            this.splitMessageButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblStatus,
            this.progressBar,
            this.lblFilename});
            this.statusStrip1.Location = new System.Drawing.Point(0, 520);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1074, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.Text = "lblStatus";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(150, 16);
            this.progressBar.Step = 1;
            // 
            // lblFilename
            // 
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(68, 17);
            this.lblFilename.Text = "lblFilename";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reloadFileToolStripMenuItem,
            this.extrasToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1074, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFileOpen,
            this.saveRequestAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(163, 22);
            this.btnFileOpen.Text = "Open...";
            this.btnFileOpen.Click += new System.EventHandler(this.HandleFileOpen);
            // 
            // saveRequestAsToolStripMenuItem
            // 
            this.saveRequestAsToolStripMenuItem.Name = "saveRequestAsToolStripMenuItem";
            this.saveRequestAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveRequestAsToolStripMenuItem.Text = "Save request as...";
            this.saveRequestAsToolStripMenuItem.Click += new System.EventHandler(this.HandleSaveRequestAsClicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.HandleClose);
            // 
            // reloadFileToolStripMenuItem
            // 
            this.reloadFileToolStripMenuItem.Name = "reloadFileToolStripMenuItem";
            this.reloadFileToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.reloadFileToolStripMenuItem.Text = "Reload file";
            this.reloadFileToolStripMenuItem.Click += new System.EventHandler(this.HandleReloadFile);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAppAsDefaultForsvclogFilesToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.extrasToolStripMenuItem.Text = "Extras";
            // 
            // setAppAsDefaultForsvclogFilesToolStripMenuItem
            // 
            this.setAppAsDefaultForsvclogFilesToolStripMenuItem.Name = "setAppAsDefaultForsvclogFilesToolStripMenuItem";
            this.setAppAsDefaultForsvclogFilesToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.setAppAsDefaultForsvclogFilesToolStripMenuItem.Text = "Set app as default for .svclog files...";
            this.setAppAsDefaultForsvclogFilesToolStripMenuItem.Click += new System.EventHandler(this.HandleSetAsDefaultClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.helpToolStripMenuItem.Text = "About";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HandleAbout);
            // 
            // splitLeftRight
            // 
            this.splitLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLeftRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitLeftRight.IsSplitterFixed = true;
            this.splitLeftRight.Location = new System.Drawing.Point(0, 24);
            this.splitLeftRight.Margin = new System.Windows.Forms.Padding(2);
            this.splitLeftRight.Name = "splitLeftRight";
            // 
            // splitLeftRight.Panel1
            // 
            this.splitLeftRight.Panel1.Controls.Add(this.splitFilterResult);
            // 
            // splitLeftRight.Panel2
            // 
            this.splitLeftRight.Panel2.Controls.Add(this.splitMessageButtons);
            this.splitLeftRight.Size = new System.Drawing.Size(1074, 496);
            this.splitLeftRight.SplitterDistance = 310;
            this.splitLeftRight.SplitterWidth = 3;
            this.splitLeftRight.TabIndex = 2;
            // 
            // splitFilterResult
            // 
            this.splitFilterResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitFilterResult.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitFilterResult.IsSplitterFixed = true;
            this.splitFilterResult.Location = new System.Drawing.Point(0, 0);
            this.splitFilterResult.Margin = new System.Windows.Forms.Padding(2);
            this.splitFilterResult.Name = "splitFilterResult";
            this.splitFilterResult.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitFilterResult.Panel1
            // 
            this.splitFilterResult.Panel1.Controls.Add(this.label1);
            this.splitFilterResult.Panel1.Controls.Add(this.cmbSouce);
            this.splitFilterResult.Panel1.Controls.Add(this.button5);
            this.splitFilterResult.Panel1.Controls.Add(this.button4);
            this.splitFilterResult.Panel1.Controls.Add(this.txtFilter);
            // 
            // splitFilterResult.Panel2
            // 
            this.splitFilterResult.Panel2.Controls.Add(this.dataGridView1);
            this.splitFilterResult.Size = new System.Drawing.Size(310, 496);
            this.splitFilterResult.SplitterDistance = 70;
            this.splitFilterResult.SplitterWidth = 3;
            this.splitFilterResult.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source:";
            // 
            // cmbSouce
            // 
            this.cmbSouce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSouce.FormattingEnabled = true;
            this.cmbSouce.Location = new System.Drawing.Point(52, 31);
            this.cmbSouce.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSouce.Name = "cmbSouce";
            this.cmbSouce.Size = new System.Drawing.Size(179, 21);
            this.cmbSouce.TabIndex = 3;
            this.cmbSouce.SelectionChangeCommitted += new System.EventHandler(this.HandleSourceChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(194, 2);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(39, 24);
            this.button5.TabIndex = 2;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.HandleFilterClear);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(151, 2);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(38, 24);
            this.button4.TabIndex = 1;
            this.button4.Text = "Filter";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.HandleFilterClick);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(2, 6);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(145, 20);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HandleFilterKeyUp);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Datetime,
            this.Size});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(310, 423);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.HandleGridSelectionChanged);
            // 
            // Datetime
            // 
            this.Datetime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Datetime.DefaultCellStyle = dataGridViewCellStyle1;
            this.Datetime.HeaderText = "Datetime";
            this.Datetime.MinimumWidth = 215;
            this.Datetime.Name = "Datetime";
            this.Datetime.ReadOnly = true;
            this.Datetime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Datetime.Width = 215;
            // 
            // Size
            // 
            this.Size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Size.HeaderText = "Size (kb)";
            this.Size.MinimumWidth = 70;
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Size.Width = 70;
            // 
            // splitMessageButtons
            // 
            this.splitMessageButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMessageButtons.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMessageButtons.IsSplitterFixed = true;
            this.splitMessageButtons.Location = new System.Drawing.Point(0, 0);
            this.splitMessageButtons.Margin = new System.Windows.Forms.Padding(2);
            this.splitMessageButtons.Name = "splitMessageButtons";
            this.splitMessageButtons.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMessageButtons.Panel1
            // 
            this.splitMessageButtons.Panel1.Controls.Add(this.panel1);
            // 
            // splitMessageButtons.Panel2
            // 
            this.splitMessageButtons.Panel2.Controls.Add(this.textBox1);
            this.splitMessageButtons.Size = new System.Drawing.Size(761, 496);
            this.splitMessageButtons.SplitterDistance = 35;
            this.splitMessageButtons.SplitterWidth = 3;
            this.splitMessageButtons.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkSyntaxColoring);
            this.panel1.Controls.Add(this.checkAutoFormat);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 35);
            this.panel1.TabIndex = 1;
            // 
            // checkAutoFormat
            // 
            this.checkAutoFormat.AutoSize = true;
            this.checkAutoFormat.Location = new System.Drawing.Point(376, 6);
            this.checkAutoFormat.Name = "checkAutoFormat";
            this.checkAutoFormat.Size = new System.Drawing.Size(105, 17);
            this.checkAutoFormat.TabIndex = 3;
            this.checkAutoFormat.Text = "Auto-format XML";
            this.checkAutoFormat.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(189, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 24);
            this.button2.TabIndex = 1;
            this.button2.Text = "Copy soapenv to clipboard";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.HandleCopySoapenvToClipboard);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Copy to clipboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.HandleCopyToClipboard);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.EnableSyntaxColoring = false;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(761, 458);
            this.textBox1.TabIndex = 0;
            // 
            // checkSyntaxColoring
            // 
            this.checkSyntaxColoring.AutoSize = true;
            this.checkSyntaxColoring.Location = new System.Drawing.Point(487, 6);
            this.checkSyntaxColoring.Name = "checkSyntaxColoring";
            this.checkSyntaxColoring.Size = new System.Drawing.Size(118, 17);
            this.checkSyntaxColoring.TabIndex = 4;
            this.checkSyntaxColoring.Text = "Use syntax coloring";
            this.checkSyntaxColoring.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 542);
            this.Controls.Add(this.splitLeftRight);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "SvclogViewer";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.HandleDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitLeftRight.Panel1.ResumeLayout(false);
            this.splitLeftRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLeftRight)).EndInit();
            this.splitLeftRight.ResumeLayout(false);
            this.splitFilterResult.Panel1.ResumeLayout(false);
            this.splitFilterResult.Panel1.PerformLayout();
            this.splitFilterResult.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitFilterResult)).EndInit();
            this.splitFilterResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitMessageButtons.Panel1.ResumeLayout(false);
            this.splitMessageButtons.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMessageButtons)).EndInit();
            this.splitMessageButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnFileOpen;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitLeftRight;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SwitchableTextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitMessageButtons;
        private System.Windows.Forms.SplitContainer splitFilterResult;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.CheckBox checkAutoFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.ToolStripStatusLabel lblFilename;
        private System.Windows.Forms.ToolStripMenuItem reloadFileToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSouce;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRequestAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAppAsDefaultForsvclogFilesToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkSyntaxColoring;
    }
}

