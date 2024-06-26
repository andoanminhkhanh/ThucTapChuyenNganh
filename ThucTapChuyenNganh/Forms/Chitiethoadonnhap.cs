﻿using System;
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
using System.Xml;
using ThucTapChuyenNganh.Class;
using System.Globalization;


namespace ThucTapChuyenNganh.Forms
{
    public partial class Chitiethoadonnhap : Form
    {
        public Chitiethoadonnhap()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Chitiethoadonnhap_Load(object sender, EventArgs e)
        {
            Function.Connect();
            btnThemhoadon.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyhoadon.Enabled = false;
            btnInhoadon.Enabled = false;
            btnThemsanpham.Enabled = false;

            btnTim.Click += new EventHandler(btnTim_Click);

            Function.FillCombo("SELECT MaNV, TenNV FROM tblnhanvien",cboManhanvien, "MaNV", "MaNV");
            cboManhanvien.SelectedIndex = -1;

            Function.FillCombo("SELECT DISTINCT MaHDN FROM tblchitiethoadonnhap", cboMahoadon,"MaHDN", "MaHDN");
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
            //txtMahoadon.Text = Function.CreateKey("HDB");
            txtMahoadon.Text = "";
            txtNgaynhap.Text = "";
            cboManhanvien.Text = "";
            txtTennhanvien.Text = "";
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiachi.Text = "";
            mskDienthoai.Text = "";
            //str = "select TenNV from tblnhanvien where MaNV = N'" + cboManhanvien.Text + "'";
            //txtTennhanvien.Text = Class.Function.GetFieldValues(str);
            mskDienthoai.Text = "";
            txtTongtien.Text = "0";
            lblBangchu.Text = "Bằng chữ: ";
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDongia.Text = "0";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
            Load_DataGridViewChitiet();
        }
        
        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "SELECT tblchitiethoadonnhap.MaSP, TenSP, tblchitiethoadonnhap.SoLuong,DonGiaNhap, GiamGia, (DonGiaNhap*(1-GiamGia)*tblchitiethoadonnhap.SoLuong) as Thanhtien FROM tblchitiethoadonnhap JOIN tblsanpham on tblchitiethoadonnhap.MaSP=tblsanpham.MaSP where MaHDN = N'" + txtMahoadon.Text + "'";
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
            str = "SELECT MaNV FROM tblhoadonnhap WHERE MaHDN = N'" + txtMahoadon.Text + "'";
            cboManhanvien.Text = Function.GetFieldValues(str);
            str = "SELECT MaNCC FROM tblhoadonnhap WHERE MaHDN = N'" + txtMahoadon.Text + "'";
            txtMaNCC.Text = Function.GetFieldValues(str);
            str = "SELECT NgayNhap FROM tblhoadonnhap WHERE MaHDN = N'" + txtMahoadon.Text + "'";
            txtNgaynhap.Text = Function.ConvertDateTime(Function.GetFieldValues(str));

            //Khi kich chon dien thoai thi ten NCC, mã ncc, dien thoai se tu dong hien ra
            if (txtMaNCC.Text == "")
            {
                txtTenNCC.Text = "";
                txtDiachi.Text = "";
                mskDienthoai.Text = "";

            }
            str = "Select TenNCC from tblnhacungcap where MaNCC= N'" + txtMaNCC.Text + "'";
            txtTenNCC.Text = Function.GetFieldValues(str);
            str = "Select DiaChi from tblnhacungcap where MaNCC = N'" + txtMaNCC.Text + "'";
            txtDiachi.Text = Function.GetFieldValues(str);
            str = "Select DienThoai from tblnhacungcap where MaNCC = N'" + txtMaNCC.Text + "'";
            mskDienthoai.Text = Function.GetFieldValues(str);



            if (cboManhanvien.Text == "")
            {
                txtTennhanvien.Text = "";
            }
            str = "Select TenNV from tblNhanvien where MaNV= N'" + cboManhanvien.Text + "'";
            txtTennhanvien.Text = Function.GetFieldValues(str);

            str = "SELECT TongTien FROM tblhoadonnhap where MaHDN = N'" + txtMahoadon.Text + "'";
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
            btnThemsanpham.Enabled = true;
            ResetValues();
            txtMahoadon.Text = Class.Function.CreateHDNKey();
            txtNgaynhap.Text = DateTime.Now.ToShortDateString();
            txtMahoadon.Enabled = false;
            txtNgaynhap.Enabled = false;
            btnTim.Enabled = true;
            btnBoqua.Enabled = true;
            Load_DataGridViewChitiet();
        }

        private void txtDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtTennhanvien.Text) || string.IsNullOrEmpty(txtTenNCC.Text) ||
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
                string customerID = txtMaNCC.Text.Trim();
                string query = $"SELECT COUNT(*) FROM tblnhacungcap WHERE MaNCC = N'{customerID}'";
                int customerCount = int.Parse(Class.Function.GetFieldValues(query));

                if (customerCount == 0)
                {
                    // Insert new customer information
                    query = $"INSERT INTO tblnhacungcap (MaNCC, TenNCC, DiaChi, DienThoai) " +
                            $"VALUES (N'{customerID}', N'{txtTenNCC.Text.Trim()}', N'{txtDiachi.Text.Trim()}', '{phone}')";
                    Class.Function.RunSql(query);
                }

                // Save Order Details
                string sql = $"INSERT INTO tblhoadonnhap (MaHDN, MaNV, MaNCC, NgayNhap, TongTien) " +
                             $"VALUES (N'{txtMahoadon.Text.Trim()}', " +
                             $"N'{cboManhanvien.SelectedValue}', N'{customerID}', '{Class.Function.ConvertDateTime(txtNgaynhap.Text.Trim())}', {txtTongtien.Text.Trim()})";
                Class.Function.RunSql(sql);

                //Save Order Items
                foreach (DataRow row in tblCTHDN.Rows)
                {
                    string maSP = row["MaSP"].ToString();

                    // Check if the product exists in tblsanpham
                    query = $"SELECT COUNT(*) FROM tblsanpham WHERE MaSP = N'{maSP}'";
                    int productCount = int.Parse(Class.Function.GetFieldValues(query));

                    if (productCount == 0)
                    {
                        MessageBox.Show($"Sản phẩm với Mã SP = {maSP} không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue; // Skip this product and move to the next
                    }

                    sql = $"INSERT INTO tblchitiethoadonnhap (MaHDN, MaSP, SoLuong, DonGiaNhap, GiamGia) " +
                          $"VALUES (N'{txtMahoadon.Text.Trim()}', N'{maSP}', '{row["SoLuong"].ToString()}', '{row["DonGiaNhap"].ToString()}', '{row["GiamGia"].ToString()}')";
                    Class.Function.RunSql(sql);

                    // Update quantity of product in product table
                    double sl, SLcon;
                    sl = Convert.ToDouble(Function.GetFieldValues($"SELECT Soluong FROM tblsanpham WHERE MaSP = N'{maSP}'"));

                    SLcon = sl + Convert.ToDouble(row["SoLuong"].ToString());
                    sql = $"UPDATE tblsanpham SET Soluong = {SLcon} WHERE MaSP = N'{maSP}'";
                    Function.RunSql(sql);
                }


                // Update the total amount in the main order table
                double tongTien = double.Parse(txtTongtien.Text);
                sql = $"UPDATE tblhoadonnhap SET TongTien = {tongTien} WHERE MaHDN = N'{txtMahoadon.Text.Trim()}'";
                Class.Function.RunSql(sql);

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
            btnLuu.Enabled = false;
            btnInhoadon.Enabled = true;
            cboMahoadon.SelectedIndex = -1;
            btnBoqua.Enabled = true;
            btnThemhoadon.Enabled = false;

        }

        private void btnThemsanpham_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường dữ liệu có được nhập đầy đủ không
            if (string.IsNullOrEmpty(txtMahoadon.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtMaSP.Text))
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
            
            // Nếu không có sản phẩm có mã sách tương tự, thêm sản phẩm mới vào danh sách
            if (!productExists)
            {
                DataRow newRow = tblCTHDN.NewRow();
                newRow["MaSP"] = txtMaSP.Text;
                newRow["TenSP"] = txtTenSP.Text;
                newRow["SoLuong"] = soluong;
                newRow["DonGiaNhap"] = decimal.Parse(txtDongia.Text);
                newRow["GiamGia"] = txtGiamgia.Text;
                newRow["Thanhtien"] = decimal.Parse(txtThanhtien.Text);
                tblCTHDN.Rows.Add(newRow);
            }
            // Cập nhật lại DataGridView
            DataGridView.DataSource = tblCTHDN;

            // Tính toán lại tổng tiền
            CalculateTotalPrice();

            // Reset các giá trị nhập vào
            ResetProductInputs();
            btnBoqua.Enabled = true;
            btnTim.Enabled = true;
        }
        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtDongia_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }
        private void txtGiamgia_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }
        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalculateTotal();
                e.Handled = true;
            }
        }

        private void txtGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalculateTotal();
                e.Handled = true;
            }
        }

        private void txtDongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalculateTotal();
                e.Handled = true;
            }
        }

        private void CalculateTotal()
        {
            if (int.TryParse(txtSoluong.Text, out int soluong) && decimal.TryParse(txtDongia.Text, out decimal dongia) && decimal.TryParse(txtGiamgia.Text, out decimal giamgia))
            {
                //giamgia = giamgia / 100; // Chuyển đổi phần trăm giảm giá thành dạng số thập phân
                decimal thanhtien = (soluong * dongia) * (1 - giamgia);
                txtThanhtien.Text = thanhtien.ToString("0.00"); // Định dạng thành tiền với 2 chữ số thập phân
                CalculateTotalPrice(); // Update the total price whenever the line item total changes
            }
            else
            {
                //MessageBox.Show("Vui lòng nhập số lượng và đơn giá hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ResetProductInputs()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtSoluong.Clear();
            txtDongia.Clear();
            txtGiamgia.Text = "0";
            txtThanhtien.Clear();
        }

        private void CalculateTotalPrice()
        {
            decimal tongtien = 0;
            foreach (DataRow row in tblCTHDN.Rows)
            {
                tongtien += Convert.ToDecimal(row["Thanhtien"]);
            }
            txtTongtien.Text = tongtien.ToString("0.00");
            lblBangchu.Text = "Bằng chữ: " + Class.Function.ChuyenSoSangChu(txtTongtien.Text);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string phone = GetPhoneNumber(mskDienthoai.Text);

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = $"SELECT MaNCC, TenNCC, DiaChi, DienThoai FROM tblnhacungcap WHERE REPLACE(DienThoai, ' ', '') = '{phone}'";
            DataTable dt = Function.GetDataToTable(query);

            if (dt.Rows.Count > 0)
            {
                txtMaNCC.Text = dt.Rows[0]["MaNCC"].ToString();
                txtTenNCC.Text = dt.Rows[0]["TenNCC"].ToString();
                txtDiachi.Text = dt.Rows[0]["DiaChi"].ToString();
                mskDienthoai.Text = dt.Rows[0]["DienThoai"].ToString();
            }
            else
            {
                MessageBox.Show("NCC chưa có trong cơ sở dữ liệu. Vui lòng nhập thông tin NCC mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetNCCInputs();
                txtMaNCC.Text = GenerateNewNCCID();
                txtTenNCC.Enabled = true;
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
        private void ResetNCCInputs()
        {
            txtMaNCC.Clear();
            txtTenNCC.ReadOnly = false;
            txtTenNCC.Clear();
            txtDiachi.ReadOnly = false;
            txtDiachi.Clear();
            //mskDienthoai.Clear();
        }
        private string GenerateNewNCCID()
        {
            // Generate a new customer ID based on your logic. For example:
            string query = "SELECT TOP 1 MaNCC FROM tblnhacungcap ORDER BY MaNCC DESC";
            string lastID = Function.GetFieldValues(query);

            if (string.IsNullOrEmpty(lastID))
            {
                return "NCC001";
            }

            int newID = int.Parse(lastID.Substring(3)) + 1;
            return "NCC" + newID.ToString("D3"); // Format as NCCxxx
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                // Lấy chỉ số dòng hiện tại
                int rowIndex = e.RowIndex;

                // Lấy mã sản phẩm và thành tiền của dòng hiện tại
                string masanpham = DataGridView.Rows[rowIndex].Cells["MaSP"].Value.ToString();
                double Thanhtien = Convert.ToDouble(DataGridView.Rows[rowIndex].Cells["Thanhtien"].Value.ToString());

                // Xóa hàng tạm thời khỏi DataGridView
                DelHangTamThoi(rowIndex);

                // Cập nhật lại tổng tiền cho hóa đơn
                DelUpdateTongtien(txtMahoadon.Text, Thanhtien);
            }
        }
        private void DelHangTamThoi(int rowIndex)
        {
            // Xóa hàng tạm thời khỏi DataGridView
            if (rowIndex >= 0 && rowIndex < DataGridView.Rows.Count)
            {
                DataGridView.Rows.RemoveAt(rowIndex);
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
                lblBangchu.Text = "Bằng chữ: " + Class.Function.ChuyenSoSangChu(Tongmoi.ToString());
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("Lỗi khi cập nhật tổng tiền: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyhoadon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string maHDN = txtMahoadon.Text.Trim();

                    // Xóa các chi tiết hóa đơn trước
                    string query = $"DELETE FROM tblchitiethoadonnhap WHERE MaHDN = N'{maHDN}'";
                    Class.Function.RunSql(query);

                    // Xóa hóa đơn
                    query = $"DELETE FROM tblhoadonnhap WHERE MaHDN = N'{maHDN}'";
                    Class.Function.RunSql(query);

                    // Đặt lại tất cả các giá trị và trạng thái ban đầu của hóa đơn
                    ResetValues();

                    // Đặt lại trạng thái của các nút và hộp thoại
                    btnThemhoadon.Enabled = true;
                    btnThemsanpham.Enabled = false;
                    btnLuu.Enabled = false;
                    btnHuyhoadon.Enabled = false;
                    btnInhoadon.Enabled = false;

                    // Xóa toàn bộ dữ liệu trong DataGridView
                    tblCTHDN.Clear();
                    DataGridView.DataSource = tblCTHDN;

                    MessageBox.Show("Hóa đơn đã được hủy thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP HÀNG";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHDN, a.NgayNhap, a.Tongtien, b.TenNCC, b.Diachi, b.Dienthoai, c.TenNV FROM tblhoadonnhap AS a, tblnhacungcap AS b, tblnhanvien AS c WHERE a.MaHDN = N'" + txtMahoadon.Text + "' AND a.MaNCC = b.MaNCC AND a.MaNV = c.MaNV";
            tblThongtinHD = Function.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "NCC:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT TenSP, tblchitiethoadonnhap.SoLuong,DonGiaNhap, Giamgia, (DonGiaNhap*(1-GiamGia)*tblchitiethoadonnhap.SoLuong) as Thanhtien FROM tblchitiethoadonnhap JOIN tblsanpham on tblchitiethoadonnhap.MaSP = tblsanpham.MaSP  WHERE MaHDN = N'" + txtMahoadon.Text + "'";
            tblThongtinHang = Function.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên SP";
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

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThemhoadon.Enabled = true;
            btnHuyhoadon.Enabled = true;
            //btnsua.Enabled = true;
            btnLuu.Enabled = false;
            btnTimkiem.Enabled = true;
            cboMahoadon.Enabled = true;
            
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaSP.Text = DataGridView.CurrentRow.Cells["MaSP"].Value.ToString();
            txtTenSP.Text = DataGridView.CurrentRow.Cells["TenSP"].Value.ToString();
            txtSoluong.Text = DataGridView.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDongia.Text = DataGridView.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtGiamgia.Text = DataGridView.CurrentRow.Cells["GiamGia"].Value.ToString();


            CalculateTotal();
            Load_ThongtinHD();
            //btnsua.Enabled = true;
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

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (txtMaSP.Text == "")
                txtTenSP.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select TenSP from tblsanpham where MaSP = N'" + txtMaSP.Text + "'";
            txtTenSP.Text = Function.GetFieldValues(str);
        }
    }
}
