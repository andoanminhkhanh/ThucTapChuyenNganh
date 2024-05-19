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
    public partial class Sanpham : Form
    {
        public Sanpham()
        {
            InitializeComponent();
        }
        DataTable tblSP;
        private void Sanpham_Load(object sender, EventArgs e)
        {
            
            txtMaSP.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            Function.Fillcombo("SELECT MaMau, TenMau FROM tblmau", cboMamau, "MaMau", "TenMau");
            cboMamau.SelectedIndex = -1;
            Function.Fillcombo("SELECT MaLoai, TheLoai FROM tbltheloai", cboMaloai, "MaLoai", "TheLoai");
            cboMaloai.SelectedIndex = -1;
            ResetValues();
            Load_DataGridView();
        }
       
        private void ResetValues()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            cboMaloai.Text = "";
            txtSize.Text = "";
            cboMamau.Text = "";
            txtSoluong.Text = "";
            txtAnh.Text = "";
            txtDongianhap.Text = "0";
            txtDongiaban.Text = "0";
            txtDongianhap.Enabled = false;
            txtDongiaban.Enabled = false;
            txtAnh.Text = "";
            picAnh.Image = null;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT tblsanpham.MaSP, TenSP, MaLoai, Size, MaMau, tblsanpham.SoLuong, Anh, DonGiaNhap, DonGiaBan FROM(tblsanpham JOIN tblchitiethoadonnhap ON tblsanpham.MaSP = tblchitiethoadonnhap.MaSP) JOIN tblchitiethoadonban ON tblsanpham.MaSP = tblchitiethoadonban.MaSP";
            tblSP = Function.GetDataToTable(sql);
            DataGridView.DataSource = tblSP;
            DataGridView.Columns[0].HeaderText = "Mã sản phẩm";
            DataGridView.Columns[1].HeaderText = "Tên sản phẩm";
            DataGridView.Columns[2].HeaderText = "Mã loại";
            DataGridView.Columns[3].HeaderText = "Size";
            DataGridView.Columns[4].HeaderText = "Mã màu";
            DataGridView.Columns[5].HeaderText = "Số lượng";
            DataGridView.Columns[6].HeaderText = "Ảnh";
            DataGridView.Columns[7].HeaderText = "Đơn giá nhập";
            DataGridView.Columns[8].HeaderText = "Đơn giá bán";
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            string maloai, mamau;
            if (tblSP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtMaSP.Text = DataGridView.CurrentRow.Cells["MaSP"].Value.ToString();
            txtTenSP.Text = DataGridView.CurrentRow.Cells["TenSP"].Value.ToString();
            maloai = DataGridView.CurrentRow.Cells["MaLoai"].Value.ToString();
            cboMaloai.Text = Function.GetFieldValues("SELECT TheLoai FROM tbltheloai WHERE MaLoai = N'" + maloai + "'");
            txtSize.Text = DataGridView.CurrentRow.Cells["Size"].Value.ToString();
            mamau = DataGridView.CurrentRow.Cells["MaMau"].Value.ToString();
            cboMamau.Text = Function.GetFieldValues("SELECT TenMau FROM tblmau WHERE MaMau = N'" + mamau + "'");
            txtSoluong.Text = DataGridView.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDongianhap.Text = DataGridView.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtDongiaban.Text = DataGridView.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            txtAnh.Text = Function.GetFieldValues("SELECT Anh FROM tblsanpham WHERE MaSP = N'" + txtMaSP.Text + "'");
            picAnh.Image = Image.FromFile(txtAnh.Text);

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSP.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSP.Focus();
                return;
            }
            if (txtTenSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenSP.Focus();
                return;
            }
            if (cboMaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMaloai.Focus();
                return;
            }
            if (txtSize.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập size", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSize.Focus();
                return;
            }
            if (cboMamau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMamau.Focus();
                return;
            }
            if (txtSoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoluong.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAnh.Focus();
                return;
            }
            sql = "UPDATE tblsanpham SET  TenSP=N'" + txtTenSP.Text.Trim().ToString() + "',MaLoai=N'" + cboMaloai.SelectedValue.ToString() + "',MaMau=N'" + cboMamau.SelectedValue.ToString() +
                "',Size =N'" + txtSize.Text.Trim()+ "',SoLuong=N'" + txtSoluong.Text.Trim() + "',Anh='" + txtAnh.Text + "' WHERE MaSP=N'" + txtMaSP.Text + "'";
            Function.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSP.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblsanpham WHERE MaSP=N'" + txtMaSP.Text + "'";
                Function.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();

            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtMaSP.Enabled = false;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "JPG|*.jpg|GIF|*.gif|Allfile|*.*";
            dlgOpen.InitialDirectory = "C:\\";
            dlgOpen.FilterIndex = 3;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaSP.Text == "") && (txtTenSP.Text == "") && (cboMaloai.Text =="") && (cboMamau.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "SELECT * FROM tblsanpham WHERE 1=1";
            if (txtMaSP.Text != "")
                sql = sql + " AND MaSP Like N'%" + txtMaSP.Text + "%'";
            if (txtTenSP.Text != "")
                sql = sql + " AND TenSP Like N'%" + txtTenSP.Text + "%'";
            if (cboMaloai.Text != "")
                sql = sql + " AND MaLoai Like N'%" + cboMaloai.SelectedValue + "%'";
            if (cboMamau.Text != "")
                sql = sql + " AND MaMau Like N'%" + cboMamau.SelectedValue + "%'";
            tblSP = Function.GetDataToTable(sql);
            if (tblSP.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Có " + tblSP.Rows.Count + " bản ghi thỏa mãn điều kiện!!!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            DataGridView.DataSource = tblSP;
            ResetValues();

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
