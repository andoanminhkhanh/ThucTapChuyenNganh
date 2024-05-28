namespace ThucTapChuyenNganh.Forms
{
    partial class Chitiethoadonbanhang
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
            this.btnThemsanpham = new System.Windows.Forms.Button();
            this.mskDienthoai = new System.Windows.Forms.MaskedTextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnNgay = new System.Windows.Forms.Button();
            this.cboMasanpham = new System.Windows.Forms.ComboBox();
            this.DataGridViewChitiet = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnInhoadon = new System.Windows.Forms.Button();
            this.btnHuyhoadon = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnThemhoadon = new System.Windows.Forms.Button();
            this.cboMahoadon = new System.Windows.Forms.ComboBox();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.txtThanhtien = new System.Windows.Forms.TextBox();
            this.txtDongia = new System.Windows.Forms.TextBox();
            this.txtGiamgia = new System.Windows.Forms.TextBox();
            this.txtTenhang = new System.Windows.Forms.TextBox();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.cboManhanvien = new System.Windows.Forms.ComboBox();
            this.txtNgayban = new System.Windows.Forms.TextBox();
            this.txtTennhanvien = new System.Windows.Forms.TextBox();
            this.txtMakhachhang = new System.Windows.Forms.TextBox();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.txtTenkhachhang = new System.Windows.Forms.TextBox();
            this.txtMahoadon = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBangchu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewChitiet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThemsanpham
            // 
            this.btnThemsanpham.Location = new System.Drawing.Point(344, 539);
            this.btnThemsanpham.Name = "btnThemsanpham";
            this.btnThemsanpham.Size = new System.Drawing.Size(143, 33);
            this.btnThemsanpham.TabIndex = 98;
            this.btnThemsanpham.Text = "Thêm sản phẩm";
            this.btnThemsanpham.UseVisualStyleBackColor = true;
            this.btnThemsanpham.Click += new System.EventHandler(this.btnThemsanpham_Click);
            // 
            // mskDienthoai
            // 
            this.mskDienthoai.Location = new System.Drawing.Point(870, 177);
            this.mskDienthoai.Mask = "(999) 000-0000";
            this.mskDienthoai.Name = "mskDienthoai";
            this.mskDienthoai.Size = new System.Drawing.Size(180, 22);
            this.mskDienthoai.TabIndex = 97;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(1104, 178);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(60, 23);
            this.btnTim.TabIndex = 95;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnNgay
            // 
            this.btnNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNgay.Location = new System.Drawing.Point(471, 110);
            this.btnNgay.Name = "btnNgay";
            this.btnNgay.Size = new System.Drawing.Size(55, 23);
            this.btnNgay.TabIndex = 94;
            this.btnNgay.Text = "...";
            this.btnNgay.UseVisualStyleBackColor = true;
            // 
            // cboMasanpham
            // 
            this.cboMasanpham.FormattingEnabled = true;
            this.cboMasanpham.Location = new System.Drawing.Point(271, 244);
            this.cboMasanpham.Name = "cboMasanpham";
            this.cboMasanpham.Size = new System.Drawing.Size(126, 24);
            this.cboMasanpham.TabIndex = 93;
            this.cboMasanpham.SelectedIndexChanged += new System.EventHandler(this.cboMasanpham_SelectedIndexChanged);
            //this.cboMasanpham.TextChanged += new System.EventHandler(this.cboMasanpham_TextChanged);
            // 
            // DataGridViewChitiet
            // 
            this.DataGridViewChitiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewChitiet.Location = new System.Drawing.Point(177, 319);
            this.DataGridViewChitiet.Name = "DataGridViewChitiet";
            this.DataGridViewChitiet.RowHeadersWidth = 51;
            this.DataGridViewChitiet.RowTemplate.Height = 24;
            this.DataGridViewChitiet.Size = new System.Drawing.Size(987, 150);
            this.DataGridViewChitiet.TabIndex = 92;
            this.DataGridViewChitiet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewChitiet_CellDoubleClick);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(1148, 539);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(84, 33);
            this.btnDong.TabIndex = 91;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnInhoadon
            // 
            this.btnInhoadon.Location = new System.Drawing.Point(960, 539);
            this.btnInhoadon.Name = "btnInhoadon";
            this.btnInhoadon.Size = new System.Drawing.Size(171, 33);
            this.btnInhoadon.TabIndex = 90;
            this.btnInhoadon.Text = "In hóa đơn";
            this.btnInhoadon.UseVisualStyleBackColor = true;
            this.btnInhoadon.Click += new System.EventHandler(this.btnInhoadon_Click);
            // 
            // btnHuyhoadon
            // 
            this.btnHuyhoadon.Location = new System.Drawing.Point(794, 539);
            this.btnHuyhoadon.Name = "btnHuyhoadon";
            this.btnHuyhoadon.Size = new System.Drawing.Size(145, 33);
            this.btnHuyhoadon.TabIndex = 89;
            this.btnHuyhoadon.Text = "Hủy hóa đơn";
            this.btnHuyhoadon.UseVisualStyleBackColor = true;
            this.btnHuyhoadon.Click += new System.EventHandler(this.btnHuyhoadon_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(668, 539);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(102, 33);
            this.btnLuu.TabIndex = 88;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(493, 581);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(84, 33);
            this.btnTimkiem.TabIndex = 87;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnThemhoadon
            // 
            this.btnThemhoadon.Location = new System.Drawing.Point(493, 539);
            this.btnThemhoadon.Name = "btnThemhoadon";
            this.btnThemhoadon.Size = new System.Drawing.Size(154, 33);
            this.btnThemhoadon.TabIndex = 86;
            this.btnThemhoadon.Text = "Thêm hóa đơn";
            this.btnThemhoadon.UseVisualStyleBackColor = true;
            this.btnThemhoadon.Click += new System.EventHandler(this.btnThemhoadon_Click);
            // 
            // cboMahoadon
            // 
            this.cboMahoadon.FormattingEnabled = true;
            this.cboMahoadon.Location = new System.Drawing.Point(244, 584);
            this.cboMahoadon.Name = "cboMahoadon";
            this.cboMahoadon.Size = new System.Drawing.Size(226, 24);
            this.cboMahoadon.TabIndex = 85;
            // 
            // txtTongtien
            // 
            this.txtTongtien.Location = new System.Drawing.Point(953, 488);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.Size = new System.Drawing.Size(211, 22);
            this.txtTongtien.TabIndex = 84;
            // 
            // txtThanhtien
            // 
            this.txtThanhtien.Location = new System.Drawing.Point(1038, 274);
            this.txtThanhtien.Name = "txtThanhtien";
            this.txtThanhtien.Size = new System.Drawing.Size(126, 22);
            this.txtThanhtien.TabIndex = 83;
            // 
            // txtDongia
            // 
            this.txtDongia.Location = new System.Drawing.Point(1038, 244);
            this.txtDongia.Name = "txtDongia";
            this.txtDongia.Size = new System.Drawing.Size(126, 22);
            this.txtDongia.TabIndex = 82;
            // 
            // txtGiamgia
            // 
            this.txtGiamgia.Location = new System.Drawing.Point(658, 276);
            this.txtGiamgia.Name = "txtGiamgia";
            this.txtGiamgia.Size = new System.Drawing.Size(126, 22);
            this.txtGiamgia.TabIndex = 81;
            // 
            // txtTenhang
            // 
            this.txtTenhang.Location = new System.Drawing.Point(658, 244);
            this.txtTenhang.Name = "txtTenhang";
            this.txtTenhang.Size = new System.Drawing.Size(126, 22);
            this.txtTenhang.TabIndex = 80;
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(271, 276);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(126, 22);
            this.txtSoluong.TabIndex = 79;
            this.txtSoluong.TextChanged += new System.EventHandler(this.txtSoluong_TextChanged);
            this.txtSoluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoluong_KeyPress);
            // 
            // cboManhanvien
            // 
            this.cboManhanvien.FormattingEnabled = true;
            this.cboManhanvien.Location = new System.Drawing.Point(312, 141);
            this.cboManhanvien.Name = "cboManhanvien";
            this.cboManhanvien.Size = new System.Drawing.Size(214, 24);
            this.cboManhanvien.TabIndex = 78;
            this.cboManhanvien.SelectedIndexChanged += new System.EventHandler(this.cboManhanvien_SelectedIndexChanged);
            this.cboManhanvien.TextChanged += new System.EventHandler(this.cboManhanvien_TextChanged);
            // 
            // txtNgayban
            // 
            this.txtNgayban.Location = new System.Drawing.Point(312, 111);
            this.txtNgayban.Name = "txtNgayban";
            this.txtNgayban.Size = new System.Drawing.Size(126, 22);
            this.txtNgayban.TabIndex = 77;
            // 
            // txtTennhanvien
            // 
            this.txtTennhanvien.Location = new System.Drawing.Point(312, 179);
            this.txtTennhanvien.Name = "txtTennhanvien";
            this.txtTennhanvien.Size = new System.Drawing.Size(214, 22);
            this.txtTennhanvien.TabIndex = 76;
            // 
            // txtMakhachhang
            // 
            this.txtMakhachhang.Location = new System.Drawing.Point(870, 75);
            this.txtMakhachhang.Name = "txtMakhachhang";
            this.txtMakhachhang.Size = new System.Drawing.Size(180, 22);
            this.txtMakhachhang.TabIndex = 75;
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(870, 144);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(362, 22);
            this.txtDiachi.TabIndex = 74;
            // 
            // txtTenkhachhang
            // 
            this.txtTenkhachhang.Location = new System.Drawing.Point(870, 111);
            this.txtTenkhachhang.Name = "txtTenkhachhang";
            this.txtTenkhachhang.Size = new System.Drawing.Size(180, 22);
            this.txtTenkhachhang.TabIndex = 73;
            // 
            // txtMahoadon
            // 
            this.txtMahoadon.Location = new System.Drawing.Point(312, 75);
            this.txtMahoadon.Name = "txtMahoadon";
            this.txtMahoadon.Size = new System.Drawing.Size(214, 22);
            this.txtMahoadon.TabIndex = 72;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label21.Location = new System.Drawing.Point(135, 592);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 16);
            this.label21.TabIndex = 71;
            this.label21.Text = "Mã hóa đơn";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label20.Location = new System.Drawing.Point(197, 82);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 16);
            this.label20.TabIndex = 70;
            this.label20.Text = "Mã hóa đơn";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label19.Location = new System.Drawing.Point(197, 117);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 16);
            this.label19.TabIndex = 69;
            this.label19.Text = "Ngày bán";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label18.Location = new System.Drawing.Point(197, 150);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 16);
            this.label18.TabIndex = 68;
            this.label18.Text = "Mã nhân viên";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label17.Location = new System.Drawing.Point(195, 185);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 16);
            this.label17.TabIndex = 67;
            this.label17.Text = "Tên nhân viên";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(752, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 16);
            this.label16.TabIndex = 66;
            this.label16.Text = "Mã khách hàng";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(750, 117);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 16);
            this.label15.TabIndex = 65;
            this.label15.Text = "Tên khách hàng";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(752, 185);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 16);
            this.label14.TabIndex = 64;
            this.label14.Text = "Điện thoại";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(174, 250);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 16);
            this.label13.TabIndex = 63;
            this.label13.Text = "Mã sản phẩm:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(174, 282);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 16);
            this.label12.TabIndex = 62;
            this.label12.Text = "Số lượng:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(556, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 16);
            this.label11.TabIndex = 61;
            this.label11.Text = "Tên sản phẩm:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(556, 282);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 60;
            this.label10.Text = "Giảm giá %";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(752, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 59;
            this.label9.Text = "Địa chỉ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(135, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 16);
            this.label8.TabIndex = 58;
            this.label8.Text = "Thông tin các mặt hàng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(950, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 57;
            this.label7.Text = "Đơn giá";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(950, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 56;
            this.label6.Text = "Thành tiền";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(174, 480);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 16);
            this.label5.TabIndex = 55;
            this.label5.Text = "Kích đúp một hàng để xóa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(867, 494);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 54;
            this.label4.Text = "Tổng tiền";
            // 
            // lblBangchu
            // 
            this.lblBangchu.AutoSize = true;
            this.lblBangchu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBangchu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblBangchu.Location = new System.Drawing.Point(135, 519);
            this.lblBangchu.Name = "lblBangchu";
            this.lblBangchu.Size = new System.Drawing.Size(71, 16);
            this.lblBangchu.TabIndex = 53;
            this.lblBangchu.Text = "Bằng chữ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(174, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 52;
            this.label2.Text = "Thông tin chung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(567, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 32);
            this.label1.TabIndex = 51;
            this.label1.Text = "HÓA ĐƠN BÁN HÀNG";
            // 
            // Chitiethoadonbanhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 630);
            this.Controls.Add(this.btnThemsanpham);
            this.Controls.Add(this.mskDienthoai);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnNgay);
            this.Controls.Add(this.cboMasanpham);
            this.Controls.Add(this.DataGridViewChitiet);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnInhoadon);
            this.Controls.Add(this.btnHuyhoadon);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.btnThemhoadon);
            this.Controls.Add(this.cboMahoadon);
            this.Controls.Add(this.txtTongtien);
            this.Controls.Add(this.txtThanhtien);
            this.Controls.Add(this.txtDongia);
            this.Controls.Add(this.txtGiamgia);
            this.Controls.Add(this.txtTenhang);
            this.Controls.Add(this.txtSoluong);
            this.Controls.Add(this.cboManhanvien);
            this.Controls.Add(this.txtNgayban);
            this.Controls.Add(this.txtTennhanvien);
            this.Controls.Add(this.txtMakhachhang);
            this.Controls.Add(this.txtDiachi);
            this.Controls.Add(this.txtTenkhachhang);
            this.Controls.Add(this.txtMahoadon);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblBangchu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Chitiethoadonbanhang";
            this.Text = "Chitiethoadonbanhang";
            this.Load += new System.EventHandler(this.Chitiethoadonbanhang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewChitiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThemsanpham;
        private System.Windows.Forms.MaskedTextBox mskDienthoai;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnNgay;
        private System.Windows.Forms.ComboBox cboMasanpham;
        private System.Windows.Forms.DataGridView DataGridViewChitiet;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnInhoadon;
        private System.Windows.Forms.Button btnHuyhoadon;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnThemhoadon;
        private System.Windows.Forms.ComboBox cboMahoadon;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.TextBox txtThanhtien;
        private System.Windows.Forms.TextBox txtDongia;
        private System.Windows.Forms.TextBox txtGiamgia;
        private System.Windows.Forms.TextBox txtTenhang;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.ComboBox cboManhanvien;
        private System.Windows.Forms.TextBox txtNgayban;
        private System.Windows.Forms.TextBox txtTennhanvien;
        private System.Windows.Forms.TextBox txtMakhachhang;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.TextBox txtTenkhachhang;
        private System.Windows.Forms.TextBox txtMahoadon;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBangchu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}