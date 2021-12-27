using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Nhom20_Bùi Đức Minh_18103100061_11/11/2000_DHTI12A1HN
//Nhom20_Dương Văn Long_18103100027_19/11/2000_DHTI12A1HN
//Nhom20_Nguyễn Thăng Long_18103100034_23/10/2000_DHTI12A1HN
namespace _20_BĐMinhDVLongNTLong_LTNET
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            
            //MessageBox.Show(Form1.ID_USER);
            this.IsMdiContainer = true;
            if (Login.MOD.Equals("user"))
            {
                this.Item_QLTK.Visible = false;
                label3.Text = "Xin chào: "+Login.NAME_USER;
            }
            else
            {
                label3.Text = "Xin chào: " + Login.NAME_USER;
            }

        }

        private void Item_QLTK_Click(object sender, EventArgs e)
        {
            Form Form3 = new AccountManagement();
            Form3.MdiParent = this;
            Form3.Show();
        }

        private void Item_DMK_Click(object sender, EventArgs e)
        {
            Form Form7 = new ChangePass();
            Form7.MdiParent = this;
            Form7.Show();
        }

        private void Item_T_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Form1 = new Login();
            Form1.Show();
        }

        private void Item_QL_HH_Click(object sender, EventArgs e)
        {
            Form Form4 = new GoodsManagement();
            Form4.MdiParent = this;
            Form4.Show();
        }

        private void Item_QL_NMH_Click(object sender, EventArgs e)
        {
            Form Form5 = new CategoriesManagement();
            Form5.MdiParent = this;
            Form5.Show();
        }

        private void Item_TG_Click(object sender, EventArgs e)
        {
            Form Form6 = new Author();
            Form6.MdiParent = this;
            Form6.Show();
        }

        private void Item_BC_HH_Click(object sender, EventArgs e)
        {
            Form Form11 = new ReportGoods();
            Form11.MdiParent = this;
            Form11.Show();
        }

        private void Item_BC_NMH_Click(object sender, EventArgs e)
        {
            Form Form10 = new ReportCategories();
            Form10.MdiParent = this;
            Form10.Show();
        }

        private void Item_W_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Word 2016");
            }
            catch
            {
                MessageBox.Show("CHƯA MỞ ĐƯỢC ỨNG DỤNG, KIỂM TRA LẠI ĐƯỜNG DẪN", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Item_E_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Excel 2016");
            }
            catch
            {
                MessageBox.Show("CHƯA MỞ ĐƯỢC ỨNG DỤNG, KIỂM TRA LẠI ĐƯỜNG DẪN", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Item_P_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Accessories\Paint");
            }
            catch
            {
                MessageBox.Show("CHƯA MỞ ĐƯỢC ỨNG DỤNG, KIỂM TRA LẠI ĐƯỜNG DẪN", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Item_HD_Click(object sender, EventArgs e)
        {
            Form Form12 = new Guide();
            Form12.MdiParent = this;
            Form12.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Item_BQ_Click(object sender, EventArgs e)
        {
            Form Form13 = new Copyright();
            Form13.MdiParent = this;
            Form13.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
