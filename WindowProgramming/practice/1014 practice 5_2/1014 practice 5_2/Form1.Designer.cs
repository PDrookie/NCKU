namespace _1014_practice_5_2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.P1_end = new System.Windows.Forms.Button();
            this.P1_default = new System.Windows.Forms.Button();
            this.P1_skill = new System.Windows.Forms.Button();
            this.P1_move = new System.Windows.Forms.Button();
            this.P1_atk = new System.Windows.Forms.Button();
            this.P1_information = new System.Windows.Forms.Label();
            this.P1_character = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.P2_end = new System.Windows.Forms.Button();
            this.P2_default = new System.Windows.Forms.Button();
            this.P2_skill = new System.Windows.Forms.Button();
            this.P2_move = new System.Windows.Forms.Button();
            this.P2_atk = new System.Windows.Forms.Button();
            this.P2_character = new System.Windows.Forms.Label();
            this.P2_information = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(294, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 500);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "開始遊戲";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(403, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "準備階段";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(471, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "10";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(110, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "P1";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(117, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "P2";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(12, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 481);
            this.panel2.TabIndex = 6;
            this.panel2.Visible = false;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.P1_information);
            this.panel6.Controls.Add(this.P1_character);
            this.panel6.Enabled = false;
            this.panel6.Location = new System.Drawing.Point(25, 85);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(216, 354);
            this.panel6.TabIndex = 9;
            this.panel6.Visible = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.P1_end);
            this.panel8.Controls.Add(this.P1_default);
            this.panel8.Controls.Add(this.P1_skill);
            this.panel8.Controls.Add(this.P1_move);
            this.panel8.Controls.Add(this.P1_atk);
            this.panel8.Location = new System.Drawing.Point(20, 210);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(181, 132);
            this.panel8.TabIndex = 7;
            // 
            // P1_end
            // 
            this.P1_end.Location = new System.Drawing.Point(9, 89);
            this.P1_end.Name = "P1_end";
            this.P1_end.Size = new System.Drawing.Size(163, 34);
            this.P1_end.TabIndex = 6;
            this.P1_end.Text = "結束";
            this.P1_end.UseVisualStyleBackColor = true;
            this.P1_end.Click += new System.EventHandler(this.P1_end_Click);
            // 
            // P1_default
            // 
            this.P1_default.Location = new System.Drawing.Point(94, 48);
            this.P1_default.Name = "P1_default";
            this.P1_default.Size = new System.Drawing.Size(79, 27);
            this.P1_default.TabIndex = 5;
            this.P1_default.Text = "待機";
            this.P1_default.UseVisualStyleBackColor = true;
            this.P1_default.Click += new System.EventHandler(this.P1_default_Click);
            // 
            // P1_skill
            // 
            this.P1_skill.Location = new System.Drawing.Point(8, 48);
            this.P1_skill.Name = "P1_skill";
            this.P1_skill.Size = new System.Drawing.Size(79, 27);
            this.P1_skill.TabIndex = 4;
            this.P1_skill.Text = "技能";
            this.P1_skill.UseVisualStyleBackColor = true;
            this.P1_skill.Click += new System.EventHandler(this.P1_skill_Click);
            // 
            // P1_move
            // 
            this.P1_move.Location = new System.Drawing.Point(94, 7);
            this.P1_move.Name = "P1_move";
            this.P1_move.Size = new System.Drawing.Size(79, 27);
            this.P1_move.TabIndex = 3;
            this.P1_move.Text = "移動";
            this.P1_move.UseVisualStyleBackColor = true;
            this.P1_move.Click += new System.EventHandler(this.P1_move_Click);
            // 
            // P1_atk
            // 
            this.P1_atk.Location = new System.Drawing.Point(7, 7);
            this.P1_atk.Name = "P1_atk";
            this.P1_atk.Size = new System.Drawing.Size(79, 27);
            this.P1_atk.TabIndex = 2;
            this.P1_atk.Text = "攻擊";
            this.P1_atk.UseVisualStyleBackColor = true;
            this.P1_atk.Click += new System.EventHandler(this.P1_atk_Click);
            // 
            // P1_information
            // 
            this.P1_information.AutoSize = true;
            this.P1_information.Location = new System.Drawing.Point(75, 86);
            this.P1_information.Name = "P1_information";
            this.P1_information.Size = new System.Drawing.Size(41, 15);
            this.P1_information.TabIndex = 1;
            this.P1_information.Text = "label6";
            // 
            // P1_character
            // 
            this.P1_character.AutoSize = true;
            this.P1_character.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.P1_character.Location = new System.Drawing.Point(66, 24);
            this.P1_character.Name = "P1_character";
            this.P1_character.Size = new System.Drawing.Size(70, 24);
            this.P1_character.TabIndex = 0;
            this.P1_character.Text = "label5";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Location = new System.Drawing.Point(54, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(154, 172);
            this.panel4.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 119);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 38);
            this.button4.TabIndex = 7;
            this.button4.Text = "遊俠: 1顆";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 38);
            this.button3.TabIndex = 6;
            this.button3.Text = "法師: 1顆";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "戰士: 1顆";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(706, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 481);
            this.panel3.TabIndex = 7;
            this.panel3.Visible = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.P2_character);
            this.panel7.Controls.Add(this.P2_information);
            this.panel7.Enabled = false;
            this.panel7.Location = new System.Drawing.Point(27, 85);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(216, 354);
            this.panel7.TabIndex = 10;
            this.panel7.Visible = false;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.P2_end);
            this.panel9.Controls.Add(this.P2_default);
            this.panel9.Controls.Add(this.P2_skill);
            this.panel9.Controls.Add(this.P2_move);
            this.panel9.Controls.Add(this.P2_atk);
            this.panel9.Location = new System.Drawing.Point(19, 210);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(183, 131);
            this.panel9.TabIndex = 10;
            // 
            // P2_end
            // 
            this.P2_end.Location = new System.Drawing.Point(11, 89);
            this.P2_end.Name = "P2_end";
            this.P2_end.Size = new System.Drawing.Size(163, 34);
            this.P2_end.TabIndex = 7;
            this.P2_end.Text = "結束";
            this.P2_end.UseVisualStyleBackColor = true;
            this.P2_end.Click += new System.EventHandler(this.P2_end_Click);
            // 
            // P2_default
            // 
            this.P2_default.Location = new System.Drawing.Point(95, 48);
            this.P2_default.Name = "P2_default";
            this.P2_default.Size = new System.Drawing.Size(79, 27);
            this.P2_default.TabIndex = 6;
            this.P2_default.Text = "待機";
            this.P2_default.UseVisualStyleBackColor = true;
            this.P2_default.Click += new System.EventHandler(this.P2_default_Click);
            // 
            // P2_skill
            // 
            this.P2_skill.Location = new System.Drawing.Point(10, 48);
            this.P2_skill.Name = "P2_skill";
            this.P2_skill.Size = new System.Drawing.Size(79, 27);
            this.P2_skill.TabIndex = 5;
            this.P2_skill.Text = "技能";
            this.P2_skill.UseVisualStyleBackColor = true;
            this.P2_skill.Click += new System.EventHandler(this.P2_skill_Click);
            // 
            // P2_move
            // 
            this.P2_move.Location = new System.Drawing.Point(95, 7);
            this.P2_move.Name = "P2_move";
            this.P2_move.Size = new System.Drawing.Size(79, 27);
            this.P2_move.TabIndex = 4;
            this.P2_move.Text = "移動";
            this.P2_move.UseVisualStyleBackColor = true;
            this.P2_move.Click += new System.EventHandler(this.P2_move_Click);
            // 
            // P2_atk
            // 
            this.P2_atk.Location = new System.Drawing.Point(10, 7);
            this.P2_atk.Name = "P2_atk";
            this.P2_atk.Size = new System.Drawing.Size(79, 27);
            this.P2_atk.TabIndex = 3;
            this.P2_atk.Text = "攻擊";
            this.P2_atk.UseVisualStyleBackColor = true;
            this.P2_atk.Click += new System.EventHandler(this.P2_atk_Click);
            // 
            // P2_character
            // 
            this.P2_character.AutoSize = true;
            this.P2_character.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.P2_character.Location = new System.Drawing.Point(74, 24);
            this.P2_character.Name = "P2_character";
            this.P2_character.Size = new System.Drawing.Size(70, 24);
            this.P2_character.TabIndex = 9;
            this.P2_character.Text = "label8";
            // 
            // P2_information
            // 
            this.P2_information.AutoSize = true;
            this.P2_information.Location = new System.Drawing.Point(92, 88);
            this.P2_information.Name = "P2_information";
            this.P2_information.Size = new System.Drawing.Size(41, 15);
            this.P2_information.TabIndex = 8;
            this.P2_information.Text = "label7";
            this.P2_information.Click += new System.EventHandler(this.label7_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button7);
            this.panel5.Controls.Add(this.button6);
            this.panel5.Controls.Add(this.button5);
            this.panel5.Location = new System.Drawing.Point(53, 54);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(164, 174);
            this.panel5.TabIndex = 9;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(16, 62);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(138, 38);
            this.button7.TabIndex = 8;
            this.button7.Text = "法師: 1顆";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(16, 113);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(138, 38);
            this.button6.TabIndex = 7;
            this.button6.Text = "遊俠: 1顆";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(16, 7);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(138, 38);
            this.button5.TabIndex = 6;
            this.button5.Text = "戰士: 1顆";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 603);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button P1_end;
        private System.Windows.Forms.Button P1_default;
        private System.Windows.Forms.Button P1_skill;
        private System.Windows.Forms.Button P1_move;
        private System.Windows.Forms.Button P1_atk;
        private System.Windows.Forms.Label P1_information;
        private System.Windows.Forms.Label P1_character;
        private System.Windows.Forms.Button P2_move;
        private System.Windows.Forms.Button P2_atk;
        private System.Windows.Forms.Button P2_skill;
        private System.Windows.Forms.Label P2_information;
        private System.Windows.Forms.Button P2_end;
        private System.Windows.Forms.Button P2_default;
        private System.Windows.Forms.Label P2_character;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
    }
}

