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
            Class.Function.Fillcombo("SELECT MaNV, TenNV FROM tblnhanvien", cboMaNV, "MaNV", "TenNV");
            cboMaNV.SelectedIndex = -1;
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
           
            manv = DataGridView.CurrentRow.Cells["MaNV"].Value.ToString();
            cboMaNV.Text = Function.GetFieldValues("SELECT MaNV FROM tblnhanvien WHERE MaNV = N'" + manv + "'");
            txtThang.Text = DataGridView.CurrentRow.Cells["Thang"].Value.ToString();
            txtNam.Text = DataGridView.CurrentRow.Cells["Nam"].Value.ToString();
            btnBoqua.Enabled = true;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {           
                ResetValues();
                btnBoqua.Enabled = false;
                btnDong.Enabled = true;
                btnTim.Enabled = true;
                cboMaNV.Enabled = true;
                Load_DataGridView();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cboMaNV.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") )
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "SELECT * FROM tblbangluong WHERE 1=1";
            if (txtThang.Text != "")
                sql = sql + " AND Thang Like N'%" + txtThang.Text + "%'";
            if (txtNam.Text != "")
                sql = sql + " AND Nam Like N'%" + txtNam.Text + "%'";
            if (cboMaNV.Text != "")
                sql = sql + " AND MaNV Like N'%" + cboMaNV.SelectedValue + "%'";
            tblBL = Function.GetDataToTable(sql);
            if (tblBL.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Có " + tblBL.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DataGridView.DataSource = tblBL;
            btnBoqua.Enabled = true;
            ResetValues();
        }

        private void txtTong_TextChanged(object sender, EventArgs e)
        {
            double tt;
            /*
            tt = sl * dg - sl * dg * gg / 100;
            txtTong.Text = tt.ToString();*/

        }
    }
}
