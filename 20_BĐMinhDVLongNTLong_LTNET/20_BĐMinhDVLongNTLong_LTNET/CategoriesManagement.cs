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
    public partial class CategoriesManagement : Form
    {
        Connect con = new Connect();
        DataTable dt = new DataTable();

        public CategoriesManagement()
        {
            InitializeComponent();
        }


        private void Btn_TimKiemNMH_Click(object sender, EventArgs e)
        {
            //this.Close();
            Form Form8 = new FindCategories();
            Form8.Show();
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dt = con.GetData("SELECT * FROM nhommathang");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Mã nhóm";
            dataGridView1.Columns[1].HeaderText = "Tên nhóm";
            dataGridView1.Columns[2].HeaderText = "Thông tin";
            dataGridView1.Columns[3].HeaderText = "Nhà cung cấp";
            btn_nhaplai_Click(sender, e);
            

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string manhommh = txt_manhommh.Text;
            string tennhommh = txt_tennhommh.Text;
            string thongtin = txt_thongtin.Text;
            string nhacc = txt_nhacc.Text;
            if (manhommh == "" || tennhommh == "" || thongtin == "" || nhacc == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP THÔNG TIN", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (con.SetData("INSERT INTO nhommathang VALUES (N'" + txt_manhommh.Text + "',N'" + txt_tennhommh.Text + "',N'" + txt_thongtin.Text + "',N'" + txt_nhacc.Text + "')") == true)
                {
                    MessageBox.Show("THÊM THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form5_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("THÊM THẤT BẠI", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           


        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string manhommh = txt_manhommh.Text;
            string tennhommh = txt_tennhommh.Text;
            string thongtin = txt_thongtin.Text;
            string nhacc = txt_nhacc.Text;
            if (manhommh == "" || tennhommh == "" || thongtin == "" || nhacc == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP THÔNG TIN", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (con.SetData("UPDATE nhommathang SET tennhommh = N'" + tennhommh + "',thongtinchung = N'" + thongtin + "',nhaccmh = N'"+ nhacc + "' WHERE manhommh = N'" + manhommh + "'") == true)
                {
                    MessageBox.Show("SỬA THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form5_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("SỬA THẤT BẠI", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_manhommh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_tennhommh.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_thongtin.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_nhacc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_manhommh.ReadOnly = true;
        }

        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            txt_nhacc.Text = "";
            txt_manhommh.Text = "";
            txt_tennhommh.Text = "";
            txt_thongtin.Text = "";
            txt_manhommh.ReadOnly = false;
        }
        
        private void btn_sapxep_Click(object sender, EventArgs e)
        {
            dt = con.GetData("SELECT * FROM nhommathang ORDER BY tennhommh DESC");
            dataGridView1.DataSource = dt;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string manhommh = txt_manhommh.Text;
            DialogResult res = MessageBox.Show("BẠN CÓ CHẮC CHẮN MUỐN XÓA ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                if (manhommh == "")
                {
                    MessageBox.Show("BẠN CHƯA CHỌN ĐỐI TƯỢNG XÓA", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (con.SetData("DELETE FROM nhommathang WHERE nhommathang.manhommh = '" + manhommh + "'") == true)
                    {
                        MessageBox.Show("XÓA THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form5_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("XÓA THẤT BẠI", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
