using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThucTapChuyenNganh;
using ThucTapChuyenNganh.Class;

namespace ThucTapChuyenNganh
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
            //labelError.Visible = false;
            txtMatkhau.PasswordChar = '*';
            this.SizeChanged += new EventHandler(Dangnhap_SizeChanged);

        }
        DataTable tblnv;
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTendangnhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTendangnhap.Focus();
                return;
            }
            if (txtMatkhau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatkhau.Focus();
                return;
            }

            // Sử dụng câu lệnh SQL để kiểm tra tên đăng nhập và mật khẩu
            sql = "select Tk_id, pass from tblnhanvien where Tk_id = N'" + txtTendangnhap.Text + "' and pass = N'" + txtMatkhau.Text + "'";
            tblnv = Class.Function.GetDataToTable(sql);

            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu đã sai. Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTendangnhap.Focus();
            }
            else
            {
                Form1 a = new Form1();
                a.Show();
                this.Hide();
            }
        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
        }

        private void Dangnhap_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Form đã được mở rộng toàn màn hình
            }
        }
    }
}
