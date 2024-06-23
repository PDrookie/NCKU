namespace _0930_practice_3_1
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
            this.editBT = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.searchBOX = new System.Windows.Forms.TextBox();
            this.dangerBT = new System.Windows.Forms.Button();
            this.searchBT = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.userTxT = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.passwdTxT = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.resultBOX = new System.Windows.Forms.RichTextBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // editBT
            // 
            this.editBT.Location = new System.Drawing.Point(560, 140);
            this.editBT.Name = "editBT";
            this.editBT.Size = new System.Drawing.Size(174, 28);
            this.editBT.TabIndex = 2;
            this.editBT.Text = "新增或刪除";
            this.editBT.UseVisualStyleBackColor = true;
            this.editBT.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "密碼管理員";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.searchBOX);
            this.panel3.Controls.Add(this.dangerBT);
            this.panel3.Controls.Add(this.searchBT);
            this.panel3.Location = new System.Drawing.Point(56, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(678, 85);
            this.panel3.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "搜尋列";
            // 
            // searchBOX
            // 
            this.searchBOX.Location = new System.Drawing.Point(60, 3);
            this.searchBOX.Name = "searchBOX";
            this.searchBOX.Size = new System.Drawing.Size(512, 25);
            this.searchBOX.TabIndex = 7;
            // 
            // dangerBT
            // 
            this.dangerBT.Location = new System.Drawing.Point(5, 53);
            this.dangerBT.Name = "dangerBT";
            this.dangerBT.Size = new System.Drawing.Size(672, 29);
            this.dangerBT.TabIndex = 6;
            this.dangerBT.Text = "風險帳號";
            this.dangerBT.UseVisualStyleBackColor = true;
            this.dangerBT.Click += new System.EventHandler(this.dangerBT_Click);
            // 
            // searchBT
            // 
            this.searchBT.Location = new System.Drawing.Point(596, 3);
            this.searchBT.Name = "searchBT";
            this.searchBT.Size = new System.Drawing.Size(81, 25);
            this.searchBT.TabIndex = 5;
            this.searchBT.Text = "搜尋";
            this.searchBT.UseVisualStyleBackColor = true;
            this.searchBT.Click += new System.EventHandler(this.searchBT_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.userTxT);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.passwdTxT);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(131, 185);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 239);
            this.panel1.TabIndex = 24;
            this.panel1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(14, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(459, 25);
            this.textBox2.TabIndex = 23;
            this.textBox2.Text = "我是狀態列";
            // 
            // userTxT
            // 
            this.userTxT.AutoSize = true;
            this.userTxT.Location = new System.Drawing.Point(10, 106);
            this.userTxT.Name = "userTxT";
            this.userTxT.Size = new System.Drawing.Size(52, 15);
            this.userTxT.TabIndex = 16;
            this.userTxT.Text = "使用者";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "連結";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(356, 199);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(81, 29);
            this.button5.TabIndex = 22;
            this.button5.Text = "刪除";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // passwdTxT
            // 
            this.passwdTxT.AutoSize = true;
            this.passwdTxT.Location = new System.Drawing.Point(11, 151);
            this.passwdTxT.Name = "passwdTxT";
            this.passwdTxT.Size = new System.Drawing.Size(37, 15);
            this.passwdTxT.TabIndex = 17;
            this.passwdTxT.Text = "密碼";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(260, 199);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 29);
            this.button4.TabIndex = 21;
            this.button4.Text = "新增";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(68, 103);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(404, 25);
            this.textBox3.TabIndex = 19;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(69, 146);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(403, 25);
            this.textBox4.TabIndex = 20;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(404, 25);
            this.textBox1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.resultBOX);
            this.panel2.Location = new System.Drawing.Point(55, 196);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 242);
            this.panel2.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "搜尋結果";
            // 
            // resultBOX
            // 
            this.resultBOX.Location = new System.Drawing.Point(0, 18);
            this.resultBOX.Name = "resultBOX";
            this.resultBOX.Size = new System.Drawing.Size(675, 221);
            this.resultBOX.TabIndex = 28;
            this.resultBOX.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editBT);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button editBT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchBOX;
        private System.Windows.Forms.Button dangerBT;
        private System.Windows.Forms.Button searchBT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label userTxT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label passwdTxT;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox resultBOX;
    }
}

