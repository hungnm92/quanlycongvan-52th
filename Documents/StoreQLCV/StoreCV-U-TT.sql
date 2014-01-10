--THỦ TỤC LƯU TRỮ Công Văn_User_Tình Trạng
---------------THÊM---------------
CREATE PROC CV_U_TT_Them
@So_CV int,
@Ma_TT tinyint,
@Ma_User tinyint,
@Ma_UserNhan tinyint,
@ThoiGianGui smalldatetime,
@ThoiGianNhan smalldatetime
AS
		IF ((NOT EXISTS(SELECT So_CV FROM CV_UserN_TT WHERE So_CV = @So_CV AND Ma_TT = @Ma_TT AND Ma_User = @Ma_User AND Ma_UserNhan = @Ma_UserNhan )) 
			AND (NOT EXISTS(SELECT Ma_TT FROM CV_UserN_TT WHERE So_CV = @So_CV AND Ma_TT = @Ma_TT AND Ma_User = @Ma_User AND Ma_UserNhan = @Ma_UserNhan))
			AND (NOT EXISTS(SELECT Ma_User FROM CV_UserN_TT WHERE So_CV = @So_CV AND Ma_TT = @Ma_TT AND Ma_User = @Ma_User AND Ma_UserNhan = @Ma_UserNhan))
			AND (NOT EXISTS(SELECT Ma_UserNhan FROM CV_UserN_TT WHERE So_CV = @So_CV AND Ma_TT = @Ma_TT AND Ma_User = @Ma_User AND Ma_UserNhan = @Ma_UserNhan)))
				BEGIN
				DECLARE @So int
				SET @So = 1
				WHILE  (@So in (SELECT So FROM CongVan))
				SET @So = @So +1
					INSERT INTO CV_UserN_TT(So,So_CV,Ma_TT,Ma_User,Ma_UserNhan,ThoiGianGui,ThoiGianNhan) VALUES (@So,@So_CV,@Ma_TT,@Ma_User,@Ma_UserNhan,@ThoiGianGui,@ThoiGianNhan)
				END
		ELSE
			RAISERROR (N'THÊM KHÔNG THÀNH CÔNG-ĐÃ TỒN TẠI.',16,1)
GO
DROP PROC CV_U_TT_Them
EXEC CV_U_TT_Them 1,1,1,1,N'',N''
-------------------XÓA-------------------
CREATE PROC CV_U_TT_Xoa
@So int
AS
		DELETE CV_UserN_TT
		WHERE So = @So
GO
EXEC CV_U_TT_Xoa 4
----------------------DANH SÁCH--------------------
CREATE PROC CV_U_TT_DS
AS
	SELECT CV.Ma,CV.So, CV.Ten,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TT.Ten, U.Ten AS NguoiGoi, ThoiGianGui, ThoiGianNhan,
	(SELECT U.Ten FROM UserN, CV_UserN_TT CT WHERE UserN.Ma = CT.Ma_UserNhan AND CUT.So_CV = CT.So_CV AND CUT.Ma_TT = CT.Ma_TT AND CUT.Ma_User = CT.Ma_User AND CUT.Ma_UserNhan = CT.Ma_UserNhan) AS NguoiNhan
	FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT
	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma
	ORDER BY CV.So
GO
DROP PROC CV_U_TT_DS
EXEC CV_U_TT_DS
-----------------------CHI TIẾT------------------------
CREATE PROC CV_U_TT_CT
@So int
AS
		SELECT CV.Ma,CV.So, CV.Ten,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TT.Ten, U.Ten AS NguoiGoi, ThoiGianGui, ThoiGianNhan,
	(SELECT U.Ten FROM UserN, CV_UserN_TT CT WHERE UserN.Ma = CT.Ma_UserNhan AND CUT.So_CV = CT.So_CV AND CUT.Ma_TT = CT.Ma_TT AND CUT.Ma_User = CT.Ma_User AND CUT.Ma_UserNhan = CT.Ma_UserNhan) AS NguoiNhan
	FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT
	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma
	ORDER BY CV.So DESC
GO
DROP PROC CV_U_TT_CT
EXEC CV_U_TT_CT 1