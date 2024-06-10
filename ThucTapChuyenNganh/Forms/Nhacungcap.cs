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
    public partial class Nhacungcap : Form
    {
        public Nhacungcap()
        {
            InitializeComponent();
        }

        private void Nhacungcap_Load(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            load_datagrid();
        }

        DataTable tblncc;
        private void load_datagrid()
        {
            string sql;
            sql = "select MaNCC, TenNCC, DiaChi, DienThoai from tblnhacungcap";
            tblncc = Class.Function.GetDataToTable(sql);
            drgidNhaCungCap.DataSource = tblncc;
            drgidNhaCungCap.Columns[0].HeaderText = "Mã nhà cung cấp";
            drgidNhaCungCap.Columns[1].HeaderText = "Tên nhà cung cấp";
            drgidNhaCungCap.Columns[2].HeaderText = "Địa chỉ";
            drgidNhaCungCap.Columns[3].HeaderText = "Điện thoại";
            drgidNhaCungCap.Columns[0].Width = 140;
            drgidNhaCungCap.Columns[1].Width = 240;
            drgidNhaCungCap.Columns[2].Width = 300;
            drgidNhaCungCap.Columns[3].Width = 140;
            drgidNhaCungCap.AllowUserToAddRows = false;
            drgidNhaCungCap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void drgidNhaCungCap_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Ban dang o che do them moi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtMaNCC.Text = drgidNhaCungCap.CurrentRow.Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = drgidNhaCungCap.CurrentRow.Cells["MaNCC"].Value.ToString();
            txtDiaChi.Text = drgidNhaCungCap.CurrentRow.Cells["DiaChi"].Value.ToString();
            mtxtDienThoai.Text = drgidNhaCungCap.CurrentRow.Cells["DienThoai"].Value.ToString();
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
            txtMaNCC.Enabled = true;
            txtMaNCC.Focus();
        }

        private void resetvalue()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            mtxtDienThoai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (mtxtDienThoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            sql = "SELECT MaNCC FROM tblnhacungcap WHERE MaNCC = N'" + txtMaNCC.Text.Trim() + "'";
            if (Class.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã có, bạn phải nhập mã khác", "Thôngbáo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                txtMaNCC.Text = "";
                return;
            }
            sql = "INSERT INTO tblnhacungcap(MaNCC,TenNCC, DiaChi, DienThoai) VALUES(N'" + txtMaNCC.Text + "',N'" + txtTenNCC.Text + "',N'" + txtDiaChi.Text + "',N'" + mtxtDienThoai.Text + "')";
            Class.Function.RunSql(sql);
            load_datagrid();
            resetvalue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNCC.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return;
            }
            sql = "UPDATE tblnhacungcap SET TenNCC=N'" + txtTenNCC.Text.ToString() + "' WHERE MaNCC=N'" + txtMaNCC.Text + "'";
            Class.Function.RunSql(sql);
            load_datagrid();
            resetvalue();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblnhacungcap WHERE MaNCC=N'" + txtMaNCC.Text + "'";
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
            txtMaNCC.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
