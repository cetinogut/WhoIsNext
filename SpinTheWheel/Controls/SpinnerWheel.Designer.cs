namespace SpinTheWheel.Controls
{
    partial class SpinnerWheel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nonFlickerPanel = new SpinTheWheel.Utility.Components.NonFlickerPanel();
            this.BtnRoundSpin = new SpinTheWheel.Utility.Components.RoundButton();
            this.LblAppHeader = new System.Windows.Forms.Label();
            this.nonFlickerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nonFlickerPanel
            // 
            this.nonFlickerPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nonFlickerPanel.Controls.Add(this.BtnRoundSpin);
            this.nonFlickerPanel.Location = new System.Drawing.Point(0, 43);
            this.nonFlickerPanel.Name = "nonFlickerPanel";
            this.nonFlickerPanel.Size = new System.Drawing.Size(480, 480);
            this.nonFlickerPanel.TabIndex = 0;
            this.nonFlickerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.nonFlickerPanel_Paint);
            // 
            // BtnRoundSpin
            // 
            this.BtnRoundSpin.BackColor = System.Drawing.Color.Transparent;
            this.BtnRoundSpin.BorderColor = System.Drawing.Color.Transparent;
            this.BtnRoundSpin.ButtonColor = System.Drawing.Color.ForestGreen;
            this.BtnRoundSpin.FlatAppearance.BorderSize = 0;
            this.BtnRoundSpin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnRoundSpin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRoundSpin.Location = new System.Drawing.Point(148, 141);
            this.BtnRoundSpin.Name = "BtnRoundSpin";
            this.BtnRoundSpin.OnHoverBorderColor = System.Drawing.Color.ForestGreen;
            this.BtnRoundSpin.OnHoverButtonColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnRoundSpin.OnHoverTextColor = System.Drawing.Color.ForestGreen;
            this.BtnRoundSpin.Size = new System.Drawing.Size(94, 94);
            this.BtnRoundSpin.TabIndex = 2;
            this.BtnRoundSpin.Text = "Click Here!";
            this.BtnRoundSpin.TextColor = System.Drawing.Color.White;
            this.BtnRoundSpin.UseVisualStyleBackColor = false;
            this.BtnRoundSpin.Click += new System.EventHandler(this.BtnRoundSpin_Click);
            // 
            // LblAppHeader
            // 
            this.LblAppHeader.AutoSize = true;
            this.LblAppHeader.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblAppHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblAppHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblAppHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAppHeader.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.LblAppHeader.Location = new System.Drawing.Point(0, 0);
            this.LblAppHeader.Name = "LblAppHeader";
            this.LblAppHeader.Size = new System.Drawing.Size(501, 44);
            this.LblAppHeader.TabIndex = 1;
            this.LblAppHeader.Text = "          Who is next?             ";
            this.LblAppHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SpinnerWheel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.LblAppHeader);
            this.Controls.Add(this.nonFlickerPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SpinnerWheel";
            this.Size = new System.Drawing.Size(480, 526);
            this.Load += new System.EventHandler(this.SpinnerWheel_Load);
            this.Resize += new System.EventHandler(this.SpinnerWheel_Resize);
            this.nonFlickerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utility.Components.NonFlickerPanel nonFlickerPanel;
        private System.Windows.Forms.Label LblAppHeader;
        private Utility.Components.RoundButton BtnRoundSpin;
    }
}
