CREATE TABLE PhongBan
(
	Ma tinyint primary key,
	TenPB nvarchar(50) not null unique
)
Drop table PhongBan
INSERT INTO PhongBan VALUES (1,N'Kinh doanh'),
							(2,N'Tài chính'),
							(3,N'Nhân sự')
CREATE TABLE LoaiCV
(
	Ma tinyint primary key,
	TenLCV nvarchar(50) not null unique
)
Drop table LoaiCV
INSERT INTO LoaiCV VALUES (1,N'Soạn thảo'),
							(2,N'Phát hành'),
							(3,N'Văn bản đến')
CREATE TABLE TinhTrang
(
	Ma tinyint primary key,
	TenTT nvarchar(50) not null unique
)
Drop table TinhTrang
INSERT INTO TinhTrang VALUES (1,N'Đã đọc'),
							(2,N'Đã duyệt'),
							(3,N'Đã gởi'),
							(4,N' Đã phát hành'),
							(5,N' Đã trình duyệt'),
							(6,N' Đang soạn')
CREATE TABLE ChucNang
(
	Ma varchar(10) primary key,
	TenCN nvarchar(50) not null unique,
	STT tinyint not null,
	Me varchar(10) not null,
	ThuTuc nvarchar(20)
)
Drop table ChucNang
INSERT INTO ChucNang VALUES (N'1.',N'Soạn',1,N'1.'),
							(N'2.',N'Sửa',2,N'2.'),
							(N'3.',N'Đánh số',3,N'3.'),
							(N'4.',N'Đọc',4,N'4.'),
							(N'5.',N'Xóa',5,N'5.')
CREATE TABLE Menu
(
	Ma tinyint primary key,
	TenMenu nvarchar(50) not null unique,
	Me tinyint not null,
	Link nvarchar(100)
)
CREATE TABLE CongVan
(
	Ma varchar(7) ,
	Me varchar(9),
	So varchar(9) not null primary key,
	Ma_LCV tinyint not null foreign key references LoaiCV(Ma),
	TenCV nvarchar(100),
	TrichYeu nvarchar(500),
	TenFile nvarchar(100),
	NgayPH smalldatetime ,
	YKienLD nvarchar(500),
	YKienCV nvarchar(500),
	ThoiGianSoan datetime
)
Drop table CongVan
INSERT INTO CongVan VALUES (N'CV071213',1,1,N'Kế hoạch công tác tháng 12',N'',N'KeHoachCongTacThang12',07/12/2013,N'',N''),
							(N'CV070210',2,3,N'Hợp đồng về dây chuyền nhập khẩu',N'',N'HopDongVeDayChuyenNhapKhau',07/02/2010,N'',N''),
							(N'CV151212',3,1,N'Quy định khen thưởng',N'',N'QuyDinhKhenThuong',15/12/2012,N'',N'')


exec CongVan_Them 3,N'Họp tổng kết năm 2013',N'Mời các đồng chí về dự buổi họp tổng kết năm 2013',N'Tongketnam2013.doc',30/12/2013, N'',N''
exec CongVan_Them 1,N'Thông báo: Danh sách tăng lương',N'Danh sách tăng lương bắt đầu từ tháng 1/2014',N'danhsachtangluong114.doc',30/12/2013, N'',N''
exec CongVan_Them 4,N'Đôn đốc hoàn thành dự án',N'Nhắc các đồng chí nhanh chóng kết thúc dự án trong tháng này',N'dondocduan.doc',27/12/2013, N'',N''


CREATE TABLE NhanVien
(
	Ma tinyint primary key,
	Ma_PB tinyint not null foreign key references PhongBan(Ma),
	Ho nvarchar(50) not null,
	TenNV nvarchar(15) not null,
	NgaySinh smalldatetime not null,
	GioiTinh bit not null,
	DiaChi nvarchar(100) not null,
	DienThoai nvarchar(12) not null,
	AnhNV nvarchar(50) not null
)
Drop table NhanVien
INSERT INTO NhanVien VALUES (1,1,N'Nguyễn Thị',N'Lãnh',N'05/11/1992',1,N'Tam Anh-Núi Thành-Quảng Nam',N'01674590380',N'anhlanh'),
							(2,2,N'Nguyễn Mạnh',N'Hùng',N'11/10/1992',0,N'Nga Tân-Nga Sơn-Thanh Hóa',N'0976744231',N'anhhung'),
							(3,2,N'Bùi Ngọc',N'Hưng',N'02/08/1992',0,N'Vĩnh Thọ-Nha Trang-Khánh Hòa',N'0121200513',N'anhhung'),
							(4,3,N'Trần Thị',N'Hạnh',N'10/09/1992',1,N'Tam Hải- Núi Thành-Quảng Nam',N'01655585131',N'anhhanh')
CREATE TABLE UserN
(
	Ma tinyint primary key,
	Ma_NV tinyint not null foreign key references NhanVien(Ma),
	TenUser nvarchar(100) not null,
	MatKhau nvarchar(100) not null,
	IsUser bit not null
)
Drop table UserN							
INSERT INTO UserN VALUES (5, 4, N'tranthihanh@gmail.com', pwdencrypt(N'tranthihanh@gmail.com'),1),
						 (1, 1, N'nguyenthilanh52th@gmail.com',N'nguyenthilanh52th@gmail.com',1),
						 (2, 1, N'nguyenthilan@gmail.com',N'nguyenthilan@gmail.com',1),
						 (3, 2, N'nguyenmanhhung@gmail.com',N'nguyenmanhhung@gmail.com',1),
						 (4, 3, N'buingochung@gmail.com',N'buingochung@gmail.com',1)
CREATE TABLE NhomUser
(
	Ma tinyint not null,
	TenNhom nvarchar(20) not null,
	Ma_User tinyint not null foreign key references UserN(Ma),
	constraint PK_NhomUser primary key (Ma,Ma_User)
)
Drop table NhomUser
INSERT INTO NhomUser VALUES (1,N'Lãnh đạo',1),
							(1,N'Lãnh đạo',2),
							(2,N'Chuyên viên',3),
							(3,N'Văn thư',4)
CREATE TABLE PhanQuyen
(
	Ma_CN varchar(10) not null foreign key references ChucNang(Ma),
	Ma_User tinyint not null foreign key references UserN(Ma),
	constraint PK_PhanQuyen primary key (Ma_CN,Ma_User)
)
Drop table PhanQuyen
INSERT INTO PhanQuyen VALUES (N'1.',1),
							(N'2.',2)
CREATE TABLE CV_UserN_TT
(
	So int primary key,
	So_CV varchar(9) not null foreign key references CongVan(So),
	Ma_TT tinyint not null foreign key references TinhTrang(Ma),
	Ma_User tinyint not null foreign key references UserN(Ma),
	Ma_UserNhan tinyint,
	ThoiGianGui smalldatetime,
	ThoiGianDoc smalldatetime,
	ThoiGianDuyet smalldatetime
)
Drop table CV_UserN_TT
INSERT INTO CV_UserN_TT VALUES (1, 1, 1, 2, 05/12/2013,N''),
								(1, 1, 1, 3, 05/12/2013,N''),
								(2, 2, 2, 2, 05/12/2013,N'')