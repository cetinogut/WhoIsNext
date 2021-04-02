namespace SpinTheWheel.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemFileSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSelectedStudent = new System.Windows.Forms.Label();
            this.spinnerWheel = new SpinTheWheel.Controls.SpinnerWheel();
            this.labelClassName = new System.Windows.Forms.Label();
            this.ListBoxSelectedStudents = new System.Windows.Forms.ListBox();
            this.LblSelectedStudentsInSession = new System.Windows.Forms.Label();
            this.btnResetList = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.yardımToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(846, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFileSettings});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.dosyaToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItemFileSettings
            // 
            this.toolStripMenuItemFileSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemFileSettings.Image")));
            this.toolStripMenuItemFileSettings.Name = "toolStripMenuItemFileSettings";
            this.toolStripMenuItemFileSettings.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItemFileSettings.Text = "Ayarlar";
            this.toolStripMenuItemFileSettings.Click += new System.EventHandler(this.toolStripMenuItemFileSettings_Click);
            // 
            // yardımToolStripMenuItem
            // 
            this.yardımToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemHelpAbout});
            this.yardımToolStripMenuItem.Name = "yardımToolStripMenuItem";
            this.yardımToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.yardımToolStripMenuItem.Text = "Help";
            // 
            // toolStripMenuItemHelpAbout
            // 
            this.toolStripMenuItemHelpAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemHelpAbout.Image")));
            this.toolStripMenuItemHelpAbout.Name = "toolStripMenuItemHelpAbout";
            this.toolStripMenuItemHelpAbout.Size = new System.Drawing.Size(99, 22);
            this.toolStripMenuItemHelpAbout.Text = "Help";
            this.toolStripMenuItemHelpAbout.Click += new System.EventHandler(this.toolStripMenuItemHelpAbout_Click);
            // 
            // labelSelectedStudent
            // 
            this.labelSelectedStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectedStudent.BackColor = System.Drawing.Color.Black;
            this.labelSelectedStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSelectedStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSelectedStudent.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelSelectedStudent.Location = new System.Drawing.Point(3, 69);
            this.labelSelectedStudent.Name = "labelSelectedStudent";
            this.labelSelectedStudent.Size = new System.Drawing.Size(215, 359);
            this.labelSelectedStudent.TabIndex = 2;
            this.labelSelectedStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinnerWheel
            // 
            this.spinnerWheel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spinnerWheel.AnimationDuration = 1800;
            this.spinnerWheel.AnimationEnabled = true;
            this.spinnerWheel.AnimationEndWaitDuration = 2500;
            this.spinnerWheel.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.spinnerWheel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.spinnerWheel.FontSize = 9;
            this.spinnerWheel.Location = new System.Drawing.Point(28, 27);
            this.spinnerWheel.Margin = new System.Windows.Forms.Padding(0);
            this.spinnerWheel.MinimumSize = new System.Drawing.Size(350, 350);
            this.spinnerWheel.Name = "spinnerWheel";
            this.spinnerWheel.Size = new System.Drawing.Size(443, 442);
            this.spinnerWheel.StudentReelectionInSession = false;
            this.spinnerWheel.StudentsReadyInClass = null;
            this.spinnerWheel.TabIndex = 1;
            // 
            // labelClassName
            // 
            this.labelClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClassName.BackColor = System.Drawing.Color.Black;
            this.labelClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelClassName.ForeColor = System.Drawing.Color.Tomato;
            this.labelClassName.Location = new System.Drawing.Point(2, 0);
            this.labelClassName.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.labelClassName.Name = "labelClassName";
            this.labelClassName.Size = new System.Drawing.Size(349, 37);
            this.labelClassName.TabIndex = 3;
            this.labelClassName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListBoxSelectedStudents
            // 
            this.ListBoxSelectedStudents.BackColor = System.Drawing.Color.Black;
            this.ListBoxSelectedStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBoxSelectedStudents.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ListBoxSelectedStudents.FormattingEnabled = true;
            this.ListBoxSelectedStudents.Location = new System.Drawing.Point(222, 69);
            this.ListBoxSelectedStudents.Name = "ListBoxSelectedStudents";
            this.ListBoxSelectedStudents.Size = new System.Drawing.Size(129, 221);
            this.ListBoxSelectedStudents.TabIndex = 4;
            // 
            // LblSelectedStudentsInSession
            // 
            this.LblSelectedStudentsInSession.AutoSize = true;
            this.LblSelectedStudentsInSession.ForeColor = System.Drawing.Color.Tomato;
            this.LblSelectedStudentsInSession.Location = new System.Drawing.Point(223, 50);
            this.LblSelectedStudentsInSession.Margin = new System.Windows.Forms.Padding(3);
            this.LblSelectedStudentsInSession.MaximumSize = new System.Drawing.Size(200, 40);
            this.LblSelectedStudentsInSession.Name = "LblSelectedStudentsInSession";
            this.LblSelectedStudentsInSession.Size = new System.Drawing.Size(87, 13);
            this.LblSelectedStudentsInSession.TabIndex = 5;
            this.LblSelectedStudentsInSession.Text = "Already Selected";
            this.LblSelectedStudentsInSession.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnResetList
            // 
            this.btnResetList.BackColor = System.Drawing.Color.Black;
            this.btnResetList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetList.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnResetList.Location = new System.Drawing.Point(218, 296);
            this.btnResetList.Name = "btnResetList";
            this.btnResetList.Size = new System.Drawing.Size(138, 32);
            this.btnResetList.TabIndex = 6;
            this.btnResetList.Text = "Reset";
            this.btnResetList.UseVisualStyleBackColor = false;
            this.btnResetList.Click += new System.EventHandler(this.btnResetList_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.labelSelectedStudent);
            this.panel1.Controls.Add(this.btnResetList);
            this.panel1.Controls.Add(this.labelClassName);
            this.panel1.Controls.Add(this.ListBoxSelectedStudents);
            this.panel1.Controls.Add(this.LblSelectedStudentsInSession);
            this.panel1.Location = new System.Drawing.Point(477, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 442);
            this.panel1.TabIndex = 7;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(846, 545);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.spinnerWheel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 420);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Who is next?";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFileSettings;
        private System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelpAbout;
        private Controls.SpinnerWheel spinnerWheel;
        private System.Windows.Forms.Label labelSelectedStudent;
        private System.Windows.Forms.Label labelClassName;
        private System.Windows.Forms.ListBox ListBoxSelectedStudents;
        private System.Windows.Forms.Label LblSelectedStudentsInSession;
        private System.Windows.Forms.Button btnResetList;
        private System.Windows.Forms.Panel panel1;
    }
}

