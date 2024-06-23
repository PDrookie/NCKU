using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0930_practice_3_1
{
    public partial class Form1 : Form
    {
        Boolean click = false;
        List<Account> Accounts = new List<Account>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if(!click)
            {
                editBT.Text = "回到主畫面";
                textBox2.Text = "我是狀態列";
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Enabled = false;
            }
            else
            {
                editBT.Text = "新增或刪除";
                resultBOX.Text = "";
                searchBOX.Text = "";
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Enabled = true;
            }

            click = !click;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "我是狀態列";
            Account newuser = new Account(textBox1.Text, textBox3.Text, textBox4.Text);
            if (!Accounts.Contains(newuser))
            {
                Accounts.Add(newuser);
                textBox2.Text = "新增完成";
                textBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                textBox2.Text = "帳號已存在";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "我是狀態列";
            Account newuser = new Account(textBox1.Text, textBox3.Text, textBox4.Text);
            if (Accounts.Contains(newuser))
            {
                Accounts.Remove(newuser);
                textBox2.Text = "刪除完成";
                textBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                textBox2.Text = "帳號不存在或密碼錯誤";
            }
        }

        private void searchBT_Click(object sender, EventArgs e)
        {
            resultBOX.Text = "";
            string link = searchBOX.Text;
            foreach(Account account in Accounts)
            {
                if(account.link.Contains(link))
                {                   
                    resultBOX.Text += "連結：" + account.link + "\n" + "使用者：" + account.user + "\n" + "密碼：" + account.pass + "\n" + "====================================" + "\n";
                }
            }
            searchBOX.Text = "";
        }

        private void dangerBT_Click(object sender, EventArgs e)
        {
            searchBOX.Text = "";
            resultBOX.Text = "";
            for (int i = 0 ; i < Accounts.Count; i++) 
            {
                for (int j = i; j < Accounts.Count ; j ++ )
                {
                    if(Accounts[i].pass == Accounts[j].pass && i != j )
                    resultBOX.Text += "連結：" + Accounts[i].link + "\n" + "使用者：" + Accounts[i].user + "\n" + "密碼：" + Accounts[i].pass + "\n" + "====================================" + "\n";
                }
            }
        }
    }
}
