using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1028_practice_7_1
{
    public partial class Form2 : Form
    {
        public Form2(Form1 fr)
        {
            InitializeComponent();
            list = fr;
        }
        Form1 list = new Form1();

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            list.create();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("請輸入事項", "", MessageBoxButtons.OK);
            else
            {
                list.richTextBox1.Text = list.richTextBox1.Text + textBox1.Text + "\n";
                list.create();
                this.Close();
            }
        }
    }
}
