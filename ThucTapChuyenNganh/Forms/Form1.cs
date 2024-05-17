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

        private void mnuHoadonnhap_Click(object sender, EventArgs e)
        {
            Forms.Hoadonnhap a = new Forms.Hoadonnhap();
            a.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Nhacungcap a = new Forms.Nhacungcap();
            a.Show();
        }
        private void côngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Congviec a = new Forms.Congviec();
            a.Show();
        }
    }
}
