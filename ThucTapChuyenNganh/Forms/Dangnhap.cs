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
        }
        DataTable tblnd;
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTendangnhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTendangnhap.Focus();
                return;
            }
            if (txtMatkhau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatkhau.Focus();
                return;
            }
            sql = "select Tk_id, pass from tblnguoidung where Tk_id = N'" + txtTendangnhap.Text + "'";
            Class.Function.RunSql(sql);
            tblnd = Class.Function.GetDataToTable(sql);
            if (tblnd.Rows.Count == 0 )
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu đã sai. Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTendangnhap.Enabled = true;
                txtMatkhau.Enabled = true;
            }
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
        }
    }
}
