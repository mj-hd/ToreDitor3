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

        private List<ToreDitorCore.ToreDitorCore> _Editors = new List<ToreDitorCore.ToreDitorCore>();

        private int AddEditTab(string name)
        {
            TabPage tb = new TabPage();
            tb.Text = name;
            tb.Tag  = this.TabControl.TabPages.Count;

            ToreDitorCore.ToreDitorCore tc = new ToreDitorCore.ToreDitorCore(new Font("MS Gothic", 11.0f));
            tc.Dock = DockStyle.Fill;
            tc.Name = "Editor";

            this._Editors.Add(tc);
            tb.Controls.Add(tc);
            this.TabControl.TabPages.Add(tb);

            return this.TabControl.TabPages.Count -1;
        }

        private void Debug()
        {
            int tabNum = this.AddEditTab("Debug");
            ToreDitorCore.ToreDitorCore tc = (ToreDitorCore.ToreDitorCore)this.TabControl.TabPages[tabNum].Controls["Editor"];
            tc.Document.Insert(0, new StringBuilder("Hello, World!!"));
            tc.Buffer.Aliases.Add(new ToreDitorCore.Highlight("DebugHello", @"Hello", new SolidBrush(ColorTranslator.FromHtml("#181")), 1));
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
            /*DialogResult dr = this.openFileDialog.ShowDialog();

            if (dr == DialogResult.OK) {
                int tabNum = this.AddEditTab(Path.GetFileName(this.openFileDialog.FileName));
                this.TabControl.TabPages[tabNum].Tag = this.openFileDialog.FileName;
                ToreDitorCore.ToreDitorCore editor = (ToreDitorCore.ToreDitorCore)this.TabControl.TabPages[tabNum].Controls["Editor"];
                editor.Load(this.openFileDialog.FileName);

                this.TabControl.SelectedTab = this.TabControl.TabPages[tabNum];
            }*/

            if (this.openFileDialog.ShowDialog() == DialogResult.OK) {
                int tabNum = this.AddEditTab(Path.GetFileName(this.openFileDialog.FileName));
                this.TabControl.TabPages[tabNum].Tag = this.openFileDialog.FileName; 
                this._Editors[tabNum].Open(this.openFileDialog.FileName);

                if (this.openFileDialog.FileName.EndsWith(".cs")) {
                    this._Editors[tabNum].Buffer.Aliases.Add(new ToreDitorCore.Highlight("CSKeyword", "(using)|(namespace)|(public)|(partial)|(class)|(this)", new SolidBrush(ColorTranslator.FromHtml("#99d"))));
                    this._Editors[tabNum].Buffer.Aliases.Add(new ToreDitorCore.Highlight("CSClassName", "(ToreDitorCore)|(UserControl)", new SolidBrush(ColorTranslator.FromHtml("#9d9"))));
                }

                this.TabControl.SelectedTab = this.TabControl.TabPages[tabNum];
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

            this.TabControl.SelectedTab = this.TabControl.TabPages[this.AddEditTab("名称未設定"+this._NonameCount.ToString())];
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
   }
}
