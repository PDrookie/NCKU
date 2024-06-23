using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1014_practice5_1_1
{
    public partial class Form1 : Form
    {

        string guessWord;
        string invisible;
        Button[] capital = new Button[26];
        char[] word = new char[52];
        char[] visible = new char[11];
        int c, k, disappear;
        int time = 0, wrong = 0;
        int visibleWord;
        int win;
        DialogResult result;
        public void reset()
        {
            textBox1.Text = "";
            time = 0; wrong = 0;
            panel1.Visible = true;
            panel2.Visible = false;
            panel1.Enabled = true;
            panel2.Enabled = false;
            button2.Visible = true; button3.Visible = true; button4.Visible = true;
            button5.Visible = true; button6.Visible = true; button7.Visible = true;
            button8.Visible = true; button9.Visible = true; button10.Visible = true;
            button11.Visible = true; button12.Visible = true; button13.Visible = true;
            button14.Visible = true; button15.Visible = true; button16.Visible = true;
            button17.Visible = true; button18.Visible = true; button19.Visible = true;
            button20.Visible = true; button21.Visible = true; button22.Visible = true;
            button23.Visible = true; button24.Visible = true; button25.Visible = true;
            button26.Visible = true; button27.Visible = true;
            button2.Enabled = true; button3.Enabled = true; button4.Enabled = true;
            button5.Enabled = true; button6.Enabled = true; button7.Enabled = true;
            button8.Enabled = true; button9.Enabled = true; button10.Enabled = true;
            button11.Enabled = true; button12.Enabled = true; button13.Enabled = true;
            button14.Enabled = true; button15.Enabled = true; button16.Enabled = true;
            button17.Enabled = true; button18.Enabled = true; button19.Enabled = true;
            button20.Enabled = true; button21.Enabled = true; button22.Enabled = true;
            button23.Enabled = true; button24.Enabled = true; button25.Enabled = true;
            button26.Enabled = true; button27.Enabled = true;
        }
        public void resetColor()
        {
            button2.BackColor = Color.FromArgb(224, 224, 224); button3.BackColor = Color.FromArgb(224, 224, 224);
            button4.BackColor = Color.FromArgb(224, 224, 224); button5.BackColor = Color.FromArgb(224, 224, 224);
            button6.BackColor = Color.FromArgb(224, 224, 224); button7.BackColor = Color.FromArgb(224, 224, 224);
            button8.BackColor = Color.FromArgb(224, 224, 224); button9.BackColor = Color.FromArgb(224, 224, 224);
            button10.BackColor = Color.FromArgb(224, 224, 224); button11.BackColor = Color.FromArgb(224, 224, 224);
            button12.BackColor = Color.FromArgb(224, 224, 224); button13.BackColor = Color.FromArgb(224, 224, 224);
            button14.BackColor = Color.FromArgb(224, 224, 224); button15.BackColor = Color.FromArgb(224, 224, 224);
            button16.BackColor = Color.FromArgb(224, 224, 224); button17.BackColor = Color.FromArgb(224, 224, 224);
            button18.BackColor = Color.FromArgb(224, 224, 224); button19.BackColor = Color.FromArgb(224, 224, 224);
            button20.BackColor = Color.FromArgb(224, 224, 224); button21.BackColor = Color.FromArgb(224, 224, 224);
            button22.BackColor = Color.FromArgb(224, 224, 224); button23.BackColor = Color.FromArgb(224, 224, 224);
            button24.BackColor = Color.FromArgb(224, 224, 224); button25.BackColor = Color.FromArgb(224, 224, 224);
            button26.BackColor = Color.FromArgb(224, 224, 224); button27.BackColor = Color.FromArgb(224, 224, 224);
        }
        public int Guess(int c)
        {            
            for (k = 0; k < guessWord.Length; k++)
            {
                if (guessWord[k] == word[c] || guessWord[k] == word[c + 26])
                {
                    visibleWord = k;
                    disappear = 1;
                    break;
                }
                else
                {
                    disappear = 0;
                }
            }
            return disappear;
        }
        public void GuessRight(int N)
        {
            win = guessWord.Length;
            switch (N) {
                case 0:
                    button2.BackColor = Color.LightGreen;
                    break;
                case 1:
                    button3.BackColor = Color.LightGreen;
                    break;
                case 2:
                    button4.BackColor = Color.LightGreen;
                    break;
                case 3:
                    button5.BackColor = Color.LightGreen;
                    break;
                case 4:
                    button6.BackColor = Color.LightGreen;
                    break;
                case 5:
                    button7.BackColor = Color.LightGreen;
                    break;
                case 6:
                    button8.BackColor = Color.LightGreen;
                    break;
                case 7:
                    button9.BackColor = Color.LightGreen;
                    break;
                case 8:
                    button10.BackColor = Color.LightGreen;
                    break;
                case 9:
                    button11.BackColor = Color.LightGreen;
                    break;
                case 10:
                    button12.BackColor = Color.LightGreen;
                    break;
                case 11:
                    button13.BackColor = Color.LightGreen;
                    break;
                case 12:
                    button14.BackColor = Color.LightGreen;
                    break;
                case 13:
                    button15.BackColor = Color.LightGreen;
                    break;
                case 14:
                    button16.BackColor = Color.LightGreen;
                    break;
                case 15:
                    button17.BackColor = Color.LightGreen;
                    break;
                case 16:
                    button18.BackColor = Color.LightGreen;
                    break;
                case 17:
                    button19.BackColor = Color.LightGreen;
                    break;
                case 18:
                    button20.BackColor = Color.LightGreen;
                    break;
                case 19:
                    button21.BackColor = Color.LightGreen;
                    break;
                case 20:
                    button22.BackColor = Color.LightGreen;
                    break;
                case 21:
                    button23.BackColor = Color.LightGreen;
                    break;
                case 22:
                    button24.BackColor = Color.LightGreen;
                    break;
                case 23:
                    button25.BackColor = Color.LightGreen;
                    break;
                case 24:
                    button26.BackColor = Color.LightGreen;
                    break;
                case 25:
                    button27.BackColor = Color.LightGreen;
                    break;

            }
            invisible = "";
            for (int i = 0; i < guessWord.Length; i++)
            {
                if (word[N] == guessWord[i] || word[N + 26] == guessWord[i] || visible[i] != '_') 
                {
                    win--;
                    visible[i] = guessWord[i];
                }
                else
                {
                    visible[i] = '_';
                }
            }
            for (int i = 0; i < guessWord.Length; i++)
            {
                invisible = invisible + visible[i] + " ";
            }
            label5.Text = invisible;
            label3.Text = "時間: " + time;
            if (win == 0)
            {
                label5.Text = guessWord;
                result = MessageBox.Show("花費時間:" + time + "\n猜錯 " + wrong +"次", "You Win！", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    timer1.Enabled = false;
                    reset();
                    resetColor();
                }
            }
        }

        public void GuessWrong(int N)
        {
            wrong++;
            switch (N)
            {
                case 0:
                    button2.Visible = false;
                    button2.Enabled = false;
                    break;
                case 1:
                    button3.Visible = false;
                    button3.Enabled = false;
                    break;
                case 2:
                    button4.Visible = false;
                    button4.Enabled = false; 
                    break;
                case 3:
                    button5.Visible = false;
                    button5.Enabled = false; 
                    break;
                case 4:
                    button6.Visible = false;
                    button6.Enabled = false; 
                    break;
                case 5:
                    button7.Visible = false;
                    button7.Enabled = false; 
                    break;
                case 6:
                    button8.Visible = false;
                    button8.Enabled = false; 
                    break;
                case 7:
                    button9.Visible = false;
                    button9.Enabled = false; 
                    break;
                case 8:
                    button10.Visible = false;
                    button10.Enabled = false;
                    break;
                case 9:
                    button11.Visible = false;
                    button11.Enabled = false;
                    break;
                case 10:
                    button12.Visible = false;
                    button12.Enabled = false;
                    break;
                case 11:
                    button13.Visible = false;
                    button13.Enabled = false;
                    break;
                case 12:
                    button14.Visible = false;
                    button14.Enabled = false;
                    break;
                case 13:
                    button15.Visible = false;
                    button15.Enabled = false;
                    break;
                case 14:
                    button16.Visible = false;
                    button16.Enabled = false;
                    break;
                case 15:
                    button17.Visible = false;
                    button17.Enabled = false;
                    break;
                case 16:
                    button18.Visible = false;
                    button18.Enabled = false;
                    break;
                case 17:
                    button19.Visible = false;
                    button19.Enabled = false;
                    break;
                case 18:
                    button20.Visible = false;
                    button20.Enabled = false;
                    break;
                case 19:
                    button21.Visible = false;
                    button21.Enabled = false;
                    break;
                case 20:
                    button22.Visible = false;
                    button22.Enabled = false;
                    break;
                case 21:
                    button23.Visible = false;
                    button23.Enabled = false;
                    break;
                case 22:
                    button24.Visible = false;
                    button24.Enabled = false;
                    break;
                case 23:
                    button25.Visible = false;
                    button25.Enabled = false;
                    break;
                case 24:
                    button26.Visible = false;
                    button26.Enabled = false;
                    break;
                case 25:
                    button27.Visible = false;
                    button27.Enabled = false;
                    break;

            }
            label4.Text = "猜錯次數: " + wrong + "次";
            if(wrong == 6)
            {
                label5.Text = guessWord;
                result = MessageBox.Show("You Lose！", "", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    timer1.Enabled = false;
                    reset();
                    resetColor();
                }
            }
        }
        public int Capital(char c)
        {
            for(int i = 0; i < 11; i++)
            {
                visible[i] = '_';
            }
            int flag = 0;
            for(int i = 0; i < 52; i++)
            {
                if(i < 26)
                {
                    word[i] = Convert.ToChar('A' + i);
                }
                else
                {
                    word[i] = Convert.ToChar('a' + i - 26);
                }
            }
            for(int j = 0; j < 52; j++)
            {
                if(c != word[j])
                {
                    flag++;
                }
                if(c == word[j])
                {
                    flag = 0;
                    break;
                }
            }
            return flag;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel2.Enabled = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            for(int i = 0; i < 26; i++)
            {
                if(e.KeyValue == 65 + i)
                {
                    c = i;
                    if (Guess(c) == 1)
                    {
                        GuessRight(c);
                    }
                    else
                    {
                        GuessWrong(c);
                    }
                }
                else if(e.KeyValue == 65 + i + 26)
                {
                    c = i + 26;
                    if (Guess(c) == 1)
                    {
                        GuessRight(c);
                    }
                    else
                    {
                        GuessWrong(c);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            guessWord = textBox1.Text;
            invisible = "";
            for(int i = 0; i < guessWord.Length; i++)
            {
                invisible += "_ ";
            }
            if(guessWord != "")
            {
                button1.Enabled = true;
            }
        }

        private void button2_ControlAdded(object sender, ControlEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            c = 0;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c = 1;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            c = 2;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }        

        private void button5_Click(object sender, EventArgs e)
        {
            c = 3;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            c = 4;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            c = 5;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            c = 6;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            c = 7;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            c = 8;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            c = 9;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            c = 10;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            c = 11;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            c = 12;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            c = 13;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            c = 14;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            c = 15;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            c = 16;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            c = 17;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            c = 18;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            c = 19;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            c = 20;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            c = 21;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            c = 22;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            c = 23;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            c = 24;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label3.Text = "時間: " + time.ToString();
            time++;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            c = 25;
            if (Guess(c) == 1)
            {
                GuessRight(c);
            }
            else
            {
                GuessWrong(c);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            win = guessWord.Length;
            int isEng = 0;
            for (int i = 0; i < guessWord.Length; i++)
            {
                isEng += Capital(guessWord[i]);
            }
            if (isEng != 0)
            {
                MessageBox.Show("請輸入英文單字");
                textBox1.Text = "";
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel1.Enabled = false;
                panel2.Enabled = true;
                label5.Text = invisible;
                label3.Text = "時間: " + time;
                label4.Text = "猜錯次數: " + wrong + "次";
            }
        }
    }
}
