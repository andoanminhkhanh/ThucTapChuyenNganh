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
    public partial class Mausanpham : Form
    {
        public Mausanpham()
        {
            InitializeComponent();
        }

        private void Mausanpham_Load(object sender, EventArgs e)
        {
            txtMamau.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            load_data();
        }
        DataTable tblmau;
        private void load_data() 
        {
            string sql;
            sql = "select Mamau,Tenmau from tblmau";
            tblmau = Class.Function.GetDataToTable(sql);
            dgridMausanpham.DataSource = tblmau;
            dgridMausanpham.Columns[0].HeaderText = "Mã màu";
            dgridMausanpham.Columns[1].HeaderText = "Tên màu";
            dgridMausanpham.AllowUserToAddRows = false;
            dgridMausanpham.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridMausanpham_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblmau.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtMamau.Text = dgridMausanpham.CurrentRow.Cells["Mamau"].Value.ToString();
            txtTenmau.Text = dgridMausanpham.CurrentRow.Cells["Tenmau"].Value.ToString();
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
            txtMamau.Enabled = true;
            txtMamau.Focus();
            ResetValues();
        }
        private void ResetValues()
        {
            txtMamau.Text = "";
            txtTenmau.Text = "";
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMamau.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMamau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMamau.Focus();
                return;
            }
            if (txtTenmau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenmau.Focus();
                return;
            }
            sql = "select Mamau from tblmau where Mamau = N'" + txtMamau.Text.Trim() + "'";
            if (Class.Function.CheckKey(sql))
            {
            MessageBox.Show("Mã màu này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtMamau.Focus();
            txtMamau.Text = "";
            }
            sql = "insert into tblmau(Mamau,Tenmau) values (N'" + txtMamau.Text + "',N'" + txtTenmau.Text + "')";
            Class.Function.RunSql(sql);
            load_data();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            txtMamau.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblmau.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMamau.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenmau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenmau.Focus();
                return;
            }
            sql = "Update tblmau set Tenmau=N'" + txtTenmau.Text.Trim().ToString()  + "' where Mamau=N'" + txtMamau.Text + "'";
            Class.Function.RunSql(sql);
            load_data();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblmau.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMamau.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Ban co chac chan xoa khong?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                sql = "delete tblmau where Mamau =N'" + txtMamau.Text + "'";
                Class.Function.RunSql(sql);
                load_data();
                ResetValues();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMamau_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB]");
        }
    }
}
