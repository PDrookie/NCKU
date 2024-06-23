using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1014_practice_5_2
{
    public partial class Form1 : Form
    {
        int round = 1;
        int action;
        int index = 0;
        int num = 10;
        int times = 0;
        int up, down, right, left;
        int ready = 1, turn = 1, character, getHurt, damage;
        int[] pos = new int[6];
        int[] role = new int[7];
        int P1_Chess = 3, P2_Chess = 3;
        Button[] checkerboard = new Button[42];
        P1_warrior p1_Warrior = new P1_warrior();
        P1_magician p1_Magician = new P1_magician();
        P1_ranger p1_Ranger = new P1_ranger();
        P2_warrior p2_Warrior = new P2_warrior();
        P2_magician p2_Magician = new P2_magician();
        P2_ranger p2_Ranger = new P2_ranger();
        DialogResult result;
        public Form1()
        {
            InitializeComponent();
        }
        public void search(int who)
        {
            switch (who)
            {
                case 1:
                    for(int i = 0; i < 42; i++)
                    {
                        if(checkerboard[i].Text == "戰士" && checkerboard[i].BackColor == Color.LightBlue)
                        {
                            pos[0] = i;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < 42; i++)
                    {
                        if (checkerboard[i].Text == "法師" && checkerboard[i].BackColor == Color.LightBlue)
                        {
                            pos[1] = i;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < 42; i++)
                    {
                        if (checkerboard[i].Text == "遊俠" && checkerboard[i].BackColor == Color.LightBlue)
                        {
                            pos[2] = i;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < 42; i++)
                    {
                        if (checkerboard[i].Text == "戰士" && checkerboard[i].BackColor == Color.LightPink)
                        {
                            pos[3] = i;
                        }
                    }
                    break;
                case 5:
                    for (int i = 0; i < 42; i++)
                    {
                        if (checkerboard[i].Text == "法師" && checkerboard[i].BackColor == Color.LightPink)
                        {
                            pos[4] = i;
                        }
                    }
                    break;
                case 6:
                    for (int i = 0; i < 42; i++)
                    {
                        if (checkerboard[i].Text == "遊俠" && checkerboard[i].BackColor == Color.LightPink)
                        {
                            pos[5] = i;
                        }
                    }
                    break;
            }
        }

        public void showInformation(int who)
        {
            switch (who)
            {
                case 0:
                    P1_character.Text = "";
                    P1_information.Text = "";
                    P2_character.Text = "";
                    P2_information.Text = "";
                break;
                case 1:
                    P1_character.Text = "戰士";
                    P1_information.Text = "HP: " + p1_Warrior.hp + "\n"
                        + "MP: " + p1_Warrior.mp + "\n" + "ATK: " + p1_Warrior.atk + "\n"
                        + "ATK Range: " + p1_Warrior.attackrange + "\n" + "MOVE Range: " + p1_Warrior.moverange + "\n";
                break;
                case 2:
                    P1_character.Text = "法師";
                    P1_information.Text = "HP: " + p1_Magician.hp + "\n"
                        + "MP: " + p1_Magician.mp + "\n" + "ATK: " + p1_Magician.atk + "\n"
                        + "ATK Range: " + p1_Magician.attackrange + "\n" + "MOVE Range: " + p1_Magician.moverange + "\n";
                    break;
                case 3:
                    P1_character.Text = "遊俠";
                    P1_information.Text = "HP: " + p1_Ranger.hp + "\n"
                        + "MP: " + p1_Ranger.mp + "\n" + "ATK: " + p1_Ranger.atk + "\n"
                        + "ATK Range: " + p1_Ranger.attackrange + "\n" + "MOVE Range: " + p1_Ranger.moverange + "\n";
                    break;
                case 4:
                    P2_character.Text = "戰士";
                    P2_information.Text = "HP: " + p2_Warrior.hp + "\n"
                        + "MP: " + p2_Warrior.mp + "\n" + "ATK: " + p2_Warrior.atk + "\n"
                        + "ATK Range: " + p2_Warrior.attackrange + "\n" + "MOVE Range: " + p2_Warrior.moverange + "\n";
                    break;
                case 5:
                    P2_character.Text = "法師";
                    P2_information.Text = "HP: " + p2_Magician.hp + "\n"
                        + "MP: " + p2_Magician.mp + "\n" + "ATK: " + p2_Magician.atk + "\n"
                        + "ATK Range: " + p2_Magician.attackrange + "\n" + "MOVE Range: " + p2_Magician.moverange + "\n";
                    break;
                case 6:
                    P2_character.Text = "遊俠"; 
                    P2_information.Text = "HP: " + p2_Ranger.hp + "\n"
                        + "MP: " + p2_Ranger.mp + "\n" + "ATK: " + p2_Ranger.atk + "\n"
                        + "ATK Range: " + p2_Ranger.attackrange + "\n" + "MOVE Range: " + p2_Ranger.moverange + "\n";
                    break;
            }
        }
        public void taketurn(int p)
        {
            if(p == 1)
            {
                panel7.Visible = true;
                panel7.Enabled = true;
                P2_atk.Enabled = true;
                P2_move.Enabled = true;
                P2_skill.Enabled = true;
                P2_default.Enabled = true;
                panel9.Enabled = true;
                P2_end.Enabled = false;
                P2_information.Visible = true;
                P2_character.Visible = true;
                P1_character.Visible = false;
                P1_information.Visible = false;
                showInformation(role[round]);
                panel8.Enabled = false;
                turn = 2;
                label1.Visible = true;
                label1.Text = "P2 TURN";
            }
            else if(p == 2)
            {
                panel6.Enabled = true;
                panel8.Enabled = true;
                P1_atk.Enabled = true;
                P1_move.Enabled = true;
                P1_skill.Enabled = true;
                P1_default.Enabled = true;
                P1_end.Enabled = false;
                P1_character.Visible = true;
                P1_information.Visible = true;
                P2_character.Visible = false;
                P2_information.Visible = false;
                showInformation(role[round]);
                panel9.Enabled = false;
                turn = 1;
                label1.Visible = true;
                label1.Text = "P1 TURN";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Enabled = true;
            panel2.Visible = true;
            panel2.Enabled = true;
            panel3.Visible = true;
            panel3.Enabled = true;
            panel5.Enabled = false;
            button1.Visible = false;
            button1.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            for(int i = 0; i < 42; i++)
            {
                if (i < 21)
                {
                    checkerboard[i].Enabled = true;
                }
                else
                    checkerboard[i].Enabled = false;
            }
        }


        public void buttonArray()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Button c = new Button();
                    c.Size = new Size(50, 50);
                    c.Location = new Point(i * 50, j * 50);
                    checkerboard[index++] = c;
                    c.Click += btn_click;
                    panel1.Controls.Add(c);
                }
            }
            for(int i = 1; i < 7; i++)
            {
                role[i] = i;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonArray();                        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {        
            label2.Text = num.ToString();
            if (num == 0 && times == 0)
            {
                if (button2.Enabled)
                {
                    for(int i = 0; i < 7; i++)
                    {
                        if(checkerboard[i].Text == "")
                        {
                            checkerboard[i].Text = "戰士";
                            checkerboard[i].BackColor = Color.LightBlue;
                            break;
                        }
                    }                    
                }
                if (button3.Enabled)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (checkerboard[i].Text == "")
                        {
                            checkerboard[i].Text = "法師";
                            checkerboard[i].BackColor = Color.LightBlue;
                            break;
                        }
                    }
                }
                if (button4.Enabled)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (checkerboard[i].Text == "")
                        {
                            checkerboard[i].Text = "遊俠";
                            checkerboard[i].BackColor = Color.LightBlue;
                            break;
                        }
                    }
                }
                ready = 4;
                for (int i = 0; i < 42; i++)
                {
                    if (i >= 21)
                        checkerboard[i].Enabled = true;
                    else
                        checkerboard[i].Enabled = false;
                }
                panel4.Enabled = false;
                panel5.Enabled = true;
                times++;
                num += 10;
            }
            else if(num == 0 && times == 1)
            {
                if (button5.Enabled)
                {
                    for (int i = 35; i < 42; i++)
                    {
                        if (checkerboard[i].Text == "")
                        {
                            checkerboard[i].Text = "戰士";
                            checkerboard[i].BackColor = Color.LightPink;
                            break;
                        }
                    }
                }
                if (button7.Enabled)
                {
                    for (int i = 35; i < 42; i++)
                    {
                        if (checkerboard[i].Text == "")
                        {
                            checkerboard[i].Text = "法師";
                            checkerboard[i].BackColor = Color.LightPink;
                            break;
                        }
                    }
                }
                if (button6.Enabled)
                {
                    for (int i = 35; i < 42; i++)
                    {
                        if (checkerboard[i].Text == "")
                        {
                            checkerboard[i].Text = "遊俠";
                            checkerboard[i].BackColor = Color.LightPink;
                            break;
                        }
                    }
                }
                panel4.Visible = false;
                panel4.Enabled = false;
                panel5.Visible = false;
                panel5.Enabled = false;
                label2.Visible = false;
                timer1.Enabled = false;
                panel6.Visible = true;
                panel6.Enabled = true;
                panel7.Enabled = true;
                panel7.Visible = true;
                P2_character.Visible = false;
                P2_information.Visible = false;
                panel9.Enabled = false;
                panel9.Visible = true;
                P1_end.Enabled = false;
                for(int i = 1; i <= 6; i++)
                {
                    search(i);
                }
                for(int i = 0; i < 42; i++)
                {
                    checkerboard[i].Enabled = true;
                }
                showInformation(role[round]);
                label1.Text = "P1 Turn";
                ready = 0;
            }
            num--;
    }

        private void button2_Click(object sender, EventArgs e)
        {
            ready = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ready = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ready = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ready = 4;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ready = 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ready = 6;
        }

        public void btn_click(object sendor, EventArgs e)
        {
            Button btn = (Button)sendor;
            switch (ready)
            {
                case 0:
                    break;
                case 1:
                    btn.BackColor = Color.LightBlue;
                    btn.Text = "戰士";
                    button2.Enabled = false;
                    search(1);
                    ready = 0;
                    break;
                case 2:
                    btn.BackColor = Color.LightBlue;
                    btn.Text = "法師";
                    button3.Enabled = false;
                    search(2);
                    ready = 0;
                    break;
                case 3:
                    btn.BackColor = Color.LightBlue;
                    btn.Text = "遊俠";
                    button4.Enabled = false;
                    search(3);
                    ready = 0;
                    break;
                case 4:
                    btn.BackColor = Color.LightPink;
                    btn.Text = "戰士";
                    button5.Enabled = false;
                    search(4);
                    ready = 0;
                    break;
                case 5:
                    btn.BackColor = Color.LightPink;
                    btn.Text = "法師";
                    button7.Enabled = false;
                    search(5);
                    ready = 0;
                    break;
                case 6:
                    btn.BackColor = Color.LightPink;
                    btn.Text = "遊俠";
                    button6.Enabled = false;
                    search(6);
                    ready = 0;
                    break;
            }
            if (action == 1)
            {
                switch (role[round])
                {
                    case 1:
                        damage = p1_Warrior.atk;
                        for(int i = 1; i <= p1_Warrior.attackrange; i++)
                        {
                            if (pos[0] - 7 * i > 0)//up
                            {
                                left = pos[0] - 7 * i;
                            }
                            else
                            {
                                left = 0;
                            }
                            if (pos[0] + 7 * i < 42)//down
                            {
                                right = pos[0] + 7 * i;
                            }
                            else
                            {
                                right = 41;
                            }
                            if (pos[0] + i < 42)//right
                            {
                                down = pos[0] + i;
                            }
                            else
                            {
                                down = 41;
                            }
                            if (pos[0] - i > 0)//left
                            {
                                up = pos[0] - i;
                            }
                            else
                            {
                                up = 0;
                            }
                            if (btn == checkerboard[down])//find down
                            {
                                if(btn.Text != "")
                                {
                                    character = down;
                                }
                            }
                            else if (btn == checkerboard[right])//find right
                            {
                                if (btn.Text != "")
                                {
                                    character = right;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[left])//find left
                            {
                                if (btn.Text != "")
                                {
                                    character = left;
                                    break;

                                }
                            }
                            else if (btn == checkerboard[up])//find up
                            {
                                if (btn.Text != "")
                                {
                                    character = up;
                                    break;
                                }
                            }
                            else if(i == p1_Warrior.attackrange)
                            {
                                result = MessageBox.Show("超出攻擊範圍", "", MessageBoxButtons.OK);
                                if(result == DialogResult.OK)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case 2:
                        damage = p1_Magician.atk;
                        for (int i = 1; i <= p1_Magician.attackrange; i++)
                        {
                            if (pos[1] - 7 * i > 0)//up
                            {
                                left = pos[1] - 7 * i;
                            }
                            else
                            {
                                left = 0;
                            }
                            if (pos[1] + 7 * i < 42)//down
                            {
                                right = pos[1] + 7 * i;
                            }
                            else
                            {
                                right = 41;
                            }
                            if (pos[1] + i < 42)//right
                            {
                                down = pos[1] + i;
                            }
                            else
                            {
                                down = 41;
                            }
                            if (pos[1] - i > 0)//left
                            {
                                up = pos[1] - i;
                            }
                            else
                            {
                                up = 0;
                            }
                            if (btn == checkerboard[down])//find down
                            {
                                if (btn.Text != "")
                                {
                                    character = down;
                                }
                            }
                            else if (btn == checkerboard[right])//find right
                            {
                                if (btn.Text != "")
                                {
                                    character = right;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[left])//find left
                            {
                                if (btn.Text != "")
                                {
                                    character = left;
                                    break;

                                }
                            }
                            else if (btn == checkerboard[up])//find up
                            {
                                if (btn.Text != "")
                                {
                                    character = up;
                                    break;
                                }
                            }
                            else if (i == p1_Magician.attackrange)
                            {
                                result = MessageBox.Show("超出攻擊範圍", "", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case 3:
                        damage = p1_Ranger.atk;
                        for (int i = 1; i <= p1_Ranger.attackrange; i++)
                        {
                            if (pos[2] - 7 * i > 0)//up
                            {
                                left = pos[2] - 7 * i;
                            }
                            else
                            {
                                left = 0;
                            }
                            if (pos[2] + 7 * i < 42)//down
                            {
                                right = pos[2] + 7 * i;
                            }
                            else
                            {
                                right = 41;
                            }
                            if (pos[2] + i < 42)//right
                            {
                                down = pos[2] + i;
                            }
                            else
                            {
                                down = 41;
                            }
                            if (pos[2] - i > 0)//left
                            {
                                up = pos[2] - i;
                            }
                            else
                            {
                                up = 0;
                            }
                            if (btn == checkerboard[down])//find down
                            {
                                if (btn.Text != "")
                                {
                                    character = down;
                                }
                            }
                            else if (btn == checkerboard[right])//find right
                            {
                                if (btn.Text != "")
                                {
                                    character = right;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[left])//find left
                            {
                                if (btn.Text != "")
                                {
                                    character = left;
                                    break;

                                }
                            }
                            else if (btn == checkerboard[up])//find up
                            {
                                if (btn.Text != "")
                                {
                                    character = up;
                                    break;
                                }
                            }
                            else if (i == p1_Ranger.attackrange)
                            {
                                result = MessageBox.Show("超出攻擊範圍", "", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case 4:
                        damage = p2_Warrior.atk;
                        for (int i = 1; i <= p2_Warrior.attackrange; i++)
                        {
                            if (pos[3] - 7 * i > 0)//up
                            {
                                left = pos[3] - 7 * i;
                            }
                            else
                            {
                                left = 0;
                            }
                            if (pos[3] + 7 * i < 42)//down
                            {
                                right = pos[3] + 7 * i;
                            }
                            else
                            {
                                right = 41;
                            }
                            if (pos[3] + i < 42)//right
                            {
                                down = pos[3] + i;
                            }
                            else
                            {
                                down = 41;
                            }
                            if (pos[3] - i > 0)//left
                            {
                                up = pos[3] - i;
                            }
                            else
                            {
                                up = 0;
                            }
                            if (btn == checkerboard[down])//find down
                            {
                                if (btn.Text != "")
                                {
                                    character = down;
                                }
                            }
                            else if (btn == checkerboard[right])//find right
                            {
                                if (btn.Text != "")
                                {
                                    character = right;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[left])//find left
                            {
                                if (btn.Text != "")
                                {
                                    character = left;
                                    break;

                                }
                            }
                            else if (btn == checkerboard[up])//find up
                            {
                                if (btn.Text != "")
                                {
                                    character = up;
                                    break;
                                }
                            }
                            else if (i == p2_Warrior.attackrange)
                            {
                                result = MessageBox.Show("超出攻擊範圍", "", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case 5:
                        damage = p2_Magician.atk;
                        for (int i = 1; i <= p2_Magician.attackrange; i++)
                        {
                            if (pos[4] - 7 * i > 0)//up
                            {
                                left = pos[4] - 7 * i;
                            }
                            else
                            {
                                left = 0;
                            }
                            if (pos[4] + 7 * i < 42)//down
                            {
                                right = pos[4] + 7 * i;
                            }
                            else
                            {
                                right = 41;
                            }
                            if (pos[4] + i < 42)//right
                            {
                                down = pos[4] + i;
                            }
                            else
                            {
                                down = 41;
                            }
                            if (pos[4] - i > 0)//left
                            {
                                up = pos[4] - i;
                            }
                            else
                            {
                                up = 0;
                            }
                            if (btn == checkerboard[down])//find down
                            {
                                if (btn.Text != "")
                                {
                                    character = down;
                                }
                            }
                            else if (btn == checkerboard[right])//find right
                            {
                                if (btn.Text != "")
                                {
                                    character = right;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[left])//find left
                            {
                                if (btn.Text != "")
                                {
                                    character = left;
                                    break;

                                }
                            }
                            else if (btn == checkerboard[up])//find up
                            {
                                if (btn.Text != "")
                                {
                                    character = up;
                                    break;
                                }
                            }
                            else if (i == p2_Magician.attackrange)
                            {
                                result = MessageBox.Show("超出攻擊範圍", "", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case 6:
                        damage = p2_Ranger.atk;
                        for (int i = 1; i <= p2_Ranger.attackrange; i++)
                        {
                            if (pos[5] - 7 * i > 0)//up
                            {
                                left = pos[5] - 7 * i;
                            }
                            else
                            {
                                left = 0;
                            }
                            if (pos[5] + 7 * i < 42)//down
                            {
                                right = pos[5] + 7 * i;
                            }
                            else
                            {
                                right = 41;
                            }
                            if (pos[5] + i < 42)//right
                            {
                                down = pos[5] + i;
                            }
                            else
                            {
                                down = 41;
                            }
                            if (pos[5] - i > 0)//left
                            {
                                up = pos[5] - i;
                            }
                            else
                            {
                                up = 0;
                            }
                            if (btn == checkerboard[down])//find down
                            {
                                if (btn.Text != "")
                                {
                                    character = down;
                                }
                            }
                            else if (btn == checkerboard[right])//find right
                            {
                                if (btn.Text != "")
                                {
                                    character = right;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[left])//find left
                            {
                                if (btn.Text != "")
                                {
                                    character = left;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[up])//find up
                            {
                                if (btn.Text != "")
                                {
                                    character = up;
                                    break;
                                }
                            }
                            else if (i == p2_Ranger.attackrange)
                            {
                                result = MessageBox.Show("超出攻擊範圍", "", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                }
                for(int j = 0; j < 6; j++)
                {
                    if(character == pos[j])
                    {
                        getHurt = j + 1;
                    }
                }
                switch (getHurt)
                {
                    case 1:
                        p1_Warrior.hp -= damage;
                        showInformation(1);
                        if (p1_Warrior.hp == 0)
                        {
                            role[0] = 0;
                            P1_Chess--;
                            checkerboard[pos[0]].BackColor = Color.FromArgb(224, 224, 224);
                            checkerboard[pos[0]].Text = "";
                        }
                        round++;
                        showInformation(0);
                        showInformation(role[round]);
                        break;
                    case 2:
                        p1_Magician.hp -= damage;
                        showInformation(2);
                        if (p1_Magician.hp == 0)
                        {
                            role[1] = 0;
                            P1_Chess--;
                            checkerboard[pos[1]].BackColor = Color.FromArgb(224, 224, 224);
                            checkerboard[pos[1]].Text = "";
                        }
                        round++;
                        showInformation(0);
                        showInformation(role[round]);
                        break;
                    case 3:
                        p1_Ranger.hp -= damage;
                        showInformation(3);
                        if (p1_Ranger.hp == 0)
                        {
                            role[2] = 0;
                            P1_Chess--;
                            checkerboard[pos[2]].BackColor = Color.FromArgb(224, 224, 224);
                            checkerboard[pos[2]].Text = "";
                        }
                        round++;
                        showInformation(0);
                        showInformation(role[round]);
                        break;
                    case 4:
                        p2_Warrior.hp -= damage;
                        showInformation(4);
                        if (p2_Warrior.hp == 0)
                        {
                            role[3] = 0;
                            P2_Chess--;
                            checkerboard[pos[3]].BackColor = Color.FromArgb(224, 224, 224);
                            checkerboard[pos[3]].Text = "";
                        }
                        round++;
                        showInformation(0);
                        showInformation(role[round]);
                        break;
                    case 5:
                        p2_Magician.hp -= damage;
                        showInformation(5);
                        if (p2_Magician.hp == 0)
                        {
                            role[4] = 0;
                            P2_Chess--;
                            checkerboard[pos[4]].BackColor = Color.FromArgb(224, 224, 224);
                            checkerboard[pos[4]].Text = "";
                        }
                        round++;
                        showInformation(0);
                        showInformation(role[round]);
                        break;
                    case 6:
                        p2_Ranger.hp -= damage;
                        showInformation(6);
                        if (p2_Ranger.hp == 0)
                        {
                            role[5] = 0;
                            P2_Chess--;
                            checkerboard[pos[5]].BackColor = Color.FromArgb(224, 224, 224);
                            checkerboard[pos[5]].Text = "";
                        }
                        round++;
                        showInformation(0);
                        showInformation(role[round]);
                        break;
                }
            }
            else if (action == 2)
            {
                switch (role[round])
                {
                    case 1:
                        for (int i = 1; i <= p1_Warrior.moverange; i++)
                        {                            
                            if(pos[0] - 7 * i > 0)//up
                            {
                                left = pos[0] - 7 * i;
                            }
                            else
                            {
                                left = 0;
                            }
                            if (pos[0] + 7 * i < 42)//down
                            {
                                right = pos[0] + 7 * i;
                            }
                            else
                            {
                                right = 41;
                            }
                            if (pos[0] + i < 42)//right
                            {
                                down = pos[0] + i;
                            }
                            else
                            {
                                down = 41;
                            }
                            if (pos[0] - i > 0)//left
                            {
                                up = pos[0] - i;
                            }
                            else
                            {
                                up = 0;
                            }
                            if (btn == checkerboard[down])//find down
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[0]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[0]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "戰士";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[right])//find right
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[0]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[0]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "戰士";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[left])//find left
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[0]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[0]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "戰士";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[up])//find up
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[0]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[0]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "戰士";
                                    round++;
                                    break;
                                }
                            }
                            else if(i == p1_Warrior.moverange)
                            {
                                result = MessageBox.Show("超出移動範圍", "", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    break;
                                }
                            }
                        }
                        showInformation(role[round]);
                        break;
                    case 2:
                        for (int i = 1; i <= p1_Magician.moverange; i++)
                        {
                            if (pos[1] - 7 * i > 0)//up
                            {
                                left = pos[1] - 7 * i;
                            }
                            else
                            {
                                left = 0;
                            }
                            if (pos[1] + 7 * i < 42)//down
                            {
                                right = pos[1] + 7 * i;
                            }
                            else
                            {
                                right = 41;
                            }
                            if (pos[1] + i < 42)//right
                            {
                                down = pos[1] + i;
                            }
                            else
                            {
                                down = 41;
                            }
                            if (pos[1] - i > 0)//left
                            {
                                up = pos[1] - i;
                            }
                            else
                            {
                                up = 0;
                            }
                            if (btn == checkerboard[down])//find down
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[1]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[1]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "法師";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[right])//find right
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[1]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[1]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "法師";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[left])//find left
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[1]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[1]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "法師";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[up])//find up
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[1]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[1]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "法師";
                                    round++;
                                    break;
                                }
                            }
                            else if(i == p1_Magician.moverange)
                            {
                                result = MessageBox.Show("超出移動範圍", "", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    break;
                                }
                            }

                        }
                        showInformation(role[round]);
                        break;
                    case 3:
                        for (int i = 1; i <= p1_Ranger.moverange; i++)
                        {
                            if (pos[2] - 7 * i > 0)//up
                            {
                                left = pos[2] - 7 * i;
                            }
                            else
                            {
                                left = 0;
                            }
                            if (pos[2] + 7 * i < 42)//down
                            {
                                right = pos[2] + 7 * i;
                            }
                            else
                            {
                                right = 41;
                            }
                            if (pos[2] + i < 42)//right
                            {
                                down = pos[2] + i;
                            }
                            else
                            {
                                down = 41;
                            }
                            if (pos[2] - i > 0)//left
                            {
                                up = pos[2] - i;
                            }
                            else
                            {
                                up = 0;
                            }
                            if (btn == checkerboard[down])//find down
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[2]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[2]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "遊俠";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[right])//find right
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[2]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[2]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "遊俠";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[left])//find left
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[2]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[2]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "遊俠";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[up])//find up
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[2]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[2]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "遊俠";
                                    round++;
                                    break;
                                }
                            }
                            else if(i == p1_Ranger.moverange)
                            {
                                result = MessageBox.Show("超出移動範圍", "", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    break;
                                }
                            }
                        }
                        showInformation(role[round]);
                        break;
                    case 4:
                        for (int i = 1; i <= p2_Warrior.moverange; i++)
                        {
                            if (pos[3] - 7 * i > 0)//up
                            {
                                left = pos[3] - 7 * i;
                            }
                            else
                            {
                                left = 0;
                            }
                            if (pos[3] + 7 * i < 42)//down
                            {
                                right = pos[3] + 7 * i;
                            }
                            else
                            {
                                right = 41;
                            }
                            if (pos[3] + i < 42)//right
                            {
                                down = pos[3] + i;
                            }
                            else
                            {
                                down = 41;
                            }
                            if (pos[3] - i > 0)//left
                            {
                                up = pos[3] - i;
                            }
                            else
                            {
                                up = 0;
                            }
                            if (btn == checkerboard[down])//find down
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[3]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[3]].Text = "";
                                    btn.BackColor = Color.LightPink;
                                    btn.Text = "戰士";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[right])//find right
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[3]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[3]].Text = "";
                                    btn.BackColor = Color.LightPink;
                                    btn.Text = "戰士";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[left])//find left
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[3]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[3]].Text = "";
                                    btn.BackColor = Color.LightPink;
                                    btn.Text = "戰士";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[up])//find up
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[3]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[3]].Text = "";
                                    btn.BackColor = Color.LightBlue;
                                    btn.Text = "戰士";
                                    round++;
                                    break;
                                }
                            }
                            else if(p2_Warrior.moverange == i)
                            {
                                result = MessageBox.Show("超出移動範圍", "", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    break;
                                }
                            }

                        }
                        showInformation(role[round]);
                        break;
                    case 5:
                        for (int i = 1; i <= p2_Magician.moverange; i++)
                        {
                            if (pos[4] - 7 * i > 0)//up
                            {
                                left = pos[4] - 7 * i;
                            }
                            else
                            {
                                left = 0;
                            }
                            if (pos[4] + 7 * i < 42)//down
                            {
                                right = pos[4] + 7 * i;
                            }
                            else
                            {
                                right = 41;
                            }
                            if (pos[4] + i < 42)//right
                            {
                                down = pos[4] + i;
                            }
                            else
                            {
                                down = 41;
                            }
                            if (pos[4] - i > 0)//left
                            {
                                up = pos[4] - i;
                            }
                            else
                            {
                                up = 0;
                            }
                            if (btn == checkerboard[down])//find down
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[4]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[4]].Text = "";
                                    btn.BackColor = Color.LightPink;
                                    btn.Text = "法師";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[right])//find right
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[4]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[4]].Text = "";
                                    btn.BackColor = Color.LightPink;
                                    btn.Text = "法師";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[left])//find left
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[4]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[4]].Text = "";
                                    btn.BackColor = Color.LightPink;
                                    btn.Text = "法師";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[up])//find up
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[4]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[4]].Text = "";
                                    btn.BackColor = Color.LightPink;
                                    btn.Text = "法師";
                                    round++;
                                    break;
                                }
                            }
                            else if(i == p2_Magician.moverange)
                            {
                                result = MessageBox.Show("超出移動範圍", "", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    break;
                                }
                            }

                        }
                        showInformation(role[round]);
                        break;
                    case 6:
                        for (int i = 1; i <= p2_Ranger.moverange; i++)
                        {
                            if (pos[5] - 7 * i > 0)//up
                            {
                                left = pos[5] - 7 * i;
                            }
                            else
                            {
                                left = 0;
                            }
                            if (pos[5] + 7 * i < 42)//down
                            {
                                right = pos[5] + 7 * i;
                            }
                            else
                            {
                                right = 41;
                            }
                            if (pos[5] + i < 42)//right
                            {
                                down = pos[5] + i;
                            }
                            else
                            {
                                down = 41;
                            }
                            if (pos[5] - i > 0)//left
                            {
                                up = pos[5] - i;
                            }
                            else
                            {
                                up = 0;
                            }
                            if (btn == checkerboard[down])//find down
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[5]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[5]].Text = "";
                                    btn.BackColor = Color.LightPink;
                                    btn.Text = "遊俠";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[right])//find right
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[5]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[5]].Text = "";
                                    btn.BackColor = Color.LightPink;
                                    btn.Text = "遊俠";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[left])//find left
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[5]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[5]].Text = "";
                                    btn.BackColor = Color.LightPink;
                                    btn.Text = "遊俠";
                                    round++;
                                    break;
                                }
                            }
                            else if (btn == checkerboard[up])//find up
                            {
                                if (btn.Text == "")
                                {
                                    checkerboard[pos[5]].BackColor = Color.FromArgb(224, 224, 224);
                                    checkerboard[pos[5]].Text = "";
                                    btn.BackColor = Color.LightPink;
                                    btn.Text = "遊俠";
                                    round++;
                                    break;
                                }
                            }
                            else if(p2_Ranger.moverange == i)
                            {
                                result = MessageBox.Show("超出移動範圍", "", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    break;
                                }
                            }
                        }
                        showInformation(role[round]);
                        break;
                }
            }
            else if (action == 3)
            {
                switch (role[round])
                {
                    case 1:
                        if (p1_Warrior.mp - 10 > 0)
                        {
                            damage = p1_Warrior.chop();
                            p1_Warrior.mp -= 10;
                            for (int i = 1; i <= p1_Warrior.attackrange; i++)
                            {
                                if (pos[0] - 7 * i > 0)//up
                                {
                                    left = pos[0] - 7 * i;
                                }
                                else
                                {
                                    left = 0;
                                }
                                if (pos[0] + 7 * i < 42)//down
                                {
                                    right = pos[0] + 7 * i;
                                }
                                else
                                {
                                    right = 41;
                                }
                                if (pos[0] + i < 42)//right
                                {
                                    down = pos[0] + i;
                                }
                                else
                                {
                                    down = 41;
                                }
                                if (pos[0] - i > 0)//left
                                {
                                    up = pos[0] - i;
                                }
                                else
                                {
                                    up = 0;
                                }
                                if (btn == checkerboard[down])//find down
                                {
                                    if (btn.Text != "")
                                    {
                                        character = down;
                                    }
                                }
                                else if (btn == checkerboard[right])//find right
                                {
                                    if (btn.Text != "")
                                    {
                                        character = right;
                                        break;
                                    }
                                }
                                else if (btn == checkerboard[left])//find left
                                {
                                    if (btn.Text != "")
                                    {
                                        character = left;
                                        break;

                                    }
                                }
                                else if (btn == checkerboard[up])//find up
                                {
                                    if (btn.Text != "")
                                    {
                                        character = up;
                                        break;
                                    }
                                }
                                else if (i == p1_Warrior.attackrange)
                                {
                                    result = MessageBox.Show("超出攻擊範圍", "", MessageBoxButtons.OK);
                                    if (result == DialogResult.OK)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    case 2:
                        if (p1_Magician.mp - 10 > 0)
                        {
                            p1_Magician.mp -= 10;
                            damage = p1_Magician.magic();
                            for (int i = 1; i <= p1_Magician.attackrange; i++)
                            {
                                if (pos[1] - 7 * i > 0)//up
                                {
                                    left = pos[1] - 7 * i;
                                }
                                else
                                {
                                    left = 0;
                                }
                                if (pos[1] + 7 * i < 42)//down
                                {
                                    right = pos[1] + 7 * i;
                                }
                                else
                                {
                                    right = 41;
                                }
                                if (pos[1] + i < 42)//right
                                {
                                    down = pos[1] + i;
                                }
                                else
                                {
                                    down = 41;
                                }
                                if (pos[1] - i > 0)//left
                                {
                                    up = pos[1] - i;
                                }
                                else
                                {
                                    up = 0;
                                }
                                if (btn == checkerboard[down])//find down
                                {
                                    if (btn.Text != "")
                                    {
                                        character = down;
                                    }
                                }
                                else if (btn == checkerboard[right])//find right
                                {
                                    if (btn.Text != "")
                                    {
                                        character = right;
                                        break;
                                    }
                                }
                                else if (btn == checkerboard[left])//find left
                                {
                                    if (btn.Text != "")
                                    {
                                        character = left;
                                        break;

                                    }
                                }
                                else if (btn == checkerboard[up])//find up
                                {
                                    if (btn.Text != "")
                                    {
                                        character = up;
                                        break;
                                    }
                                }
                                else if (i == p1_Magician.attackrange)
                                {
                                    result = MessageBox.Show("超出攻擊範圍", "", MessageBoxButtons.OK);
                                    if (result == DialogResult.OK)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    case 3:
                        if (p1_Ranger.mp - 10 > 0)
                        {
                            p1_Ranger.mp -= 10;
                            p1_Ranger.arrow();
                            damage = p1_Ranger.atk;
                            for (int i = 1; i <= p1_Ranger.attackrange; i++)
                            {
                                if (pos[2] - 7 * i > 0)//up
                                {
                                    left = pos[2] - 7 * i;
                                }
                                else
                                {
                                    left = 0;
                                }
                                if (pos[2] + 7 * i < 42)//down
                                {
                                    right = pos[2] + 7 * i;
                                }
                                else
                                {
                                    right = 41;
                                }
                                if (pos[2] + i < 42)//right
                                {
                                    down = pos[2] + i;
                                }
                                else
                                {
                                    down = 41;
                                }
                                if (pos[2] - i > 0)//left
                                {
                                    up = pos[2] - i;
                                }
                                else
                                {
                                    up = 0;
                                }
                                if (btn == checkerboard[down])//find down
                                {
                                    if (btn.Text != "")
                                    {
                                        character = down;
                                    }
                                }
                                else if (btn == checkerboard[right])//find right
                                {
                                    if (btn.Text != "")
                                    {
                                        character = right;
                                        break;
                                    }
                                }
                                else if (btn == checkerboard[left])//find left
                                {
                                    if (btn.Text != "")
                                    {
                                        character = left;
                                        break;

                                    }
                                }
                                else if (btn == checkerboard[up])//find up
                                {
                                    if (btn.Text != "")
                                    {
                                        character = up;
                                        break;
                                    }
                                }
                                else if (i == p1_Ranger.attackrange)
                                {
                                    result = MessageBox.Show("超出攻擊範圍", "", MessageBoxButtons.OK);
                                    if (result == DialogResult.OK)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    case 4:
                        if (p2_Warrior.mp - 10 > 0)
                        {
                            p2_Warrior.mp -= 10;
                            damage = p2_Warrior.chop();
                            for (int i = 1; i <= p2_Warrior.attackrange; i++)
                            {
                                if (pos[3] - 7 * i > 0)//up
                                {
                                    left = pos[3] - 7 * i;
                                }
                                else
                                {
                                    left = 0;
                                }
                                if (pos[3] + 7 * i < 42)//down
                                {
                                    right = pos[3] + 7 * i;
                                }
                                else
                                {
                                    right = 41;
                                }
                                if (pos[3] + i < 42)//right
                                {
                                    down = pos[3] + i;
                                }
                                else
                                {
                                    down = 41;
                                }
                                if (pos[3] - i > 0)//left
                                {
                                    up = pos[3] - i;
                                }
                                else
                                {
                                    up = 0;
                                }
                                if (btn == checkerboard[down])//find down
                                {
                                    if (btn.Text != "")
                                    {
                                        character = down;
                                    }
                                }
                                else if (btn == checkerboard[right])//find right
                                {
                                    if (btn.Text != "")
                                    {
                                        character = right;
                                        break;
                                    }
                                }
                                else if (btn == checkerboard[left])//find left
                                {
                                    if (btn.Text != "")
                                    {
                                        character = left;
                                        break;

                                    }
                                }
                                else if (btn == checkerboard[up])//find up
                                {
                                    if (btn.Text != "")
                                    {
                                        character = up;
                                        break;
                                    }
                                }
                                else if (i == p2_Warrior.attackrange)
                                {
                                    result = MessageBox.Show("超出攻擊範圍", "", MessageBoxButtons.OK);
                                    if (result == DialogResult.OK)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    case 5:
                        if (p2_Magician.mp - 10 > 0)
                        {
                            p2_Magician.mp -= 10;
                            damage = p2_Magician.magic();
                            for (int i = 1; i <= p2_Magician.attackrange; i++)
                            {
                                if (pos[4] - 7 * i > 0)//up
                                {
                                    left = pos[4] - 7 * i;
                                }
                                else
                                {
                                    left = 0;
                                }
                                if (pos[4] + 7 * i < 42)//down
                                {
                                    right = pos[4] + 7 * i;
                                }
                                else
                                {
                                    right = 41;
                                }
                                if (pos[4] + i < 42)//right
                                {
                                    down = pos[4] + i;
                                }
                                else
                                {
                                    down = 41;
                                }
                                if (pos[4] - i > 0)//left
                                {
                                    up = pos[4] - i;
                                }
                                else
                                {
                                    up = 0;
                                }
                                if (btn == checkerboard[down])//find down
                                {
                                    if (btn.Text != "")
                                    {
                                        character = down;
                                    }
                                }
                                else if (btn == checkerboard[right])//find right
                                {
                                    if (btn.Text != "")
                                    {
                                        character = right;
                                        break;
                                    }
                                }
                                else if (btn == checkerboard[left])//find left
                                {
                                    if (btn.Text != "")
                                    {
                                        character = left;
                                        break;

                                    }
                                }
                                else if (btn == checkerboard[up])//find up
                                {
                                    if (btn.Text != "")
                                    {
                                        character = up;
                                        break;
                                    }
                                }
                                else if (i == p2_Magician.attackrange)
                                {
                                    result = MessageBox.Show("超出攻擊範圍", "", MessageBoxButtons.OK);
                                    if (result == DialogResult.OK)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    case 6:
                        if (p2_Ranger.mp - 10 > 0)
                        {
                            p2_Ranger.mp -= 10;
                            p2_Ranger.arrow();
                            damage = p2_Ranger.atk;
                            for (int i = 1; i <= p2_Ranger.attackrange; i++)
                            {
                                if (pos[5] - 7 * i > 0)//up
                                {
                                    left = pos[5] - 7 * i;
                                }
                                else
                                {
                                    left = 0;
                                }
                                if (pos[5] + 7 * i < 42)//down
                                {
                                    right = pos[5] + 7 * i;
                                }
                                else
                                {
                                    right = 41;
                                }
                                if (pos[5] + i < 42)//right
                                {
                                    down = pos[5] + i;
                                }
                                else
                                {
                                    down = 41;
                                }
                                if (pos[5] - i > 0)//left
                                {
                                    up = pos[5] - i;
                                }
                                else
                                {
                                    up = 0;
                                }
                                if (btn == checkerboard[down])//find down
                                {
                                    if (btn.Text != "")
                                    {
                                        character = down;
                                    }
                                }
                                else if (btn == checkerboard[right])//find right
                                {
                                    if (btn.Text != "")
                                    {
                                        character = right;
                                        break;
                                    }
                                }
                                else if (btn == checkerboard[left])//find left
                                {
                                    if (btn.Text != "")
                                    {
                                        character = left;
                                        break;
                                    }
                                }
                                else if (btn == checkerboard[up])//find up
                                {
                                    if (btn.Text != "")
                                    {
                                        character = up;
                                        break;
                                    }
                                }
                                else if (i == p2_Ranger.attackrange)
                                {
                                    result = MessageBox.Show("超出攻擊範圍", "", MessageBoxButtons.OK);
                                    if (result == DialogResult.OK)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                }
                for (int j = 0; j < 6; j++)
                {
                    if (character == pos[j])
                    {
                        getHurt = j + 1;
                    }
                }
                switch (getHurt)
                {
                    case 1:
                        p1_Warrior.hp -= damage;
                        showInformation(1);
                        if (p1_Warrior.hp == 0)
                        {
                            role[0] = 0;
                            P1_Chess--;
                            checkerboard[pos[0]].BackColor = Color.FromArgb(224, 224, 224);
                            checkerboard[pos[0]].Text = "";
                        }
                        round++;
                        showInformation(0);
                        showInformation(role[round]);
                        break;
                    case 2:
                        p1_Magician.hp -= damage;
                        showInformation(2);
                        if (p1_Magician.hp == 0)
                        {
                            role[1] = 0;
                            P1_Chess--;
                            checkerboard[pos[1]].BackColor = Color.FromArgb(224, 224, 224);
                            checkerboard[pos[1]].Text = "";
                        }
                        round++;
                        showInformation(0);
                        showInformation(role[round]);
                        break;
                    case 3:
                        p1_Ranger.hp -= damage;
                        showInformation(3);
                        if (p1_Ranger.hp == 0)
                        {
                            role[2] = 0;
                            P1_Chess--;
                            checkerboard[pos[2]].BackColor = Color.FromArgb(224, 224, 224);
                            checkerboard[pos[2]].Text = "";
                        }
                        round++;
                        showInformation(0);
                        showInformation(role[round]);
                        break;
                    case 4:
                        p2_Warrior.hp -= damage;
                        showInformation(4);
                        if (p2_Warrior.hp == 0)
                        {
                            role[3] = 0;
                            P2_Chess--;
                            checkerboard[pos[3]].BackColor = Color.FromArgb(224, 224, 224);
                            checkerboard[pos[3]].Text = "";
                        }
                        round++;
                        showInformation(0);
                        showInformation(role[round]);
                        break;
                    case 5:
                        p2_Magician.hp -= damage;
                        showInformation(5);
                        if (p2_Magician.hp == 0)
                        {
                            role[4] = 0;
                            P2_Chess--;
                            checkerboard[pos[4]].BackColor = Color.FromArgb(224, 224, 224);
                            checkerboard[pos[4]].Text = "";
                        }
                        round++;
                        showInformation(0);
                        showInformation(role[round]);
                        break;
                    case 6:
                        p2_Ranger.hp -= damage;
                        showInformation(6);
                        if (p2_Ranger.hp == 0)
                        {
                            role[5] = 0;
                            P2_Chess--;
                            checkerboard[pos[5]].BackColor = Color.FromArgb(224, 224, 224);
                            checkerboard[pos[5]].Text = "";
                        }
                        round++;
                        showInformation(0);
                        showInformation(role[round]);
                        break;
                }
            }
            if(round == 4)
            {
                P1_atk.Enabled = false;
                P1_move.Enabled = false;
                P1_skill.Enabled = false;
                P1_default.Enabled = false;
                P1_end.Enabled = true;
            }
            else if(round == 7)
            {
                P2_atk.Enabled = false;
                P2_move.Enabled = false;
                P2_skill.Enabled = false;
                P2_default.Enabled = false;
                P2_end.Enabled = true;
                round = 1;
            }
            if (P1_Chess == 0)
            {
                result = MessageBox.Show("P2 贏了", "", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            else if(P2_Chess == 0)
            {
                result = MessageBox.Show("P1 贏了", "", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }




        private void P1_atk_Click(object sender, EventArgs e)
        {
            search(role[round]);
            action = 1;
        }

        private void P1_move_Click(object sender, EventArgs e)
        {
            search(role[round]);
            action = 2;
        }

        private void P1_skill_Click(object sender, EventArgs e)
        {
            search(role[round]);
            action = 3;
        }

        private void P1_default_Click(object sender, EventArgs e)
        {
            round++;
            if(round < 4)
            {
                showInformation(role[round]);
            }
            if (round == 4)
            {
                P1_atk.Enabled = false;
                P1_move.Enabled = false;
                P1_skill.Enabled = false;
                P1_default.Enabled = false;
                P1_end.Enabled = true;
            }
        }

        private void P1_end_Click(object sender, EventArgs e)
        {
            taketurn(1);
        }

        private void P2_atk_Click(object sender, EventArgs e)
        {
            search(role[round]);
            action = 1;
        }

        private void P2_move_Click(object sender, EventArgs e)
        {
            search(role[round]);
            action = 2;
        }

        private void P2_skill_Click(object sender, EventArgs e)
        {
            search(role[round]);
            action = 3;
        }

        private void P2_default_Click(object sender, EventArgs e)
        {
            round++;
            if(round < 7)
            {
                showInformation(role[round]);
            }
            if (round == 7)
            {
                P2_atk.Enabled = false;
                P2_move.Enabled = false;
                P2_skill.Enabled = false;
                P2_default.Enabled = false;
                P2_end.Enabled = true;
                round = 1;
            }
        }

        private void P2_end_Click(object sender, EventArgs e)
        {
            taketurn(2);
        }
        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
