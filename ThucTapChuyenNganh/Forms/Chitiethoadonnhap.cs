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
    public partial class Chitiethoadonnhap : Form
    {
        public Chitiethoadonnhap()
        {
            InitializeComponent();
        }

        private void Chitiethoadonnhap_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            txtMahoadon.ReadOnly = true;

            cboManhanvien.Enabled = false;
            txtTennhanvien.Enabled = true;
            txtTenNCC.Enabled = true;
            txtDiachi.Enabled = true;
            mskDienthoai.Enabled = true;
            txtTenSP.ReadOnly = true;
            txtDongia.ReadOnly = true;
            //txtTongtien.ReadOnly = true;
            txtGiamgia.Text = "0";
            txtTongtien.Text = "0";
            Load_DataGridView();
           // Function.Fillcombo("SELECT MaNV, TenNV FROM tblnhanvien", cboManhanvien, "MaNV", "TenNV");
            //cboManhanvien.SelectedIndex = -1;
            //Class.Function.Fillcombo("SELECT MaHDN FROM tblchitiethoadonnhap", cboMahoadon, "MaHDN", "MaHDN");
            //cboMahoadon.SelectedIndex = -1;
            if (txtMahoadon.Text != "")
            {
                //Load_ThongtinHD();
                btnHuyhoadon.Enabled = true;
                btnInhoadon.Enabled = true;
            }
            ResetValues();
        }
        DataTable tblCTHDN;
        private void ResetValues()
        {
            /*txtMaSP.Text = "";
            txtTenSP.Text = "";
            cboMaloai.Text = "";
            txtSize.Text = "";
            cboMamau.Text = "";
            txtSoluong.Text = "";
            txtAnh.Text = "";
            txtDongianhap.Text = "0";
            txtDongiaban.Text = "0";
            txtDongianhap.Enabled = false;
            txtDongiaban.Enabled = false;
            txtAnh.Text = "";
            picAnh.Image = null;*/
        }
        
        private void Load_DataGridView()
        {
            string sql;
            //sql = "select tblsanpham.MaSP, tblsanpham.TenSP, tblchitiethoadonban.Soluong, tblchitiethoadonban.DonGiaBan, tblchitiethoadonban.GiamGia, (tblchitiethoadonban.DonGiaBan*tblchitiethoadonban.SoLuong*(1-tblchitiethoadonban.GiamGia)) as ThanhTien from tblsanpham JOIN tblchitiethoadonban ON tblsanpham.MaSP=tblchitiethoadonban.MaSP";
            //tblCTHDN = Class.Function.GetDataToTable(sql);
            DataGridView.DataSource = tblCTHDN;
            DataGridView.Columns[0].HeaderText = "Mã sản phẩm";
            DataGridView.Columns[1].HeaderText = "Tên sản phẩm";
            DataGridView.Columns[2].HeaderText = "Số lượng";
            DataGridView.Columns[3].HeaderText = "Đơn giá";
            DataGridView.Columns[4].HeaderText = "Giảm giá %";
            DataGridView.Columns[5].HeaderText = "Tổng tiền";
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
    }
}
