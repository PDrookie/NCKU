using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _1028_practice_7_1
{
    public partial class Form1 : Form
    {
        string path, check;
        public Form1()
        {
            InitializeComponent();
        }

        public void create()
        {
            this.檢視ToolStripMenuItem.Enabled = true;
            this.檔案ToolStripMenuItem.Enabled = true;
            this.richTextBox1.Enabled = true;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
        private void 開啟ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            openFileDialog1.Filter = "Todo Files(*.todo)|*.todo|Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;

                List<string> datas = File.ReadAllLines(path).ToList();

                foreach(string data in datas)
                {
                    richTextBox1.Text = richTextBox1.Text + data + "\n";
                }
            }
        }

        private void 檔案ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 儲存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Todo Files(*.todo)|*.todo|Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            if(path == null || path == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                    if (File.Exists(path))
                    {
                        File.WriteAllText(path, richTextBox1.Text);
                    }
                    else
                    {
                        File.WriteAllText(path, richTextBox1.Text);
                    }


                }
            }
            else
            {
                File.WriteAllText(path, richTextBox1.Text);
                //StreamWriter sw = new StreamWriter(path);
                //sw.Write(richTextBox1.Text);
            }            
        }

        private void 另存新檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Todo Files(*.todo)|*.todo|Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            path = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                File.WriteAllText(path, richTextBox1.Text);
            }
        }

        private void 離開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 字型大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {   
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 add = new Form2(this);
            add.Show();
            檢視ToolStripMenuItem.Enabled = false;
            檔案ToolStripMenuItem.Enabled = false;
            richTextBox1.Enabled = false;
        }
    }
}
