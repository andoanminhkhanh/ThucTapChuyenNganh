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
            txtMaNV.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtThang.Text = "";
            txtNam.Text = "";
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblbangluong";
            tblBL = Function.GetDataToTable(sql);
            DataGridView.DataSource = tblBL;
            DataGridView.Columns[0].HeaderText = "Mã nhân viên";
            DataGridView.Columns[1].HeaderText = "Tên nhân viên";
            DataGridView.Columns[2].HeaderText = "Năm";
            DataGridView.Columns[3].HeaderText = "Tháng";
            DataGridView.Columns[4].HeaderText = "Tổng giờ làm";
            DataGridView.Columns[5].HeaderText = "Tổng tiền lương";
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

    }
}
