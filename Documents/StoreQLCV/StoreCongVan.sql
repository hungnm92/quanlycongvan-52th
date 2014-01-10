--THỦ TỤC LƯU TRỮ CÔNG VĂN
----------------THÊM-----------------
CREATE PROC CongVan_Them
@Ma_LCV tinyint,
@Ten nvarchar(100),
@TrichYeu nvarchar(500),
@TenFile nvarchar(100),
@NgayPH smalldatetime,
@YKienLD nvarchar(500),
@YKienCV nvarchar(500)
AS	
		IF((@Ten not in(SELECT Ten FROM CongVan)) And (@TenFile not in(SELECT TenFile FROM CongVan)))
			BEGIN
				DECLARE @So int
				SET @So = 1 -- đặt Công văn đầu tiên có Số là 1.
				WHILE  (@So in (SELECT So FROM CongVan)) -- trong khi Số công văn đó đã có trong Công văn thì tiếp tục lặp.
				SET @So = @So +1 -- tăng Số lên 1.
				DECLARE @Ma varchar(9)
				DECLARE @NamThangNgay nchar(6)
				SELECT @NamThangNgay =SUBSTRING (CONVERT(nvarchar,GETDATE(),103),9,2)
									  +SUBSTRING (CONVERT(nvarchar,GETDATE(),103),4,2)
									  +SUBSTRING (CONVERT(nvarchar,GETDATE(),103),1,2)
				SELECT Ma
				FROM CongVan
				WHERE Ma LIKE @NamThangNgay+'%'
				IF(@@ROWCOUNT = 0)
					SET @Ma = @NamThangNgay+'001'
				ELSE
					BEGIN
						SELECT @Ma = Max(Ma) FROM CongVan
						SET @Ma = CONVERT(int,@Ma) + 1
					END
				INSERT INTO CongVan(Ma,So,Ma_LCV,Ten,TrichYeu,TenFile,NgayPH,YKienLD,YKienCV) VALUES(@Ma,@So,@Ma_LCV,@Ten,@TrichYeu,@TenFile,@NgayPH,@YKienLD,@YKienCV)
			END
		ELSE 
				RAISERROR (N'THÊM KHÔNG THÀNH CÔNG-TÊN CÔNG VĂN HOẶC TÊN FILE ĐÃ TỒN TẠI TRONG HỆ THỐNG.',16,1)
GO
DROP PROC CongVan_Them
EXEC CongVan_Them N'Siêu khuyến mãi',N'Nhân ngày lễ Giỗ tổ mùng 10/3...',N'Nhân ngày lễ Giỗ tổ mùng 10/3, công ty chúng tôi ra mắt các loại xe mới có kèm theo khuyến mãi',N'anh.jpg',3,2
---------------------XÓA-------------------------
CREATE PROC CongVan_Xoa
@So int
AS
			DELETE CongVan
			WHERE So = @So
GO
DROP PROC CongVan_Xoa
EXEC CongVan_Xoa 130610006
-----------------------SỬA-------------------------
CREATE PROC CongVan_Sua
@Ma varchar(9),
@So int,
@Ma_LCV tinyint,
@Ten nvarchar(100),
@TrichYeu nvarchar(500),
@TenFile nvarchar(100),
@NgayPH smalldatetime
--@YKienLD nvarchar(500),
--@YKienCV nvarchar(500)
AS
	IF(@Ma not in (SELECT Ma FROM CongVan WHERE So <> @So) AND (@Ten not in(SELECT Ten FROM CongVan WHERE So <> @So)) AND ((@TenFile not in(SELECT TenFile FROM CongVan WHERE So <> @So))))
		BEGIN
			UPDATE CongVan
			SET @Ma = @Ma,
				@Ma_LCV = @Ma_LCV,
				@Ten = @Ten,
				@TrichYeu = @TrichYeu,
				@TenFile = @TenFile,
				@NgayPH = @NgayPH
				--@YKienLD = @YKienLD,
				--@YKienCV = @YKienCV,
			WHERE So = @So
		END
	ELSE
				RAISERROR ('SỬA KHÔNG THÀNH CÔNG-MÃ CÔNG VĂN HOẶC TÊN CÔNG VĂN HOẶC TÊN FILE TỒN TẠI TRONG HỆ THỐNG.',16,1)
GO
DROP PROC CongVan_Sua
EXEC CongVan_Sua 130516001,N'New',N'Nhân ngày lễ Giỗ tổ mùng 10/3...',N'Nhân ngày lễ Giỗ tổ mùng 10/3, công ty chúng tôi ra mắt các loại xe mới có kèm theo khuyến mãi',N'anh.jpg',0,3,2
----------------------DANH SÁCH--------------------
CREATE PROC CongVan_DS
AS
	SELECT CV.Ma,CV.So, CV.Ten,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TT.Ten, U.Ten AS NguoiGoi, ThoiGianGui, ThoiGianNhan,
	(SELECT U.Ten FROM UserN, CV_UserN_TT CT WHERE UserN.Ma = CT.Ma_UserNhan AND CUT.So_CV = CT.So_CV AND CUT.Ma_TT = CT.Ma_TT AND CUT.Ma_User = CT.Ma_User AND CUT.Ma_UserNhan = CT.Ma_UserNhan) AS NguoiNhan
	FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT
	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma
	ORDER BY CV.So
GO
DROP PROC CongVan_DS
EXEC CongVan_DS
-----------------------CHI TIẾT------------------------
CREATE PROC CongVan_CT
@So int
AS
		SELECT CV.Ma,CV.So, CV.Ten,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TT.Ten, U.Ten AS NguoiGoi, ThoiGianGui, ThoiGianNhan,
	(SELECT U.Ten FROM UserN, CV_UserN_TT CT WHERE UserN.Ma = CT.Ma_UserNhan AND CUT.So_CV = CT.So_CV AND CUT.Ma_TT = CT.Ma_TT AND CUT.Ma_User = CT.Ma_User AND CUT.Ma_UserNhan = CT.Ma_UserNhan) AS NguoiNhan
	FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT
	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma
	ORDER BY CV.So DESC
GO
DROP PROC CongVan_CT
EXEC CongVan_CT 1
-------------------------CÔNG VĂN THEO TÌNH TRẠNG -----------------------------
CREATE PROC CongVan_Theo_TinhTrang
@Ma tinyint
AS
	SELECT CV.Ma, TrichYeu, U.Ten AS NguoiGoi, ThoiGianGui, ThoiGianNhan
	FROM TinhTrang TT, CongVan CV, CV_UserN_TT CUT, UserN U
	WHERE TT.Ma = @Ma AND TT.Ma = CUT.Ma_TT AND CUT.So_CV = CV.So AND CUT.Ma_User = U.Ma
	ORDER BY CV.So DESC
GO