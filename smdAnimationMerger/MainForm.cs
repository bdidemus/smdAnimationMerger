using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace smdAnimationMerger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = ".smd";
            openFileDialog.Filter = "Valve SMD animation|*.smd";
            openFileDialog.Multiselect = true;

            DialogResult result = openFileDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                foreach (String path in openFileDialog.FileNames)
                {
                    lbFiles.Items.Add(path);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (txtOutPath.Text.Length == 0)
            {
                MessageBox.Show("Output file not set", "You dun goofed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                SmdParser parser = new SmdParser(lbFiles.Items.Cast<String>().ToArray(), txtOutPath.Text);
                bool success = true;
                try
                {
                    parser.doParse();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Something bad happened", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
                if (success)
                {
                    MessageBox.Show("Done");
                }
            }
        }

        private void txtOutPath_Click(object sender, EventArgs e)
        {
            saveFileDialog.DefaultExt = ".smd";
            saveFileDialog.Filter = "Valve SMD animation|*.smd";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutPath.Text = saveFileDialog.FileName;
            }


        }
    }
}
