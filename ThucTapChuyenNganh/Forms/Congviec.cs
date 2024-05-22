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
    public partial class Congviec : Form
    {
        public Congviec()
        {
            InitializeComponent();
        }

        private void Congviec_Load(object sender, EventArgs e)
        {

            txtMaCV.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            load_datagrid();
        }

        DataTable tblcv;
        private void load_datagrid()
        {
            string sql;
            sql = "select MaCV, TenCV, HeSoLuong from tblcongviec";
            tblcv = Class.Function.GetDataToTable(sql);
            dgridCongViec.DataSource = tblcv;
            dgridCongViec.Columns[0].HeaderText = "Mã công việc";
            dgridCongViec.Columns[1].HeaderText = "Tên công việc";
            dgridCongViec.Columns[2].HeaderText = "Hệ số lương";
            dgridCongViec.AllowUserToAddRows = false;
            dgridCongViec.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridCongViec_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Ban dang o che do them moi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblcv.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtMaCV.Text = dgridCongViec.CurrentRow.Cells["MaCV"].Value.ToString();
            txtTenCV.Text = dgridCongViec.CurrentRow.Cells["TenCV"].Value.ToString();
            txtHeSoLuong.Text = dgridCongViec.CurrentRow.Cells["HeSoLuong"].Value.ToString();
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
            resetvalue();
            txtMaCV.Enabled = true;
            txtMaCV.Focus();
        }

        private void resetvalue()
        {
            txtMaCV.Text = "";
            txtTenCV.Text = "";
            txtHeSoLuong.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaCV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }
            if (txtTenCV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCV.Focus();
                return;
            }
            if (txtHeSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập hệ số lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHeSoLuong.Focus();
                return;
            }
            sql = "SELECT MaCV FROM tblcongviec WHERE MaCV = N'" + txtMaCV.Text.Trim() + "'";
            if (Class.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thôngbáo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                txtMaCV.Text = "";
                return;
            }
            sql = "INSERT INTO tblcongviec(MaCV,TenCV, HeSoLuong) VALUES(N'" + txtMaCV.Text + "',N'" + txtTenCV.Text + "',N'" + txtHeSoLuong.Text + "')";
            Class.Function.RunSql(sql);
            load_datagrid();
            resetvalue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaCV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblcv.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            if (txtMaCV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenCV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCV.Focus();
                return;
            }
            sql = "UPDATE tblcongviec SET TenCV=N'" + txtTenCV.Text.ToString() + "' WHERE MaCV=N'" + txtMaCV.Text + "'";
            Class.Function.RunSql(sql);
            load_datagrid();
            resetvalue();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblcv.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            if (txtMaCV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblcongviec WHERE MaCV=N'" + txtMaCV.Text + "'";
                Class.Function.RunSqlDel(sql);
                load_datagrid();
                resetvalue();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            resetvalue();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaCV.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
