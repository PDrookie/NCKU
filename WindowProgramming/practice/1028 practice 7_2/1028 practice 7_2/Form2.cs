using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1028_practice_7_2
{
    public partial class Form2 : Form
    {
        int mode;
        public Form2(Form1 fr)
        {
            InitializeComponent();
            list = fr;
        }
        Form1 list = new Form1();

        public void knowMode(int n)
        {
            mode = n;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            list.create(1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("請輸入事項", "", MessageBoxButtons.OK);
            else
            {
                switch (mode)
                {
                    case 1:
                        list.add(textBox1.Text);
                        list.create(1);
                        break;
                    case 2:
                        list.complete(textBox1.Text);
                        list.create(1);
                        break;
                    case 3:
                        list.remove(textBox1.Text);
                        list.create(1);
                        break;
                    case 4:
                        list.create(2);
                        list.search(textBox1.Text);                        
                        break;

                }
                this.Close();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
