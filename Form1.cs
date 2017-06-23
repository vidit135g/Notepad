using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        OpenFileDialog file_open = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file_open.Filter = "Rich Text File (*.rtf)|*.rtf|Plain Text File (*.txt)|*.txt";
            file_open.FilterIndex = 1;
            file_open.Title = "Open RTF or TXT file";
            RichTextBoxStreamType stream_type;
            stream_type = RichTextBoxStreamType.RichText;
            if (DialogResult.OK == file_open.ShowDialog())
            {
                if (string.IsNullOrEmpty(file_open.FileName))
                {
                    return;
                }
                if (file_open.FilterIndex == 2)
                {
                    stream_type = RichTextBoxStreamType.PlainText;
                }
                richTextBox1.LoadFile(file_open.FileName, stream_type);
                string s = file_open.FileName.ToString();
                int c=s.LastIndexOf('\\');
                int x = s.LastIndexOf('.');
                int d = x - c;
                this.Text = s.Substring(c + 1, d-1);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_file = new SaveFileDialog();
            string filename = "";

            save_file.Filter = "Rich Text File (*.rtf)|*.rtf|Plain Text File (*.txt)|*.txt";
            save_file.DefaultExt = "*.rtf";
            save_file.FilterIndex = 1;
            save_file.Title = "Save the contents";
            filename = file_open.FileName;

            RichTextBoxStreamType stream_type;
            if (filename.Contains(".txt"))
            {
                stream_type = RichTextBoxStreamType.PlainText;
            }
            else
            {
                stream_type = RichTextBoxStreamType.RichText;
            }
            richTextBox1.SaveFile(filename, stream_type);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_file = new SaveFileDialog();
            string filename = "";
            save_file.Filter = "Rich Text File (*.rtf)|*.rtf|Plain Text File (*.txt)|*.txt";
            save_file.DefaultExt = "*.rtf";
            save_file.FilterIndex = 1;
            save_file.Title = "Save the contents";
            DialogResult retval = save_file.ShowDialog();
            if (retval == DialogResult.OK)
                filename = save_file.FileName;
            else
                return;
            RichTextBoxStreamType stream_type;
            if (save_file.FilterIndex == 2)
                stream_type = RichTextBoxStreamType.PlainText;
            else
                stream_type = RichTextBoxStreamType.RichText;
            richTextBox1.SaveFile(filename, stream_type);
            this.Text = filename.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Font font = fontDialog1.Font;
                this.richTextBox1.Font = font;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Options:\n\nFile Open : Press 'CTRL + O'\nFile Save : Press 'CTRL + S'\nCut : Press 'CTRL + X'\nCopy : Press 'CTRL + C'\nPaste : Press 'CTRL + V'\n");
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;
            panel1.BackColor = Color.White;
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Black;
            richTextBox1.ForeColor = Color.White;
            panel1.BackColor = Color.Black;
        }
    }
}
