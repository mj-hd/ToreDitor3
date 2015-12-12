namespace ToreDitor
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.DevlionLink = new System.Windows.Forms.LinkLabel();
            this.InfomationGroup = new System.Windows.Forms.GroupBox();
            this.CreditLabel = new System.Windows.Forms.Label();
            this.DayLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.InfomationGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // IconBox
            // 
            this.IconBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.IconBox.Image = global::ToreDitor.Properties.Resources.icon64x64;
            this.IconBox.Location = new System.Drawing.Point(3, 3);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(64, 64);
            this.IconBox.TabIndex = 0;
            this.IconBox.TabStop = false;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.VersionLabel.Location = new System.Drawing.Point(6, 15);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(69, 11);
            this.VersionLabel.TabIndex = 2;
            this.VersionLabel.Text = "Version 0.00a";
            // 
            // DevlionLink
            // 
            this.DevlionLink.AutoSize = true;
            this.DevlionLink.Location = new System.Drawing.Point(109, 82);
            this.DevlionLink.Name = "DevlionLink";
            this.DevlionLink.Size = new System.Drawing.Size(61, 12);
            this.DevlionLink.TabIndex = 3;
            this.DevlionLink.TabStop = true;
            this.DevlionLink.Text = "Devlion.net";
            this.DevlionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.StrawberryLink_LinkClicked);
            // 
            // InfomationGroup
            // 
            this.InfomationGroup.Controls.Add(this.CreditLabel);
            this.InfomationGroup.Controls.Add(this.DayLabel);
            this.InfomationGroup.Controls.Add(this.VersionLabel);
            this.InfomationGroup.Location = new System.Drawing.Point(73, 3);
            this.InfomationGroup.Name = "InfomationGroup";
            this.InfomationGroup.Size = new System.Drawing.Size(118, 62);
            this.InfomationGroup.TabIndex = 4;
            this.InfomationGroup.TabStop = false;
            this.InfomationGroup.Text = "蕩ディタ";
            // 
            // CreditLabel
            // 
            this.CreditLabel.AutoSize = true;
            this.CreditLabel.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.CreditLabel.Location = new System.Drawing.Point(27, 48);
            this.CreditLabel.Name = "CreditLabel";
            this.CreditLabel.Size = new System.Drawing.Size(90, 11);
            this.CreditLabel.TabIndex = 4;
            this.CreditLabel.Text = "Composed by mjhd";
            // 
            // DayLabel
            // 
            this.DayLabel.AutoSize = true;
            this.DayLabel.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.DayLabel.Location = new System.Drawing.Point(43, 37);
            this.DayLabel.Name = "DayLabel";
            this.DayLabel.Size = new System.Drawing.Size(74, 11);
            this.DayLabel.TabIndex = 3;
            this.DayLabel.Text = "2011年4月1日";
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(3, 71);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(91, 23);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "閉じる(&C)";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(196, 98);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.InfomationGroup);
            this.Controls.Add(this.DevlionLink);
            this.Controls.Add(this.IconBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "バージョン情報";
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.InfomationGroup.ResumeLayout(false);
            this.InfomationGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox IconBox;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.LinkLabel DevlionLink;
        private System.Windows.Forms.GroupBox InfomationGroup;
        private System.Windows.Forms.Label CreditLabel;
        private System.Windows.Forms.Label DayLabel;
        private System.Windows.Forms.Button CloseButton;
    }
}