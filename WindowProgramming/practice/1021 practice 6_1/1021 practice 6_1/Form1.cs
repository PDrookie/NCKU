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

namespace _1021_practice_6_1
{
    public partial class Form1 : Form
    {
        SoundPlayer dong = new SoundPlayer(@"C:\Users\user\Desktop\C#\assets\6-1\audio\dong.wav");
        SoundPlayer ding = new SoundPlayer(@"C:\Users\user\Desktop\C#\assets\6-1\audio\ding.wav");
        SoundPlayer doo = new SoundPlayer(@"C:\Users\user\Desktop\C#\assets\6-1\audio\doo.wav");
        int mode;
        int state = 0;
        int count = 0;
        double i;
        Button[] light8 = new Button[8];
        Button[] light4 = new Button[8];
        public Form1()
        {
            InitializeComponent();
        }

        private void x(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value + " BPM";
            i = ((double)60 / trackBar1.Value) * 1000;
            timer1.Interval = (int)i;
            timer2.Interval = timer1.Interval / 2;
        }

        public void buttonArray(int soundmode)
        {            
            switch (soundmode)
            {
                case 4:
                    for(int i = 0; i < 4; i++)
                    {
                        Button buttons = new Button();
                        buttons.Size = new Size(40, 40);
                        buttons.Location = new Point(146 * i, 7);
                        light4[i] = buttons;
                    }
                    panel1.Controls.AddRange(light4);
                    break;
                case 8:
                    for (int i = 0; i < 8; i++)
                    {
                        Button buttons = new Button();
                        buttons.Size = new Size(40, 40);
                        buttons.Location = new Point(i * 62, 7);
                        light8[i] = buttons;
                    }
                    panel1.Controls.AddRange(light8);
                    break;
            }
            
        }

        public void lightchange(int where, int soundmode)
        {
            int last;
            if(soundmode == 4)
            {
                if (where >= 4)
                {
                    where -= 4;
                }
                if (where - 1 < 0 && soundmode == 4)
                {
                    last = 3;
                } 
                else
                {
                    last = where - 1;
                }
                light4[where].BackColor = Color.LightGreen;
                light4[last].BackColor = Color.FromArgb(224, 224, 224);
            }
            if (soundmode == 8)
            {
                if (where - 1 < 0 && soundmode == 8)
                {
                    last = 7;
                }
                else
                {
                    last = where - 1;
                }
                light8[where].BackColor = Color.LightGreen;
                light8[last].BackColor = Color.FromArgb(224, 224, 224);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Value = 120;
            label3.Text = Convert.ToString(trackBar1.Value) + " BPM";
            button1.Text = "Start";            
            buttonArray(4);
            comboBox1.Text = "4";
            radioButton1.Checked = true;
            i = ((double) 60 / trackBar1.Value) * 1000;
            timer1.Interval = (int)i;
            timer2.Interval = timer1.Interval / 2;
            mode = 1;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lightChange = Convert.ToInt32(comboBox1.Text);
            if(lightChange == 4)
            {
                panel1.Controls.Clear();
                buttonArray(4);
                if (radioButton1.Checked)
                {
                    mode = 1;
                }
                else if (radioButton2.Checked)
                {
                    mode = 3;
                }
            }
            else if (lightChange == 8)
            {
                panel1.Controls.Clear();                
                buttonArray(8);
                if (radioButton1.Checked)
                {
                    mode = 2;
                }
                else if(radioButton2.Checked)
                {
                    mode = 4;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Stop")
            {
                timer1.Enabled = false;
                button1.Text = "Start";
            }
            else if (button1.Text == "Start")
            {
                count = 0;
                timer1.Enabled = true;
                if (radioButton1.Checked  && Convert.ToInt32(comboBox1.Text) == 4)
                {                    
                    mode = 1;
                }
                else if (radioButton1.Checked && Convert.ToInt32(comboBox1.Text) == 8)
                {
                    mode = 2;
                }
                else if (radioButton2.Checked && Convert.ToInt32(comboBox1.Text) == 4)
                {
                    mode = 3;
                }
                else if (radioButton2.Checked && Convert.ToInt32(comboBox1.Text) == 8)
                {
                    mode = 4;
                }
                button1.Text = "Stop";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 1:                                             //單音、四拍       
                    if (count >= 4)
                    {
                        count -= 4;
                    }
                    if (state >= 4)
                    {
                        state -= 4;
                    }
                    if (count == 0)
                    {
                        ding.Play();
                    }
                    else
                    {
                        dong.Play();
                    }
                    lightchange(state, 4);
                    state++;
                    count++;
                    break;
                case 2:                                             //單音、八拍
                    if (count == 8)
                    {
                        count = 0;
                    }
                    if (state == 8)
                    {
                        state = 0;
                    }
                    if (count == 0)
                    {
                        ding.Play();
                    }
                    else
                    {
                        dong.Play();
                    }
                    lightchange(state, 8);
                    state++;
                    count++;
                    break;
                case 3:                                             //重音、四拍
                    if (count >= 4)
                    {
                        count -= 4;
                    }
                    if (state >= 4)
                    {
                        state -= 4;
                    }
                    if (count == 0)
                    {
                        ding.Play();                        
                    }
                    else
                    {
                        dong.Play();
                    }
                    timer2.Start();
                    lightchange(state, 4);
                    state++;
                    count++;
                    break;
                case 4:                                             //重音、八拍
                    if (count == 8)
                    {
                        count = 0;
                    }
                    if (state == 8)
                    {
                        state = 0;
                    }
                    if (count == 0)
                    {
                        ding.Play();
                    }
                    else
                    {                        
                        dong.Play();                        
                    }
                    timer2.Start();
                    lightchange(state, 8);
                    state++;
                    count++;
                    break;

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.Text) == 4)
            {
                mode = 1;
            }
            else if (Convert.ToInt32(comboBox1.Text) == 8)
            {
                mode = 2;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.Text) == 4)
            {
                mode = 3;
            }
            else if (Convert.ToInt32(comboBox1.Text) == 8)
            {
                mode = 4;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            doo.Play();            
        }
    }
}
