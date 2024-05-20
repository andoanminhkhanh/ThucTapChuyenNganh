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
    public partial class Chitiethoadonnhap : Form
    {
        public Chitiethoadonnhap()
        {
            InitializeComponent();
        }

        private void Chitiethoadonnhap_Load(object sender, EventArgs e)
        {
            btnThemhoadon.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyhoadon.Enabled = false;
            btnInhoadon.Enabled = false;
            txtMahoadon.ReadOnly = true;
            txtTennhanvien.Enabled = true;
            txtTenNCC.Enabled = true;
            txtDiachi.Enabled = true;
            mskDienthoai.Enabled = true;
            txtTenSP.ReadOnly = true;
            txtDongia.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtGiamgia.Text = "0";
            txtTongtien.Text = "0";
            Class.Function.Fillcombo("SELECT MaNV, TenNV FROM tblnhanvien", cboManhanvien, "Tennhanvien", "Manhanvien");
            cboManhanvien.SelectedIndex = -1;
            Class.Function.Fillcombo("SELECT MaSP, TenSP FROM  tblsanpham", cboMaSP, "TenSP", "MaSP");
            cboMaSP.SelectedIndex = -1;
            Class.Function.Fillcombo("SELECT MaHDB FROM tblchitiethoadonban", cboMahoadon, "MaHDB", "MaHDB");
            cboMahoadon.SelectedIndex = -1;
            if (txtMahoadon.Text != "")
            {
                //Load_ThongtinHD();
                btnHuyhoadon.Enabled = true;
                btnInhoadon.Enabled = true;
            }
            Load_data();
        }
        DataTable tblCTHDN;
        private void Load_data()
        {
            string sql;
            sql = "select tblsanpham.MaSP, tblsanpham.TenSP, tblchitiethoadonban.Soluong, tblchitiethoadonban.DonGiaBan, tblchitiethoadonban.GiamGia, (tblchitiethoadonban.DonGiaBan*tblchitiethoadonban.SoLuong*(1-tblchitiethoadonban.GiamGia)) as ThanhTien from tblsanpham JOIN tblchitiethoadonban ON tblsanpham.MaSP=tblchitiethoadonban.MaSP";
            tblCTHDN = Class.Function.GetDataToTable(sql);
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
