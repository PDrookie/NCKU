using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1007_practice_4_1
{
    public partial class Form1 : Form
    {
        int[] positiveSide = new int[17];
        int choise1, choise2, clickTimes = 0, flag;
        int state;
        int WIN = 16;
        public void decideTheCard()
        {
            int[] card = new int[16];
            Random myobject = new Random();
            for(int i = 0; i < 8; i++)
            {
                card[i] = i + 1;
            }
            for (int i = 0; i < 8; i++)
            {
                card[i + 8] = i + 1;
            }
            for (int j = 0; j < 8; j++)
            {
                state = myobject.Next(0, 8);
                if (card[state] == 0)
                {
                    j--;
                }
                else
                {                    
                    positiveSide[j] = card[state];
                    card[state] = 0;
                }
            }
            for (int j = 8; j < 16; j++)
            {
                state = myobject.Next(8, 16);
                if (card[state] == 0)
                {
                    j--;
                }
                else
                {
                    positiveSide[j] = card[state];
                    card[state] = 0;
                }
            }
            /*for (int i = 0; i < 16; i++)
            {
                richTextBox1.Text += positiveSide[i];
                richTextBox1.Text += " ";
            }*/
       }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.ImageIndex = 0; button2.ImageIndex = 0; button3.ImageIndex = 0; button4.ImageIndex = 0;
            button5.ImageIndex = 0; button6.ImageIndex = 0; button7.ImageIndex = 0; button8.ImageIndex = 0;
            button9.ImageIndex = 0; button10.ImageIndex = 0; button11.ImageIndex = 0; button12.ImageIndex = 0;
            button13.ImageIndex = 0; button14.ImageIndex = 0; button15.ImageIndex = 0; button16.ImageIndex = 0;
            richTextBox1.Visible = false;
            decideTheCard();
        }
        public void Done(int flag)
        {
            switch (flag)
            {
                case 1:
                    button1.Enabled = false;
                    break;
                case 2:
                    button2.Enabled = false;
                    break;
                case 3:
                    button3.Enabled = false;
                    break;
                case 4:
                    button4.Enabled = false;
                    break;
                case 5:
                    button5.Enabled = false;
                    break;
                case 6:
                    button6.Enabled = false;
                    break;
                case 7:
                    button7.Enabled = false;
                    break;
                case 8:
                    button8.Enabled = false;
                    break;
                case 9:
                    button9.Enabled = false;
                    break;
                case 10:
                    button10.Enabled = false;
                    break;
                case 11:
                    button11.Enabled = false;
                    break;
                case 12:
                    button12.Enabled = false;
                    break;
                case 13:
                    button13.Enabled = false;
                    break;
                case 14:
                    button14.Enabled = false;
                    break;
                case 15:
                    button15.Enabled = false;
                    break;
                case 16:
                    button16.Enabled = false;
                    break;
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button17.Enabled = false;
            button18.Enabled = false;
        }
        private void button19_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool wannaWin(int left)
        {
            if (left == 0)
                return true;
            return false;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            switch (flag)
            {
                case 1:
                    button1.ImageIndex = 0;
                    break;
                case 2:
                    button2.ImageIndex = 0;
                    break;
                case 3:
                    button3.ImageIndex = 0;
                    break;
                case 4:
                    button4.ImageIndex = 0;
                    break;
                case 5:
                    button5.ImageIndex = 0;
                    break;
                case 6:
                    button6.ImageIndex = 0;
                    break;
                case 7:
                    button7.ImageIndex = 0;
                    break;
                case 8:
                    button8.ImageIndex = 0;
                    break;
                case 9:
                    button9.ImageIndex = 0;
                    break;
                case 10:
                    button10.ImageIndex = 0;
                    break;
                case 11:
                    button11.ImageIndex = 0;
                    break;
                case 12:
                    button12.ImageIndex = 0;
                    break;
                case 13:
                    button13.ImageIndex = 0;
                    break;
                case 14:
                    button14.ImageIndex = 0;
                    break;
                case 15:
                    button15.ImageIndex = 0;
                    break;
                case 16:
                    button16.ImageIndex = 0;
                    break;
            }
            switch (choise2)
            {
                case 1:
                    button1.ImageIndex = 0;
                    break;
                case 2:
                    button2.ImageIndex = 0;
                    break;
                case 3:
                    button3.ImageIndex = 0;
                    break;
                case 4:
                    button4.ImageIndex = 0;
                    break;
                case 5:
                    button5.ImageIndex = 0;
                    break;
                case 6:
                    button6.ImageIndex = 0;
                    break;
                case 7:
                    button7.ImageIndex = 0;
                    break;
                case 8:
                    button8.ImageIndex = 0;
                    break;
                case 9:
                    button9.ImageIndex = 0;
                    break;
                case 10:
                    button10.ImageIndex = 0;
                    break;
                case 11:
                    button11.ImageIndex = 0;
                    break;
                case 12:
                    button12.ImageIndex = 0;
                    break;
                case 13:
                    button13.ImageIndex = 0;
                    break;
                case 14:
                    button14.ImageIndex = 0;
                    break;
                case 15:
                    button15.ImageIndex = 0;
                    break;
                case 16:
                    button16.ImageIndex = 0;
                    break;
            }
            button18.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.ImageIndex = positiveSide[0];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 1;
                choise1 = positiveSide[0];
            }
            else
            {
                choise2 = positiveSide[0];
                if (choise1 != choise2)
                {
                    button18.Enabled = true;
                    choise2 = 1;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button1.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.ImageIndex = positiveSide[1];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 2;
                choise1 = positiveSide[1];
            }
            else
            {
                
                choise2 = positiveSide[1];
                if (choise1 != choise2)
                {
                    choise2 = 2;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button2.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.ImageIndex = positiveSide[2];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 3;
                choise1 = positiveSide[2];
            }
            else
            {                
                choise2 = positiveSide[2];
                if (choise1 != choise2)
                {
                    choise2 = 3;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button3.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.ImageIndex = positiveSide[3];
            clickTimes++;
            if (clickTimes == 0)
            {
                flag = 4;
                choise1 = positiveSide[3];
            }
            else
            {                
                choise2 = positiveSide[3];
                if (choise1 != choise2)
                {
                    choise2 = 4;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button4.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.ImageIndex = positiveSide[4];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 5;
                choise1 = positiveSide[4];
            }
            else
            {
                
                choise2 = positiveSide[4];
                if (choise1 != choise2)
                {
                    choise2 = 5;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button5.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.ImageIndex = positiveSide[5];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 6;
                choise1 = positiveSide[5];
            }
            else
            {
               
                choise2 = positiveSide[5];
                if (choise1 != choise2)
                {
                    choise2 = 6;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button6.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.ImageIndex = positiveSide[6];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 7;
                choise1 = positiveSide[6];
            }
            else
            {
                
                choise2 = positiveSide[6];
                if (choise1 != choise2)
                {
                    choise2 = 7;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button7.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.ImageIndex = positiveSide[7];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 8;
                choise1 = positiveSide[7];
            }
            else
            {
                
                choise2 = positiveSide[7];
                if (choise1 != choise2)
                {
                    choise2 = 8;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button8.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.ImageIndex = positiveSide[8];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 9;
                choise1 = positiveSide[8];
            }
            else
            {
                
                choise2 = positiveSide[8];
                if (choise1 != choise2)
                {
                    choise2 = 9;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button9.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.ImageIndex = positiveSide[9];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 10;
                choise1 = positiveSide[9];
            }
            else
            {
                
                choise2 = positiveSide[9];
                if (choise1 != choise2)
                {
                    choise2 = 10;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button10.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.ImageIndex = positiveSide[10];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 11;
                choise1 = positiveSide[10];
            }
            else
            {
                
                choise2 = positiveSide[10];
                if (choise1 != choise2)
                {
                    choise2 = 11;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button11.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button12.ImageIndex = positiveSide[11];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 12;
                choise1 = positiveSide[11];
            }
            else
            {
                
                choise2 = positiveSide[11];
                if (choise1 != choise2)
                {
                    choise2 = 12;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button12.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button13.ImageIndex = positiveSide[12];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 13;
                choise1 = positiveSide[12];
            }
            else
            {
                
                choise2 = positiveSide[12];
                if (choise1 != choise2)
                {
                    choise2 = 13;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button13.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button14.ImageIndex = positiveSide[13];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 14;
                choise1 = positiveSide[13];
            }
            else
            {
                
                choise2 = positiveSide[13];
                if (choise1 != choise2)
                {
                    choise2 = 14;
                    button18.Enabled = true;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button14.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button15.ImageIndex = positiveSide[14];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 15;
                choise1 = positiveSide[14];
            }
            else
            {
                
                choise2 = positiveSide[14];
                if (choise1 != choise2)
                {
                    button18.Enabled = true;
                    choise2 = 15;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button15.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button16.ImageIndex = positiveSide[15];
            clickTimes++;
            if (clickTimes == 1)
            {
                flag = 16;
                choise1 = positiveSide[15];
            }
            else
            {
                choise2 = positiveSide[15];
                if (choise1 != choise2)
                {
                    button18.Enabled = true;
                    choise2 = 16;
                }
                else
                {
                    WIN -= 2;
                    button18.Enabled = false;
                    Done(flag);
                    button16.Enabled = false;
                    if (wannaWin(WIN))
                    {
                        MessageBox.Show("你贏了！");
                    }
                }
                clickTimes = 0;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
