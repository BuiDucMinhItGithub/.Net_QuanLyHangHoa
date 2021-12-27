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
    public partial class GoodsManagement : Form
    {
        Connect con = new Connect();
        DataTable dt = new DataTable();
        public GoodsManagement()
        {
            
            InitializeComponent();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form Form9 = new FindGoods();
            Form9.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dt = con.GetData("SELECT * FROM hanghoa");

           // dataGridView1.DataSource = dt;

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Mã hàng";
            dataGridView1.Columns[1].HeaderText = "Tên hàng";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
            dataGridView1.Columns[3].HeaderText = "Đơn giá";
            dataGridView1.Columns[4].HeaderText = "Thành tiền";
            dataGridView1.Columns[5].HeaderText = "Giới thiệu";
            dataGridView1.Columns[6].HeaderText = "Mã nhóm";
            btn_nhaplai_Click(sender, e); 
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_mahanghoa.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_tenhanghoa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_soluong.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_dongia.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_thanhtien.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_gioithieu.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_manhommh.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_mahanghoa.ReadOnly = true;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
           
            string mahanghoa = txt_mahanghoa.Text;
            string tenhanghoa = txt_tenhanghoa.Text;
            string soluong = txt_soluong.Text;
            string dongia = txt_dongia.Text;
            string thanhtien = txt_thanhtien.Text;
            string gioithieu = txt_gioithieu.Text;
            string manhommathang = txt_manhommh.Text;
            if (mahanghoa == "" || tenhanghoa == "" || soluong == "" || dongia == "" || thanhtien == "" || gioithieu == "" || manhommathang == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP THÔNG TIN", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (con.SetData("UPDATE hanghoa SET tenhh = N'" + tenhanghoa + "',soluong = N'" + soluong + "',dongia = N'"
                 + dongia + "',thanhtien = N'" + thanhtien + "',gioithieu = N'" + gioithieu + "',manhommh = N'" + manhommathang + "' where mahh = N'" + mahanghoa + "'") == true)
                {
                    MessageBox.Show("SỬA THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form4_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("SỬA THẤT BẠI", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            txt_mahanghoa.ReadOnly = false;
            txt_mahanghoa.Text = "";
            txt_tenhanghoa.Text = "";
            txt_gioithieu.Text = "";
            txt_dongia.Text = "";
            txt_soluong.Text = "";
            txt_thanhtien.Text = "";
            txt_manhommh.Text = "";
            
        }

        private void btn_sapxep_Click(object sender, EventArgs e)
        {
            dt = con.GetData("SELECT * FROM hanghoa ORDER BY tenhh DESC");
            dataGridView1.DataSource = dt;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string mahanghoa = txt_mahanghoa.Text;
            DialogResult res = MessageBox.Show("BẠN CÓ CHẮC CHẮN MUỐN XÓA ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                if (mahanghoa == "")
                {
                    MessageBox.Show("BẠN CHƯA CHỌN ĐỐI TƯỢNG XÓA", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                     if (con.SetData("DELETE FROM hanghoa WHERE mahh = N'" + mahanghoa + "'") == true)
                     {
                        MessageBox.Show("XÓA THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_nhaplai_Click(sender, e);
                        Form4_Load(sender, e);
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





        private void btn_Them_Click(object sender, EventArgs e)
        {
            string mahanghoa = txt_mahanghoa.Text;
            string tenhanghoa = txt_tenhanghoa.Text;
            string soluong = txt_soluong.Text;
            string dongia = txt_dongia.Text;
            string thanhtien = txt_thanhtien.Text;
            string gioithieu = txt_gioithieu.Text;
            string manhommathang = txt_manhommh.Text;
            if(mahanghoa =="" || tenhanghoa =="" || soluong =="" ||dongia =="" || thanhtien =="" || gioithieu == "" || manhommathang == "")
            {
                MessageBox.Show("BẠN CHƯA NHẬP THÔNG TIN", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (con.SetData("INSERT INTO hanghoa VALUES (N'" + mahanghoa + "',N'" + tenhanghoa
                + "',N'" + soluong + "',N'" + dongia + "',N'" + thanhtien + "',N'" + gioithieu + "',N'" + manhommathang + "')") == true)
                {
                    MessageBox.Show("THÊM THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form4_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("THÊM THẤT BẠI", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
    }
}
