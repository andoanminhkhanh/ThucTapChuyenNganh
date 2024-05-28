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
using COMExcel = Microsoft.Office.Interop.Excel;


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
            cboManhanvien.Enabled = false;
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

            // Add event handlers
            //cboManhanvien.SelectedIndexChanged += new EventHandler(cboManhanvien_SelectedIndexChanged);
            //cboMasanpham.SelectedIndexChanged += new EventHandler(cboMasanpham_SelectedIndexChanged);
            //txtSoluong.TextChanged += new EventHandler(txtSoluong_TextChanged);

            //txtSoluong.KeyPress += new KeyPressEventHandler(txtSoluong_KeyPress);
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
            //sql = "select tblchitiethoadonban.MaSP, tblsanpham.TenSP, tblchitiethoadonban.Soluong, tblsanpham.DonGiaBan, tblchitiethoadonban.GiamGia, (tblsanpham.DonGiaBan*tblchitiethoadonban.SoLuong*(1-tblchitiethoadonban.GiamGia)) as ThanhTien where tblchitiethoadonban.MaHDB = N'" + txtMahoadon.Text + "' and tblchitiethoadonban.MaSP = tblsanpham.MaSP";
            //a bảng bảng chi tiết HDB, b bảng sp
            sql = "select a.MaSP, b.TenSP, a.SoLuong, b.DonGiaBan, a.GiamGia, (a.SoLuong*b.DonGiaBan*(1-a.GiamGia)) as Thanhtien from tblchitiethoadonban as a, tblsanpham as b where a.MaHDB = N'" + txtMahoadon.Text + "' and a.MaSP = b.MaSP";
            tblcthdb = Class.Function.GetDataToTable(sql);
            dgridChitiet.DataSource = tblcthdb;
            dgridChitiet.Columns[0].HeaderText = "Mã sản phẩm";
            dgridChitiet.Columns[1].HeaderText = "Tên sản phẩm";
            dgridChitiet.Columns[2].HeaderText = "Số lượng";
            dgridChitiet.Columns[3].HeaderText = "Đơn giá";
            dgridChitiet.Columns[4].HeaderText = "Giảm giá %";
            dgridChitiet.Columns[5].HeaderText = "Thành tiền";
            dgridChitiet.Columns[0].Width = 100;
            dgridChitiet.Columns[1].Width = 120;
            dgridChitiet.Columns[2].Width = 120;
            dgridChitiet.Columns[3].Width = 110;
            dgridChitiet.Columns[4].Width = 110;
            dgridChitiet.Columns[5].Width = 120;
            dgridChitiet.AllowUserToAddRows = false;
            dgridChitiet.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD()
        {
            string str;
            str = "SELECT NgayBan FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            txtNgayban.Text = Class.Function.ConvertDateTime(Class.Function.GetFieldValues(str));
            str = "SELECT MaNV FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            cboManhanvien.Text = Class.Function.GetFieldValues(str);
            str = "select TenNV from tblnhanvien where MaNV = N'" + cboManhanvien.Text + "'";
            txtTennhanvien.Text = Class.Function.GetFieldValues(str);
            str = "SELECT MaKH FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            txtMakhachhang.Text = Class.Function.GetFieldValues(str);
            //str = "select TenKH from tblkhachhang join tblhoadonban where "
            if (txtMakhachhang.Text == "")
            {
                txtTenkhachhang.Text = "";
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
            }
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            str = "Select TenKH from tblkhachhang where MaKH= N'" + txtMakhachhang.Text+ "'";
            txtTenkhachhang.Text = Function.GetFieldValues(str);
            str = "Select DiaChi from tblkhachhang where MaKH = N'" + txtMakhachhang.Text+ "'";
            txtDiachi.Text = Function.GetFieldValues(str);
            str = "Select Dienthoai from tblkhachhang where MaKH= N'" +txtMakhachhang.Text+ "'";
            txtDienthoai.Text = Function.GetFieldValues(str);
            str = "SELECT TongTien FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
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
            cboManhanvien.Enabled = true;
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
            //txtDienthoai.Text = "";
            //str = "select TenNV from tblnhanvien where MaNV = N'" + cboManhanvien.Text + "'";
            //txtTennhanvien.Text = Class.Function.GetFieldValues(str);
            mskDienthoai.Text = "";
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
            //sql = "select MaKH, TenKH, DiaChi from tblkhachhang where DienThoai = '" + txtDienthoai.Text + "'";
            sql = "select MaKH, TenKH, DiaChi from tblkhachhang WHERE DienThoai = REPLACE(REPLACE(REPLACE(REPLACE('" + mskDienthoai.Text.Trim().ToString() + "', '(', ''), ')', ''), ' ', ''), '-', '')";
            tblkh = Class.Function.GetDataToTable(sql);
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                string newCustomerID = Function.CreateCustomerKey();

                // Hiển thị mã nhân viên mới lên TextBox hoặc sử dụng cho mục đích khác
                txtMakhachhang.Text = newCustomerID;
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
            str = "select DiaChi from tblkhachhang where DienThoai = '" + mskDienthoai.Text + "'";
            txtDiachi.Text = Class.Function.GetFieldValues(str);
            str = "insert into tblkhachhang(MaKH, TenKH, DiaChi, DienThoai) values (N'" + txtMakhachhang.Text.Trim() + "', N '" + txtTenkhachhang.Text.Trim() + "', N'" + txtDiachi.Text.Trim() + "', '" + txtDienthoai.Text.Trim() + "')";
            Function.RunSql(str);
        }
        private void btnThemsanpham_Click(object sender, EventArgs e)
        {
            ResetValuesHang();
            // Kiểm tra các trường dữ liệu có được nhập đầy đủ không
            if (string.IsNullOrEmpty(txtMahoadon.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboMasanpham.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtSoluong.Text) || !int.TryParse(txtSoluong.Text, out int soluong) || soluong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính toán thành tiền
            //CalculateTotal();

            // Tạo một hàng mới
            DataRow newRow = tblcthdb.NewRow();

            // Điền thông tin của sản phẩm vào hàng mới
            newRow["MaSP"] = cboMasanpham.SelectedValue;
            newRow["TenSP"] = txtTenhang.Text;
            newRow["SoLuong"] = soluong;
            newRow["DonGiaBan"] = decimal.Parse(txtDongia.Text);
            newRow["GiamGia"] = txtGiamgia.Text;
            newRow["Thanhtien"] = decimal.Parse(txtThanhtien.Text);

            // Thêm hàng vào bảng
            tblcthdb.Rows.Add(newRow);

            // Cập nhật lại DataGridView
            dgridChitiet.DataSource = tblcthdb;

            // Tính toán lại tổng tiền
            //CalculateTotalPrice();

            // Reset các giá trị nhập vào
            //ResetProductInputs();
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
                if (mskDienthoai.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDienthoai.Focus();
                    return;
                }
                //lưu thông tin chung vào bảng tblhdban 
                sql = "INSERT INTO tblhoadonban(MaHDB, Ngayban, MaNV, MaKH, Tongtien, TrangThai) VALUES(N'" + txtMahoadon.Text.Trim() + "', '" + Function.ConvertDateTime(txtNgayban.Text.Trim()) + "',N'" + cboManhanvien.SelectedValue + "',N'" + txtMakhachhang.Text + "'," + txtTongtien.Text + ", 'Đang chuẩn bị hàng' )"; 
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
            sl = Convert.ToDouble(Function.GetFieldValues("SELECT Soluong FROM tblsanpham WHERE MaSP = N'" + cboMasanpham.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng sản phẩm này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            sql = "INSERT INTO tblchitiethoadonban(MaHDB, MaSP, SoLuong, GiamGia) VALUES(N'" + txtMahoadon.Text.Trim() + "', N'" + cboMasanpham.SelectedValue + "'," + txtSoluong.Text + "," + txtGiamgia.Text + ")";
            Function.RunSql(sql);
            Load_data();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE tblsanpham SET Soluong =" + SLcon + " WHERE MaSP = N'" + cboMasanpham.SelectedValue + "'";
            Function.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Function.GetFieldValues("select Tongtien FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'"));

            Tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "UPDATE tblhoadonban SET Tongtien =" + Tongmoi + " WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            Function.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(Tongmoi.ToString());
            ResetValuesHang();
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
            sql = "SELECT Soluong FROM tblchitiethoadonban WHERE MaHDB = N'" + Mahoadon + "' AND MaSP = N'" + Mahang + "'"; 
            s = Convert.ToDouble(Function.GetFieldValues(sql));
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
            str = "SELECT DonGiaBan FROM tblsanpham WHERE MaSP =N'" + cboMasanpham.SelectedValue + "'";
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


        private void btnInhoadon_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "VSPink Store";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "A10CT1 - Nam Trung Yên - Cầu Giấy - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (09)49910666";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment =
           COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN HÀNG";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHDB, a.Ngayban, a.Tongtien, b.TenKH, b.Diachi, b.Dienthoai, c.TenNV FROM tblhoadonban AS a, tblkhachhang AS b, tblnhanvien AS c WHERE a.MaHDB = N'" + txtMahoadon.Text + "' AND a.MaKH = b.MaKH AND a.MaNV = c.MaNV";
            tblThongtinHD = Function.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSP, a.Soluong, b.DonGiaBan, a.Giamgia, (a.SoLuong*b.DonGiaBan*(1-a.GiamGia)) " + "FROM tblChitiethoadonban AS a , tblsanpham AS b WHERE a.MaHDB = N'" + txtMahoadon.Text + "' AND a.MaSP = b.MaSP";
            tblThongtinHang = Function.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang ++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment =COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            btnTim.Enabled = false;
            if (cboMahoadon.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMahoadon.Focus();
                return;
            }
            txtMahoadon.Text = cboMahoadon.Text;
            Load_ThongtinHD();
            Load_data();
            btnHuyhoadon.Enabled = true;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = true;
            cboMahoadon.SelectedIndex = -1;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void cboMahoadon_DropDown(object sender, EventArgs e)
        {
            Function.FillCombo("SELECT MaHDB FROM tblhoadonban", cboMahoadon, "MaHDB","MaHDB");
            cboMahoadon.SelectedIndex = -1;
        }

        private void Hoadonbanhang_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgridChitiet_Click(object sender, EventArgs e)
        {
            if (btnThemhoadon.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahoadon.Focus();
                return;
            }
            if (tblcthdb.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cboMasanpham.Text = dgridChitiet.CurrentRow.Cells["MaSP"].Value.ToString();
            txtThanhtien.Text = dgridChitiet.CurrentRow.Cells["ThanhTien"].Value.ToString();
            txtTenhang.Text = dgridChitiet.CurrentRow.Cells["TenSP"].Value.ToString();
            txtDongia.Text = dgridChitiet.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            txtSoluong.Text = dgridChitiet.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtGiamgia.Text = dgridChitiet.CurrentRow.Cells["GiamGia"].Value.ToString();
            //Load_TTHD();
            //btnSua.Enabled = true;
            btnHuyhoadon.Enabled = true;
            btnInhoadon.Enabled = true;
        }

        private void cboManhanvien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboManhanvien.Text == "")
                txtTennhanvien.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select TenNV from tblnhanvien where MaNV = N'" + cboManhanvien.SelectedValue + "'";
            txtTennhanvien.Text = Function.GetFieldValues(str);
        }

        
    }
}
