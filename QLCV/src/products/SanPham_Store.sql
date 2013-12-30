--THỦ TỤC LƯU TRỮ SẢN PHẨM
---------------------THÊM----------------------
CREATE PROC SanPham_Them
@TenSP nvarchar(50),
@AnhMH nvarchar(50),
@BaoHanh tinyint,
@DungTXL float,
@CongSTD1 float,
@CongSTD2 smallint,
@DonGia money,
@MoTaSP nvarchar(200), 
@MaNVDangSP tinyint,
@MaLSP tinyint,
@MaHSX tinyint,
@MaDC tinyint
AS
	IF(@TenSP not in(SELECT TenSP FROM SanPham))
		BEGIN
			DECLARE @MaSP nchar(8)
			DECLARE @TinhTrang bit
			DECLARE @NgayDangSP smalldatetime
			DECLARE @NamThangNgay nchar(6)
			SELECT @NamThangNgay =SUBSTRING (CONVERT(nvarchar,GETDATE(),103),9,2)
									  +SUBSTRING (CONVERT(nvarchar,GETDATE(),103),4,2)
									  +SUBSTRING (CONVERT(nvarchar,GETDATE(),103),1,2)
			SELECT MaSP
			FROM SanPham
			WHERE MaSP LIKE @NamThangNgay+'%'
			IF(@@ROWCOUNT = 0)
				SET @MaSP = @NamThangNgay+'01'
			ELSE
				BEGIN
					SELECT @MaSP = Max(MaSP) FROM SanPham
					SET @MaSP = CONVERT(int,@MaSP) + 1
				END
			SET @TinhTrang = 1
			INSERT INTO SanPham(MaSP,TenSP,TinhTrang,AnhMH,NgayDangSP,BaoHanh,DungTXL,CongSTD1,CongSTD2,DonGia,MoTaSP,MaNVDangSP,MaLSP,MaHSX,MaDC)
			VALUES (@MaSP,@TenSP,@TinhTrang,@AnhMH,GETDATE(),@BaoHanh,@DungTXL,@CongSTD1,@CongSTD2,@DonGia,@MoTaSP,@MaNVDangSP,@MaLSP,@MaHSX,@MaDC)
		END
	ELSE
		RAISERROR (N'THÊM KHÔNG THÀNH CÔNG-TÊN SẢN PHẨM ĐÃ TỒN TẠI TRONG HỆ THỐNG.',16,1);
GO
DROP PROC SanPham_Them
-------------------------XÓA-----------------------------
CREATE PROC SanPham_Xoa
@MaSP nchar(8)
AS
	IF(@MaSP in(SELECT MaSP FROM SanPham))
		BEGIN
			DELETE SanPham
			WHERE MaSP = @MaSP
		END
	ELSE
		RAISERROR (N'XÓA KHÔNG THÀNH CÔNG-MÃ SẢN PHẨM KHÔNG TỒN TẠI TRONG HỆ THỐNG.',16,1)
GO
--------------------------SỬA------------------------------
CREATE PROC SanPham_Sua
@MaSP nchar(8),
@TenSP nvarchar(50),
@TinhTrang bit,
@AnhMH nvarchar(50),
@BaoHanh tinyint,
@DungTXL float,
@CongSTD1 float,
@CongSTD2 smallint,
@DonGia money,
@MoTaSP nvarchar(200),
@KQDuyetSP bit, 
--@MaNVDangSP tinyint,
@MaLSP tinyint,
@MaHSX tinyint,
@MaDC tinyint
AS
	IF((@MaSP in(SELECT MaSP FROM SanPham)) AND (@TenSP not in(SELECT TenSP FROM SanPham WHERE MaSP <> @MaSP )))
		BEGIN
			UPDATE SanPham
			SET TenSP = @TenSP,
				TinhTrang = @TinhTrang,
				AnhMH = @AnhMH, 
				BaoHanh = @BaoHanh,
				DungTXL = @DungTXL,
				CongSTD1 =  @CongSTD1,
				CongSTD2 =  @CongSTD2,
				DonGia = @DonGia,
				MoTaSP = @MoTaSP,
				KQDuyetSP = @KQDuyetSP,
				MaLSP = @MaLSP,
				MaHSX = @MaHSX,
				MaDC = @MaDC
			WHERE MaSP = @MaSP --AND MaNVDangSP = @MaNVDangSP
		END
	ELSE
		IF((@MaSP in(SELECT MaSP FROM SanPham)) AND (@TenSP in(SELECT TenSP FROM SanPham)))
			RAISERROR (N'SỬA KHÔNG THÀNH CÔNG-TÊN SẢN PHẨM TỒN TẠI TRONG HỆ THỐNG.',16,1)
		ELSE
			RAISERROR (N'SỬA KHÔNG THÀNH CÔNG-MÃ SẢN PHẨM KHÔNG TỒN TẠI TRONG HỆ THỐNG.',16,1)
GO
DROP PROC SanPham_Sua
--------------------------DANH SÁCH---------------------------
CREATE PROC SanPham_DS
AS
	BEGIN
		SELECT MaSP, TenSP, TinhTrang, AnhMH, NgayDangSP, BaoHanh, DungTXL, CAST(CongSTD1 AS varchar) +'/ '+ CAST(CongSTD2 AS varchar) AS CongSTD, DonGia, MoTaSP, HoNV +''+ TenNV AS HoTenNV, TenLSP, TenHSX, TenDC,NgayDuyetSP,KQDuyetSP, MaNVDuyetSP,(SELECT NV.HoNV+' '+NV.TenNV FROM NhanVien NV, SanPham SP1 WHERE SP1.MaSP = SP.MaSP AND SP.MaNVDuyetSP = NV.MaNV AND SP.MaHSX = HSX.MaHSX AND SP.MaDC = DC.MaDC) AS NguoiDuyet
		FROM SanPham SP, NhanVien NV, LoaiSP LSP,HangSX HSX, DongCo DC
		WHERE SP.MaLSP = LSP.MaLSP AND SP.MaNVDangSP = NV.MaNV AND SP.MaHSX = HSX.MaHSX AND SP.MaDC = DC.MaDC
		ORDER BY MaSP
	END
GO
DROP PROC SanPham_DS

-------------------------CHI TIẾT----------------------------
CREATE PROC SanPham_CT
@MaSP nchar(8)
AS
	IF(@MaSP in (SELECT MaSP FROM SanPham))
		BEGIN
			SELECT MaSP, TenSP, TinhTrang, AnhMH, NgayDangSP, BaoHanh, DungTXL, CongSTD1, CongSTD2, DonGia, MoTaSP, MaNVDangSP, HoNV +''+ TenNV AS HoTenNV, SP.MaLSP,TenLSP, SP.MaHSX, TenHSX, SP.MaDC, TenDC,NgayDuyetSP,KQDuyetSP, MaNVDuyetSP
			FROM SanPham SP, NhanVien NV, LoaiSP LSP,HangSX HSX, DongCo DC
			WHERE MaSP = @MaSP AND SP.MaLSP = LSP.MaLSP AND SP.MaNVDangSP = NV.MaNV AND SP.MaHSX = HSX.MaHSX AND SP.MaDC = DC.MaDC
		END
	ELSE
		RAISERROR (N'MÃ SẢN PHẨM KHÔNG TỒN TẠI TRONG HỆ THỐNG',16,1)
GO
drop proc SanPham_CT
--------------------------SẢN PHẨM THEO LOẠI SẢN PHẨM------------------------
CREATE PROC SanPham_Theo_LoaiSP
@MaLSP tinyint
AS
	SELECT MaSP, TenSP, TinhTrang, AnhMH, NgayDangSP, BaoHanh, DonGia, MaNVDangSP, HoNV +' '+ TenNV AS HoTenNV
	FROM SanPham SP, NhanVien NV
	WHERE MaLSP = @MaLSP AND MaNVDangSP = MaNV
	ORDER BY NgayDangSP DESC
GO
DROP PROC SanPham_Theo_LoaiSP
--------------------------SẢN PHẨM CÙNG LOẠI SẢN PHẨM-------------------------
CREATE PROC SanPham_Cung_LoaiSP
@MaSP nchar(9)
AS
	DECLARE @MaLSP TINYINT
	--SELECT @MaNT = MaNT
	--FROM TinTuc
	--WHERE MaTT = @MaTT
	SELECT MaSP, TenSP, NgayDangSP
	FROM SanPham
	WHERE MaLSP = @MaLSP AND MaSP <> @MaSP
	ORDER BY NgayDangSP DESC
GO
----------------------------DUYỆT SẢN PHẨM-----------------------------
CREATE PROC SanPham_Duyet
@MaSP nchar(9),
@KQDuyetSP bit
AS	
			BEGIN
				DECLARE @NgayDuyet smalldatetime
				DECLARE @TenPB NVARCHAR(50)
				UPDATE SanPham
				SET @NgayDuyet = GETDATE(),
					KQDuyetSP = @KQDuyetSP
					--MaNVDuyet = @MaNVDuyet
				WHERE MaSP = @MaSP
			END
GO