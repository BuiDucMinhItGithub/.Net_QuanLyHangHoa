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
    public partial class FindCategories : Form
    {
        Connect con = new Connect();
        DataTable dt = new DataTable();
        public static string tenhommh = "";
        public FindCategories()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            tenhommh = txt_TenNhommh.Text;
            if (FindCategories.tenhommh == null)
            {

                dt = con.GetData("SELECT * FROM nhommathang");
                dataGridView1.DataSource = dt;
            }
            else
            {

                string key = FindCategories.tenhommh;
                dt = con.GetData("SELECT * FROM nhommathang WHERE tennhommh LIKE N'%" + key + "%'");
                dataGridView1.DataSource = dt;

            }
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
        
        }
    }
}
