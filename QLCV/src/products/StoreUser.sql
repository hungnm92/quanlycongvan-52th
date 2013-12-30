--------------THỦ TỤC USER--------------------
-------------USER THÊM-----------------
CREATE PROC USER_Them
@Ma_NV tinyint,
@Ten nvarchar(100),
@IsUser bit
AS
	IF(@Ten not in(SELECT Ten FROM UserN))
		BEGIN
			DECLARE @Ma tinyint
			DECLARE @MatKhau nvarchar(100)
			SET @Ma = 1
			SET @MatKhau = @Ten
			WHILE (@Ma in (SELECT Ma FROM UserN))
				SET @Ma = @Ma +1
			BEGIN
					INSERT INTO UserN(Ma,Ma_NV,Ten,MatKhau,IsUser)
					VALUES (@Ma,@Ma_NV,@Ten,PWDENCRYPT (@MatKhau),@IsUser)
			END
		END
	ELSE
			RAISERROR (N'THÊM KHÔNG THÀNH CÔNG-EMAIL NHÂN VIÊN ĐÃ TỒN TẠI TRONG HỆ THỐNG.',16,1)
GO
DROP PROC USER_Them
EXEC USER_Them 1, N'nguyenthilanh2th@gmail.com',1
EXEC USER_Them 1, N'nguyenthilanh2th@gmail.com',1
-------------USER SỬA-----------------
CREATE PROC USER_Sua
@Ma tinyint,
@Ma_NV tinyint,
@Ten nvarchar(100),
@IsUser bit
AS
	IF((@Ten not in(SELECT Ten FROM UserN WHERE Ma <> @Ma)))
		BEGIN
			UPDATE UserN
			SET Ma_NV = @Ma_NV,
				Ten = @Ten,
				IsUser = @IsUser
			WHERE Ma = @Ma 
		END
	ELSE
		RAISERROR (N'SỬA KHÔNG THÀNH CÔNG-EMAIL ĐÃ TỒN TẠI.',16,1)
GO
DROP PROC USER_Sua
EXEC USER_Sua 1,1,N'nguyenthilanh2th@gmail',1
-------------USER ĐĂNG NHẬP---------------
CREATE PROC USER_DangNhap 
@Ten nvarchar(100),
@MatKhau nvarchar(100)
AS
	IF (@Ten in (SELECT Ten FROM UserN WHERE PWDCOMPARE(@MatKhau,MatKhau) =1 ))
		BEGIN
			SELECT *, NU.Ten, NU.Ma
			FROM UserN U, NhomUser NU
			WHERE PWDCOMPARE(@MatKhau,MatKhau) = 1 AND U.Ten = @Ten AND U.Ma = NU.Ma_User
		END
	ELSE
		RAISERROR (N'EMAIL ĐĂNG NHẬP HOẶC MẬT KHẨU KHÔNG HỢP LỆ.',16,1)
GO
DROP PROC USER_DangNhap
--------------USER ĐỔI MẬT KHẨU----------------
CREATE PROC USER_DoiMatKhau
@Ten nvarchar(100),
@MatKhauCu nvarchar(100),
@MatKhauMoi nvarchar(100),
@MatKhauXN nvarchar(100)
AS
	IF(@Ten in(SELECT Ten FROM UserN))
		BEGIN
			DECLARE @MatKhau nvarchar(100)
			SET @MatKhau = (SELECT MatKhau FROM UserN WHERE Ten = @Ten)
			IF(PWDCOMPARE(@MatKhauCu,@MatKhau)= 1)
				BEGIN 
					IF(@MatKhauMoi = @MatKhauXN)
						BEGIN 
							UPDATE UserN
							SET MatKhau = PWDENCRYPT(@MatKhauMoi)
							WHERE Ten = @Ten
						END
					ELSE
						RAISERROR (N'MẬT KHẨU MỚI VÀ XÁC NHẬN MẬT KHẨU MỚI KHÔNG TRÙNG NHAU.',16,1)
				END
			ELSE
				RAISERROR (N'SAI MẬT KHẨU.',16,1)
		END
	ELSE
		RAISERROR (N'ĐỊA CHỈ EMAIL KHÔNG HỢP LỆ.',16,1)
DROP PROC USER_DoiMatKhau