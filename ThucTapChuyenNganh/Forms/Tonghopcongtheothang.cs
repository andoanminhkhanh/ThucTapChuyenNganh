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
    public partial class Tonghopcongtheothang : Form
    {
        public Tonghopcongtheothang()
        {
            InitializeComponent();
        }

        private void Tonghopcongtheothang_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgridCongtheothang.DataSource = null;
        }
        DataTable tblCongtheothang;

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtThang.Focus();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtThang.Text == "") && (txtNam.Text == "") && (txtMaNV.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblchamcong WHERE 1=1";

            if (txtThang.Text != "")
                sql = sql + " AND MONTH(NgayBan) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(NgayBan) =" + txtNam.Text;
            if (txtMaNV.Text != "")
                sql = sql + " AND MaNV Like N'%" + txtMaNV.Text + "%'";
            tblCongtheothang = Function.GetDataToTable(sql);

            if (tblCongtheothang.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblCongtheothang.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridCongtheothang.DataSource = tblCongtheothang;
            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            dgridCongtheothang.Columns[0].HeaderText = "Mã nhân viên";
            dgridCongtheothang.Columns[1].HeaderText = "NgayLam";
            dgridCongtheothang.Columns[2].HeaderText = "GioLam";
            dgridCongtheothang.Columns[0].Width = 150;
            dgridCongtheothang.Columns[1].Width = 100;
            dgridCongtheothang.Columns[2].Width = 80;
            dgridCongtheothang.AllowUserToAddRows = false;
            dgridCongtheothang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
    }
}
