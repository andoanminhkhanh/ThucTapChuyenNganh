using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThucTapChuyenNganh.Class;

namespace ThucTapChuyenNganh.Forms
{
    public partial class TimHDB : Form
    {
        public TimHDB()
        {
            InitializeComponent();
        }

        DataTable tblTKHDB;

        private void TimHDB_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgridTimHDB.DataSource = null;
            Class.Function.Fillcombo("SELECT MaNV, TenNV FROM tblnhanvien", cboMaNV, "MaNV", "MaNV");
            cboMaNV.SelectedIndex = -1;
            //Class.Function.Fillcombo("SELECT TrangThai FROM tblhoadonban ", cboTrangthai, "TrangThai", "TrangThai");
            //cboMaNV.SelectedIndex = -1;
        }

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHDB.Focus();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHDB.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") && (cboMaNV.Text == "") && (txtMaKH.Text == "") && (txtTongTien.Text == "")&&(cboTrangthai.Text=="") && (txtMagiaovan.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT MaHDB, MaNV, NgayBan, MaKH, TongTien, MaVanDon, TrangThai,MONTH(NgayBan) AS Tháng, YEAR(NgayBan) AS Năm FROM tblhoadonban WHERE 1=1";
            if (txtMaHDB.Text != "")
                sql = sql + " AND MaHDB Like N'%" + txtMaHDB.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(NgayBan) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(NgayBan) =" + txtNam.Text;
            if (cboMaNV.Text != "")
                sql = sql + " AND MaNV Like N'%" + cboMaNV.Text + "%'";
            if (txtMaKH.Text != "")
                sql = sql + " AND MaKH Like N'%" + txtMaKH.Text + "%'";
            if (txtTongTien.Text != "")
                sql = sql + " AND TongTien <=" + txtTongTien.Text;
            if (txtMagiaovan.Text != "")
                sql = sql + " AND MaVanDon Like N'% " + txtMagiaovan.Text + "%'";
            if(cboTrangthai.Text != "")
                sql = sql + " AND TrangThai Like N'%" + cboTrangthai.Text + "%'";

            tblTKHDB = Function.GetDataToTable(sql);

            if (tblTKHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblTKHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridTimHDB.DataSource = tblTKHDB;
            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            dgridTimHDB.Columns[0].HeaderText = "Mã HĐB";
            dgridTimHDB.Columns[1].HeaderText = "Mã nhân viên";
            dgridTimHDB.Columns[2].HeaderText = "Ngày bán";
            dgridTimHDB.Columns[3].HeaderText = "Mã khách";
            dgridTimHDB.Columns[4].HeaderText = "Tổng tiền";
            dgridTimHDB.Columns[5].HeaderText = "Mã vận đơn";
            dgridTimHDB.Columns[6].HeaderText = "Trạng thái";
            dgridTimHDB.Columns[0].Width = 150;
            dgridTimHDB.Columns[1].Width = 100;
            dgridTimHDB.Columns[2].Width = 80;
            dgridTimHDB.Columns[3].Width = 80;
            dgridTimHDB.Columns[4].Width = 80;
            dgridTimHDB.Columns[5].Width = 100;
            dgridTimHDB.Columns[6].Width = 80;
            dgridTimHDB.AllowUserToAddRows = false;
            dgridTimHDB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgridTimHDB.DataSource = null;
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            string sql;
            if (tblTKHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtMaHDB.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sql = "UPDATE tblhoadonban SET MaVanDon = N'" + txtMagiaovan.Text.Trim() + "', TrangThai = N'" + cboTrangthai.Text.Trim() + "' WHERE MaHDB = N'" + txtMaHDB.Text + "'";

            try
            {
                Function.RunSql(sql);
                Load_DataGridView();
                ResetValues();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Function.RunSql(sql);
            Load_DataGridView();
            ResetValues();
        }

        private void dgridTimHDB_Click(object sender, EventArgs e)
        {
            txtMaHDB.Text = dgridTimHDB.CurrentRow.Cells["MaHDB"].Value.ToString();
            txtThang.Text = dgridTimHDB.CurrentRow.Cells["Tháng"].Value.ToString();
            txtNam.Text = dgridTimHDB.CurrentRow.Cells["Năm"].Value.ToString();
            txtMaHDB.Text = dgridTimHDB.CurrentRow.Cells["MaHDB"].Value.ToString();
            cboMaNV.Text = dgridTimHDB.CurrentRow.Cells["MaNV"].Value.ToString();
            cboTrangthai.Text = dgridTimHDB.CurrentRow.Cells["TrangThai"].Value.ToString();
            txtMaKH.Text = dgridTimHDB.CurrentRow.Cells["MaKH"].Value.ToString();
            txtTongTien.Text = dgridTimHDB.CurrentRow.Cells["TongTien"].Value.ToString();
            txtMagiaovan.Text = dgridTimHDB.CurrentRow.Cells["MaVanDon"].Value.ToString();
            btnSua.Enabled = true;
            txtMaHDB.Enabled = false;
            txtThang.Enabled = false;
            txtNam.Enabled = false;
            cboMaNV.Enabled = false;
            txtMaKH.Enabled = false;
            txtTongTien.Enabled = false;

        }

        private void dgridTimHDB_DoubleClick(object sender, EventArgs e)
        {
            if (dgridTimHDB.CurrentRow != null && dgridTimHDB.CurrentRow.Cells["MaHDB"] != null)
            {
                string mahd = dgridTimHDB.CurrentRow.Cells["MaHDB"].Value?.ToString();

                if (!string.IsNullOrEmpty(mahd) &&
                    MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Chitiethoadonbanhang frm = new Chitiethoadonbanhang();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.txtMahoadon.Text = mahd;
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Không thể lấy mã hóa đơn. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
