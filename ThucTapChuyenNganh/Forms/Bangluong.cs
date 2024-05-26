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
           
            manv = DataGridView.CurrentRow.Cells["MaNV"].Value.ToString();
            cboMaNV.Text = Function.GetFieldValues("SELECT MaNV FROM tblnhanvien WHERE MaNV = N'" + manv + "'");
            txtThang.Text = DataGridView.CurrentRow.Cells["Thang"].Value.ToString();
            txtNam.Text = DataGridView.CurrentRow.Cells["Nam"].Value.ToString();
            btnSua.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {           
                ResetValues();
                btnBoqua.Enabled = false;
                btnSua.Enabled = true;
                btnDong.Enabled = false;
                btnTim.Enabled = false;
                cboMaNV.Enabled = false;            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
