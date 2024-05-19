using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThucTapChuyenNganh.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ThucTapChuyenNganh.Forms
{
    public partial class Hoadonbanhang : Form
    {
        public Hoadonbanhang()
        {
            InitializeComponent();
        }
        DataTable tblcthdb;
        DataTable tblkh;
        private void Hoadonbanhang_Load(object sender, EventArgs e)
        {
            btnThemhoadon.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyhoadon.Enabled = false;
            btnInhoadon.Enabled = false;
            txtMahoadon.ReadOnly = true;
            txtTennhanvien.ReadOnly = true;
            txtMakhachhang.ReadOnly = true;
            txtTenkhachhang.Enabled = false;
            txtDiachi.Enabled = false;
            txtDienthoai.Enabled = true ;
            txtTenhang.ReadOnly = true;
            txtDongia.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtGiamgia.Text = "0";
            txtTongtien.Text = "0";
            //Class.Function.Fillcombo("SELECT MaKH, TenKH FROM tblkhachhang", cboMakhachhang, "MaKH", "TenKH");
            //cboManhanvien.SelectedIndex = -1;
            Class.Function.Fillcombo("SELECT MaNV, TenNV FROM tblnhanvien", cboManhanvien, "MaNV", "MaNV");
            cboManhanvien.SelectedIndex = -1;
            Class.Function.Fillcombo("select MaSP, TenSP from tblsanpham", cboMasanpham, "MaSP", "TenSP");
            cboMasanpham.SelectedIndex = -1;
            Class.Function.Fillcombo("SELECT MaHDB FROM tblchitiethoadonban", cboMahoadon, "MaHDB", "MaHDB");
            cboMahoadon.SelectedIndex = -1;
            if (txtMahoadon.Text != "")
            {
                Load_ThongtinHD();
                btnHuyhoadon.Enabled = true;
                btnInhoadon.Enabled = true;
            }
            Load_data();
        }
        private void Load_data()
        {
            string sql;
            sql = "select tblsanpham.MaSP, tblsanpham.TenSP, tblchitiethoadonban.Soluong, tblchitiethoadonban.DonGiaBan, tblchitiethoadonban.GiamGia, (tblchitiethoadonban.DonGiaBan*tblchitiethoadonban.SoLuong*(1-tblchitiethoadonban.GiamGia)) as ThanhTien from tblsanpham JOIN tblchitiethoadonban ON tblsanpham.MaSP=tblchitiethoadonban.MaSP";
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
            str = "SELECT NgayBan FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            txtNgayban.Text = Class.Function.ConvertDateTime(Class.Function.GetFieldValues(str));
            str = "SELECT MaNV FROM tblchitiethoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            cboManhanvien.Text = Class.Function.GetFieldValues(str);

            str = "SELECT MaKH FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";

            str = "SELECT TongTien FROM tblthoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            txtTongtien.Text = Class.Function.GetFieldValues(str);

            lblBangchu.Text = "Bằng chữ: " + Class.Function.ChuyenSoSangChu(txtTongtien.Text);
        }

        private void btnThemhoadon_Click(object sender, EventArgs e)
        {
            btnHuyhoadon.Enabled = false;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = false;
            btnThemhoadon.Enabled = false;
            txtMahoadon.ReadOnly = true;
            ResetValues();
            Load_data();
        }

        private void ResetValues()
        {
            txtMahoadon.Text = Function.CreateKey("HDB");
            txtNgayban.Text = DateTime.Now.ToShortDateString();
            cboManhanvien.Text = "";
            //txtMakhachhang.Text = "";
            //txtTenkhachhang.Text = "";
            //txtDiachi.Text = "";
            txtDienthoai.Text = "";
            txtTongtien.Text = "0";
            lblBangchu.Text = "Bằng chữ: ";
            cboMasanpham.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "select MaKH, TenKH, DiaChi from tblkhachhang where DienThoai = '" + txtDienthoai.Text + "'";
            //sql = "select MaKH, TenKH, DiaChi from tblkhachhang WHERE DienThoai = REPLACE(REPLACE(REPLACE(REPLACE('" + mskDienthoai.Text.Trim().ToString() + "', '(', ''), ')', ''), ' ', ''), '-', '')";
            tblkh = Class.Function.GetDataToTable(sql);
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMakhachhang.Text = Function.CreateKey("KH");
                txtTenkhachhang.Enabled = true;
                txtDiachi.Enabled = true;
                //txtTenkhachhang.Text = "";
                //txtDiachi.Text = "";
            }
            else
            {
                MessageBox.Show("Đã có khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Load_ThongtinKH();
            }
        }
        private void Load_ThongtinKH()
        {
            string str;
            str = "select MaKH from tblkhachhang where DienThoai = '" + txtDienthoai.Text + "'";
            txtMakhachhang.Text = Class.Function.GetFieldValues(str);
            str = "select TenKH from tblkhachhang where DienThoai = '" + txtDienthoai.Text + "'";
            txtTenkhachhang.Text = Class.Function.GetFieldValues(str);
            str = "select DiaChi from tblkhachhang where DienThoai = '" + txtDienthoai.Text + "'";
            txtDiachi.Text = Class.Function.GetFieldValues(str);
            str = "insert into tblkhachhang(MaKH, TenKH, DiaChi, DienThoai) values (N'" + txtMakhachhang.Text.Trim() + "', N '" + txtTenkhachhang.Text.Trim() + "', N'" + txtDiachi.Text.Trim() + "', '" + txtDienthoai.Text.Trim() + "')";
            Function.RunSql(str);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHDB FROM tblhoadonban WHERE MaHDB=N'" + txtMahoadon.Text + "'";
            if (!Class.Function.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtNgayban.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayban.Focus();
                    return;
                }
                if (cboManhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManhanvien.Focus();
                    return;
                }
                if (txtDienthoai.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDienthoai.Focus();
                    return;
                }
                //lưu thông tin chung vào bảng tblhdban 
                sql = "INSERT INTO tblhoadonban(MaHDB, Ngayban, MaNV, MaKH, Tongtien) VALUES(N'" + txtMahoadon.Text.Trim() + "', '" + Function.ConvertDateTime(txtNgayban.Text.Trim()) + "',N'" + cboManhanvien.SelectedValue + "',N'" + txtMakhachhang.Text + "'," + txtTongtien.Text + ")"; 
                Function.RunSql(sql);
            }

            // Lưu thông tin của các mặt hàng
            if (cboMasanpham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMasanpham.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            if (txtGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamgia.Focus();
                return;
            }
            sql = "SELECT MaSP FROM tblchitiethoadonban WHERE MaSP=N'" + cboMasanpham.SelectedValue + "' AND MaHDB = N'" + txtMahoadon.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ResetValuesHang();
                cboMasanpham.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không ?
            sl = Convert.ToDouble(Function.GetFieldValues("SELECT Soluong FROM tblsanpham WHERE Mahang = N'" + cboMasanpham.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng sản phẩm này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            sql = "INSERT INTO tblchitiethoadonban(MaHDB, MaSP, Soluong, Dongiaban, Giamgia, ThanhTien) VALUES(N'" + txtMahoadon.Text.Trim() + "', N'" + cboMasanpham.SelectedValue + "'," + txtSoluong.Text + "," + txtGiamgia.Text + ", " + txtThanhtien.Text + ")";
            Function.RunSql(sql);
            Load_data();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE tblsanpham SET Soluong =" + SLcon + " WHERE MaSP = N'" + cboMasanpham.SelectedValue + "'";
            Function.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Function.GetFieldValues("SELECT Tongtien FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'"));

            Tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "UPDATE tblhoadonban SET Tongtien =" + Tongmoi + " WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            Function.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(Tongmoi.ToString());
            //ResetValuesHang();
            btnHuyhoadon.Enabled = true;
            btnThemhoadon.Enabled = true;
            btnInhoadon.Enabled = true;
        }
        private void ResetValuesHang()
        {
            cboMasanpham.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }

        private void dgridChitiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahang;
            Double Thanhtien;
            if (tblcthdb.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahang = dgridChitiet.CurrentRow.Cells["MaSP"].Value.ToString();
                DelHang(txtMahoadon.Text, mahang);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                Thanhtien = Convert.ToDouble(dgridChitiet.CurrentRow.Cells["Thanhtien"].Value.ToString());
                DelUpdateTongtien(txtMahoadon.Text, Thanhtien);
                Load_data();
            }
        }
        private void DelHang(string Mahoadon, string Mahang)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT Soluong FROM tblchitiethoadonban WHERE MaHDB = N'" + Mahoadon + "' AND MaSP = N'" + Mahang + "'"; s = Convert.ToDouble(Function.GetFieldValues(sql));
            sql = "DELETE tblchitiethoadonban WHERE MaHDB=N'" + Mahoadon + "' AND MaSP = N'" + Mahang + "'";
            Function.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT Soluong FROM tblsanpham WHERE Masanpham = N'" + Mahang + "'";
            sl = Convert.ToDouble(Function.GetFieldValues(sql));
            SLcon = sl + s;
            sql = "UPDATE tblsanpham SET Soluong =" + SLcon + " WHERE MaSP= N'" + Mahang + "'";
            Function.RunSql(sql);
        }
        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT Tongtien FROM tblhoadonban WHERE MaHDB = N'" +
           Mahoadon + "'";
            Tong = Convert.ToDouble(Function.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE tblhoadonban SET Tongtien =" + Tongmoi + " WHERE  MaHDB = N'" + Mahoadon + "'";
            Function.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(Tongmoi.ToString());
        }

        private void btnHuyhoadon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] Mahang = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT MaSP FROM tblchitiethoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Function.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtMahoadon.Text, Mahang[i]);
                //Xóa hóa đơn
                sql = "DELETE tblhoadonban WHERE MaHDB=N'" + txtMahoadon.Text + "'";
                Function.RunSqlDel(sql);
                ResetValues();
                Load_data();
                btnHuyhoadon.Enabled = false;
                btnInhoadon.Enabled = false;
            }

        }

        private void cboManhanvien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboManhanvien.Text == "")
                txtTennhanvien.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select TenNV from tblnhanvien where MaNv = N'" + cboManhanvien.SelectedValue + "'";
            txtTennhanvien.Text = Function.GetFieldValues(str);
        }

        private void cboMasanpham_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMasanpham.Text == "")
            {
                txtTenhang.Text = "";
                txtDongia.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "SELECT TenSP FROM tblsanpham WHERE MaSP =N'" + cboMasanpham.SelectedValue+ "'";
            txtTenhang.Text = Function.GetFieldValues(str);
            str = "SELECT Dongiaban FROM tblchitiethoadonban WHERE MaSP =N'" + cboMasanpham.SelectedValue + "'";
            txtDongia.Text = Function.GetFieldValues(str);
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamgia.Text);
            if (txtDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void txtGiamgia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamgia.Text);
            if (txtDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }
    }
}
