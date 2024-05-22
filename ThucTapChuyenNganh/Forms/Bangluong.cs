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
    public partial class Bangluong : Form
    {
        public Bangluong()
        {
            InitializeComponent();
        }
        DataTable tblBL;
        private void Bangluong_Load(object sender, EventArgs e)
        {
            btnBoqua.Enabled = false;
            Load_DataGridView();
            ResetValues();
        }
        private void ResetValues()
        {
            cboMaNV.Text = "";
            txtThang.Text = "";
            txtNam.Text = "";
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblbangluong";
            tblBL = Function.GetDataToTable(sql);
            DataGridView.DataSource = tblBL;
            DataGridView.Columns[0].HeaderText = "Mã nhân viên";
            DataGridView.Columns[1].HeaderText = "Năm";
            DataGridView.Columns[2].HeaderText = "Tháng";
            DataGridView.Columns[3].HeaderText = "Tổng giờ làm";
            DataGridView.Columns[4].HeaderText = "Tổng tiền lương";
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            string manv;
            if (tblBL.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           /*
            manv = DataGridView.CurrentRow.Cells["MaLoai"].Value.ToString();
            cboMaloai.Text = Function.GetFieldValues("SELECT TheLoai FROM tbltheloai WHERE MaLoai = N'" + maloai + "'");

            txtSize.Text = DataGridView.CurrentRow.Cells["Size"].Value.ToString();

            mamau = DataGridView.CurrentRow.Cells["MaMau"].Value.ToString();
            cboMamau.Text = Function.GetFieldValues("SELECT TenMau FROM tblmau WHERE MaMau = N'" + mamau + "'");

            txtSoluong.Text = DataGridView.CurrentRow.Cells["SoLuong"].Value.ToString();
            //txtDongianhap.Text = DataGridView.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            ma = DataGridView.CurrentRow.Cells["MaSP"].Value.ToString();
            txtDongianhap.Text = Function.GetFieldValues("SELECT DonGiaNhap FROM tblchitiethoadonnhap WHERE MaSP = N'" + ma + "'");

            txtDongiaban.Text = DataGridView.CurrentRow.Cells["DonGiaBan"].Value.ToString();

            txtAnh.Text = Function.GetFieldValues("SELECT Anh FROM tblsanpham WHERE MaSP = N'" + txtMaSP.Text + "'");
            picAnh.Image = Image.FromFile(txtAnh.Text);

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;*/
        }
    }
}
