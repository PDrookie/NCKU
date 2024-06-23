using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace _1020_practice_6_2
{
    public partial class Form1 : Form
    {
        Button[] phoneBTN = new Button[15];
        string[] phoneNumber = new string[50];
        int index = 0, n = 0, flag = 0, saveN = 0;
        List<string> save = new List<string>();
        int row = 3, col = 5;
        int lastpos, breakpoint = 0;
        DialogResult result;
        public Form1()
        {
            InitializeComponent();
        }

        public void buttonArray()
        {
            for(int i = 0; i < col; i++)
            {
                for(int j = 0; j < row; j++)
                {
                    Button b = new Button();
                    b.Size = new Size(65, 65);
                    b.Location = new Point((j + 1) * 65 + 155, i * 65 + 80);
                    b.Font = new Font("新明細體", 22, FontStyle.Bold);
                    b.MouseDown += btn_click;
                    b.MouseUp += btn_leave;
                    phoneBTN[index] = b;                    
                    if (i < 3) phoneBTN[index].Text = Convert.ToString(index + 1);
                    phoneBTN[index].ImageList = imageList1;
                    index++;
                }
            }
            phoneBTN[9].Text = "*"; phoneBTN[10].Text = "0"; phoneBTN[11].Text = "#";
            phoneBTN[12].ImageIndex = 0; phoneBTN[13].ImageIndex = 1; phoneBTN[14].ImageIndex = 2;
            tabPage1.Controls.AddRange(phoneBTN);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                tabControl1.SelectedIndex = 1;
                for (int i = 0; i < save.Count; i++)
                {
                    richTextBox1.Text += save[i];
                    richTextBox1.Text += "\n";
                }
            }
            else if (tabControl1.SelectedTab == tabPage1)
            {
                tabControl1.SelectedIndex = 0;
                KeyPreview = true;
                richTextBox1.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            label2.Text = "Telephone";
            buttonArray();
        }

        public void recordphone()
        {
            string path = textBox1.Text;
            if(tabControl1.SelectedIndex == 1)
            {
                if(path == "")
                {
                    MessageBox.Show("Empty String", "", MessageBoxButtons.OK);
                }
                else if (!File.Exists(path))
                {
                    MessageBox.Show("Directory Not Found", "", MessageBoxButtons.OK);
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.Write(richTextBox1.Text);
                    }
                    MessageBox.Show("Done\n" + path, "", MessageBoxButtons.OK);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                if (e.Shift && e.KeyCode == Keys.D8)
                {
                    playmusic(10);

                }
                else if (e.Shift && e.KeyCode == Keys.D3)
                {
                    playmusic(12);
                }
                else if (e.KeyCode == Keys.D0)
                {
                    playmusic(11);
                }
                else if (e.KeyValue > 48 && e.KeyValue < 58)
                {
                    playmusic(e.KeyValue - 48);
                }
            }
        }

        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                if (e.Shift && e.KeyCode == Keys.D8)
                {
                    setPhoneNumber("*");
                    stopmusic(10);
                }
                else if (e.Shift && e.KeyCode == Keys.D3)
                {
                    setPhoneNumber("#");
                    stopmusic(12);
                }
                else if (e.KeyCode == Keys.Space)
                {
                    setPhoneNumber("delete");
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (phoneBTN[13].ImageIndex == 1)
                    {
                        phoneBTN[13].ImageIndex = 3;
                    }
                    else if (phoneBTN[13].ImageIndex == 3)
                    {
                        setPhoneNumber("save");
                        label2.Text = "Telephone";
                        phoneBTN[13].ImageIndex = 1;
                    }
                }
                else if (e.KeyCode == Keys.D0)
                {
                    setPhoneNumber(Convert.ToString(0));
                    stopmusic(11);
                }
                else if (e.KeyValue > 48 && e.KeyValue < 58)
                {
                    setPhoneNumber(Convert.ToString(e.KeyValue - 48));
                    stopmusic(e.KeyValue - 48);
                }
            }            
        }

        public void setPhoneNumber(string number)
        {            
            if (label2.Text == "Telephone" || number == "Telephone")
            {
                flag = 4;
            }
            else if (number == "delete" && label2.Text != "Telephone")
            {
                flag = 2;
            }
            else if(number == "save")
            {
                save.Add(label2.Text);
                flag = 4;
            }
            else
            {
                phoneNumber[n++] = number;
                flag = 3;
            }

            label2.Text = "";

            if (flag == 2)
            {
                phoneNumber[n - 1] = "";
                if (n > 0) n--;
            }
            else if (flag == 4)
            {
                if (number != "Telephone" && number != "save")
                {
                    phoneNumber[n++] = number;
                    flag = 3;
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        phoneNumber[i] = "";
                    }
                }                                
            }
            if(flag == 2 || flag == 3)
            {
                for (int i = 0; i < n; i++)
                {
                    label2.Text += phoneNumber[i];
                }
            }          
            
        }

        public void btn_click(object sendor, EventArgs e)
        {
            Button btn = (Button)sendor;
            if (btn.Text != "")
            {
                setPhoneNumber(btn.Text);
                if (btn.Text != "*" && btn.Text != "0" && btn.Text != "#")
                {
                    if (btn.Text != "*")
                    {
                        playmusic(9);
                    }
                    else if (btn.Text != "0")
                    {
                        playmusic(10);
                    }
                    else if (btn.Text != "#")
                    {
                        playmusic(11);
                    }
                    else 
                    {
                        playmusic(Convert.ToInt32(btn.Text));
                    }
                }
            }
            else if (btn == phoneBTN[12])
            {
                setPhoneNumber("Telephone");
            }
            else if (btn == phoneBTN[13])
            {
                if (btn.ImageIndex == 1)
                {
                    btn.ImageIndex = 3;
                }
                else if (btn.ImageIndex == 3)
                {
                    setPhoneNumber("save");
                    label2.Text = "Telephone";
                    btn.ImageIndex = 1;
                }

            }
            else if (btn == phoneBTN[14])
            {
                setPhoneNumber("delete");
            }
        }

        public void btn_leave(object sendor, EventArgs e)
        {
            Button btn = (Button)sendor;
            if (btn.Text != "")
            {
                if (btn.Text != "*" && btn.Text != "0" && btn.Text != "#")
                {
                    if (btn.Text != "*")
                    {
                        stopmusic(9);
                    }
                    else if (btn.Text != "0")
                    {
                        stopmusic(10);
                    }
                    else if (btn.Text != "#")
                    {
                        stopmusic(11);
                    }
                    else
                    {
                        stopmusic(Convert.ToInt32(btn.Text));
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recordphone();
        }

        public void playmusic(int where)
        {
            int Highf = 0, Lowf = 0;
            int p = 0;
            breakpoint = 0;
            for (int i = 0; i < col - 1; i++)
            {
                for(int j = 0; j < row; j++)
                {
                    p++;
                    if(p == where)
                    {
                        Highf = j + 1;
                        Lowf = i + 1;
                        breakpoint++;
                        break;
                    }
                }
                if (breakpoint > 0) break;
            }
            switch (Highf)
            {
                case 1:
                    axWindowsMediaPlayer1.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\1209.wav";
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    switch (Lowf)
                    {
                        case 1:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\697.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.play();
                            break;
                        case 2:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\770.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.play();
                            break;
                        case 3:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\852.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.play();
                            break;
                        case 4:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\941.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.play();
                            break;
                    }
                    break;
                case 2:
                    axWindowsMediaPlayer1.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\1336.wav";
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    switch (Lowf)
                    {
                        case 1:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\697.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.play();
                            break;
                        case 2:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\770.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.play();
                            break;
                        case 3:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\852.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.play();
                            break;
                        case 4:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\941.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.play();
                            break;
                    }
                    break;
                case 3:
                    axWindowsMediaPlayer1.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\1477.wav";
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    switch (Lowf)
                    {
                        case 1:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\697.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.play();
                            break;
                        case 2:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\770.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.play();
                            break;
                        case 3:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\852.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.play();
                            break;
                        case 4:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\941.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.play();
                            break;
                    }
                    break;
            }
            lastpos = where;
        }

        public void stopmusic(int where)
        {
            int Highf = 0, Lowf = 0;
            int p = 0;
            breakpoint = 0;
            for (int i = 0; i < col - 1; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    p++;
                    if (p == where)
                    {
                        Highf = j + 1;
                        Lowf = i + 1;
                        break;
                    }
                }
                if (breakpoint > 0) break;
            }
            switch (Highf)
            {
                case 1:
                    axWindowsMediaPlayer1.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\1209.wav";
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    switch (Lowf)
                    {
                        case 1:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\697.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.stop();
                            break;
                        case 2:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\770.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.stop();
                            break;
                        case 3:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\852.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.stop();
                            break;
                        case 4:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\941.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.stop();
                            break;
                    }
                    break;
                case 2:
                    axWindowsMediaPlayer1.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\1336.wav";
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    switch (Lowf)
                    {
                        case 1:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\697.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.stop();
                            break;
                        case 2:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\770.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.stop();
                            break;
                        case 3:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\852.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.stop();
                            break;
                        case 4:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\941.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.stop();
                            break;
                    }
                    break;
                case 3:
                    axWindowsMediaPlayer1.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\1477.wav";
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    switch (Lowf)
                    {
                        case 1:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\697.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.stop();
                            break;
                        case 2:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\770.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.stop();
                            break;
                        case 3:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\852.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.stop();
                            break;
                        case 4:
                            axWindowsMediaPlayer2.URL = @"C:\Users\user\Desktop\C#\assets\6-2\audio\941.wav";
                            axWindowsMediaPlayer2.Ctlcontrols.stop();
                            break;
                    }
                    break;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void tabPage1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
