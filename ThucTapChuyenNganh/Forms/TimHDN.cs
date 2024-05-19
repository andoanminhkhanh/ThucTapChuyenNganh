using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucTapChuyenNganh.Forms
{
    public partial class TimHDN : Form
    {
        public TimHDN()
        {
            InitializeComponent();
        }
        DataTable tblhdn;
        private void Hoadonnhap_Load(object sender, EventArgs e)
        {
            ResetValues();
            Class.Function.Fillcombo("select MaNCC, TenNCC from tblnhacungcap", cboMaNCC, "MaNCC", "TenNCC");
            cboMaNCC.SelectedIndex = -1;
            dgridHoadonnhap.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ct1 in this.Controls)
                if (Ct1 is TextBox)
                    Ct1.Text = "";
            txtMaHDN.Focus();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHDN.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") && (txtMaNV.Text == "") && (cboMaNCC.Text == "") && (txtTongtien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "select * from tblhoadonnhap where 1=1";
            if (txtMaHDN.Text != "")
                sql = sql + "AND MaHDN like N'%" + txtMaHDN.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + "and month(NgayNhap) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + "and year(NgayNhap) =" + txtNam.Text;
            if (txtMaNV.Text != "")
                sql = sql + "and MaNV like N'%" + txtMaNV.Text + "%'";
            if (cboMaNCC.Text != "")
                sql = sql + "and MaNCC =N'" + cboMaNCC.SelectedValue.ToString() + "'";
            if (txtTongtien.Text != "")
                sql = sql + "and Tongtien <=" + txtTongtien.Text;
            tblhdn = Class.Function.GetDataToTable(sql);
            if ( tblhdn.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblhdn.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridHoadonnhap.DataSource = tblhdn;
            load_data();
        }
        private void load_data()
        {
            dgridHoadonnhap.Columns[0].HeaderText = "Mã HĐN";
            dgridHoadonnhap.Columns[1].HeaderText = "Mã nhân viên";
            dgridHoadonnhap.Columns[2].HeaderText = "Ngày nhâp";
            dgridHoadonnhap.Columns[3].HeaderText = "Mã nhà cung cấp";
            dgridHoadonnhap.Columns[4].HeaderText = "Tổng tiền";
            dgridHoadonnhap.Columns[0].Width = 150;
            dgridHoadonnhap.Columns[1].Width = 100;
            dgridHoadonnhap.Columns[2].Width = 80;
            dgridHoadonnhap.Columns[3].Width = 80;
            dgridHoadonnhap.Columns[4].Width = 80;
            dgridHoadonnhap.AllowUserToAddRows = false;
            dgridHoadonnhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgridHoadonnhap.DataSource = null;
        }

        private void txtTongtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgridHoadonnhap_DoubleClick(object sender, EventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dgridHoadonnhap.CurrentRow.Cells["MaHDN"].Value.ToString();
                TimHDN frm = new TimHDN();
                frm.txtMaHDN.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}