using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToreDitor
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StrawberryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.StrawberryLink.LinkVisited = true;
            System.Diagnostics.Process.Start("http://strawberrylab.0am.jp/");
        }
    }
}
