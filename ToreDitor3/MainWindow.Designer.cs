namespace ToreDitor
{
    partial class MainWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            ToreDitorCore.Buffer buffer1 = new ToreDitorCore.Buffer();
            ToreDitorCore.Caret caret1 = new ToreDitorCore.Caret();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.ファイルFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新規作成NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.上書きSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名前をつけて保存SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.終了OpenWithEncodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.元に戻すUnDoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.やり直しReDoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.切り取りCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.コピーCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.貼り付けPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.削除DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.すべて選択SelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.エンコードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sJISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eUCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.エンコードを適用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.機能FunctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.設定OptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ドキュメントDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.バージョン情報AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.Editor = new ToreDitorCore.ToreDitorCore();
            this.StripLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripSeparator = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripLeft,
            this.StripSeparator,
            this.StripRight});
            this.StatusBar.Location = new System.Drawing.Point(0, 246);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(434, 22);
            this.StatusBar.TabIndex = 0;
            this.StatusBar.Text = "statusStrip1";
            // 
            // ToolBar
            // 
            this.ToolBar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ToolBar.Location = new System.Drawing.Point(0, 24);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(434, 25);
            this.ToolBar.TabIndex = 1;
            this.ToolBar.Text = "toolStrip1";
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFileToolStripMenuItem,
            this.編集EditToolStripMenuItem,
            this.機能FunctionToolStripMenuItem,
            this.ヘルプHelpToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(434, 24);
            this.Menu.TabIndex = 2;
            this.Menu.Text = "menuStrip1";
            // 
            // ファイルFileToolStripMenuItem
            // 
            this.ファイルFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規作成NewToolStripMenuItem,
            this.開くOpenToolStripMenuItem,
            this.toolStripSeparator1,
            this.上書きSaveToolStripMenuItem,
            this.名前をつけて保存SaveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.終了OpenWithEncodingToolStripMenuItem});
            this.ファイルFileToolStripMenuItem.Name = "ファイルFileToolStripMenuItem";
            this.ファイルFileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.ファイルFileToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 新規作成NewToolStripMenuItem
            // 
            this.新規作成NewToolStripMenuItem.Name = "新規作成NewToolStripMenuItem";
            this.新規作成NewToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.新規作成NewToolStripMenuItem.Text = "新規作成(&N)";
            this.新規作成NewToolStripMenuItem.Click += new System.EventHandler(this.新規作成NewToolStripMenuItem_Click);
            // 
            // 開くOpenToolStripMenuItem
            // 
            this.開くOpenToolStripMenuItem.Name = "開くOpenToolStripMenuItem";
            this.開くOpenToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.開くOpenToolStripMenuItem.Text = "開く(&O)...";
            this.開くOpenToolStripMenuItem.Click += new System.EventHandler(this.開くOpenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // 上書きSaveToolStripMenuItem
            // 
            this.上書きSaveToolStripMenuItem.Name = "上書きSaveToolStripMenuItem";
            this.上書きSaveToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.上書きSaveToolStripMenuItem.Text = "上書き保存(&S)";
            this.上書きSaveToolStripMenuItem.Click += new System.EventHandler(this.上書きSaveToolStripMenuItem_Click);
            // 
            // 名前をつけて保存SaveAsToolStripMenuItem
            // 
            this.名前をつけて保存SaveAsToolStripMenuItem.Name = "名前をつけて保存SaveAsToolStripMenuItem";
            this.名前をつけて保存SaveAsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.名前をつけて保存SaveAsToolStripMenuItem.Text = "名前をつけて保存(&A)...";
            this.名前をつけて保存SaveAsToolStripMenuItem.Click += new System.EventHandler(this.名前をつけて保存SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // 終了OpenWithEncodingToolStripMenuItem
            // 
            this.終了OpenWithEncodingToolStripMenuItem.Name = "終了OpenWithEncodingToolStripMenuItem";
            this.終了OpenWithEncodingToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.終了OpenWithEncodingToolStripMenuItem.Text = "終了(&E)";
            this.終了OpenWithEncodingToolStripMenuItem.Click += new System.EventHandler(this.終了OpenWithEncodingToolStripMenuItem_Click);
            // 
            // 編集EditToolStripMenuItem
            // 
            this.編集EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.元に戻すUnDoToolStripMenuItem,
            this.やり直しReDoToolStripMenuItem,
            this.toolStripSeparator3,
            this.切り取りCutToolStripMenuItem,
            this.コピーCopyToolStripMenuItem,
            this.貼り付けPasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.削除DeleteToolStripMenuItem,
            this.すべて選択SelectToolStripMenuItem,
            this.toolStripSeparator5,
            this.エンコードToolStripMenuItem,
            this.エンコードを適用ToolStripMenuItem});
            this.編集EditToolStripMenuItem.Name = "編集EditToolStripMenuItem";
            this.編集EditToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.編集EditToolStripMenuItem.Text = "操作(&C)";
            // 
            // 元に戻すUnDoToolStripMenuItem
            // 
            this.元に戻すUnDoToolStripMenuItem.Name = "元に戻すUnDoToolStripMenuItem";
            this.元に戻すUnDoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.元に戻すUnDoToolStripMenuItem.Text = "元に戻す(&U)";
            // 
            // やり直しReDoToolStripMenuItem
            // 
            this.やり直しReDoToolStripMenuItem.Name = "やり直しReDoToolStripMenuItem";
            this.やり直しReDoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.やり直しReDoToolStripMenuItem.Text = "やり直し(&R)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // 切り取りCutToolStripMenuItem
            // 
            this.切り取りCutToolStripMenuItem.Name = "切り取りCutToolStripMenuItem";
            this.切り取りCutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.切り取りCutToolStripMenuItem.Text = "切り取り(&T)";
            // 
            // コピーCopyToolStripMenuItem
            // 
            this.コピーCopyToolStripMenuItem.Name = "コピーCopyToolStripMenuItem";
            this.コピーCopyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.コピーCopyToolStripMenuItem.Text = "コピー(&C)";
            // 
            // 貼り付けPasteToolStripMenuItem
            // 
            this.貼り付けPasteToolStripMenuItem.Name = "貼り付けPasteToolStripMenuItem";
            this.貼り付けPasteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.貼り付けPasteToolStripMenuItem.Text = "貼り付け(&P)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // 削除DeleteToolStripMenuItem
            // 
            this.削除DeleteToolStripMenuItem.Name = "削除DeleteToolStripMenuItem";
            this.削除DeleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.削除DeleteToolStripMenuItem.Text = "削除(&D)";
            // 
            // すべて選択SelectToolStripMenuItem
            // 
            this.すべて選択SelectToolStripMenuItem.Name = "すべて選択SelectToolStripMenuItem";
            this.すべて選択SelectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.すべて選択SelectToolStripMenuItem.Text = "すべて選択(&A)";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // エンコードToolStripMenuItem
            // 
            this.エンコードToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uTF8ToolStripMenuItem,
            this.sJISToolStripMenuItem,
            this.eUCToolStripMenuItem});
            this.エンコードToolStripMenuItem.Name = "エンコードToolStripMenuItem";
            this.エンコードToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.エンコードToolStripMenuItem.Text = "エンコード";
            // 
            // uTF8ToolStripMenuItem
            // 
            this.uTF8ToolStripMenuItem.Name = "uTF8ToolStripMenuItem";
            this.uTF8ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.uTF8ToolStripMenuItem.Text = "UTF-8";
            this.uTF8ToolStripMenuItem.Click += new System.EventHandler(this.uTF8ToolStripMenuItem_Click);
            // 
            // sJISToolStripMenuItem
            // 
            this.sJISToolStripMenuItem.Name = "sJISToolStripMenuItem";
            this.sJISToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.sJISToolStripMenuItem.Text = "SJIS";
            this.sJISToolStripMenuItem.Click += new System.EventHandler(this.sJISToolStripMenuItem_Click);
            // 
            // eUCToolStripMenuItem
            // 
            this.eUCToolStripMenuItem.Name = "eUCToolStripMenuItem";
            this.eUCToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.eUCToolStripMenuItem.Text = "EUC-JP";
            this.eUCToolStripMenuItem.Click += new System.EventHandler(this.eUCToolStripMenuItem_Click);
            // 
            // エンコードを適用ToolStripMenuItem
            // 
            this.エンコードを適用ToolStripMenuItem.Name = "エンコードを適用ToolStripMenuItem";
            this.エンコードを適用ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.エンコードを適用ToolStripMenuItem.Text = "エンコードを適用";
            this.エンコードを適用ToolStripMenuItem.Click += new System.EventHandler(this.エンコードを適用ToolStripMenuItem_Click);
            // 
            // 機能FunctionToolStripMenuItem
            // 
            this.機能FunctionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.設定OptionToolStripMenuItem});
            this.機能FunctionToolStripMenuItem.Name = "機能FunctionToolStripMenuItem";
            this.機能FunctionToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.機能FunctionToolStripMenuItem.Text = "機能(&F)";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(149, 6);
            // 
            // 設定OptionToolStripMenuItem
            // 
            this.設定OptionToolStripMenuItem.Name = "設定OptionToolStripMenuItem";
            this.設定OptionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.設定OptionToolStripMenuItem.Text = "設定(&O)...";
            this.設定OptionToolStripMenuItem.Click += new System.EventHandler(this.設定OptionToolStripMenuItem_Click);
            // 
            // ヘルプHelpToolStripMenuItem
            // 
            this.ヘルプHelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ドキュメントDocumentsToolStripMenuItem,
            this.toolStripSeparator7,
            this.バージョン情報AboutToolStripMenuItem});
            this.ヘルプHelpToolStripMenuItem.Name = "ヘルプHelpToolStripMenuItem";
            this.ヘルプHelpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.ヘルプHelpToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // ドキュメントDocumentsToolStripMenuItem
            // 
            this.ドキュメントDocumentsToolStripMenuItem.Name = "ドキュメントDocumentsToolStripMenuItem";
            this.ドキュメントDocumentsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ドキュメントDocumentsToolStripMenuItem.Text = "ドキュメント(&D)...";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(155, 6);
            // 
            // バージョン情報AboutToolStripMenuItem
            // 
            this.バージョン情報AboutToolStripMenuItem.Name = "バージョン情報AboutToolStripMenuItem";
            this.バージョン情報AboutToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.バージョン情報AboutToolStripMenuItem.Text = "バージョン情報(&A)";
            this.バージョン情報AboutToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報AboutToolStripMenuItem_Click);
            // 
            // TabControl
            // 
            this.TabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.TabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TabControl.Location = new System.Drawing.Point(0, 226);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(434, 20);
            this.TabControl.TabIndex = 3;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.Title = "ファイルを開く...";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.Title = "名前をつけて保存...";
            // 
            // Editor
            // 
            this.Editor.AutoScroll = true;
            this.Editor.AutoScrollMargin = new System.Drawing.Size(1, 1);
            this.Editor.AutoSize = true;
            this.Editor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Editor.BackColor = System.Drawing.Color.White;
            caret1.Point = new System.Drawing.Point(0, 0);
            caret1.Visible = false;
            caret1.X = 0;
            caret1.Y = 0;
            buffer1.Caret = caret1;
            buffer1.Encoding = ((System.Text.Encoding)(resources.GetObject("buffer1.Encoding")));
            this.Editor.CurrentBuffer = buffer1;
            this.Editor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Editor.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Editor.Location = new System.Drawing.Point(0, 49);
            this.Editor.Name = "Editor";
            this.Editor.Size = new System.Drawing.Size(434, 177);
            this.Editor.TabIndex = 4;
            this.Editor.TabStop = false;
            this.Editor.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Editor_PreviewKeyDown);
            // 
            // StripLeft
            // 
            this.StripLeft.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.StripLeft.Name = "StripLeft";
            this.StripLeft.Size = new System.Drawing.Size(0, 17);
            // 
            // StripRight
            // 
            this.StripRight.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.StripRight.Name = "StripRight";
            this.StripRight.Size = new System.Drawing.Size(0, 17);
            this.StripRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StripSeparator
            // 
            this.StripSeparator.Name = "StripSeparator";
            this.StripSeparator.Size = new System.Drawing.Size(419, 17);
            this.StripSeparator.Spring = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 268);
            this.Controls.Add(this.Editor);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.Name = "MainWindow";
            this.Text = "蕩ディタ";
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip Menu;
        public System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.ToolStripMenuItem ファイルFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新規作成NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 上書きSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 名前をつけて保存SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 終了OpenWithEncodingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 元に戻すUnDoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem やり直しReDoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 切り取りCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem コピーCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 貼り付けPasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 削除DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem すべて選択SelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem エンコードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uTF8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sJISToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eUCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem エンコードを適用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 機能FunctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem 設定OptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ドキュメントDocumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報AboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private ToreDitorCore.ToreDitorCore Editor;
        public System.Windows.Forms.ToolStripStatusLabel StripLeft;
        private System.Windows.Forms.ToolStripStatusLabel StripSeparator;
        public System.Windows.Forms.ToolStripStatusLabel StripRight;
        public System.Windows.Forms.StatusStrip StatusBar;
        public System.Windows.Forms.ToolStrip ToolBar;
    }
}

