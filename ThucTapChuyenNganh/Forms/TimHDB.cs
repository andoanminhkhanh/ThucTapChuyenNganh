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
            if ((txtMaHDB.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") && (txtMaNV.Text == "") && (txtMaKH.Text == "") && (txtTongTien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblhoadonban WHERE 1=1";
            if (txtMaHDB.Text != "")
                sql = sql + " AND MaHDB Like N'%" + txtMaHDB.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(NgayBan) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(NgayBan) =" + txtNam.Text;
            if (txtMaNV.Text != "")
                sql = sql + " AND MaNV Like N'%" + txtMaNV.Text + "%'";
            if (txtMaKH.Text != "")
                sql = sql + " AND MaKH Like N'%" + txtMaKH.Text + "%'";
            if (txtTongTien.Text != "")
                sql = sql + " AND Tongtien <=" + txtTongTien.Text;
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
            dgridTimHDB.Columns[0].Width = 150;
            dgridTimHDB.Columns[1].Width = 100;
            dgridTimHDB.Columns[2].Width = 80;
            dgridTimHDB.Columns[3].Width = 80;
            dgridTimHDB.Columns[4].Width = 80;
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
    }
}
