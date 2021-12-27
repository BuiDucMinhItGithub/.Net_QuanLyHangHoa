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
    public partial class ChangePass : Form
    {
        Connect con = new Connect();
        DataTable dt = new DataTable();
        public ChangePass()
        {
            InitializeComponent();
        }

        private void btn_dongy_Click(object sender, EventArgs e)
        {
            string name = txt_username.Text;
            string pass = txt_oldpass.Text;
            string newpass = txt_newpass.Text;
            string renewpass = txt_nhaplaimk.Text;
            dt = con.GetData("SELECT * FROM dangnhap WHERE username = N'" + name + "' and password = N'" + pass + "'");
            if (dt.Rows.Count > 0)
            {
                if (renewpass.Equals(newpass))
                {
                    if (con.SetData("UPDATE dangnhap SET password = N'" + newpass +  "' where username = N'" + name + "'") == true)
                    {
                        MessageBox.Show("ĐÔI MẬT KHẨU THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("ĐỔI MẬT KHẨU THẤT BẠI", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("NHẬP LẠI MẬT KHẨU KHÔNG ĐÚNG", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("TÀI KHOẢN HOẶC MẬT KHẨU KHÔNG ĐÚNG !", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            txt_username.Text = Login.ID_USER;
            txt_newpass.Text = "";
            txt_nhaplaimk.Text = "";
            txt_oldpass.Text = "";
            txt_oldpass.UseSystemPasswordChar = true;
            txt_nhaplaimk.UseSystemPasswordChar = true;
            txt_newpass.UseSystemPasswordChar = true;
        }

        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
