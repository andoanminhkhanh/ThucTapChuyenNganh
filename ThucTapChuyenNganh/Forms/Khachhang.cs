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
    public partial class Khachhang : Form
    {
        public Khachhang()
        {
            InitializeComponent();
        }

        private void Khachhang_Load(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            load_data();
        }
        DataTable tblkh;
        private void load_data()
        {
            string sql;
            sql = "select MaKH,TenKH,DiaChi,DienThoai from tblkhachhang";
            tblkh = Class.Function.GetDataToTable(sql);
            dgridKhachhang.DataSource = tblkh;
            dgridKhachhang.Columns[0].HeaderText = "Mã khách hàng";
            dgridKhachhang.Columns[1].HeaderText = "Tên khách hàng";
            dgridKhachhang.Columns[2].HeaderText = "Địa chỉ";
            dgridKhachhang.Columns[3].HeaderText = "Điện thoại";
            dgridKhachhang.AllowUserToAddRows = false;
            dgridKhachhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridKhachhang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Dang o che do them moi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtMaKH.Text = dgridKhachhang.CurrentRow.Cells["makh"].Value.ToString();
            txtTenKH.Text = dgridKhachhang.CurrentRow.Cells["tenkh"].Value.ToString();
            txtDiaChi.Text = dgridKhachhang.CurrentRow.Cells["diachi"].Value.ToString();
            mskDienThoai.Text = dgridKhachhang.CurrentRow.Cells["dienthoai"].Value.ToString();
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
            ResetValue();
            txtMaKH.Text = Class.Function.CreateKey("KH");
            load_data();
        }
        private void ResetValue()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            mskDienThoai.Text = "";
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaKH.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "select MaKH from tblkhachhang where MaKH = N'" + txtMaKH.Text + "'";
            //if (txtMaKH.Text == "")
            //{
                //MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtMaKH.Focus();
                //return;
            //}
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKH.Focus();
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return;
            }
            if (mskDienThoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskDienThoai.Focus();
                return;
            }
            //ktra trung ma
            //string sql;
            //sql = "select MaKH from tblkhachhang where MaKH = N'" + txtMaKH.Text.Trim() + "'";
            //if (Class.Function.CheckKey(sql))
            //{
                //MessageBox.Show("Mã khách hàng này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtMaKH.Focus();
                //txtMaKH.Text = "";
            //}
            sql = "insert into tblkhachhang(MaKH,TenKH,DiaChi,DienThoai) values (N'" + txtMaKH.Text + "',N'" + txtTenKH.Text + "',N'" + txtDiaChi.Text + "','" + mskDienThoai.Text + "')";
            Class.Function.RunSql(sql);
            load_data();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            txtMaKH.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (mskDienThoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienThoai.Focus();
                return;
            }
            sql = "Update tblkhachhang set TenKH=N'" + txtTenKH.Text.Trim().ToString() + "',DiaChi=N'" + txtDiaChi.Text.Trim().ToString() + "',DienThoai=N'" + mskDienThoai.Text.ToString() + "' where MaKH=N'" + txtMaKH.Text + "'";
            Class.Function.RunSql(sql);
            load_data();
            ResetValue();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Ban co chac chan xoa khong?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "delete tblkhachhang where MaKh =N'" + txtMaKH.Text + "'";
                Class.Function.RunSqlDel(sql);
                load_data();
                ResetValue();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB]");
        }

        private void txtDiaChi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB]");
        }
    }
}
