using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToreDitorCore;
using ToreDitorCore.Schemes;

namespace ToreDitor
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();

            var scheme = Scheme.GetInstance();

            foreach (var theme in scheme.Themes) {
                var node = new TreeNode(theme.Key, 1, 1);
                this.TreeView.Nodes["テーマノード"].Nodes.Add(node);
            }

            foreach (var lex in scheme.Dynamic.Lexes)
            {
                var node = new TreeNode(lex.Key, 1, 1);
                this.TreeView.Nodes["字句解析器ノード"].Nodes.Add(node);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int i;

            this.ConfigGridView.Columns.Clear();
            this.ConfigGridView.Rows.Clear();
            var scheme = Scheme.GetInstance();

            switch (e.Node.Name)
            {
                case "基本ノード":

                    return;
                case "処理ノード":

                    return;
                case "動作ノード":

                    return;
                case "見た目ノード":
                    this.ConfigGridView.AllowUserToAddRows = false;

                    this.ConfigGridView.Columns.Add("Key", "設定項目");
                    this.ConfigGridView.Columns.Add("Value", "値");

                    this.ConfigGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.ConfigGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    // ToDo: 未定義の際の処理
                    var themeCombo = new DataGridViewComboBoxCell();
                    themeCombo.DataSource = scheme.Themes.Keys.ToArray();
                    themeCombo.Value = scheme.Static.appearance.theme;

                    var sideCombo = new DataGridViewComboBoxCell();
                    sideCombo.Items.Add("light");
                    sideCombo.Items.Add("dark");
                    sideCombo.Value = scheme.Static.appearance["theme-side"];

                    var themeRow = new DataGridViewRow();
                    var themeLabel = new DataGridViewTextBoxCell();
                    themeLabel.Value = "テーマ";
                    themeRow.Cells.Add(themeLabel);
                    themeRow.Cells.Add(themeCombo);

                    var sideRow = new DataGridViewRow();
                    var sideLabel = new DataGridViewTextBoxCell();
                    sideLabel.Value = "テーマの表/裏";
                    sideRow.Cells.Add(sideLabel);
                    sideRow.Cells.Add(sideCombo);
                    this.ConfigGridView.Rows.Add(themeRow);
                    this.ConfigGridView.Rows.Add(sideRow);

                    return;
                case "テーマノード":
                    this.ConfigGridView.AllowUserToAddRows = true;

                    this.ConfigGridView.Columns.Add("Name", "名称");
                    this.ConfigGridView.Columns.Add("Author", "作者");
                    this.ConfigGridView.Columns.Add("Version", "バージョン");
                    this.ConfigGridView.Columns.Add("Website", "URL");

                    this.ConfigGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.ConfigGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.ConfigGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.ConfigGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    foreach (var theme in scheme.Themes)
                    {
                        this.ConfigGridView.Rows.Add(theme.Value.Name, theme.Value.Author, theme.Value.Version, theme.Value.Website);
                    }

                    return;
                case "字句解析器ノード":

                    this.ConfigGridView.AllowUserToAddRows = false;

                    this.ConfigGridView.Columns.Add("Name", "名称");
                    this.ConfigGridView.Columns.Add("Ext", "拡張子");

                    this.ConfigGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.ConfigGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    foreach (var lex in scheme.Dynamic.Lexes)
                    {
                        this.ConfigGridView.Rows.Add(lex.Value.Name, lex.Value.ExtPattern);
                    }

                    return;
            }

            switch (e.Node.Parent.Name)
            {
                case "テーマノード":

                    var theme = scheme.Themes[e.Node.Text];

                    this.ConfigGridView.AllowUserToAddRows = true;

                    this.ConfigGridView.Columns.Add("Name", "スタイル名");
                    this.ConfigGridView.Columns.Add("Fore", "前景色");
                    this.ConfigGridView.Columns.Add("Back", "背景色");
                    this.ConfigGridView.Columns.Add("Font", "字体");
                    this.ConfigGridView.Columns.Add("Decoration", "装飾");

                    for (i = 0; i < this.ConfigGridView.Columns.Count-1; i++)
                    {
                        this.ConfigGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    this.ConfigGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    foreach (var style in theme.Style[0])
                    {
                        var styleRow = new DataGridViewRow();

                        string color = "",
                                background = "",
                                font = "",
                                deco = "";

                        style.Value.Styles.TryGetValue(Syntax.Directive.Style.Color, out color);
                        style.Value.Styles.TryGetValue(Syntax.Directive.Style.BackgroundColor, out background);
                        style.Value.Styles.TryGetValue(Syntax.Directive.Style.Font, out font);
                        style.Value.Styles.TryGetValue(Syntax.Directive.Style.Decoration, out deco);

                        var nameCell = new DataGridViewTextBoxCell()
                        {
                            Value = style.Key + "-light"
                        };
                        var colorCell = new DataGridViewColorBoxCell(color);
                        var backgroundCell = new DataGridViewColorBoxCell(background);
                        var fontCell = new DataGridViewFontBoxCell(font);
                        var decoCell = new DataGridViewDecorationBoxCell(deco);

                        styleRow.Cells.Add(nameCell);
                        styleRow.Cells.Add(colorCell);
                        styleRow.Cells.Add(backgroundCell);
                        styleRow.Cells.Add(fontCell);
                        styleRow.Cells.Add(decoCell);


                        this.ConfigGridView.Rows.Add(styleRow);
                    }

                    foreach (var style in theme.Style[1])
                    {
                        var styleRow = new DataGridViewRow();

                        string color = "",
                                background = "",
                                font = "",
                                deco = "";

                        style.Value.Styles.TryGetValue(Syntax.Directive.Style.Color, out color);
                        style.Value.Styles.TryGetValue(Syntax.Directive.Style.BackgroundColor, out background);
                        style.Value.Styles.TryGetValue(Syntax.Directive.Style.Font, out font);
                        style.Value.Styles.TryGetValue(Syntax.Directive.Style.Decoration, out deco);

                        var nameCell = new DataGridViewTextBoxCell()
                        {
                            Value = style.Key + "-dark"
                        };
                        var colorCell = new DataGridViewColorBoxCell(color);
                        var backgroundCell = new DataGridViewColorBoxCell(background);
                        var fontCell = new DataGridViewFontBoxCell(font);
                        var decoCell = new DataGridViewDecorationBoxCell(deco);

                        styleRow.Cells.Add(nameCell);
                        styleRow.Cells.Add(colorCell);
                        styleRow.Cells.Add(backgroundCell);
                        styleRow.Cells.Add(fontCell);
                        styleRow.Cells.Add(decoCell);


                        this.ConfigGridView.Rows.Add(styleRow);
                    }

                    return;
                case "字句解析器ノード":
                    this.ConfigGridView.AllowUserToAddRows = false;

                    var lex = scheme.Dynamic.Lexes[e.Node.Text];

                    this.ConfigGridView.AllowUserToAddRows = true;

                    this.ConfigGridView.Columns.Add("Name", "字句名");
                    this.ConfigGridView.Columns.Add("Fore", "前景色");
                    this.ConfigGridView.Columns.Add("Back", "背景色");
                    this.ConfigGridView.Columns.Add("Font", "字体");
                    this.ConfigGridView.Columns.Add("Decoration", "装飾");
                    this.ConfigGridView.Columns.Add("State", "状態");
                    this.ConfigGridView.Columns.Add("NextState", "次の状態");
                    this.ConfigGridView.Columns.Add("Transit", "遷移");
                    this.ConfigGridView.Columns.Add("ExStyle", "外部スタイル");

                    for (i = 0; i < this.ConfigGridView.Columns.Count-1; i++)
                    {
                        this.ConfigGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    this.ConfigGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    foreach (var syn in lex)
                    {
                        var synRow = new DataGridViewRow();

                        string color = "",
                               background = "",
                               font = "",
                               deco = "",
                               state = "",
                               nexst = "",
                               trans = "",
                               exs = "";
                        syn.Value.Style.Styles.TryGetValue(Syntax.Directive.Style.Color, out color);
                        syn.Value.Style.Styles.TryGetValue(Syntax.Directive.Style.BackgroundColor, out background);
                        syn.Value.Style.Styles.TryGetValue(Syntax.Directive.Style.Font, out font);
                        syn.Value.Style.Styles.TryGetValue(Syntax.Directive.Style.Decoration, out deco);
                        syn.Value.Style.Styles.TryGetValue(Syntax.Directive.Style.State, out state);
                        syn.Value.Style.Styles.TryGetValue(Syntax.Directive.Style.NextState, out nexst);
                        syn.Value.Style.Styles.TryGetValue(Syntax.Directive.Style.Transit, out trans);
                        syn.Value.Style.Styles.TryGetValue(Syntax.Directive.Style.ExStyle, out exs);

                        synRow.Cells.Add(new DataGridViewTextBoxCell() { Value = syn.Key });
                        synRow.Cells.Add(new DataGridViewColorBoxCell(color));
                        synRow.Cells.Add(new DataGridViewColorBoxCell(background));
                        synRow.Cells.Add(new DataGridViewFontBoxCell(font));
                        synRow.Cells.Add(new DataGridViewDecorationBoxCell(deco));
                        synRow.Cells.Add(new DataGridViewTextBoxCell() { Value = state });
                        synRow.Cells.Add(new DataGridViewTextBoxCell() { Value = nexst });
                        synRow.Cells.Add(new DataGridViewTextBoxCell() { Value = trans });
                        synRow.Cells.Add(new DataGridViewTextBoxCell() { Value = exs });

                        this.ConfigGridView.Rows.Add(synRow);
                    }

                    return;
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
