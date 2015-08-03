namespace ToreDitor
{
    partial class ConfirmationForm
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
            this.Message = new System.Windows.Forms.Label();
            this.FileListView = new System.Windows.Forms.ListView();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.DecidedButton = new System.Windows.Forms.Button();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(13, 13);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(433, 12);
            this.Message.TabIndex = 0;
            this.Message.Text = "いくつかのファイルが変更されています。変更を保存するファイルの欄にチェックをつけてください。";
            // 
            // FileListView
            // 
            this.FileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FileListView.Location = new System.Drawing.Point(13, 29);
            this.FileListView.Name = "FileListView";
            this.FileListView.Size = new System.Drawing.Size(468, 273);
            this.FileListView.TabIndex = 1;
            this.FileListView.UseCompatibleStateImageBehavior = false;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ButtonPanel.Controls.Add(this.CancelButton);
            this.ButtonPanel.Controls.Add(this.DecidedButton);
            this.ButtonPanel.Location = new System.Drawing.Point(-1, 314);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(494, 31);
            this.ButtonPanel.TabIndex = 2;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(381, 4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(110, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "キャンセル(&Cancel)";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // DecidedButton
            // 
            this.DecidedButton.Location = new System.Drawing.Point(300, 4);
            this.DecidedButton.Name = "DecidedButton";
            this.DecidedButton.Size = new System.Drawing.Size(75, 23);
            this.DecidedButton.TabIndex = 0;
            this.DecidedButton.Text = "確定";
            this.DecidedButton.UseVisualStyleBackColor = true;
            this.DecidedButton.Click += new System.EventHandler(this.DecidedButton_Click);
            // 
            // ConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(493, 345);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.FileListView);
            this.Controls.Add(this.Message);
            this.Name = "ConfirmationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "終了確認...";
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.ListView FileListView;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button DecidedButton;
    }
}