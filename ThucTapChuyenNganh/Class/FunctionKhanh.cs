using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucTapChuyenNganh.Class
{
    internal class FunctionKhanh
    {
        public static SqlConnection Conn;  // Khai báo đối tượng kết nối
        public static string connString;   // Khai báo biến chứa chuỗi kết nối
        public static void Connect()
        {
            connString = "Data Source=LAPTOP-THOQUC6C\\MSSQLSERVER01;Initial Catalog=TTCN;Integrated Security=True;Encrypt=False";
            Conn = new SqlConnection();         		// Cấp phát đối tượng
            Conn.ConnectionString = connString; 		// Kết nối
            Conn.Open();                                // Mở kết nối
        }
        public static void Disconnect()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();   	// Đóng kết nối
                Conn.Dispose();     // Giải phóng tài nguyên
                Conn = null;
            }
        }

        public static void RunSql(string sql)
        {
            SqlCommand cmd;		                // Khai báo đối tượng SqlCommand
            cmd = new SqlCommand();	         // Khởi tạo đối tượng
            cmd.Connection = FunctionKhanh.Conn;	  // Gán kết nối
            cmd.CommandText = sql;			  // Gán câu lệnh SQL
            try
            {
                cmd.ExecuteNonQuery();		  // Thực hiện câu lệnh SQL
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }

        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = FunctionKhanh.Conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xóa...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cmd.Dispose();
            cmd = null;
        }



        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, FunctionKhanh.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;

            cbo.ValueMember = ma;    // Field for value
            cbo.DisplayMember = ma;  // Field to display
        }

        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, FunctionKhanh.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }

        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, FunctionKhanh.Conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        }

        // Hàm tạo khóa có dạng: TientoNgaythangnam_giophutgiay
        public static string CreateKey(string tiento)
        {
            // Ensure tiento fits within a reasonable limit, for example, 3 characters
            if (tiento.Length > 3)
                tiento = tiento.Substring(0, 3);

            // Create a new GUID and convert it to a string
            string guidPart = Guid.NewGuid().ToString("N"); // "N" format is 32 digits without hyphens

            // Combine tiento and guidPart ensuring the total length fits your needs
            string key = tiento + guidPart;

            // Truncate if necessary to fit within a specific character limit, e.g., 10 characters
            if (key.Length > 10)
                key = key.Substring(0, 10);

            return key;
        }



        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }

        public static bool IsDate(string d)
        {
            string[] parts = d.Split('/');
            if ((Convert.ToInt32(parts[0]) >= 1) && (Convert.ToInt32(parts[0]) <= 31) &&
                (Convert.ToInt32(parts[1]) >= 1) && (Convert.ToInt32(parts[1]) <= 12) &&
                (Convert.ToInt32(parts[2]) >= 1900))
                return true;
            else
                return false;
        }

        public static string ConvertDateTime(string d)
        {
            string[] parts = d.Split('/');
            string dt = String.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }

        public static string ChuyenSoSangChu(string sNumber)
        {
            if (string.IsNullOrEmpty(sNumber))
            {
                return "Không có số tiền để chuyển đổi.";
            }

            string[] mNumText = new string[]
            {
        "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín"
            };

            string[] mPowersText = new string[]
            {
        "", "nghìn", "triệu", "tỷ"
            };

            string result = "";
            int len = sNumber.Length;

            // Xử lý các nhóm ba chữ số
            for (int i = 0; i < len; i += 3)
            {
                int groupSize = Math.Min(3, len - i);
                string group = sNumber.Substring(len - i - groupSize, groupSize);
                if (!int.TryParse(group, out int number))
                {
                    return "Số tiền không hợp lệ.";
                }

                string groupResult = "";

                // Xử lý hàng đơn vị, chục và trăm
                for (int j = groupSize - 1; j >= 0; j--)
                {
                    int digit = number % 10;
                    number /= 10;

                    if (digit == 0)
                    {
                        // Bỏ qua các chữ số 0
                        if (j == 2 && groupResult != "")
                        {
                            groupResult = "không trăm " + groupResult;
                        }
                        else if (j == 1)
                        {
                            groupResult = "linh " + groupResult;
                        }
                    }
                    else
                    {
                        // Thêm vào chữ số
                        if (j == 2)
                        {
                            groupResult = mNumText[digit] + " trăm " + groupResult;
                        }
                        else if (j == 1)
                        {
                            if (digit == 1)
                            {
                                groupResult = "mười " + groupResult;
                            }
                            else
                            {
                                groupResult = mNumText[digit] + " mươi " + groupResult;
                            }
                        }
                        else
                        {
                            groupResult = mNumText[digit] + " " + groupResult;
                        }
                    }
                }

                // Thêm vào đơn vị (nghìn, triệu, tỷ)
                groupResult += " " + mPowersText[i / 3];

                // Nối vào kết quả chính
                if (result != "")
                {
                    if (groupResult.Trim() != "")
                    {
                        result = groupResult + " " + result;
                    }
                }
                else
                {
                    result = groupResult;
                }
            }

            // Viết hoa chữ cái đầu tiên
            result = char.ToUpper(result[0]) + result.Substring(1).Trim();

            return result + " đồng";
        }
    }
}
