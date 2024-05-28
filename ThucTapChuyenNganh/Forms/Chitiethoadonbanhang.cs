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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace ThucTapChuyenNganh.Forms
{
    public partial class Chitiethoadonbanhang : Form
    {
        public Chitiethoadonbanhang()
        {
            InitializeComponent();
        }
        DataTable tblcthdb;

        private void Chitiethoadonbanhang_Load(object sender, EventArgs e)
        {
            Class.FunctionKhanh.Connect();

            btnThemhoadon.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyhoadon.Enabled = false;
            btnInhoadon.Enabled = false;
            txtMahoadon.ReadOnly = true;
            txtTennhanvien.ReadOnly = true;
            txtMakhachhang.ReadOnly = true;
            txtTenkhachhang.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtTenkhachhang.Enabled = false;
            txtDiachi.Enabled = false;
            mskDienthoai.ReadOnly = false;
            txtTenhang.ReadOnly = true;
            txtDongia.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtGiamgia.Text = "0";
            txtTongtien.Text = "0";

            btnThemsanpham.Enabled = false;

            btnTim.Click += new EventHandler(btnTim_Click);

            Class.FunctionKhanh.FillCombo("SELECT MaNV, TenNV FROM tblnhanvien", cboManhanvien, "MaNV", "TenNV");
            cboManhanvien.SelectedIndex = -1;
            Class.FunctionKhanh.FillCombo("SELECT MaSP, TenSP FROM tblsanpham", cboMasanpham, "MaSP", "TenSP");
            cboMasanpham.SelectedIndex = -1;
            Class.FunctionKhanh.FillCombo("SELECT MaHDB FROM tblchitiethoadonban", cboMahoadon, "MaHDB", "MaHDB");
            cboMahoadon.SelectedIndex = -1;

            // Add event handlers
            cboManhanvien.SelectedIndexChanged += new EventHandler(cboManhanvien_SelectedIndexChanged);
            cboMasanpham.SelectedIndexChanged += new EventHandler(cboMasanpham_SelectedIndexChanged);
            txtSoluong.TextChanged += new EventHandler(txtSoluong_TextChanged);

            txtSoluong.KeyPress += new KeyPressEventHandler(txtSoluong_KeyPress);

            // Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMahoadon.Text != "")
            {
                Load_ThongtinHD();
                btnHuyhoadon.Enabled = true;
                btnInhoadon.Enabled = true;
            }
            Load_DataGridViewChitiet();
        }
        private void Load_DataGridViewChitiet()
        {
            //a: chitiet, b:sanpham
            //string sql = "select a.MaSP, b.TenSP, a.SoLuong, b.DonGiaBan, a.GiamGia, (a.SoLuong*b.DonGiaBan*(1-(a.GiamGia/100))) as Thanhtien from tblchitiethoadonban as a, tblsanpham as b where a.MaHDB = N'" + txtMahoadon.Text + "' and a.MaSP = b.MaSP";
            string sql = "select a.MaSP, b.TenSP, a.SoLuong, b.DonGiaBan, a.GiamGia, (a.SoLuong*b.DonGiaBan*(1-((a.GiamGia)/100))) as ThanhTien from tblchitiethoadonban as a, tblsanpham as b where a.MaHDB = N'" + txtMahoadon.Text + "' and a.MaSP = b.MaSP";
            tblcthdb = Class.FunctionKhanh.GetDataToTable(sql);
            DataGridViewChitiet.DataSource = tblcthdb;

            // Cập nhật lại tên cột để phản ánh chính xác dữ liệu
            DataGridViewChitiet.Columns[0].HeaderText = "Mã sản phẩm";
            DataGridViewChitiet.Columns[1].HeaderText = "Tên sản phẩm";
            DataGridViewChitiet.Columns[2].HeaderText = "Số lượng";
            DataGridViewChitiet.Columns[3].HeaderText = "Đơn giá";
            DataGridViewChitiet.Columns[4].HeaderText = "Giảm giá"; // Thay đổi vị trí cột này
            DataGridViewChitiet.Columns[5].HeaderText = "Thành tiền"; // Thay đổi vị trí cột này

            // Cập nhật lại chiều rộng của các cột
            DataGridViewChitiet.Columns[0].Width = 100;
            DataGridViewChitiet.Columns[1].Width = 160; // Tăng chiều rộng để hiển thị tên hàng đầy đủ
            DataGridViewChitiet.Columns[2].Width = 105;
            DataGridViewChitiet.Columns[3].Width = 105;
            DataGridViewChitiet.Columns[4].Width = 105; // Độ rộng cột Mức khuyến mãi
            DataGridViewChitiet.Columns[5].Width = 105;

            // Di chuyển cột Mức khuyến mãi tới vị trí thứ 5 (index = 4)
            //DataGridViewChitiet.Columns["GiamGia"].DisplayIndex = 4;

            DataGridViewChitiet.AllowUserToAddRows = false;
            DataGridViewChitiet.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD()
        {
            string str = "SELECT NgayBan FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            txtNgayban.Text = Class.FunctionKhanh.ConvertDateTime(Class.FunctionKhanh.GetFieldValues(str));
            str = "SELECT MaNV FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            cboManhanvien.Text = Class.FunctionKhanh.GetFieldValues(str);

            str = "SELECT MaKH FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            txtMakhachhang.Text = Class.FunctionKhanh.GetFieldValues(str);
            if (txtMakhachhang.Text == "")
            {
                txtTenkhachhang.Text = "";
                txtDiachi.Text = "";
                mskDienthoai.Text = "";
            }
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            str = "Select TenKH from tblkhachhang where MaKH= N'" + txtMakhachhang.Text + "'";
            txtTenkhachhang.Text = Function.GetFieldValues(str);
            str = "Select DiaChi from tblkhachhang where MaKH = N'" + txtMakhachhang.Text + "'";
            txtDiachi.Text = Function.GetFieldValues(str);
            str = "Select Dienthoai from tblkhachhang where MaKH= N'" + txtMakhachhang.Text + "'";
            mskDienthoai.Text = Function.GetFieldValues(str);
            str = "SELECT TongTien FROM tblhoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'";
            txtTongtien.Text = Class.FunctionKhanh.GetFieldValues(str);

            lblBangchu.Text = "Bằng chữ: " + Class.FunctionKhanh.ChuyenSoSangChu(txtTongtien.Text);
        }

        //private void cboManhanvien_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboMasanpham.SelectedValue != null)
        //    {
        //        string selectedManhanvien = cboMasanpham.SelectedValue.ToString();
        //        if (!string.IsNullOrEmpty(selectedManhanvien))
        //        {
        //            string query = "SELECT TenNV FROM tblnhanvien WHERE MaNV = N'" + selectedManhanvien + "'";
        //            string TenNV = Class.FunctionKhanh.GetFieldValues(query);
        //            txtTennhanvien.Text = TenNV;
        //        }
        //    }
        //}

        private void cboMasanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMasanpham.SelectedValue != null)
            {
                string selectedMasanpham = cboMasanpham.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(selectedMasanpham))
                {
                    string query = "SELECT TenSP, DonGiaBan FROM tblsanpham WHERE MaSP = N'" + selectedMasanpham + "'";
                    DataTable dt = Class.FunctionKhanh.GetDataToTable(query);
                    if (dt.Rows.Count > 0)
                    {
                        txtTenhang.Text = dt.Rows[0]["TenSP"].ToString();
                        txtDongia.Text = dt.Rows[0]["DonGiaBan"].ToString();
                        //DisplayDiscount();
                        CalculateTotal();
                    }
                }
            }
        }

        private void btnThemhoadon_Click(object sender, EventArgs e)
        {
            btnHuyhoadon.Enabled = true;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = false;
            btnThemhoadon.Enabled = false;
            btnThemsanpham.Enabled = true;
            txtGiamgia.Enabled = true;
            ResetValues();
            txtMahoadon.Text = Class.FunctionKhanh.CreateKey("HDB");
            //DisplayDiscount();
            Load_DataGridViewChitiet();
        }
        //private void DisplayDiscount()
        //{
        //    if (cboMasanpham.SelectedValue != null)
        //    {
        //        string selectedMasanpham = cboMasanpham.SelectedValue.ToString();
        //        if (!string.IsNullOrEmpty(selectedMasanpham))
        //        {
        //            string query = "SELECT GiamGia FROM tblchitiethoadonban WHERE MaSP = N'\" + selectedMasanpham + \"'";
        //            string discount = Class.FunctionKhanh.GetFieldValues(query);
        //            txtGiamgia.Text = string.IsNullOrEmpty(discount) ? "0" : discount;
        //        }
        //    }
        //}

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalculateTotal();
                e.Handled = true; // Ngăn chặn âm báo mặc định của phím Enter
            }
        }
        private void CalculateTotal()
        {
            if (int.TryParse(txtSoluong.Text, out int soluong) && decimal.TryParse(txtDongia.Text, out decimal dongia) && decimal.TryParse(txtGiamgia.Text, out decimal giamgia))
            {
                giamgia = giamgia / 100; // Chuyển đổi phần trăm giảm giá thành dạng số thập phân
                decimal thanhtien = (soluong * dongia) * (1 - giamgia);
                txtThanhtien.Text = thanhtien.ToString("0.00"); // Định dạng thành tiền với 2 chữ số thập phân
                CalculateTotalPrice(); // Update the total price whenever the line item total changes
            }
            else
            {
                //MessageBox.Show("Vui lòng nhập số lượng và đơn giá hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ResetValues()
        {
            txtMahoadon.Text = "";
            txtNgayban.Text = DateTime.Now.ToShortDateString();
            cboManhanvien.SelectedIndex = -1; // Đặt lại comboBox nhân viên
            txtTennhanvien.Clear();
            txtMakhachhang.Clear();
            txtTenkhachhang.Clear();
            txtDiachi.Clear();
            mskDienthoai.Clear();
            txtTongtien.Text = "0";
            lblBangchu.Text = "Bằng chữ: ";
            cboMasanpham.SelectedIndex = -1; // Đặt lại comboBox mã hàng
            txtSoluong.Clear();
            txtGiamgia.Text = "0";
            txtThanhtien.Clear();
            txtTenhang.Clear();
            txtDongia.Clear();
        }

        private void btnThemsanpham_Click(object sender, EventArgs e)
        {
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
            CalculateTotal();

            // Kiểm tra xem đã có sản phẩm với mã sách tương tự trong danh sách hay chưa
            bool productExists = false;
            foreach (DataRow row in tblcthdb.Rows)
            {
                if (row["MaSP"].ToString() == cboMasanpham.SelectedValue.ToString())
                {
                    // Nếu có, cập nhật lại số lượng sản phẩm
                    int existingQuantity = int.Parse(row["SoLuong"].ToString());
                    row["SoLuong"] = existingQuantity + soluong;
                    // Tính lại thành tiền
                    decimal dongia = decimal.Parse(txtDongia.Text);
                    decimal giamgia = string.IsNullOrEmpty(txtGiamgia.Text) ? 0 : decimal.Parse(txtGiamgia.Text);
                    row["Thanhtien"] = (existingQuantity + soluong) * dongia * (1 - giamgia / 100);
                    productExists = true;
                    break;
                }
            }

            // Nếu không có sản phẩm có mã sách tương tự, thêm sản phẩm mới vào danh sách
            if (!productExists)
            {
                DataRow newRow = tblcthdb.NewRow();
                newRow["MaSP"] = cboMasanpham.SelectedValue;
                newRow["TenSP"] = txtTenhang.Text;
                newRow["SoLuong"] = soluong;
                newRow["DonGiaBan"] = decimal.Parse(txtDongia.Text);
                newRow["GiamGia"] = txtGiamgia.Text;
                newRow["Thanhtien"] = decimal.Parse(txtThanhtien.Text);
                tblcthdb.Rows.Add(newRow);
            }
            // Cập nhật lại DataGridView
            DataGridViewChitiet.DataSource = tblcthdb;

            // Tính toán lại tổng tiền
            CalculateTotalPrice();

            // Reset các giá trị nhập vào
            ResetProductInputs();
        }
        private void ResetProductInputs()
        {
            cboMasanpham.SelectedIndex = -1;
            txtTenhang.Clear();
            txtSoluong.Clear();
            txtDongia.Clear();
            txtGiamgia.Text = "0";
            txtThanhtien.Clear();
        }

        private void CalculateTotalPrice()
        {
            decimal tongtien = 0;
            foreach (DataRow row in tblcthdb.Rows)
            {
                tongtien += Convert.ToDecimal(row["Thanhtien"]);
            }
            txtTongtien.Text = tongtien.ToString("0.00");
            lblBangchu.Text = "Bằng chữ: " + Class.FunctionKhanh.ChuyenSoSangChu(txtTongtien.Text);
        }
        //Tim khach hang
        private void btnTim_Click(object sender, EventArgs e)
        {
            string phone = GetPhoneNumber(mskDienthoai.Text);

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = $"SELECT MaKH, TenKH, DiaChi, DienThoai FROM tblkhachhang WHERE REPLACE(DienThoai, ' ', '') = '{phone}'";
            DataTable dt = Class.FunctionKhanh.GetDataToTable(query);

            if (dt.Rows.Count > 0)
            {
                txtMakhachhang.Text = dt.Rows[0]["MaKH"].ToString();
                txtTenkhachhang.Text = dt.Rows[0]["TenKH"].ToString();
                txtDiachi.Text = dt.Rows[0]["DiaChi"].ToString();
                mskDienthoai.Text = dt.Rows[0]["DienThoai"].ToString();
            }
            else
            {
                MessageBox.Show("Khách hàng chưa có trong cơ sở dữ liệu. Vui lòng nhập thông tin khách hàng mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetCustomerInputs();
                txtMakhachhang.Text = GenerateNewCustomerID();
                txtTenkhachhang.Enabled = true;
                txtDiachi.Enabled = true;
            }
        }
        private string GetPhoneNumber(string phoneNumber)
        {
            string digits = new string(phoneNumber.Where(char.IsDigit).ToArray());
            if (digits.Length >= 10)
            {
                return digits.Substring(digits.Length - 10);
            }
            return "";
        }
        private void ResetCustomerInputs()
        {
            txtMakhachhang.Clear();
            txtTenkhachhang.ReadOnly = false;
            txtTenkhachhang.Clear();
            txtDiachi.ReadOnly = false;
            txtDiachi.Clear();
            //mskDienthoai.Clear();
        }
        private string GenerateNewCustomerID()
        {
            // Generate a new customer ID based on your logic. For example:
            string query = "SELECT TOP 1 MaKH FROM tblkhachhang ORDER BY MaKH DESC";
            string lastID = Class.FunctionKhanh.GetFieldValues(query);

            if (string.IsNullOrEmpty(lastID))
            {
                return "KH001";
            }

            int newID = int.Parse(lastID.Substring(2)) + 1;
            return "KH" + newID.ToString("D3"); // Format as KHxxx
        }
        //click để xóa 1 sản phẩm
        private void DataGridViewChitiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblcthdb.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                // Lấy chỉ số dòng hiện tại
                int rowIndex = e.RowIndex;

                // Lấy mã sản phẩm và thành tiền của dòng hiện tại
                string masanpham = DataGridViewChitiet.Rows[rowIndex].Cells["MaSP"].Value.ToString();
                double Thanhtien = Convert.ToDouble(DataGridViewChitiet.Rows[rowIndex].Cells["Thanhtien"].Value.ToString());

                // Xóa hàng tạm thời khỏi DataGridView
                DelHangTamThoi(rowIndex);

                // Cập nhật lại tổng tiền cho hóa đơn
                DelUpdateTongtien(txtMahoadon.Text, Thanhtien);
            }
        }
        private void DelHangTamThoi(int rowIndex)
        {
            // Xóa hàng tạm thời khỏi DataGridView
            if (rowIndex >= 0 && rowIndex < DataGridViewChitiet.Rows.Count)
            {
                DataGridViewChitiet.Rows.RemoveAt(rowIndex);
            }
        }
        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            try
            {
                // Lấy tổng tiền hiện tại từ txtTongtien
                double Tong = Convert.ToDouble(txtTongtien.Text);

                // Tính toán lại tổng tiền
                double Tongmoi = Tong - Thanhtien;

                // Cập nhật tổng tiền mới trên giao diện
                txtTongtien.Text = Tongmoi.ToString();
                lblBangchu.Text = "Bằng chữ: " + Class.FunctionKhanh.ChuyenSoSangChu(Tongmoi.ToString());
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("Lỗi khi cập nhật tổng tiền: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTennhanvien.Text) || string.IsNullOrEmpty(txtTenkhachhang.Text) ||
                string.IsNullOrEmpty(txtDiachi.Text) || string.IsNullOrEmpty(mskDienthoai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của khách hàng và nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Remove unwanted characters from phone number
                string phone = mskDienthoai.Text.Trim();
                phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

                // Save Customer Information if not exists
                string customerID = txtMakhachhang.Text.Trim();
                string query = $"SELECT COUNT(*) FROM tblKhachhang WHERE MaKH = N'{customerID}'";
                int customerCount = int.Parse(Class.FunctionKhanh.GetFieldValues(query));

                if (customerCount == 0)
                {
                    // Insert new customer information
                    query = $"INSERT INTO tblkhachhang (MaKH, TenKH, DiaChi, DienThoai) " +
                            $"VALUES (N'{customerID}', N'{txtTenkhachhang.Text.Trim()}', N'{txtDiachi.Text.Trim()}', " +
                            $"'{phone}')";
                    Class.FunctionKhanh.RunSql(query);
                }

                // Check product quantity
                foreach (DataRow row in tblcthdb.Rows)
                {
                    string productID = row["MaSP"].ToString();
                    int orderedQuantity = int.Parse(row["SoLuong"].ToString());
                    int availableQuantity = GetAvailableQuantity(productID);

                    if (orderedQuantity > availableQuantity)
                    {
                        MessageBox.Show($"Số lượng sản phẩm '{productID}' không đủ để đáp ứng đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Save Order Details
                string sql = $"INSERT INTO tblhoadonban (MaHDB, NgayBan, MaNV, MaKH, TongTien) " +
                             $"VALUES (N'{txtMahoadon.Text.Trim()}', '{Class.FunctionKhanh.ConvertDateTime(txtNgayban.Text.Trim())}', " +
                             $"N'{cboManhanvien.SelectedValue}', N'{customerID}', {txtTongtien.Text})";
                Class.FunctionKhanh.RunSql(sql);

                // Save Order Items
                foreach (DataRow row in tblcthdb.Rows)
                {
                    sql = $"INSERT INTO tblchitiethoadonban (MaHDB, MaSP, SoLuong, DonGiaBan, GiamGia) " +
                          $"VALUES (N'{txtMahoadon.Text.Trim()}', N'{row["MaSP"].ToString()}', {row["SoLuong"].ToString()}, " +
                          $"{row["DonGiaBan"].ToString()}, {row["GiamGia"].ToString()})";
                    Class.FunctionKhanh.RunSql(sql);
                }

                // Update the total amount in the main order table
                double tongTien = double.Parse(txtTongtien.Text);
                sql = $"UPDATE tblhoadonban SET TongTien = {tongTien} WHERE MaHDB = N'{txtMahoadon.Text.Trim()}'";
                Class.FunctionKhanh.RunSql(sql);

                MessageBox.Show("Đơn hàng đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Update UI and reset form
                btnThemhoadon.Enabled = true;
                btnThemsanpham.Enabled = false;
                btnLuu.Enabled = false;
                btnHuyhoadon.Enabled = false;
                btnInhoadon.Enabled = true;

                Load_DataGridViewChitiet();
                ResetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu đơn hàng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetAvailableQuantity(string productID)
        {
            string query = $"SELECT Soluong FROM tblsanpham WHERE MaSP = N'{productID}'";
            int availableQuantity = int.Parse(Class.FunctionKhanh.GetFieldValues(query));
            return availableQuantity;
        }

        private void btnHuyhoadon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Đặt lại tất cả các giá trị và trạng thái ban đầu của hóa đơn
                ResetValues();

                // Đặt lại trạng thái của các nút và hộp thoại
                btnThemhoadon.Enabled = true;
                btnThemsanpham.Enabled = false;
                btnLuu.Enabled = false;
                btnHuyhoadon.Enabled = false;
                btnInhoadon.Enabled = false;

                // Xóa toàn bộ dữ liệu trong DataGridView
                tblcthdb.Clear();
                DataGridViewChitiet.DataSource = tblcthdb;
            }
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
            sql = "SELECT b.TenSP, a.Soluong, b.DonGiaBan, a.Giamgia, (a.SoLuong * b.DonGiaBan * (1 - (a.GiamGia / 100))) " +
                "FROM tblChitiethoadonban AS a , tblsanpham AS b WHERE a.MaHDB = N'" + txtMahoadon.Text + "' AND a.MaSP = b.MaSP";
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
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
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
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
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
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMahoadon.Focus();
                return;
            }
            txtMahoadon.Text = cboMahoadon.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            btnHuyhoadon.Enabled = true;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = true;
            cboMahoadon.SelectedIndex = -1;
        }

        private void cboManhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMasanpham.SelectedValue != null)
            {
                string selectedManhanvien = cboMasanpham.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(selectedManhanvien))
                {
                    string query = "SELECT TenNV FROM tblnhanvien WHERE MaNV = N'" + selectedManhanvien + "'";
                    string TenNV = Class.FunctionKhanh.GetFieldValues(query);
                    txtTennhanvien.Text = TenNV;
                }
            }
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