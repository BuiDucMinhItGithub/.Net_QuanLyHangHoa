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
using System.Text.RegularExpressions;


//Nhom20_Bùi Đức Minh_18103100061_11/11/2000_DHTI12A1HN
//Nhom20_Dương Văn Long_18103100027_19/11/2000_DHTI12A1HN
//Nhom20_Nguyễn Thăng Long_18103100034_23/10/2000_DHTI12A1HN
namespace _20_BĐMinhDVLongNTLong_LTNET
{
    
    public partial class AccountManagement : Form
    {
        Connect con = new Connect();
        DataTable dt = new DataTable();
        public AccountManagement()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_tendangnhap.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_matkhau.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_hoten.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_email.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_phanquyen.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_trangthai.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_tendangnhap.ReadOnly = true;
            txt_matkhau.UseSystemPasswordChar = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dt = con.GetData("SELECT * FROM dangnhap");

            // dataGridView1.DataSource = dt;

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Tên đăng nhập";
            dataGridView1.Columns[1].HeaderText = "Mật khẩu";
            dataGridView1.Columns[2].HeaderText = "Họ tên";
            dataGridView1.Columns[3].HeaderText = "Email";
            dataGridView1.Columns[4].HeaderText = "Phân quyền";
            dataGridView1.Columns[5].HeaderText = "Trạng thái";
            btn_nhaplai_Click(sender, e);
        }

        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            txt_trangthai.Text = "";
            txt_tendangnhap.Text = "";
            txt_phanquyen.Text = "";
            txt_matkhau.Text = "";
            txt_hoten.Text = "";
            txt_email.Text = "";
            txt_tendangnhap.ReadOnly = false;
            
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            
            string username = txt_tendangnhap.Text;
            string matkhau = txt_matkhau.Text;
            string hoten = txt_hoten.Text;
            string email = txt_email.Text;
            string phanquyen = txt_phanquyen.Text;
            txt_trangthai.Text = "1";
            int trangthai = Int32.Parse(txt_trangthai.Text);
            
            if (username == "" || matkhau == "" || hoten =="" || email == "" || phanquyen =="" || trangthai == null)
            {
                MessageBox.Show("BẠN CHƯA NHẬP THÔNG TIN", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!check_email(email)) {
                MessageBox.Show("EMAIL SAI ĐỊNH DẠNG", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_email.Focus();
            }
            else
            {
                if (trangthai==1 || trangthai==0)
                {
                    if (con.SetData("INSERT INTO dangnhap VALUES (N'" + username + "',N'" + matkhau
                + "',N'" + hoten + "',N'" + email + "',N'" + phanquyen + "',N'" + trangthai + "')") == true)
                    {
                        MessageBox.Show("THÊM THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form3_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("THÊM THẤT BẠI", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("TRẠNG THÁI VUI LÒNG NHẬP 0 (KHÔNG HOẠT ĐỘNG) HOẶC 1(CÓ HOẠT ĐỘNG)", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            }
            
            
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string username = txt_tendangnhap.Text;
            string matkhau = txt_matkhau.Text;
            string hoten = txt_hoten.Text;
            string email = txt_email.Text;
            string phanquyen = txt_phanquyen.Text;
            txt_trangthai.Text = "1";
            int trangthai = Int32.Parse(txt_trangthai.Text);
            if (username == "" || matkhau == "" || hoten == "" || email == "" || phanquyen == "" || trangthai == null)
            {
                MessageBox.Show("BẠN CHƯA NHẬP THÔNG TIN", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!check_email(email))
                {
                    MessageBox.Show("EMAIL SAI ĐỊNH DẠNG", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_email.Focus();
                }
                else
                {
                    if (trangthai == 1 || trangthai == 0)
                    {
                        if (con.SetData("UPDATE dangnhap SET username = N'" + username + "' ,password = N'" + matkhau + "',fullname = N'" + hoten + "',email = N'"
                    + email + "',mod = N'" + phanquyen + "',state = N'" + trangthai + "' where (username = N'" + username + "')") == true)
                        {
                            MessageBox.Show("SỬA THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form3_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("SỬA KHÔNG THÀNH CÔNG", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("TRẠNG THÁI VUI LÒNG NHẬP 0 (KHÔNG HOẠT ĐỘNG) HOẶC 1(CÓ HOẠT ĐỘNG)", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
           
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
           
            string username = txt_tendangnhap.Text;
            DialogResult res = MessageBox.Show("BẠN CÓ CHẮC CHẮN MUỐN XÓA ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (res == DialogResult.OK)
                {
                    if (username == "")
                    {
                        MessageBox.Show("BẠN CHƯA CHỌN ĐỐI TƯỢNG XÓA", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (con.SetData("DELETE FROM dangnhap WHERE username = N'" + username + "'") == true)
                        {
                            MessageBox.Show("XÓA THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form3_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("XÓA KHÔNG THÀNH CÔNG", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                } 
        }

        private void txt_trangthai_KeyPress(object sender, KeyPressEventArgs e){
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("VUI LÒNG NHẬP SỐ TRƯỜNG TRẠNG THÁI", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_trangthai.Focus();
            }
                
        }

        private void txt_email_KeyUp(object sender, KeyEventArgs e){}

        private void txt_email_KeyPress(object sender, KeyPressEventArgs e){}

        private bool check_email(string inputEmail)
        {
            Boolean ktr = false;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(inputEmail))
            {
                return ktr;
            }
            else
            {
                ktr =  true;
            }
            return ktr;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 1 && e.Value != null){
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }
    }
}
