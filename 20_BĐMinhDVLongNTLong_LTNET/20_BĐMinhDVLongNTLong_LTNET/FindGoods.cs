using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


//Nhom20_Bùi Đức Minh_18103100061_11/11/2000_DHTI12A1HN
//Nhom20_Dương Văn Long_18103100027_19/11/2000_DHTI12A1HN
//Nhom20_Nguyễn Thăng Long_18103100034_23/10/2000_DHTI12A1HN
namespace _20_BĐMinhDVLongNTLong_LTNET
{
    public partial class FindGoods : Form
    {
        Connect con = new Connect();
        DataTable dt = new DataTable();
        public FindGoods()
        {
            InitializeComponent();
        }

        private void Btn_TimKiemHH_Click(object sender, EventArgs e)
        {
            string tenhh = txt_Key.Text;
            if (tenhh == null)
            {

                dt = con.GetData("SELECT * FROM hanghoa");
                dataGridView1.DataSource = dt;
            }
            else
            {

                dt = con.GetData("SELECT * FROM hanghoa WHERE tenhh Like N'%" + tenhh + "%'");
                dataGridView1.DataSource = dt;
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
          
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
