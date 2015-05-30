namespace SimpleBackup.Main.Core
{
    partial class ErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLogTextBox = new System.Windows.Forms.TextBox();
            this.quitLink = new System.Windows.Forms.LinkLabel();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.errorLogTextBox);
            this.panel1.Controls.Add(this.quitLink);
            this.panel1.Controls.Add(this.buttonContinue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(9);
            this.panel1.Size = new System.Drawing.Size(351, 238);
            this.panel1.TabIndex = 0;
            // 
            // errorLogTextBox
            // 
            this.errorLogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorLogTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.errorLogTextBox.Location = new System.Drawing.Point(12, 12);
            this.errorLogTextBox.Multiline = true;
            this.errorLogTextBox.Name = "errorLogTextBox";
            this.errorLogTextBox.ReadOnly = true;
            this.errorLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorLogTextBox.Size = new System.Drawing.Size(327, 173);
            this.errorLogTextBox.TabIndex = 1;
            // 
            // quitLink
            // 
            this.quitLink.ActiveLinkColor = System.Drawing.Color.Maroon;
            this.quitLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.quitLink.LinkColor = System.Drawing.Color.Maroon;
            this.quitLink.Location = new System.Drawing.Point(160, 198);
            this.quitLink.Name = "quitLink";
            this.quitLink.Size = new System.Drawing.Size(88, 28);
            this.quitLink.TabIndex = 2;
            this.quitLink.TabStop = true;
            this.quitLink.Text = "Exit";
            this.quitLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.quitLink.VisitedLinkColor = System.Drawing.Color.Maroon;
            this.quitLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.quitLink_LinkClicked);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonContinue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonContinue.Location = new System.Drawing.Point(254, 198);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(85, 28);
            this.buttonContinue.TabIndex = 0;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            // 
            // ErrorForm
            // 
            this.AcceptButton = this.buttonContinue;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(351, 238);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.Load += new System.EventHandler(this.ErrorForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox errorLogTextBox;
        private System.Windows.Forms.LinkLabel quitLink;
        private System.Windows.Forms.Button buttonContinue;
    }
}