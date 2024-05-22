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
    public partial class Loaisanpham : Form
    {
        public Loaisanpham()
        {
            InitializeComponent();
        }

        private void Loaisanpham_Load(object sender, EventArgs e)
        {
            txtMaloai.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            load_data();
        }
        DataTable tblloai;
        private void load_data()
        {
            string sql;
            sql = "select MaLoai,TheLoai from tbltheloai";
            tblloai = Class.Function.GetDataToTable(sql);
            dgridLoaisanpham.DataSource = tblloai;
            dgridLoaisanpham.Columns[0].HeaderText = "Mã loại";
            dgridLoaisanpham.Columns[1].HeaderText = "Tên loại";
            dgridLoaisanpham.Columns[0].Width = 255;
            dgridLoaisanpham.Columns[1].Width = 255;
            dgridLoaisanpham.AllowUserToAddRows = false;
            dgridLoaisanpham.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridLoaisanpham_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblloai.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtMaloai.Text = dgridLoaisanpham.CurrentRow.Cells["MaLoai"].Value.ToString();
            txtTenloai.Text = dgridLoaisanpham.CurrentRow.Cells["TheLoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoqua.Enabled = true;
            txtMaloai.Enabled = true;
            txtMaloai.Focus();
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaloai.Text = "";
            txtTenloai.Text = "";
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaloai.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaloai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaloai.Focus();
                return;
            }
            if (txtTenloai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenloai.Focus();
                return;
            }
            sql = "select MaLoai from tbltheloai where MaLoai = N'" + txtMaloai.Text.Trim() + "'";
            if (Class.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã loại này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaloai.Focus();
                txtMaloai.Text = "";
            }
            sql = "insert into tbltheloai(MaLoai,TheLoai) values (N'" + txtMaloai.Text + "',N'" + txtTenloai.Text + "')";
            Class.Function.RunSql(sql);
            load_data();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            txtMaloai.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblloai.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaloai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenloai.Focus();
                return;
            }
            sql = "Update tbltheloai set TheLoai=N'" + txtTenloai.Text.Trim().ToString() + "' where Maloai=N'" + txtMaloai.Text + "'";
            Class.Function.RunSql(sql);
            load_data();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblloai.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaloai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                sql = "delete tbltheloai where Maloai =N'" + txtMaloai.Text + "'";
                Class.Function.RunSqlDel(sql);
                load_data();
                ResetValues();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
