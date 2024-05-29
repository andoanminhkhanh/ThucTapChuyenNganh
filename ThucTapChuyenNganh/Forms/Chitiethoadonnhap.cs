using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;
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
            btnThemhoadon.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyhoadon.Enabled = false;
            btnInhoadon.Enabled = false;
            btnThemsanpham.Enabled = false;

            btnTimkiem.Click += new EventHandler(btnTimkiem_Click);

            Function.FillCombo("SELECT MaNV, TenNV FROM tblnhanvien",cboManhanvien, "MaNV", "MaNV");
            cboManhanvien.SelectedIndex = -1;

            Function.FillCombo("SELECT MaHDN FROM tblchitiethoadonnhap", cboMahoadon,"MaHDN", "MaHDN");
            cboMahoadon.SelectedIndex = -1;

            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMahoadon.Text != "")
            {
                Load_ThongtinHD();
                btnHuyhoadon.Enabled = true;
                btnInhoadon.Enabled = true;
            }
            Load_DataGridViewChitiet();
            
        }

        DataTable tblCTHDN;
        
        private void ResetValues()
        {
            string str;
            //txtMahoadon.Text = Function.CreateKey("HDB");
            txtMahoadon.Text = "";
            txtNgaynhap.Text = DateTime.Now.ToShortDateString();
            cboManhanvien.Text = "";
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";
            //str = "select TenNV from tblnhanvien where MaNV = N'" + cboManhanvien.Text + "'";
            //txtTennhanvien.Text = Class.Function.GetFieldValues(str);
            txtDienthoai.Text = "";
            txtTongtien.Text = "0";
            lblBangchu.Text = "Bằng chữ: ";
            txtMaSP.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }
        
        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "SELECT tblsanpham.MaSP, TenSP, tblchitiethoadonnhap.SoLuong, tblsanpham.DonGiaBan, tblchitiethoadonnhap.Giamgia, (DonGiaNhap*GiamGia*tblchitiethoadonnhap.SoLuong) as Thanhtien FROM (tblchitiethoadonnhap join tblhoadonnhap on tblchitiethoadonnhap.MaHDN=tblhoadonnhap.MaHDN) JOIN tblsanpham on tblchitiethoadonnhap.MaSP=tblsanpham.MaSP";
            tblCTHDN = Function.GetDataToTable(sql);
            DataGridView.DataSource = tblCTHDN;

            DataGridView.Columns[0].HeaderText = "Mã SP";
            DataGridView.Columns[1].HeaderText = "Tên SP";
            DataGridView.Columns[2].HeaderText = "Số lượng";
            DataGridView.Columns[3].HeaderText = "Đơn giá";
            DataGridView.Columns[4].HeaderText = "Giảm giá %";
            DataGridView.Columns[5].HeaderText = "Thành tiền";
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 90;
            DataGridView.Columns[4].Width = 90;
            DataGridView.Columns[5].Width = 90;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void Load_ThongtinHD()
        {
            string str;
            str = "SELECT NgayNhap FROM tblHDN WHERE MaHDN = N'" + txtMahoadon.Text + "'";
            txtNgaynhap.Text = Function.ConvertDateTime(Function.GetFieldValues(str));
            str = "SELECT MaNV FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            cboManhanvien.Text = Class.Function.GetFieldValues(str);
            str = "select TenNV from tblnhanvien where MaNV = N'" + cboManhanvien.Text + "'";
            txtTennhanvien.Text = Class.Function.GetFieldValues(str);
            //Khi kich chon MaNCC thi ten NCC, dia chi, dien thoai se tu dong hien ra
            str = "Select TenNCC from tblnhacungcap where MaNCC= N'" + txtMaNCC.Text + "'";
            txtTenNCC.Text = Function.GetFieldValues(str);
            str = "Select DiaChi from tblnhacungcap where MaNCC = N'" + txtMaNCC.Text + "'";
            txtDiachi.Text = Function.GetFieldValues(str);
            str = "Select DienThoai from tblnhacungcap where MaNCC = N'" + txtMaNCC.Text + "'";
            txtDienthoai.Text = Function.GetFieldValues(str);


            str = "SELECT TongTien FROM tblhoadonnhap WHERE MaHDN = N'" + txtMahoadon.Text + "'";
            txtTongtien.Text = Function.GetFieldValues(str);

            lblBangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(txtTongtien.Text);
        }

        private void btnThemhoadon_Click(object sender, EventArgs e)
        {
            btnHuyhoadon.Enabled = false;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = false;
            btnThemhoadon.Enabled = false;
            txtMahoadon.ReadOnly = true;
            cboManhanvien.Enabled = true;
            ResetValues();
            Load_DataGridViewChitiet();
        }

        private void txtDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHDBan FROM tblHDBan WHERE MaHDBan=N'" + txtMahoadon.Text + "'";
            if (!Function.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtNgaynhap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgaynhap.Focus();
                    return;
                }
                if (cboManhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManhanvien.Focus();
                    return;
                }
                if (txtMaNCC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNCC.Focus();
                    return;
                }
                //lưu thông tin chung vào bảng tblhdban
                /*
                sql = "INSERT INTO tblHDBan(MaHDBan, Ngayban, Manhanvien, Makhach, Tongtien) VALUES(N'" + txtMahoadon.Text.Trim() + "', '" +
                        Function.ConvertDateTime(txtNgaynhap.Text.Trim()) + "',N'" + cboManhanvien.SelectedValue + "',N'" +
                        txtMaNCC.SelectedValue + "'," + txtTongtien.Text + ")";*/
                Function.RunSql(sql);
            }

            // Lưu thông tin của các mặt hàng
            if (txtMaSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtMaSP.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            if (txtGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtGiamgia.Focus();
                return;
            }
            //sql = "SELECT Mahang FROM tblChitietHDBan WHERE MaHang=N'" + txtMaSP.SelectedValue + "' AND MaHDBan = N'" + txtMahoadon.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ResetValuesHang();
                txtMaSP.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            /*sl = Convert.ToDouble(Function.GetFieldValues("SELECT Soluong FROM tblHang WHERE Mahang = N'" + txtMahoadon.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }*/
            //sql = "INSERT INTO tblChitietHDBan(MaHDBan,Mahang,Soluong,Dongia,Giamgia, Thanhtien) VALUES(N'" + txtMahoadon.Text.Trim() + "', N'" + txtMaSP.SelectedValue + "'," + txtSoluong.Text + ",," + txtSoluong.Text + "," + txtGiamgia.Text + "," + txtThanhtien.Text + ")";
            Function.RunSql(sql);
            Load_DataGridViewChitiet();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            //SLcon = sl - Convert.ToDouble(txtSoluong.Text);
            //sql = "UPDATE tblHang SET Soluong =" + SLcon + " WHERE Mahang= N'" + txtMaSP.SelectedValue + "'";
            Function.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán

            tong = Convert.ToDouble(Function.GetFieldValues("SELECT Tongtien FROM tblHDBan WHERE MaHDBan = N'" + txtMahoadon.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "UPDATE tblHDBan SET Tongtien =" + Tongmoi + " WHERE MaHDBan = N'" + txtMahoadon.Text + "'";
            Function.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(Tongmoi.ToString());
            //ResetValuesHang();
            btnXoaSP.Enabled = true;
            btnThemhoadon.Enabled = true;
            btnInhoadon.Enabled = true;

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {

        }
    }
}
