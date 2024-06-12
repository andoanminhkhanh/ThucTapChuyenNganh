using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucTapChuyenNganh.Class
{
    internal class Function
    {
        public static SqlConnection Conn;
        public static string connString;
        public static void Connect()
        {
            connString = "Data Source=DESKTOP-JANPPMN;Initial Catalog=TTCN;Integrated Security=True;Encrypt=False";
            Conn = new SqlConnection();
            Conn.ConnectionString = connString;
            Conn.Open();
            //MessageBox.Show("Kết nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Disconnect()
        {
            if (Conn.State == System.Data.ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
                Conn = null;
            }
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Class.Function.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }
        public static void Fillcombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Class.Function.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }
        public static void RunSql(string sql)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = Class.Function.Conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception loi)
            {
                MessageBox.Show(loi.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        //Hàm tạo khóa có dạng: TientoNgaythangnam_giophutgiay
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/05/2024
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 07:05:08 PM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa kỹ tự trắng và AM hoặc PM
            key = key + "_";
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
        public static string CreateHDNKey()
        {
            string lastHDQCID = GetLastHDNID();
            if (string.IsNullOrEmpty(lastHDQCID))
            {
                return "HDN0001";
            }

            int hdqcPart = int.Parse(lastHDQCID.Substring(3));
            hdqcPart++; // Tăng số lên 1


            return "HDN" + hdqcPart.ToString("D4");
        }
        private static string GetLastHDNID()
        {
            string query = "SELECT TOP 1 MaHDN FROM tblhoadonnhap ORDER BY MaHDN DESC";

            SqlCommand cmd = new SqlCommand(query, Conn);
            object result = cmd.ExecuteScalar();
            return result != null ? result.ToString() : null;
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
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter mydata = new SqlDataAdapter(sql, Class.Function.Conn);
            DataTable table = new DataTable();
            mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static void RunSqlDel (string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class.Function.Conn;
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
            SqlDataAdapter mydata = new SqlDataAdapter(sql, Function.Conn);
            DataTable table = new DataTable();
            mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;

        }
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Function.Conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        }
        public static bool IsDate(string d)
        {
            string[] parts = d.Split('/');
            if ((Convert.ToInt32(parts[0]) >= 1) && (Convert.ToInt32(parts[0]) <= 31) && (Convert.ToInt32(parts[1]) >= 1) && (Convert.ToInt32(parts[1]) <= 12) && Convert.ToInt32(parts[2]) >= 1900)
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
            if (sNumber.Contains("."))
            {
                if (!decimal.TryParse(sNumber, out decimal dNumber))
                {
                    return "Số tiền không hợp lệ.";
                }
                sNumber = Math.Round(dNumber).ToString();
            }
            else
            {
                if (!decimal.TryParse(sNumber, out _))
                {
                    return "Số tiền không hợp lệ.";
                }
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
            int groupIndex = 0;

            while (len > 0)
            {
                int groupSize = Math.Min(3, len);
                string group = sNumber.Substring(len - groupSize, groupSize);
                len -= groupSize;

                if (!int.TryParse(group, out int number))
                {
                    return "Số tiền không hợp lệ.";
                }

                string groupResult = "";
                bool hasHundred = false;

                for (int i = 0; i < groupSize; i++)
                {
                    int digit = number % 10;
                    number /= 10;

                    if (i == 0)
                    {
                        if (digit == 1 && groupSize > 1 && group[groupSize - 2] != '1')
                        {
                            groupResult = "mốt " + groupResult;
                        }
                        else if (digit == 5 && groupSize > 1)
                        {
                            groupResult = "lăm " + groupResult;
                        }
                        else
                        {
                            groupResult = mNumText[digit] + " " + groupResult;
                        }
                    }
                    else if (i == 1)
                    {
                        if (digit == 0)
                        {
                            if (!string.IsNullOrEmpty(groupResult))
                            {
                                groupResult = "linh " + groupResult;
                            }
                        }
                        else if (digit == 1)
                        {
                            groupResult = "mười " + groupResult;
                        }
                        else
                        {
                            groupResult = mNumText[digit] + " mươi " + groupResult;
                        }
                    }
                    else if (i == 2)
                    {
                        hasHundred = true;
                        groupResult = mNumText[digit] + " trăm " + groupResult;
                    }
                }

                // Bỏ qua nhóm nếu toàn bộ là số 0
                if (group != "000")
                {
                    if (!string.IsNullOrEmpty(groupResult))
                    {
                        groupResult = groupResult.Trim();
                        if (groupIndex > 0)
                        {
                            groupResult += " " + mPowersText[groupIndex];
                        }

                        if (result != "")
                        {
                            result = groupResult + " " + result;
                        }
                        else
                        {
                            result = groupResult;
                        }
                    }
                }

                groupIndex++;
            }

            return result.Trim();
            // Viết hoa chữ cái đầu tiên
            result = char.ToUpper(result[0]) + result.Substring(1).Trim();

            return result + " đồng";
        }
    }
}
       
