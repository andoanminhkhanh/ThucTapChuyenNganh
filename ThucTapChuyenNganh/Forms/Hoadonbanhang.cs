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
    public partial class Hoadonbanhang : Form
    {
        public Hoadonbanhang()
        {
            InitializeComponent();
        }
        DataTable tblcthdb;
        private void Hoadonbanhang_Load(object sender, EventArgs e)
        {
            btnThemhoadon.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyhoadon.Enabled = false;
            btnInhoadon.Enabled = false;
            txtMahoadon.ReadOnly = true;
            txtTennhanvien.Enabled = true;
            txtTenkhachhang.Enabled = true;
            txtDiachi.Enabled = true;
            mskDienthoai.Enabled = true;
            txtTenhang.ReadOnly = true;
            txtDongia.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtGiamgia.Text = "0";
            txtTongtien.Text = "0";
            Class.Function.Fillcombo ("SELECT Manhanvien, Tennhanvien FROM tblnhanvien", cboManhanvien, "Manhanvien", "Tennhanvien");
            cboManhanvien.SelectedIndex = -1;
            Class.Function.Fillcombo ("SELECT MaSP, TenSP FROM  tblsanpham",cboMahang, "MaSP", "TenSP");
            cboMahang.SelectedIndex = -1;
            Class.Function.Fillcombo ("SELECT MaHDB FROM tblchitiethoadonban", cboMahoadon, "MaHDB", "MaHDB");
            cboMahoadon.SelectedIndex = -1;
            if (txtMahoadon.Text != "")
            {
                //Load_ThongtinHD();
                btnHuyhoadon.Enabled = true;
                btnInhoadon.Enabled=true;
            }
            Load_data();
        }
        private void Load_data()
        {
            string sql;
            sql = "select a.MaSP, b.TenSP, a.Soluong, b.DonGiaBan, a.GiamGia, a.ThanhTien from tblchitiethoadonban as a, tblsanpham as b where a.MaHDB = N'" + txtMahoadon.Text + "' and a.MaSP = b.MaSP";
            tblcthdb = Class.Function.GetDataToTable(sql);
            dgridChitiet.DataSource = tblcthdb;
            dgridChitiet.Columns[0].HeaderText = "Mã sản phẩm";
            dgridChitiet.Columns[1].HeaderText = "Tên sản phẩm";
            dgridChitiet.Columns[2].HeaderText = "Số lượng";
            dgridChitiet.Columns[3].HeaderText = "Đơn giá";
            dgridChitiet.Columns[4].HeaderText = "Giảm giá %";
            dgridChitiet.Columns[5].HeaderText = "Thành tiền";
            dgridChitiet.Columns[0].Width = 80;
            dgridChitiet.Columns[1].Width = 100;
            dgridChitiet.Columns[2].Width = 80;
            dgridChitiet.Columns[3].Width = 90;
            dgridChitiet.Columns[4].Width = 90;
            dgridChitiet.Columns[5].Width = 90;
            dgridChitiet.AllowUserToAddRows = false;
            dgridChitiet.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD()
        {
            string str;
            str = "SELECT Ngayban FROM tblchitiethoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            txtNgayban.Text = Class.Function.ConvertDateTime(Class.Function.GetFieldValues(str));
            str = "SELECT Manhanvien FROM tblchitiethoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            cboManhanvien.Text = Class.Function.GetFieldValues(str);

            str = "SELECT Makhach FROM tblchitiethoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";

            str = "SELECT Tongtien FROM tblchitiethoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            txtTongtien.Text = Class.Function.GetFieldValues(str);

            lblBangchu.Text = "Bằng chữ: " +
            Class.Function.ChuyenSoSangChu(txtTongtien.Text);
        }
    }
}
