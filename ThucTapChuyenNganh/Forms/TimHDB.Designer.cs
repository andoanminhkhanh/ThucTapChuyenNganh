namespace ThucTapChuyenNganh.Forms
{
    partial class TimHDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaHDB = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgridTimHDB = new System.Windows.Forms.DataGridView();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnTimlai = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtMagiaovan = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTrangthai = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgridTimHDB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(73, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn:";
            // 
            // txtMaHDB
            // 
            this.txtMaHDB.Location = new System.Drawing.Point(194, 97);
            this.txtMaHDB.Name = "txtMaHDB";
            this.txtMaHDB.Size = new System.Drawing.Size(272, 26);
            this.txtMaHDB.TabIndex = 1;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(784, 103);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(292, 26);
            this.txtMaKH.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(631, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã khách hàng:";
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(145, 144);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(112, 26);
            this.txtThang.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(72, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tháng: ";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(363, 144);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(103, 26);
            this.txtNam.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(300, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Năm:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(784, 150);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(292, 26);
            this.txtTongTien.TabIndex = 9;
            this.txtTongTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTongTien_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(631, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tổng tiền:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(73, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mã nhân viên:";
            // 
            // dgridTimHDB
            // 
            this.dgridTimHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridTimHDB.Location = new System.Drawing.Point(32, 320);
            this.dgridTimHDB.Name = "dgridTimHDB";
            this.dgridTimHDB.RowHeadersWidth = 62;
            this.dgridTimHDB.RowTemplate.Height = 28;
            this.dgridTimHDB.Size = new System.Drawing.Size(1084, 303);
            this.dgridTimHDB.TabIndex = 12;
            this.dgridTimHDB.Click += new System.EventHandler(this.dgridTimHDB_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnTimkiem.Location = new System.Drawing.Point(213, 648);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(112, 47);
            this.btnTimkiem.TabIndex = 13;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnTimlai
            // 
            this.btnTimlai.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimlai.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnTimlai.Location = new System.Drawing.Point(623, 648);
            this.btnTimlai.Name = "btnTimlai";
            this.btnTimlai.Size = new System.Drawing.Size(112, 47);
            this.btnTimlai.TabIndex = 14;
            this.btnTimlai.Text = "Tìm lại";
            this.btnTimlai.UseVisualStyleBackColor = true;
            this.btnTimlai.Click += new System.EventHandler(this.btnTimlai_Click);
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDong.Location = new System.Drawing.Point(824, 648);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(112, 47);
            this.btnDong.TabIndex = 15;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(433, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 31);
            this.label7.TabIndex = 16;
            this.label7.Text = "TÌM HÓA ĐƠN BÁN";
            // 
            // cboMaNV
            // 
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(213, 190);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(253, 28);
            this.cboMaNV.TabIndex = 17;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSua.Location = new System.Drawing.Point(421, 648);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(112, 47);
            this.btnSua.TabIndex = 18;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtMagiaovan
            // 
            this.txtMagiaovan.Location = new System.Drawing.Point(784, 196);
            this.txtMagiaovan.Name = "txtMagiaovan";
            this.txtMagiaovan.Size = new System.Drawing.Size(292, 26);
            this.txtMagiaovan.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(631, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "Mã giao vận:";
            // 
            // cboTrangthai
            // 
            this.cboTrangthai.FormattingEnabled = true;
            this.cboTrangthai.Items.AddRange(new object[] {
            "Đang chuẩn bị hàng",
            "Đang vận chuyển",
            "Hoàn thành",
            "Hủy hàng"});
            this.cboTrangthai.Location = new System.Drawing.Point(267, 248);
            this.cboTrangthai.Name = "cboTrangthai";
            this.cboTrangthai.Size = new System.Drawing.Size(199, 28);
            this.cboTrangthai.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(73, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "Trạng thái đơn hàng: ";
            // 
            // TimHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 730);
            this.Controls.Add(this.cboTrangthai);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMagiaovan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.cboMaNV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTimlai);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.dgridTimHDB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaHDB);
            this.Controls.Add(this.label1);
            this.Name = "TimHDB";
            this.Text = "Tìm hóa đơn bán";
            this.Load += new System.EventHandler(this.TimHDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridTimHDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaHDB;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgridTimHDB;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnTimlai;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.TextBox txtMagiaovan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTrangthai;
        private System.Windows.Forms.Label label9;
    }
}