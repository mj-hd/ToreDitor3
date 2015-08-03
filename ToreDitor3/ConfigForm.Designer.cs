namespace ToreDitor
{
    partial class ConfigForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("動作");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("処理");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("見た目");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("基本", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBar.Location = new System.Drawing.Point(0, 0);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(528, 22);
            this.StatusBar.TabIndex = 1;
            this.StatusBar.Text = "Ready.";
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BottomPanel.Controls.Add(this.OKButton);
            this.BottomPanel.Controls.Add(this.CancelButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 296);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(528, 29);
            this.BottomPanel.TabIndex = 5;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(313, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 23);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "決定(&OK)";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(419, 3);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(106, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "キャンセル(&Cancel)";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 22);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.TreeView);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.TabControl);
            this.SplitContainer.Size = new System.Drawing.Size(528, 274);
            this.SplitContainer.SplitterDistance = 176;
            this.SplitContainer.TabIndex = 6;
            // 
            // TreeView
            // 
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.ImageIndex = 0;
            this.TreeView.ImageList = this.TreeImageList;
            this.TreeView.Location = new System.Drawing.Point(0, 0);
            this.TreeView.Name = "TreeView";
            treeNode1.ImageKey = "calendar";
            treeNode1.Name = "動作ノード";
            treeNode1.SelectedImageKey = "calendar";
            treeNode1.Text = "動作";
            treeNode2.ImageKey = "calendar";
            treeNode2.Name = "処理ノード";
            treeNode2.SelectedImageKey = "calendar";
            treeNode2.Text = "処理";
            treeNode3.ImageKey = "calendar";
            treeNode3.Name = "見た目ノード";
            treeNode3.SelectedImageKey = "calendar";
            treeNode3.Text = "見た目";
            treeNode4.Name = "基本ノード";
            treeNode4.Text = "基本";
            this.TreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.TreeView.SelectedImageIndex = 0;
            this.TreeView.Size = new System.Drawing.Size(176, 274);
            this.TreeView.TabIndex = 0;
            this.TreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView_NodeMouseClick);
            // 
            // TabControl
            // 
            this.TabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(348, 274);
            this.TabControl.TabIndex = 0;
            // 
            // TreeImageList
            // 
            this.TreeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImageList.ImageStream")));
            this.TreeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImageList.Images.SetKeyName(0, "folder");
            this.TreeImageList.Images.SetKeyName(1, "note_new");
            this.TreeImageList.Images.SetKeyName(2, "note_right");
            this.TreeImageList.Images.SetKeyName(3, "note_left");
            this.TreeImageList.Images.SetKeyName(4, "tag");
            this.TreeImageList.Images.SetKeyName(5, "check");
            this.TreeImageList.Images.SetKeyName(6, "calendar");
            this.TreeImageList.Images.SetKeyName(7, "construction");
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 325);
            this.Controls.Add(this.SplitContainer);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.StatusBar);
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "設定...";
            this.TopMost = true;
            this.BottomPanel.ResumeLayout(false);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.ImageList TreeImageList;
    }
}