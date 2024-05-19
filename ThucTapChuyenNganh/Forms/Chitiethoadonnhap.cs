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
            Class.Function.Fillcombo("SELECT Manhanvien, Tennhanvien FROM tblnhanvien", cboManhanvien, "Manhanvien", "Tennhanvien");
            cboManhanvien.SelectedIndex = -1;
            Class.Function.Fillcombo("SELECT MaSP, TenSP FROM  tblsanpham", cboMaSP, "MaSP", "TenSP");
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
    }
}
