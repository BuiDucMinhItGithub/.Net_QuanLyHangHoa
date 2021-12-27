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
    public partial class Login : Form
    {
        public static string ID_USER = "";
        public static string NAME_USER = "";
        public static string MOD = "";
        public static string PASS = "";
        Connect con = new Connect();
        DataTable dt = new DataTable();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            dt = con.GetData("SELECT * FROM dangnhap WHERE username = N'" + txt_Name.Text + "' and password = N'" + txt_Pass.Text + "' AND state = 1");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    NAME_USER = dr["fullname"].ToString();
                    ID_USER = dr["username"].ToString();
                    MOD = dr["mod"].ToString();
                    PASS = dr["password"].ToString();
                    MessageBox.Show("Chào mừng " + NAME_USER + " đã quay trở lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form Form2 = new MainForm();
                    Form2.Show();
                }
            }
            else
            {
                MessageBox.Show("ĐĂNG NHẬP KHÔNG THÀNH CÔNG, SAI TÀI KHOẢN HOẶC MẬT KHẨU HOẶC TÀI KHOẢN BỊ VÔ HIỆU HÓA", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_Pass.UseSystemPasswordChar = true;
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            txt_Name.Text = "";
            txt_Pass.Text = "";
        }
    }
}

