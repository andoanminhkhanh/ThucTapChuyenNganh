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
    public partial class Nhanvien : Form
    {
        public Nhanvien()
        {
            InitializeComponent();
        }

        DataTable tblnv;

        private void Nhanvien_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            load_datagridview();
            Function.FillCombo("SELECT MaCV, TenCV FROM tblcongviec", cboMaCV, "MaCV", "TenCV");
            cboMaCV.SelectedIndex = -1;
            resetvalues();
        }

        private void load_datagridview()
        {
            string sql;
            sql = "SELECT MaNV, TenNV, GioiTinh, NgaySinh, DienThoai, DiaChi, MaCV from tblnhanvien";

            tblnv = Function.GetDataToTable(sql);
            dgridNhanvien.DataSource = tblnv;
            dgridNhanvien.Columns[0].HeaderText = "Mã nhân viên";
            dgridNhanvien.Columns[1].HeaderText = "Tên nhân viên";
            dgridNhanvien.Columns[2].HeaderText = "Giới tính";
            dgridNhanvien.Columns[3].HeaderText = "Ngày sinh";
            dgridNhanvien.Columns[4].HeaderText = "Điện thoại";
            dgridNhanvien.Columns[5].HeaderText = "Địa Chỉ";
            dgridNhanvien.Columns[6].HeaderText = "Mã công việc";
            dgridNhanvien.Columns[0].Width = 80;
            dgridNhanvien.Columns[1].Width = 140;
            dgridNhanvien.Columns[2].Width = 80;
            dgridNhanvien.Columns[3].Width = 80;
            dgridNhanvien.Columns[4].Width = 80;
            dgridNhanvien.Columns[5].Width = 140;
            dgridNhanvien.Columns[6].Width = 80;
            dgridNhanvien.AllowUserToAddRows = false;
            dgridNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void resetvalues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            cboMaCV.Text = "";
            txtDiaChi.Text = "";
            mtxtNgaySinh.Text = "";
            mtxtDienthoai.Text = "";
            chkGioiTinh.Checked = false;
        }

        private void dgridNhanvien_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return;
            }
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtMaNV.Text = dgridNhanvien.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dgridNhanvien.CurrentRow.Cells["TenNV"].Value.ToString();
            ma = dgridNhanvien.CurrentRow.Cells["MaCV"].Value.ToString();
            cboMaCV.Text = Function.GetFieldValues("SELECT TenCV FROM tblcongviec WHERE MaCV = N'" + ma + "'");
            if (dgridNhanvien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam")
                chkGioiTinh.Checked = true;
            else
                chkGioiTinh.Checked = false;
            txtDiaChi.Text = dgridNhanvien.CurrentRow.Cells["DiaChi"].Value.ToString();
            mtxtDienthoai.Text = dgridNhanvien.CurrentRow.Cells["DienThoai"].Value.ToString();
            mtxtNgaySinh.Text = dgridNhanvien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            resetvalues();
            txtMaNV.Enabled = true;
            txtMaNV.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNV.Focus();
                return;
            }
            if (cboMaCV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMaCV.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return;
            }
            if (mtxtDienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtxtDienthoai.Focus();
                return;
            }
            if (mtxtNgaySinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtxtNgaySinh.Focus();
                return;
            }
            if (!Function.IsDate(mtxtNgaySinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtxtNgaySinh.Text = "";
                mtxtNgaySinh.Focus();
                return;
            }
            if (chkGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "SELECT MaNV FROM tblnhanvien WHERE MaNV = N'" + txtMaNV.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhaapj mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return;
            }
            sql = "INSERT INTO tblnhanvien(MaNV,TenNV, GioiTinh, NgaySinh, DienThoai, DiaChi, MaCV) VALUES(N'" + txtMaNV.Text.Trim() + "',N'" + txtTenNV.Text.Trim() + "', N'" + gt + "', N'" + Function.ConvertDateTime(mtxtNgaySinh.Text) + "', N'" + mtxtDienthoai.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "',N'" + cboMaCV.SelectedValue.ToString() + "')";
            Function.RunSql(sql);
            load_datagridview();
            resetvalues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboMaCV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMaCV.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return;
            }
            if (mtxtDienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtxtDienthoai.Focus();
                return;
            }
            if (mtxtNgaySinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtxtNgaySinh.Focus();
                return;
            }
            if (!Function.IsDate(mtxtNgaySinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtxtNgaySinh.Text = "";
                mtxtNgaySinh.Focus();
                return;
            }
            if (chkGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "UPDATE tblnhanvien SET TenNV = N'" + txtTenNV.Text.Trim().ToString() + "',GioiTinh= N'" + gt + "', NgaySinh=N'" + Function.ConvertDateTime(mtxtNgaySinh.Text) + "', DienThoai= N'" + mtxtDienthoai.Text.Trim().ToString() + "',DiaChi= N'" + txtDiaChi.Text.Trim().ToString() + "', MaCV=N'" + cboMaCV.SelectedValue.ToString() + "'  WHERE MaNV = N'" + txtMaNV.Text + "'";
            Function.RunSql(sql);
            load_datagridview();
            resetvalues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn muốn xóa không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE FROM tblnhanvien WHERE MaNV =N'" + txtMaNV.Text + "'";
                Function.RunSql(sql);
                load_datagridview();
                resetvalues();
            }
        }
    }
}
