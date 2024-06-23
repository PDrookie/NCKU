using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice9_12_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'database1DataSet.電話_員工編號' 資料表。您可以視需要進行移動或移除。
            this.電話_員工編號TableAdapter.Fill(this.database1DataSet.電話_員工編號);
            // TODO: 這行程式碼會將資料載入 'database1DataSet.員工編號_薪水' 資料表。您可以視需要進行移動或移除。
            this.員工編號_薪水TableAdapter.Fill(this.database1DataSet.員工編號_薪水);
            // TODO: 這行程式碼會將資料載入 'database1DataSet.員工編號_姓名_電子信箱' 資料表。您可以視需要進行移動或移除。
            this.員工編號_姓名_電子信箱TableAdapter.Fill(this.database1DataSet.員工編號_姓名_電子信箱);

        }
    }
}
