using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0930_practice3_3_2
{
    public partial class Form1 : Form
    {

        List<char> line1s = new List<char>();
        List<char> line2s = new List<char>();
        List<char> line3s = new List<char>();
        List<char> line4s = new List<char>();
        Check check = new Check();
        Game play = new Game();
        int line1N = 0, line2N = 0, line3N = 0, line4N = 0;
        char stack;
        int state, lastState;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox2.Text = "請輸入測資";
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            panel2.Visible = true;
            panel1.Visible = false;

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                line1s.Add('\n');
                line2s.Add('\n');
                line3s.Add('\n');
                line4s.Add('\n');
            }
            if (check.canplay(textBox3.Text) && check.canplay(textBox6.Text) && check.canplay(textBox5.Text) && check.canplay(textBox4.Text))
            {
                if (textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "")
                {
                    textBox2.Text = "測資錯誤";
                }
                else
                {

                    foreach(var c in textBox3.Text)
                    {
                        if(c != ' ')
                        {
                            line1N ++;
                            line1s.Remove('\n');
                            line1s.Add('\n');
                            line1s.Add(c);                            
                        }
                    }
                    foreach(var line1 in line1s)
                    {
                        richTextBox1.Text += line1;
                    }
                    foreach (var c in textBox4.Text)
                    {
                        if (c != ' ')
                        {
                            line2N ++;
                            line2s.Remove('\n');
                            line2s.Add('\n');
                            line2s.Add(c);
                        }
                    }
                    foreach (var line2 in line2s)
                    {
                        richTextBox2.Text += line2;
                    }
                    foreach (var c in textBox5.Text)
                    {
                        if (c != ' ')
                        {
                            line3N++;
                            line3s.Remove('\n');
                            line3s.Add('\n');
                            line3s.Add(c);
                        }
                    }
                    foreach (var line3 in line3s)
                    {
                        richTextBox4.Text += line3;
                    }
                    foreach (var c in textBox6.Text)
                    {
                        if (c != ' ')
                        {
                            line4N++;
                            line4s.Remove('\n');
                            line4s.Add('\n');
                            line4s.Add(c);
                        }
                    }
                    foreach (var line4 in line4s)
                    {
                        richTextBox3.Text += line4;
                    }
                    panel2.Visible = false;
                    panel1.Visible = true;
                }                
            }
            else
            {
                textBox2.Text = "測資錯誤";
            }

            if (!play.cantake(line1N))
            {                
                button1.Enabled = false;
            }
            if (!play.cantake(line2N))
            {
                button2.Enabled = false;
            }
            if (!play.cantake(line3N))
            {
                button3.Enabled = false;
            }
            if (!play.cantake(line4N))
            {
                button4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "選取")
            {
                foreach (var line1 in line1s)
                {
                        if (line1 != '\n')
                        {
                            stack = line1;
                            break;
                        }
                }
                richTextBox5.Text = "你選了堆疊1";
                button1.Text = "放置";
                button2.Text = "放置";
                button3.Text = "放置";
                button4.Text = "放置";
                lastState = 1;
                if (!play.canplace(line1N))
                {
                    button1.Enabled = false;
                }
                else
                    button1.Enabled = true;
                if (!play.canplace(line2N))
                {
                    button2.Enabled = false;
                }
                else
                    button2.Enabled = true;
                if (!play.canplace(line3N))
                {
                    button3.Enabled = false;
                }
                else
                    button3.Enabled = true;
                if (!play.canplace(line4N))
                {
                    button4.Enabled = false;
                }
                else
                    button4.Enabled = true;
            }
            else if (button1.Text == "放置")
            {
                state = 0;
                line1N++;
                foreach (var line1 in line1s)
                {
                    if (line1 != '\n')
                    {
                        line1s.Remove('\n');
                        line1s.Insert(state - 1, stack);
                        line1s.Insert(state, '\n');
                        break;
                    }
                    else if (line1s[line1s.Count - 1] != '\n' && state == 14)
                    {
                        line1s.Remove('\n');
                        line1s.Insert(14, stack);
                        line1s.Insert(15, '\n');
                        break;
                    }
                    else if (state == 14)
                    {
                        line1s.Add(stack);
                        break;
                    }
                    state++;
                }
                richTextBox1.Clear();
                foreach (var line1 in line1s)
                {
                    richTextBox1.Text += line1;
                }
                switch (lastState)
                {
                    case 1:
                        richTextBox1.Clear();
                        line1s.Remove(stack);
                        line1N--;
                        foreach (var line1 in line1s)
                        {
                            richTextBox1.Text += line1;
                        }
                        break;
                    case 2:
                        richTextBox2.Clear();
                        line2s.Remove(stack);
                        line2N--;
                        foreach (var line2 in line2s)
                        {
                            richTextBox2.Text += line2;
                        }
                        break;
                    case 3:
                        richTextBox4.Clear();
                        line3s.Remove(stack);
                        line3N--;
                        foreach (var line3 in line3s)
                        {
                            richTextBox4.Text += line3;
                        }
                        break;
                    case 4:
                        richTextBox3.Clear();
                        line4s.Remove(stack);
                        line4N--;
                        foreach (var line4 in line4s)
                        {
                            richTextBox3.Text += line4;
                        }
                        break;
                }
                richTextBox5.Text = "...";
                button1.Text = "選取";
                button2.Text = "選取";
                button3.Text = "選取";
                button4.Text = "選取";
                if (!play.cantake(line1N))
                {
                    button1.Enabled = false;
                }
                else
                    button1.Enabled = true;
                if (!play.cantake(line2N))
                {
                    button2.Enabled = false;
                }
                else
                    button2.Enabled = true;
                if (!play.cantake(line3N))
                {
                    button3.Enabled = false;
                }
                else
                    button3.Enabled = true;
                if (!play.cantake(line4N))
                {
                    button4.Enabled = false;
                }
                else
                    button4.Enabled = true;
                if (win())
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    richTextBox5.Text = "你贏了";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "選取")
            {
                if (play.canplace(line2N))
                {
                    button2.Enabled = true;
                    foreach (var line2 in line2s)
                    {
                        if (line2 != '\n')
                        {
                            stack = line2;
                            break;
                        }
                    }
                }
                else
                {
                    button2.Enabled = false;
                }
                richTextBox5.Text = "你選了堆疊2";
                button1.Text = "放置";
                button2.Text = "放置";
                button3.Text = "放置";
                button4.Text = "放置";
                lastState = 2;
                if (!play.canplace(line1N))
                {
                    button1.Enabled = false;
                }
                else
                    button1.Enabled = true;
                if (!play.canplace(line2N))
                {
                    button2.Enabled = false;
                }
                else
                    button2.Enabled = true;
                if (!play.canplace(line3N))
                {
                    button3.Enabled = false;
                }
                else
                    button3.Enabled = true;
                if (!play.canplace(line4N))
                {
                    button4.Enabled = false;
                }
                else
                    button4.Enabled = true;

            }
            else if (button2.Text == "放置")
            {
                state = 0;
                line2N++;
                foreach (var line2 in line2s)
                {
                    if (line2 != '\n')
                    {
                        line2s.Remove('\n');
                        line2s.Insert(state - 1, stack);
                        line2s.Insert(state, '\n');
                        break;
                    }
                    else if(line2s[line2s.Count - 1] != '\n' && state ==14)
                    {
                        line2s.Remove('\n');
                        line2s.Insert(14, stack);
                        line2s.Insert(15, '\n');
                        break;
                    }
                    else if(state == 14)
                    {                       
                        line2s.Add(stack);
                        break;
                    }
                    state++;
                }
                richTextBox2.Clear();
                foreach (var line2 in line2s)
                {
                    richTextBox2.Text += line2;
                }
                switch (lastState)
                {
                    case 1:
                        richTextBox1.Clear();
                        line1s.Remove(stack);
                        line1N--;
                        foreach (var line1 in line1s)
                        {
                            richTextBox1.Text += line1;
                        }
                        break;
                    case 2:
                        richTextBox2.Clear();
                        line2s.Remove(stack);
                        line2N--;
                        foreach (var line2 in line2s)
                        {
                            richTextBox2.Text += line2;
                        }
                        break;
                    case 3:
                        richTextBox4.Clear();
                        line3s.Remove(stack);
                        line3N--;
                        foreach (var line3 in line3s)
                        {
                            richTextBox4.Text += line3;
                        }
                        break;
                    case 4:
                        richTextBox3.Clear();
                        line4s.Remove(stack);
                        line4N--;
                        foreach (var line4 in line4s)
                        {
                            richTextBox3.Text += line4;
                        }
                        break;
                }
                richTextBox5.Text = "...";
                button1.Text = "選取";
                button2.Text = "選取";
                button3.Text = "選取";
                button4.Text = "選取";
                if (!play.cantake(line1N))
                {
                    button1.Enabled = false;
                }
                else
                    button1.Enabled = true;
                if (!play.cantake(line2N))
                {
                    button2.Enabled = false;
                }
                else
                    button2.Enabled = true;
                if (!play.cantake(line3N))
                {
                    button3.Enabled = false;
                }
                else
                    button3.Enabled = true;
                if (!play.cantake(line4N))
                {
                    button4.Enabled = false;
                }
                else
                    button4.Enabled = true;
                if (win())
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    richTextBox5.Text = "你贏了";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "選取")
            {
                foreach (var line3 in line3s)
                {
                    if (line3 != '\n')
                    {
                        stack = line3;
                        break;
                    }
                }
                richTextBox5.Text = "你選了堆疊3";
                button1.Text = "放置";
                button2.Text = "放置";
                button3.Text = "放置";
                button4.Text = "放置";
                lastState = 3;
                if (!play.canplace(line1N))
                {
                    button1.Enabled = false;
                }
                else
                    button1.Enabled = true;
                if (!play.canplace(line2N))
                {
                    button2.Enabled = false;
                }
                else
                    button2.Enabled = true;
                if (!play.canplace(line3N))
                {
                    button3.Enabled = false;
                }
                else
                    button3.Enabled = true;
                if (!play.canplace(line4N))
                {
                    button4.Enabled = false;
                }
                else
                    button4.Enabled = true;
            }
            else if (button3.Text == "放置")
            {
                state = 0;
                line3N++;
                foreach (var line3 in line3s)
                {
                    if (line3 != '\n')
                    {
                        line3s.Remove('\n');
                        line3s.Insert(state - 1, stack);
                        line3s.Insert(state, '\n');
                        break;
                    }
                    else if (line3s[line3s.Count - 1] != '\n' && state == 14)
                    {
                        line3s.Remove('\n');
                        line3s.Insert(14, stack);
                        line3s.Insert(15, '\n');
                        break;
                    }
                    else if (state == 14)
                    {
                        line3s.Add(stack);
                        break;
                    }
                    state++;
                }
                richTextBox4.Clear();
                foreach (var line3 in line3s)
                {
                    richTextBox4.Text += line3;
                }
                switch (lastState)
                {
                    case 1:
                        richTextBox1.Clear();
                        line1s.Remove(stack);
                        line1N--;
                        foreach (var line1 in line1s)
                        {
                            richTextBox1.Text += line1;
                        }
                        break;
                    case 2:
                        richTextBox2.Clear();
                        line2s.Remove(stack);
                        line2N--;
                        foreach (var line2 in line2s)
                        {
                            richTextBox2.Text += line2;
                        }
                        break;
                    case 3:
                        richTextBox4.Clear();
                        line3s.Remove(stack);
                        line3N--;
                        foreach (var line3 in line3s)
                        {
                            richTextBox4.Text += line3;
                        }
                        break;
                    case 4:
                        richTextBox3.Clear();
                        line4s.Remove(stack);
                        line4N--;
                        foreach (var line4 in line4s)
                        {
                            richTextBox3.Text += line4;
                        }
                        break;
                }
                richTextBox5.Text = "...";
                button1.Text = "選取";
                button2.Text = "選取";
                button3.Text = "選取";
                button4.Text = "選取";
                if (!play.cantake(line1N))
                {
                    button1.Enabled = false;
                }
                else
                    button1.Enabled = true;
                if (!play.cantake(line2N))
                {
                    button2.Enabled = false;
                }
                else
                    button2.Enabled = true;
                if (!play.cantake(line3N))
                {
                    button3.Enabled = false;
                }
                else
                    button3.Enabled = true;
                if (!play.cantake(line4N))
                {
                    button4.Enabled = false;
                }
                else
                    button4.Enabled = true;
                if (win())
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    richTextBox5.Text = "你贏了";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button1.Text == "選取")
            {
                foreach (var line4 in line4s)
                {
                    if (line4 != '\n')
                    {
                        stack = line4;
                        break;
                    }
                }
                richTextBox5.Text = "你選了堆疊4";
                button1.Text = "放置";
                button2.Text = "放置";
                button3.Text = "放置";
                button4.Text = "放置";
                lastState = 4;
                if (!play.canplace(line1N))
                {
                    button1.Enabled = false;
                }
                else
                    button1.Enabled = true;
                if (!play.canplace(line2N))
                {
                    button2.Enabled = false;
                }
                else
                    button2.Enabled = true;
                if (!play.canplace(line3N))
                {
                    button3.Enabled = false;
                }
                else
                    button3.Enabled = true;
                if (!play.canplace(line4N))
                {
                    button4.Enabled = false;
                }
                else
                    button4.Enabled = true;
            }
            else if (button1.Text == "放置")
            {
                state = 0;
                line4N++;
                foreach (var line4 in line4s)
                {
                    if (line4 != '\n')
                    {
                        line4s.Remove('\n');
                        line4s.Insert(state - 1, stack);
                        line4s.Insert(state, '\n');
                        break;
                    }
                    else if (line4s[line4s.Count - 1] != '\n' && state == 14)
                    {
                        line4s.Remove('\n');
                        line4s.Insert(14, stack);
                        line4s.Insert(15, '\n');
                        break;
                    }
                    else if (state == 14)
                    {
                        line4s.Add(stack);
                        break;
                    }
                    state++;
                }
                richTextBox3.Clear();
                foreach (var line4 in line4s)
                {
                    richTextBox3.Text += line4;
                }
                switch (lastState)
                {
                    case 1:
                        richTextBox1.Clear();
                        line1s.Remove(stack);
                        line1N--;
                        foreach (var line1 in line1s)
                        {
                            richTextBox1.Text += line1;
                        }
                        break;
                    case 2:
                        richTextBox2.Clear();
                        line2s.Remove(stack);
                        line2N--;
                        foreach (var line2 in line2s)
                        {
                            richTextBox2.Text += line2;
                        }
                        break;
                    case 3:
                        richTextBox4.Clear();
                        line3s.Remove(stack);
                        line3N--;
                        foreach (var line3 in line3s)
                        {
                            richTextBox4.Text += line3;
                        }
                        break;
                    case 4:
                        richTextBox3.Clear();
                        line4s.Remove(stack);
                        line4N--;
                        foreach (var line4 in line4s)
                        {
                            richTextBox3.Text += line4;
                        }
                        break;
                }
                richTextBox5.Text = "...";
                button1.Text = "選取";
                button2.Text = "選取";
                button3.Text = "選取";
                button4.Text = "選取";
                if (!play.cantake(line1N))
                {
                    button1.Enabled = false;
                }
                else
                    button1.Enabled = true;
                if (!play.cantake(line2N))
                {
                    button2.Enabled = false;
                }
                else
                    button2.Enabled = true;
                if (!play.cantake(line3N))
                {
                    button3.Enabled = false;
                }
                else
                    button3.Enabled = true;
                if (!play.cantake(line4N))
                {
                    button4.Enabled = false;
                }
                else
                    button4.Enabled = true;
                if (win())
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    richTextBox5.Text = "你贏了";
                }
            }
        }

        public bool win()
        {
            int winFlag = 0;
            if(line1N == 3)
            {
                if(line1s[line1s.Count - 5] == line1s[line1s.Count - 3] && line1s[line1s.Count - 3] == line1s[line1s.Count - 1] && line1s[line1s.Count - 1] == line1s[line1s.Count - 5])
                {
                    winFlag++;
                }
            }
            if (line3N == 3)
            {
                if (line3s[line3s.Count - 5] == line3s[line3s.Count - 3] && line3s[line3s.Count - 3] == line3s[line3s.Count - 1] && line3s[line3s.Count - 1] == line3s[line3s.Count - 5])
                {
                    winFlag++;
                }
            }
            if (line2N == 3)
            {
                if (line2s[line2s.Count - 5] == line2s[line2s.Count - 3] && line2s[line2s.Count - 3] == line2s[line2s.Count - 1] && line2s[line2s.Count - 1] == line2s[line2s.Count - 5])
                {
                    winFlag++;
                }
            }
            if (line4N == 3)
            {
                if (line4s[line4s.Count - 5] == line4s[line4s.Count - 3] && line4s[line4s.Count - 3] == line4s[line4s.Count - 1] && line4s[line4s.Count - 1] == line4s[line4s.Count - 5])
                {
                    winFlag++;
                }
            }
            if(winFlag == 3)
            {
                return true;
            }
            return false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
