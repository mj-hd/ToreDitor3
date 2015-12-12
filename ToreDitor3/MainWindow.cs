using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

namespace ToreDitor
{
    public partial class MainWindow : Form
    {
        public bool IsModified = false;

        public MainWindow()
        {
            InitializeComponent();

            Debug();
        }

        private TabPage AddEditTab(string name)
        {
            var page = new TabPage(name);
            this.TabControl.TabPages.Add(page);

            page.Tag = this.Editor.Create();

            return page;
        }

        private void Debug()
        {
            var debugBuf = this.AddEditTab("Debug").Tag as ToreDitorCore.Buffer;
            debugBuf.Document.Append(new StringBuilder("Hello, World!!"));
            debugBuf.SetFileType("hsp");
        }

        private void バージョン情報AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();

            about.ShowDialog();

            about.Dispose();
        }

        private void 終了OpenWithEncodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Exit();
        }

        private void Exit()
        {
            if (this.IsModified) {
            }

            this.Close();
        }

        private void 開くOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK) {
                this.TabControl.SelectedTab = this.AddEditTab(Path.GetFileName(this.openFileDialog.FileName));
                (this.TabControl.SelectedTab.Tag as ToreDitorCore.Buffer).Open(this.openFileDialog.FileName);
            }
 
        }

        private void 名前をつけて保存SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*this.saveFileDialog.FileName = (string)this.TabControl.SelectedTab.Tag;
            DialogResult dr = this.saveFileDialog.ShowDialog();

            if (dr == DialogResult.OK) {
                ToreDitorCore.ToreDitorCore editor = (ToreDitorCore.ToreDitorCore)this.TabControl.SelectedTab.Controls["Editor"];
                editor.Save(this.saveFileDialog.FileName);
                this.TabControl.SelectedTab.Text = Path.GetFileName(this.saveFileDialog.FileName);
                this.TabControl.SelectedTab.Tag = this.saveFileDialog.FileName;
            }*/
        }


        private int _NonameCount = 0;
        private void 新規作成NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._NonameCount++;

            this.TabControl.SelectedTab = this.AddEditTab("名称未設定"+this._NonameCount.ToString());
        }

        private void 設定OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm cf = new ConfigForm();

            cf.ShowDialog();

            cf.Dispose();
        }

        private void uTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*ToreDitorCore.ToreDitorCore tc = (ToreDitorCore.ToreDitorCore)this.TabControl.SelectedTab.Controls["Editor"];
            tc.Schemes.Dynamics.Encoding = Encoding.UTF8;*/
        }

        private void sJISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*ToreDitorCore.ToreDitorCore tc = (ToreDitorCore.ToreDitorCore)this.TabControl.SelectedTab.Controls["Editor"];
            tc.Schemes.Dynamics.Encoding = Encoding.GetEncoding("Shift-JIS");*/
        }

        private void eUCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*ToreDitorCore.ToreDitorCore tc = (ToreDitorCore.ToreDitorCore)this.TabControl.SelectedTab.Controls["Editor"];
            tc.Schemes.Dynamics.Encoding = Encoding.GetEncoding("EUC-JP");*/
        }

        private void エンコードを適用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*ToreDitorCore.ToreDitorCore tc = (ToreDitorCore.ToreDitorCore)this.TabControl.SelectedTab.Controls["Editor"];
            tc.ConvertEncoding();*/
        }

        private void 上書きSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*ToreDitorCore.ToreDitorCore tc = (ToreDitorCore.ToreDitorCore)this.TabControl.SelectedTab.Controls["Editor"];
            if (this.TabControl.SelectedTab.Tag != null)
            {
                tc.Save((string)this.TabControl.SelectedTab.Tag);
            } else {
                this.名前をつけて保存SaveAsToolStripMenuItem_Click(sender, e);
            }*/
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Editor.CurrentBuffer = this.TabControl.SelectedTab.Tag as ToreDitorCore.Buffer;
        }

        private void Editor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }
    }
}
