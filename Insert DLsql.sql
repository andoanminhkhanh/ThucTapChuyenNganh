--tblmau
insert into tblmau
values ('#000', 'Mau den');
insert into tblmau
values ('#FFF', 'Mau trang');
insert into tblmau
values ('#FF0', 'Mau do');
insert into tblmau
values ('#00F', 'Mau xanh la');
insert into tblmau
values ('#0FF', 'Mau xanh da troi');

--tbltheloai
insert into tbltheloai
values ('L1', 'Ao tam');
insert into tbltheloai
values ('L2', 'Ao ngu');
insert into tbltheloai
values ('L3', 'Quan ngu');
insert into tbltheloai
values ('L4', 'Bo quan ao ngu');
insert into tbltheloai
values ('L5', 'Ao coc tay');

--tblsanpham


--tblkhachhang
insert into tblkhachhang
values ('KH001','Hong Ngoc','So 6 - My Xa - Nam Dinh','0912873465');
insert into tblkhachhang
values ('KH002','Ho Quynh Huong','Phu Trung - Khanh An - Yen Khanh - Ninh Binh','0965784312');
insert into tblkhachhang
values ('KH003','Bang Kieu','Quang Phu Cau - Ung Hoa - Ha Tay - Ha Noi','0912834756');
insert into tblkhachhang
values ('KH004','My Tam', 'Cau Giay - Ha Noi','0914238765');
insert into tblkhachhang
values ('KH005','Xuan Bac','Pho Vien - Co Nhue - Nam Tu Liem - Ha Noi','0986735421');

--tblcongviec
insert into tblcongviec
values ('CV01','Quan ly Kho','30000');
insert into tblcongviec
values ('CV02', 'Ban hang', '28000');

--tblnhanvien
INSERT INTO tblnhanvien
VALUES 
    ('NV01', 'Pham Van Manh','Nam', '2003-10-10','0987654321','162-Khương Dinh-ThanhXuan-Ha Noi','CV01'),
    ('NV02', 'Tran Thi Hoa', 'Nu', '1995-05-10', '0987654321', '456 Duong Thanh Xuan-Quan Thanh Xuan', 'CV02'),
    ('NV03', 'Le Hong Ngoc', 'Nu', '2000-09-20', '0123456789', '789 Duong Thanh Xuan-Quan Dong Da', 'CV01'),
    ('NV04', 'Pham Thi Duyen', 'Nu', '1992-03-15', '9876543210', '101 Duong Nguyen Trai-Quan Thanh Xuan', 'CV02'),
    ('NV05', 'Hoang Thi Hong', 'Nu', '1988-07-25', '0123456789', '222 Duong Khuong Trung-Quan Thanh Xuan', 'CV02');

--tblbangchamcong
insert into tblbangchamcong
values 
--('NV01','2024-04-18','2024-04-18 08:00:00','2024-04-18 17:05:05'),
('NV01','2024-04-19','2024-04-19 07:59:03','2024-04-19 16:05:00'),
('NV01','2024-04-22','2024-04-22 08:00:03','2024-04-22 16:45:00'),
('NV01','2024-04-17','2024-04-17 08:02:03','2024-04-17 17:00:00'),
('NV02','2024-04-18','2024-04-18 07:59:03','2024-04-18 16:05:00'),
('NV02','2024-04-19','2024-04-19 08:00:03','2024-04-19 16:55:00'),
('NV03','2024-04-18','2024-04-18 08:05:03','2024-04-18 17:00:00');

--tblbangluong
--tblnhacungcap
insert into tblnhacungcap
values
('NCC001', 'Quang Hai', 'Lao Cai', '0123456789'),
('NCC002', 'Le Quyen', 'Ba Dinh - Ha Noi', '0987654321'),
('NCC003', 'Nixihao', 'Quang Chau', '0369852147'),
('NCC004', 'Dung Nhi', 'Dong Da - Ha Noi', '0542136987'),
('NCC005', 'Mixie', 'Quang Chau', '0123456789');

--tblhoadonnhap
insert into tblhoadonnhap
values
('HDN0001','NV01','NCC001','2024-02-01','184000000'),
('HDN0002','NV01','NCC003','2024-02-25','52000000'),
('HDN0003','NV03','NCC002','2024-03-12','31000000'),
('HDN0004','NV01','NCC001','2024-02-13','68000000'),
('HDN0005','NV03','NCC005','2024-02-13','29000000');

--tblhoadonban
insert into tblhoadonban
values
('HDB00001','NV02','2024-04-12','KH001','400000'),
('HDB00002','NV04','2024-04-12','KH002','360000'),
('HDB00003','NV05','2024-04-13','KH003','525000'),
('HDB00004','NV02','2024-04-14','KH004','335000'),
('HDB00005','NV04','2024-04-15','KH005','630000');


--tblchitiethoadonnhap

--tblchitiethoadonban
drop

--bangchamcong

	CREATE TABLE tblchamcong (
    MaNV NVARCHAR(10) NOT NULL,
    NgayLam DATE NOT NULL,
    GioVaoLam TIME,
    GioTanLam TIME,
    CONSTRAINT PK_tblchamcong PRIMARY KEY (MaNV, NgayLam)
);
INSERT INTO tblchamcong (MaNV, NgayLam, GioVaoLam, GioTanLam)
VALUES 
('NV01', CONVERT(DATE, '19-04-2024', 105), CONVERT(TIME, '07:59:03'), CONVERT(TIME, '16:05:00')),
('NV01', CONVERT(DATE, '22-04-2024', 105), CONVERT(TIME, '08:00:03'), CONVERT(TIME, '16:45:00')),
('NV02', CONVERT(DATE, '18-04-2024', 105), CONVERT(TIME, '07:59:03'), CONVERT(TIME, '16:05:00'));


--bangluong
INSERT INTO tblbangluong (MaNV, TongGioLam, TongTien)
SELECT
    MaNV,
    SUM(TongGioLam) AS TongGioLam,
    SUM(TongGioLam * HeSoLuong) AS TongTien
FROM
    (SELECT
        nv.MaNV,
        SUM(DATEDIFF(MINUTE, bc.GioVaoLam, bc.GioTanLam) / 60) AS TongGioLam,
        cv.HeSoLuong
    FROM
        tblnhanvien nv
    JOIN
        tblchamcong bc ON nv.MaNV = bc.MaNV
    JOIN
        tblcongviec cv ON nv.MaCV = cv.MaCV
    WHERE
        MONTH(bc.NgayLam) = 4 --theo tháng 4
    GROUP BY
        nv.MaNV, cv.HeSoLuong) AS T
GROUP BY
    MaNV;
	
	select * from tblbangluong

