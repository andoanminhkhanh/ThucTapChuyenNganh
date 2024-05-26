using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucTapChuyenNganh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuKhachhang_Click(object sender, EventArgs e)
        {
            Forms.Khachhang a = new Forms.Khachhang();
            a.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
        }

        private void mnuMausanpham_Click(object sender, EventArgs e)
        {
            Forms.Mausanpham a = new Forms.Mausanpham();
            a.Show();
        }

        private void mnuLoaisanpham_Click(object sender, EventArgs e)
        {
            Forms.Loaisanpham a = new Forms.Loaisanpham();
            a.Show();
        }

        /*private void mnuHoadonnhap_Click(object sender, EventArgs e)
        {
            Forms.Hoadonnhap a = new Forms.Hoadonnhap();
            a.Show();
        }*/

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuNhacungcap_Click(object sender, EventArgs e)
        {
            Forms.Nhacungcap a = new Forms.Nhacungcap();
            a.Show();
        }

        /*private void tìmHóaĐơnNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.Bangchamcong a = new Forms.Bangchamcong();
            a.Show();
        }*/
        private void mnuChitiethoadonnhap_Click(object sender, EventArgs e)
        {
            Forms.Chitiethoadonnhap a = new Forms.Chitiethoadonnhap();
            a.Show();
        }

        private void mnuChitiethoadonban_Click(object sender, EventArgs e)
        {
            Forms.Hoadonbanhang a = new Forms.Hoadonbanhang();
            a.Show();
        }

        private void mnuNhacungcap_Click_1(object sender, EventArgs e)
        {
            Forms.Nhacungcap a = new Forms.Nhacungcap();
            a.Show();
        }

        private void mnuNhanvien_Click(object sender, EventArgs e)
        {
            Forms.Nhanvien a = new Forms.Nhanvien();
            a.Show();
        }

        private void mnuCongviec_Click(object sender, EventArgs e)
        {
            Forms.Congviec a = new Forms.Congviec();
            a.Show();
        }

        private void côngTheoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Tonghopcongtheothang a = new Forms.Tonghopcongtheothang();
            a.Show();
        }


        private void mnuTimHDN_Click(object sender, EventArgs e)
        {
            Forms.TimHDN a = new Forms.TimHDN();
            a.Show();
        }


        private void mnuTimHDB_Click_1(object sender, EventArgs e)
        {

            Forms.TimHDB a = new Forms.TimHDB();
            a.Show();
        }

        private void mnuBangchamcong_Click(object sender, EventArgs e)
        {
            Forms.Bangchamcong a = new Forms.Bangchamcong();
            a.Show();
        }

        private void mnuBangluong_Click(object sender, EventArgs e)
        {
            Forms.Bangluong a = new Forms.Bangluong();
            a.Show();
        }

        private void mnuSanpham_Click(object sender, EventArgs e)
        {
            Forms.Sanpham a = new Forms.Sanpham();
            a.Show();
        }
    }
}
