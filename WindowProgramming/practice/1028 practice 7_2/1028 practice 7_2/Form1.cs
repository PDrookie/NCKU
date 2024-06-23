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

namespace _1028_practice_7_2
{
    public partial class Form1 : Form
    {
        string path;
        List<Todo> Todos = new List<Todo>();
        public Form1()
        {
            InitializeComponent();
        }

        public void add(string thing)
        {
            Todo newTask = new Todo("-", "[ ]", thing);
            Todos.Add(newTask);
            richTextBox1.Text = "";
            foreach(Todo item in Todos)
            {
                richTextBox1.Text += " ";
                richTextBox1.Text += item.check;
                richTextBox1.Text += " ";
                richTextBox1.Text += item.task;
                richTextBox1.Text += "\n";
            }
        }

        public void complete(string thing)
        {
            foreach (Todo item in Todos)
            {
                if(item.task == thing)
                {
                    item.output = "+";
                    item.check = "[√]";
                }
            }
            richTextBox1.Text = "";
            foreach (Todo item in Todos)
            {
                richTextBox1.Text += " ";
                richTextBox1.Text += item.check;
                richTextBox1.Text += " ";
                richTextBox1.Text += item.task;
                richTextBox1.Text += "\n";
            }
        }

        public void remove(string thing)
        {
            foreach (Todo item in Todos)
            {
                if (item.task.Equals(thing))
                {
                    Todos.Remove(item);
                    break;
                }
            }
            richTextBox1.Text = "";
            foreach (Todo item in Todos)
            {
                richTextBox1.Text += " ";
                richTextBox1.Text += item.check;
                richTextBox1.Text += " ";
                richTextBox1.Text += item.task;
                richTextBox1.Text += "\n";
            }
        }

        public void search(string thing)
        {
            int found = 0;
            richTextBox1.Text = "";
            foreach (Todo item in Todos)
            {
                if (item.task.Contains(thing))
                {
                    found++;
                }
            }
            if(found == 0)
            {
                button3.PerformClick();
            }
            else
            {
                foreach (Todo item in Todos)
                {
                    if (item.task.Contains(thing))
                    {
                        richTextBox1.Text += " ";
                        richTextBox1.Text += item.check;
                        richTextBox1.Text += " ";
                        richTextBox1.Text += item.task;
                        richTextBox1.Text += "\n";
                    }
                }
            }
        }

        public void create(int boo)
        {
            switch (boo)
            {
                case 0:
                    this.檢視ToolStripMenuItem.Enabled = false;
                    this.檔案ToolStripMenuItem.Enabled = false;
                    this.編輯ToolStripMenuItem.Enabled = false;
                    this.richTextBox1.Enabled = false;
                    break;
                case 1:
                    this.檢視ToolStripMenuItem.Enabled = true;
                    this.檔案ToolStripMenuItem.Enabled = true;
                    this.編輯ToolStripMenuItem.Enabled = true;
                    this.richTextBox1.Enabled = true;
                    this.button1.Visible = true;
                    this.button1.Enabled = true;
                    this.button2.Visible = true;
                    this.button2.Enabled = true;
                    this.button3.Visible = false;
                    this.button3.Enabled = false;
                    break;
                case 2:
                    this.檢視ToolStripMenuItem.Enabled = false;
                    this.檔案ToolStripMenuItem.Enabled = false;
                    this.編輯ToolStripMenuItem.Enabled = false;
                    this.richTextBox1.Enabled = true;
                    this.button1.Visible = false;
                    this.button1.Enabled = false;
                    this.button2.Visible = false;
                    this.button2.Enabled = false;
                    this.button3.Visible = true;
                    this.button3.Enabled = true;
                    break;
            }
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


                foreach (string data in datas)
                {
                    if(data.Contains("+"))
                    {
                        string[] done = data.Split('+');
                        Todo newTask = new Todo("+", "[√]", done[1]);
                        Todos.Add(newTask);
                    }
                    else if (data.Contains("-"))
                    {
                        string[] undo = data.Split('-');
                        Todo newTask = new Todo("-", "[ ]", undo[1]);
                        Todos.Add(newTask);
                    }
                }
                foreach (Todo item in Todos)
                {
                    richTextBox1.Text += " ";
                    richTextBox1.Text += item.check;
                    richTextBox1.Text += " ";
                    richTextBox1.Text += item.task;
                    richTextBox1.Text += "\n";
                }
            }
        }

        private void 儲存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Todo Files(*.todo)|*.todo|Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            if (path == null || path == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                    if (File.Exists(path))
                    {
                        richTextBox2.Text = "";
                        foreach (Todo item in Todos)
                        { 
                            richTextBox2.Text += item.output;
                            richTextBox2.Text += item.task;
                            richTextBox2.Text += "\n";
                        }
                        File.WriteAllText(path, richTextBox2.Text);
                    }
                    else
                    {
                        richTextBox2.Text = "";
                        foreach (Todo item in Todos)
                        {
                            richTextBox2.Text += item.output;
                            richTextBox2.Text += item.task;
                            richTextBox2.Text += "\n";
                        }
                        File.WriteAllText(path, richTextBox2.Text);
                    }
                }
            }
            else
            {
                richTextBox2.Text = "";
                foreach (Todo item in Todos)
                {
                    richTextBox2.Text += item.output;
                    richTextBox2.Text += item.task;
                    richTextBox2.Text += "\n";
                }
                File.WriteAllText(path, richTextBox2.Text);
            }
        }

        private void 另存新檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Todo Files(*.todo)|*.todo|Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            path = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                richTextBox2.Text = "";
                foreach (Todo item in Todos)
                {
                    richTextBox2.Text += item.output;
                    richTextBox2.Text += item.task;
                    richTextBox2.Text += "\n";
                }
                File.WriteAllText(path, richTextBox2.Text);
            }
        }

        private void 離開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 add = new Form2(this);
            add.Text = "新增待辦事項";
            add.Show();
            add.knowMode(1);
            create(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 add = new Form2(this);
            add.Text = "待辦事項";
            add.Show();
            add.knowMode(2);
            create(0);
        }

        private void 新增事項ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void 完成事項ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void 尋找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 add = new Form2(this);
            add.Text = "待辦事項";
            add.Show();
            add.knowMode(4);
            create(0);
        }

        private void 字型大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void 顯示完成事項ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            foreach (Todo item in Todos)
            {                
                richTextBox1.Text += " ";
                richTextBox1.Text += item.check;
                richTextBox1.Text += " ";
                richTextBox1.Text += item.task;
                richTextBox1.Text += "\n";           
            }
        }

        private void 隱藏完成事項ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            foreach (Todo item in Todos)
            {
                if (item.check != "[√]")
                {
                    richTextBox1.Text += " ";
                    richTextBox1.Text += item.check;
                    richTextBox1.Text += " ";
                    richTextBox1.Text += item.task;
                    richTextBox1.Text += "\n";
                }
            }
        }

        private void 刪除事項ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 add = new Form2(this);
            add.Text = "待辦事項";
            add.Show();
            add.knowMode(3);
            create(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            foreach (Todo item in Todos)
            {
                richTextBox1.Text += " ";
                richTextBox1.Text += item.check;
                richTextBox1.Text += " ";
                richTextBox1.Text += item.task;
                richTextBox1.Text += "\n";
            }
            create(1);
        }
    }
}
