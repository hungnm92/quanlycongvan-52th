using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;//chứa các đối tượng dataset.
using System.Data.SqlClient;//chứa các đối tượng SqlConnection, SqlCommand.
namespace lanhnt
{
    public class LoaiCV
    {
        public int Ma;
        public string TenCV;
        public string ThongBao;
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("LoaiCV_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@Ma", Ma);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)//nếu có dữ liệu để đọc
            {
                Ma = int.Parse(DocDL["Ma"].ToString());
                TenCV = DocDL["TenCV"].ToString();
            }
            BaoVe.Close();
        }
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("LoaiCV_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class TinhTrang
    {
        public int Ma;
        public string TenTT;
        public string ThongBao;
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("TinhTrang_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@Ma", Ma);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)//nếu có dữ liệu để đọc
            {
                Ma = int.Parse(DocDL["Ma"].ToString());
                TenTT = DocDL["TenTT"].ToString();
            }
            BaoVe.Close();
        }
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("TinhTrang_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class PhongBan
    {
        public int Ma;
        public string TenPB;
        public string ThongBao;      
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("PhongBan_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class NhomUser
      {
        public int Ma;
        public string TenNhom;
        public int Ma_User;
        public string ThongBao;
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("NhomUser_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@Ma", Ma);
            ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
            SqlDataReader DocDL;
            BaoVe.Open(); 
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)//nếu có dữ liệu để đọc
            {
                Ma = int.Parse(DocDL["Ma"].ToString());
                TenNhom = DocDL["TenNhom"].ToString();
                Ma_User = int.Parse(DocDL["Ma_User"].ToString());
            }
            BaoVe.Close();
        }
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("NhomUser_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public void Them()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("NhomUser_Them", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@Ma", Ma);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Xoa()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("NhomUser_Xoa", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@Ma", Ma);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Xóa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }

    }
    public class NhanVien
    {
        public int Ma;
        public int Ma_PB;
        public string TenPB;
        public int Ma_Nhom;
        public string TenNhom;
        public string Ho;
        public string TenNV;
        public string TenUser;
        public bool IsUser;
        public int Ma_User;
        public string NgaySinh;
        public string DiaChi;
        public string DienThoai;
        public string AnhNV;
        public string ThongBao;
        public void Them()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("NhanVien_Them", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@Ho", Ho);
                ThamSo = Lenh.Parameters.AddWithValue("@TenNV", TenNV);
                ThamSo = Lenh.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                ThamSo = Lenh.Parameters.AddWithValue("@DiaChi", DiaChi);
                ThamSo = Lenh.Parameters.AddWithValue("@DienThoai", DienThoai);
                ThamSo = Lenh.Parameters.AddWithValue("@AnhNV", AnhNV);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_PB", Ma_PB);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Xoa()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("NhanVien_Xoa", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@Ma", Ma);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Xóa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Sua()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("NhanVien_Sua", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@Ma", Ma);
                ThamSo = Lenh.Parameters.AddWithValue("@Ho", Ho);
                ThamSo = Lenh.Parameters.AddWithValue("@TenNV", TenNV);
                ThamSo = Lenh.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                ThamSo = Lenh.Parameters.AddWithValue("@DiaChi", DiaChi);
                ThamSo = Lenh.Parameters.AddWithValue("@DienThoai", DienThoai);
                ThamSo = Lenh.Parameters.AddWithValue("@AnhNV", AnhNV);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_PB", Ma_PB);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Sửa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("NhanVien_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)//nếu có dữ liệu để đọc
            {
                Ma = int.Parse(DocDL["Ma"].ToString());
                Ma_User = int.Parse(DocDL["Ma_User"].ToString());
                Ho = DocDL["Ho"].ToString();
                TenNV = DocDL["TenNV"].ToString();
                TenUser = DocDL["TenUser"].ToString();
                IsUser = bool.Parse(DocDL["IsUser"].ToString());
                AnhNV = DocDL["AnhNV"].ToString();
                DienThoai = DocDL["DienThoai"].ToString();
                Ma_Nhom = int.Parse(DocDL["Ma_Nhom"].ToString());
                DiaChi = DocDL["DiaChi"].ToString();
                TenPB = DocDL["TenPB"].ToString();
                Ma_PB = int.Parse(DocDL["Ma_PB"].ToString());
                TenNhom = DocDL["TenNhom"].ToString();
                NgaySinh = DocDL["NgaySinh"].ToString();
            }
            BaoVe.Close();
        }
        public void IsUser_CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("NhanVien_IsUser_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)//nếu có dữ liệu để đọc
            {
                Ma = int.Parse(DocDL["Ma"].ToString());
                Ma_User = int.Parse(DocDL["Ma_User"].ToString());
                Ho = DocDL["Ho"].ToString();
                TenNV = DocDL["TenNV"].ToString();
                TenUser = DocDL["TenUser"].ToString();
                IsUser = bool.Parse(DocDL["IsUser"].ToString());
                AnhNV = DocDL["AnhNV"].ToString();
                DienThoai = DocDL["DienThoai"].ToString();
                DiaChi = DocDL["DiaChi"].ToString();
                TenPB = DocDL["TenPB"].ToString();
                Ma_PB = int.Parse(DocDL["Ma_PB"].ToString());
                NgaySinh = DocDL["NgaySinh"].ToString();
            }
            BaoVe.Close();
        }
        public void LayMa()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("NhanVien_LayMa", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@Ho", Ho);
            ThamSo = Lenh.Parameters.AddWithValue("@TenNV", TenNV);
            ThamSo = Lenh.Parameters.AddWithValue("@NgaySinh", NgaySinh);
            ThamSo = Lenh.Parameters.AddWithValue("@DiaChi", DiaChi);
            ThamSo = Lenh.Parameters.AddWithValue("@DienThoai", DienThoai);
            ThamSo = Lenh.Parameters.AddWithValue("@AnhNV", AnhNV);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)//nếu có dữ liệu để đọc
            {
                Ma = int.Parse(DocDL["Ma"].ToString());
            }
            BaoVe.Close();
        }
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("NhanVien_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class CongVan
    {
        public string Ma;
        public string So;
        public int HoiThoai;
        public string TenCV;
        public string TrichYeu;
        public string TenFile;
        public string NgayPH;
        public string YKienLD;
        public string YKienCV;
        public int Ma_LCV;
        public int Ma_TT;
        public int Thang;
        public string TenLCV;
        public string SoCV;
        public string ThongBao;
        public string DemSoCD;
        public string DemSoCPH;
        public string DemSoD;
        public string DemSoDT;
        public string DemSoKD;
        public DataTable DS_TenFile()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("DS_TenFile", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public string LayMa()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("CongVan_Ma", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            //for (int i = 0; i < ThungChua.Rows.Count; )
            //{
                SoCV = ThungChua.Rows[0][0].ToString();
           // }
            BaoVe.Close();
            return SoCV;
        }
        public void Them()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CongVan_Them", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_LCV", Ma_LCV);
                ThamSo = Lenh.Parameters.AddWithValue("@TenCV", TenCV);
                ThamSo = Lenh.Parameters.AddWithValue("@TrichYeu", TrichYeu);
                ThamSo = Lenh.Parameters.AddWithValue("@TenFile", TenFile);
                ThamSo = Lenh.Parameters.AddWithValue("@YKienLD", YKienLD);
                ThamSo = Lenh.Parameters.AddWithValue("@YKienCV", YKienCV);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Them_HoiThoai()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CongVan_Them_HoiThoai", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_LCV", Ma_LCV);
                ThamSo = Lenh.Parameters.AddWithValue("@TenCV", TenCV);
                ThamSo = Lenh.Parameters.AddWithValue("@TrichYeu", TrichYeu);
                ThamSo = Lenh.Parameters.AddWithValue("@TenFile", TenFile);
                ThamSo = Lenh.Parameters.AddWithValue("@YKienLD", YKienLD);
                ThamSo = Lenh.Parameters.AddWithValue("@YKienCV", YKienCV);
                ThamSo = Lenh.Parameters.AddWithValue("@HoiThoai", HoiThoai);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Them_Ma()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CongVan_Them_Ma", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaLCV", Ma_LCV);
                ThamSo = Lenh.Parameters.AddWithValue("@So", So);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Xoa()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CongVan_Xoa", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So", So);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Xóa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Sua()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CongVan_Sua", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So", So);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_LCV", Ma_LCV);
                ThamSo = Lenh.Parameters.AddWithValue("@TenCV", TenCV);
                ThamSo = Lenh.Parameters.AddWithValue("@TrichYeu", TrichYeu);
                ThamSo = Lenh.Parameters.AddWithValue("@TenFile", TenFile);
                ThamSo = Lenh.Parameters.AddWithValue("@YKienCV", YKienCV);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Lưu thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Sua_YKien()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CongVan_Sua_YKien", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So", So);
                ThamSo = Lenh.Parameters.AddWithValue("@YKienLD", YKienLD);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Sửa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Them_NgayPH()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CongVan_Them_NgayPH", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So", So);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Sửa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("CongVan_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@So", So);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)
            {
                Ma = DocDL["Ma"].ToString();
                So = DocDL["So"].ToString();
                Ma_LCV = int.Parse(DocDL["Ma_LCV"].ToString());
                TenLCV = DocDL["TenLCV"].ToString();
                TenCV = DocDL["TenCV"].ToString();
                TrichYeu = DocDL["TrichYeu"].ToString();
                TenFile = DocDL["TenFile"].ToString();
                NgayPH = DocDL["NgayPH"].ToString();
                YKienLD = DocDL["YKienLD"].ToString();
                YKienCV = DocDL["YKienCV"].ToString();
                HoiThoai = int.Parse(DocDL["HoiThoai"].ToString());
            }
            BaoVe.Close();
        }
        public void Lay_HoiThoai()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("CongVan_Lay_HoiThoai", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@So", So);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)
            {
                HoiThoai = int.Parse(DocDL["HoiThoai"].ToString());
            }
            BaoVe.Close();
        }
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("CongVan_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public DataTable Me_DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("CongVan_NgayPH_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public DataTable DuThao_DS(int MaUser)
        {
            string SelectSQL = "SELECT DISTINCT CUT.So,CV.Ma, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenUser AS NguoiGui, ThoiGianGui, ThoiGianSoan,(SELECT u.TenUser FROM CV_UserN_TT CT, UserN U WHERE CT.So = CUT.So and  U.Ma = CUT.Ma_UserNhan) AS NguoiNhan FROM CongVan CV, TinhTrang TT, UserN U,  CV_UserN_TT CUT WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND TT.Ma = 6 AND CUT.Ma_User = @MaUser ORDER BY ThoiGianSoan DESC ";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();   
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable ChoDuyet_DS(int MaUser)
        {
            string SelectSQL = "SELECT DISTINCT CUT.So,CV.Ma, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenUser AS NguoiGui, ThoiGianGui, ThoiGianSoan,ThoiGianDoc,ThoiGianDuyet,(SELECT u.TenUser FROM CV_UserN_TT CT, UserN U WHERE CT.So = CUT.So and  U.Ma = CUT.Ma_UserNhan) AS NguoiNhan FROM CongVan CV, TinhTrang TT, UserN U,  CV_UserN_TT CUT WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND TT.Ma = 2 and (CUT.Ma_User = @MaUser or Ma_UserNhan = @MaUser) ORDER BY ThoiGianSoan DESC";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable ChoPhatHanh_DS(int MaUser)
        {
            string SelectSQL = "SELECT DISTINCT CUT.So,CV.Ma, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenUser AS NguoiGui, ThoiGianGui, ThoiGianDoc, ThoiGianSoan,(SELECT u.TenUser FROM CV_UserN_TT CT, UserN U WHERE CT.So = CUT.So and  U.Ma = CUT.Ma_UserNhan) AS NguoiNhan FROM CongVan CV, TinhTrang TT, UserN U,  CV_UserN_TT CUT WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND TT.Ma = 4 AND (Ma_UserNhan = @MaUser or CUT.Ma_User = @MaUser) ORDER BY ThoiGianGui DESC";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable ChuaDoc_DS(int MaUser)
        {
            string SelectSQL = "SELECT CV.Ma,CUT.So, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenUser AS NguoiGui, ThoiGianGui, ThoiGianDoc,ThoiGianSoan FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND Ma_UserNhan = @MaUser AND ThoiGianDoc is null AND TT.Ma not in (4, 2, 5, 3, 1) ORDER BY ThoiGianGui DESC";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public string ChoDuyet_ChuaDoc_SL(int MaUser)
        {
            string SelectSQL = "SELECT count(CV.So)	FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND (CUT.Ma_User = @MaUser or Ma_UserNhan = @MaUser) AND ThoiGianDoc is null AND TT.Ma = 2";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                DemSoCD = ThungChua.Rows[0][0].ToString();
                BaoVe.Close();
            }
            return DemSoCD;
        }
        public string ChoPhatHanh_ChuaDoc_SL(int MaUser)
        {
            string SelectSQL = "SELECT count(CV.So)	FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND (CUT.Ma_User = @MaUser or Ma_UserNhan = @MaUser) AND ThoiGianDoc is null AND TT.Ma = 4";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                DemSoCPH = ThungChua.Rows[0][0].ToString();
                BaoVe.Close();
            }
            return DemSoCPH;
        }
        public string KhongDuyet_ChuaDoc_SL(int MaUser)
        {
            string SelectSQL = "SELECT count(CV.So)	FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND (CUT.Ma_User = @MaUser or Ma_UserNhan = @MaUser) AND ThoiGianDoc is null AND TT.Ma = 3";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                DemSoKD = ThungChua.Rows[0][0].ToString();
                BaoVe.Close();
            }
            return DemSoKD;
        }
        public string Den_ChuaDoc_SL(int MaUser)
        {
            string SelectSQL = "SELECT count(CV.So)	FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND  Ma_UserNhan = @MaUser AND ThoiGianDoc is null AND TT.Ma not in (2, 4, 5, 3,1)";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                DemSoD = ThungChua.Rows[0][0].ToString();
                BaoVe.Close();
            }
            return DemSoD;
        }
        public string DaPhatHanh_ChuaDoc_SL(int MaUser)
        {
            string SelectSQL = "SELECT count(CV.So)	FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND  Ma_UserNhan = @MaUser AND ThoiGianDoc is null AND TT.Ma = 5";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                DemSoD = ThungChua.Rows[0][0].ToString();
                BaoVe.Close();
            }
            return DemSoD;
        }
        public string DuThao_SL(int MaUser)
        {
            string SelectSQL = "SELECT count(CV.So)	FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND CUT.Ma_User = @MaUser AND ThoiGianDoc is null AND TT.Ma = 6";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                DemSoDT = ThungChua.Rows[0][0].ToString();
                BaoVe.Close();
            }
            return DemSoDT;
        }
        public DataTable DaDoc_DS(int MaUser)
        {
            string SelectSQL = "SELECT CV.Ma,CUT.So, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenUser AS NguoiGui, ThoiGianGui, ThoiGianDoc FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND Ma_UserNhan = @MaUser AND ThoiGianDoc is not null AND TT.Ma not in (4, 2, 5,3, 1) ORDER BY ThoiGianGui DESC ";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable DaDuyet_DS(int MaUser)
        {
            string SelectSQL = "SELECT DISTINCT CUT.So,CV.Ma, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenUser AS NguoiGui, ThoiGianDoc,ThoiGianGui, ThoiGianSoan,ThoiGianDuyet,(SELECT u.TenUser FROM CV_UserN_TT CT, UserN U WHERE CT.So = CUT.So and  U.Ma = CUT.Ma_UserNhan) AS NguoiNhan FROM CongVan CV, TinhTrang TT, UserN U,  CV_UserN_TT CUT WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND TT.Ma = 1 AND (Ma_UserNhan = @MaUser or CUT.Ma_User = @MaUser) ORDER BY ThoiGianDuyet DESC ";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable DaPhatHanh_DS(int MaUser)
        {
            string SelectSQL = "SELECT DISTINCT CUT.So,CV.Ma, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenUser AS NguoiGui, ThoiGianGui, ThoiGianDoc, ThoiGianSoan,ThoiGianDuyet,(SELECT u.TenUser FROM CV_UserN_TT CT, UserN U WHERE CT.So = CUT.So and  U.Ma = CUT.Ma_UserNhan) AS NguoiNhan FROM CongVan CV, TinhTrang TT, UserN U,  CV_UserN_TT CUT, NhomUser WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND TT.Ma = 5 and (CUT.Ma_User = @MaUser or NhomUser.Ma = 1) ORDER BY ThoiGianDuyet desc ";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable Den_DS(int MaUser)
        {
            string SelectSQL = "SELECT CV.Ma,CUT.So, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenUser AS NguoiGui, ThoiGianGui, ThoiGianDoc FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND Ma_UserNhan = @MaUser AND TT.Ma = 9 ORDER BY ThoiGianGui DESC ";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable ChiTietCongVan(int HoiThoai)
        {
            string SelectSQL = "SELECT Ma_UserNhan AS NguoiNhan,Ma_User AS NguoiGui,TenTT, ThoiGianSoan, ThoiGianGui, ThoiGianDoc, ThoiGianDuyet, NgayPH FROM CongVan CV, CV_UserN_TT CUT, TinhTrang TT WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND HoiThoai = @HoiThoai";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@HoiThoai", SqlDbType.Int).Value = HoiThoai;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable DaGui_DS(int MaUser)
        {
            string SelectSQL = "SELECT CV.Ma,CUT.So, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenUser AS NguoiGui,ThoiGianGui, ThoiGianDoc,(SELECT u.TenUser FROM CV_UserN_TT CT, UserN U WHERE CT.So = CUT.So and  U.Ma = CUT.Ma_UserNhan) AS NguoiNhan FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND CUT.Ma_User = @MaUser AND TT.Ma in (9)	ORDER BY ThoiGianGui DESC";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable KhongDuyet_DS(int MaUser)
        {
            string SelectSQL = "SELECT DISTINCT CUT.So,CV.Ma, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenUser AS NguoiGui, ThoiGianGui, ThoiGianDoc, ThoiGianSoan,(SELECT u.TenUser FROM CV_UserN_TT CT, UserN U WHERE CT.So = CUT.So and  U.Ma = CUT.Ma_UserNhan) AS NguoiNhan FROM CongVan CV, TinhTrang TT, UserN U,  CV_UserN_TT CUT WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND TT.Ma = 3 AND (Ma_UserNhan = @MaUser or CUT.Ma_User = @MaUser) ORDER BY ThoiGianGui DESC ";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable TimTheoLCV(int Ma_LCV)
        {
            string SelectSQL = "SELECT CV.Ma,CUT.So, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenLCV, TenUser AS NguoiGui, ThoiGianGui, ThoiGianDoc, ThoiGianSoan,(SELECT u.TenUser FROM CV_UserN_TT CT, UserN U WHERE CT.So = CUT.So and  U.Ma = CUT.Ma_UserNhan) AS NguoiNhan FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT, LoaiCV LCV	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND CV.Ma_LCV = LCV.Ma AND LCV.Ma = @Ma_LCV ORDER BY ThoiGianGui DESC ";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@Ma_LCV", SqlDbType.Int).Value = Ma_LCV;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable TimTheoTen(string TenCV)
        {
            string SelectSQL = "SELECT CV.Ma,CUT.So, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenLCV, TenUser AS NguoiGui, ThoiGianGui, ThoiGianDoc, ThoiGianSoan,(SELECT u.TenUser FROM CV_UserN_TT CT, UserN U WHERE CT.So = CUT.So and  U.Ma = CUT.Ma_UserNhan) AS NguoiNhan FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT, LoaiCV LCV	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND LCV.Ma = CV.Ma_LCV AND TenCV like '%' + @TenCV +'%' ORDER BY ThoiGianGui DESC ";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@TenCV", SqlDbType.NVarChar).Value = TenCV;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable TimTinhTrang(int Ma_TT)
        {
            string SelectSQL = "SELECT CV.Ma,CUT.So, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenLCV, TenUser AS NguoiGui, ThoiGianGui, ThoiGianDoc, ThoiGianSoan,(SELECT u.TenUser FROM CV_UserN_TT CT, UserN U WHERE CT.So = CUT.So and  U.Ma = CUT.Ma_UserNhan) AS NguoiNhan	FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT, LoaiCV LCV	WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND CV.Ma_LCV = LCV.Ma AND TT.Ma = CUT.Ma_TT AND CUT.Ma_TT = @Ma_TT ORDER BY ThoiGianGui DESC ";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@Ma_TT", SqlDbType.Int).Value = Ma_TT;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable TimTheoThang(int Thang)
        {
            string SelectSQL = "SELECT CV.Ma,CUT.So, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenLCV, TenUser AS NguoiGui, ThoiGianGui, ThoiGianDoc, ThoiGianSoan,	(SELECT u.TenUser FROM CV_UserN_TT CT, UserN U WHERE CT.So = CUT.So and  U.Ma = CUT.Ma_UserNhan) AS NguoiNhan FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT, LoaiCV LCV WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND CV.Ma_LCV = LCV.Ma AND TT.Ma = CUT.Ma_TT AND MONTH(ThoiGianGui) = @Thang ORDER BY ThoiGianGui DESC ";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@Thang", SqlDbType.Int).Value = Thang;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable TimTongHop(int Ma_LCV, int Ma_TT, string TenCV, int Thang)
        {
            string SelectSQL = "SELECT CV.Ma,CUT.So, TenCV,TrichYeu, TenFile, NgayPH,YKienLD, YKienCV, TenTT, TenLCV, TenUser AS NguoiGui, ThoiGianGui, ThoiGianDoc, ThoiGianSoan,	(SELECT u.TenUser FROM CV_UserN_TT CT, UserN U WHERE CT.So = CUT.So and  U.Ma = CUT.Ma_UserNhan) AS NguoiNhan FROM CongVan CV, TinhTrang TT, UserN U, CV_UserN_TT CUT, LoaiCV LCV WHERE CV.So = CUT.So_CV AND CUT.Ma_TT = TT.Ma AND CUT.Ma_User = U.Ma AND CV.Ma_LCV = LCV.Ma AND TT.Ma = CUT.Ma_TT AND LCV.Ma = @Ma_LCV AND MONTH(ThoiGianGui) = @Thang AND CUT.Ma_TT = @Ma_TT AND TenCV like '%' + @TenCV +'%' ORDER BY ThoiGianGui DESC ";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@Ma_LCV", SqlDbType.Int).Value = Ma_LCV;
                Lenh.Parameters.Add("@Ma_TT", SqlDbType.Int).Value = Ma_TT;
                Lenh.Parameters.Add("@TenCV", SqlDbType.NVarChar).Value = TenCV;
                Lenh.Parameters.Add("@Thang", SqlDbType.Int).Value = Thang;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
    }
    public class UserN
    {
        public int Ma;
        public int Ma_NV;
        public string TenUser;
        public string MatKhau;
        public string MatKhauCu;
        public string MatKhauMoi;
        public string MatKhauXN;
        public bool IsUser;
        public string Ho;
        public string TenNV;
        public int MaNhom;
        public int LayNhom;
        public string ThongBao;
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("UserN_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("User_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@Ma", Ma);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)
            {
                Ma = int.Parse(DocDL["Ma"].ToString());
                TenUser = DocDL["TenUser"].ToString();
                IsUser = bool.Parse(DocDL["IsUser"].ToString());
                Ma_NV = int.Parse(DocDL["Ma_NV"].ToString());
            }
            BaoVe.Close();
        }
        public void LayMa()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("UserN_LayMa", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@Ma_NV", Ma_NV);
            ThamSo = Lenh.Parameters.AddWithValue("@TenUser", TenUser);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)
            {
                Ma = int.Parse(DocDL["Ma"].ToString());
            }
            BaoVe.Close();
        }
        public DataTable LanhDao_DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("UserN_LanhDao_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public DataTable ChuyenVien_DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("UserN_ChuyenVien_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public DataTable VanThu_DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("UserN_VanThu_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public DataTable VT_CV_DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("UserN_VT_CV_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public DataTable NhanVien_DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("UserN_NhanVien_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public bool DangNhap()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("UserN_DangNhap", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@TenUser", TenUser);
                ThamSo = Lenh.Parameters.AddWithValue("@MatKhau", MatKhau);
                SqlDataReader DocDL;
                BaoVe.Open();
                DocDL = Lenh.ExecuteReader();
                if (DocDL.Read() == true)
                {
                    Ma = int.Parse(DocDL["Ma"].ToString());
                    Ma_NV = int.Parse(DocDL["Ma_NV"].ToString());
                    TenUser = DocDL["TenUser"].ToString();
                    MatKhau = DocDL["MatKhau"].ToString();
                    MaNhom = int.Parse(DocDL["MaNhom"].ToString());
                    Ho = DocDL["Ho"].ToString();
                    TenNV = DocDL["TenNV"].ToString();
                    BaoVe.Close();
                    return true;
                }
                else
                {
                    BaoVe.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
            return false;
        }
        public void DoiMatKhau()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("UserN_DoiMatKhau", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@TenUser", TenUser);
                ThamSo = Lenh.Parameters.AddWithValue("@MatKhauCu", MatKhauCu);
                ThamSo = Lenh.Parameters.AddWithValue("@MatKhauMoi", MatKhauMoi);
                ThamSo = Lenh.Parameters.AddWithValue("@MatKhauXN", MatKhauXN);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Đổi thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public int LayMaNhom(int MaUser)
        {
            string SelectSQL = "SELECT NU.Ma AS MaNhom FROM UserN U, NhomUser NU WHERE U.Ma = @MaUser AND NU.Ma_User = U.Ma";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaUser", SqlDbType.Int).Value = MaUser;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                LayNhom = int.Parse(ThungChua.Rows[0][0].ToString());
                BaoVe.Close();
            }
            return LayNhom;
        }
        public void Them()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("UserN_Them", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_NV", Ma_NV);
                ThamSo = Lenh.Parameters.AddWithValue("@TenUser", TenUser);
                ThamSo = Lenh.Parameters.AddWithValue("@IsUser", IsUser);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Xoa()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("UserN_Xoa", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@Ma", Ma);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Xóa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Sua()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("UserN_Sua", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@Ma", Ma);
                ThamSo = Lenh.Parameters.AddWithValue("@IsUser", IsUser);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Sửa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
    public class CV_User_TT
    {
        public int So;
        public string Ma_CV;
        public int Ma_TT;
        public string TenTT;
        public string So_CV;
        public int Ma_User;
        public int Ma_UserNhan;
        public string TenUser;
        public string TenCV;
        public string TrichYeu;
        public string TenFile;
        public string NgayPH;
        public string YKienLD;
        public string YKienCV;
        public string ThoiGianSoan;
        public string ThoiGianGui;
        public string ThoiGianDoc;
        public string ThoiGianDuyet;
        public string ThongBao;
        public void Them()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CV_U_TT_Them", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So_CV", So_CV);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_TT", Ma_TT);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_UserNhan", Ma_UserNhan);
                ThamSo = Lenh.Parameters.AddWithValue("@ThoiGianSoan", ThoiGianSoan);
                ThamSo = Lenh.Parameters.AddWithValue("@ThoiGianGui", ThoiGianGui);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Xoa()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CV_U_TT_Xoa", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So", So);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Xóa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Sua()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CV_UserN_TT_DT_Sua_TrinhDuyet", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();    
                ThamSo = Lenh.Parameters.AddWithValue("@So", So);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_UserNhan", Ma_UserNhan);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Đã gửi tới Lãnh đạo!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("CV_U_TT_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@So", So);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)
            {
                Ma_CV = DocDL["Ma"].ToString();
                So = int.Parse(DocDL["So"].ToString());
                So_CV = DocDL["So_CV"].ToString();
                TenCV = DocDL["TenCV"].ToString();
                TenTT = DocDL["TenTT"].ToString();
                TenUser = DocDL["NguoiGui"].ToString();
                Ma_User = int.Parse(DocDL["Ma_User"].ToString());
                Ma_UserNhan = int.Parse(DocDL["Ma_UserNhan"].ToString());
                TrichYeu = DocDL["TrichYeu"].ToString();
                TenFile = DocDL["TenFile"].ToString();
                NgayPH = DocDL["NgayPH"].ToString();
                YKienLD = DocDL["YKienLD"].ToString();
                YKienCV = DocDL["YKienCV"].ToString();
                ThoiGianSoan = DocDL["ThoiGianSoan"].ToString();
                ThoiGianGui = DocDL["ThoiGianGui"].ToString();
                ThoiGianDoc = DocDL["ThoiGianDoc"].ToString();
                ThoiGianDuyet = DocDL["ThoiGianDuyet"].ToString();
            }
            BaoVe.Close();
        }
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlDataAdapter XeTai = new SqlDataAdapter("CV_U_TT_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public void DuThao()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CV_UserN_TT_DuThao", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So_CV", So_CV);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_UserNhan", Ma_UserNhan);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Đã lưu vào dự thảo!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void TrinhDuyet()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CV_UserN_TT_Soan_TrinhDuyet", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So_CV", So_CV);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_UserNhan", Ma_UserNhan);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Đã gửi tới Lãnh đạo!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Gui()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CV_UserN_TT_Soan_Gui", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So_CV", So_CV);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_UserNhan", Ma_UserNhan);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Đã gửi!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Doc()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CV_UserN_TT_Soan_TrinhDuyet", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So_CV", So_CV);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_UserNhan", Ma_UserNhan);
                ThamSo = Lenh.Parameters.AddWithValue("@ThoiGianDoc", ThoiGianDoc);
                ThamSo = Lenh.Parameters.AddWithValue("@ThoiGianGui", ThoiGianGui);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Đã gửi tới Lãnh đạo!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void PheDuyet()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CV_UserN_TT_PheDuyet", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So_CV", So_CV);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_UserNhan", Ma_UserNhan);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Đã gửi tới Văn thư, đang chờ Văn thư phát hành.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void KhongDuyet()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CV_UserN_TT_KhongDuyet", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So_CV", So_CV);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_UserNhan", Ma_UserNhan);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Đã gửi trả lại Chuyên viên, vui lòng chờ Chuyên viên soạn lại.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void PheDuyet_ChoPH()
        {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CV_UserN_TT_PheDuyet_ChoPH", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So_CV", So_CV);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_UserNhan", Ma_UserNhan);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
        }
        public void PhatHanh()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CV_UserN_TT_PhatHanh", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So_CV", So_CV);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_UserNhan", Ma_UserNhan);
                ThamSo = Lenh.Parameters.AddWithValue("@SoCUT", So);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Đã phát hành tới các nhân viên.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void LaySo(string So_CV, int Ma_User)
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("CUT_LaySo", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@So_CV", So_CV);
            ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)//nếu có dữ liệu để đọc
            {
                So = int.Parse(DocDL["So"].ToString());
            }
            BaoVe.Close();
        }
        public void LuuDuThao()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CV_UserN_TT_LuuDuThao", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So", So);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_UserNhan", Ma_UserNhan);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Lưu thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Update_TGDoc()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
                SqlCommand Lenh = new SqlCommand("CUT_Update_TGDoc", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So", So);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Sửa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
    }
    public class WebMsgBox
    {
        protected Hashtable handlerPages = new Hashtable();

        protected void CurrentPageUnload(object sender, EventArgs e)
        {
            Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));
            if (queue != null)
            {
                StringBuilder builder = new StringBuilder();
                int iMsgCount = queue.Count;
                builder.Append("<script language='javascript'>");
                string sMsg;
                while ((iMsgCount > 0))
                {
                    iMsgCount = iMsgCount - 1;
                    sMsg = System.Convert.ToString(queue.Dequeue());
                    sMsg = sMsg.Replace("\"", "'");
                    builder.Append("alert( \"" + sMsg + "\" );");
                }
                builder.Append("</script>");
                handlerPages.Remove(HttpContext.Current.Handler);
                HttpContext.Current.Response.Write(builder.ToString());
            }
        }

        public void Show(string Message)
        {
            if (!(handlerPages.Contains(HttpContext.Current.Handler)))
            {
                Page currentPage = (Page)HttpContext.Current.Handler;
                if (!((currentPage == null)))
                {
                    Queue messageQueue = new Queue();
                    messageQueue.Enqueue(Message);
                    handlerPages.Add(HttpContext.Current.Handler, messageQueue);
                    currentPage.Unload += new EventHandler(CurrentPageUnload);
                }
            }
            else
            {
                Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));
                queue.Enqueue(Message);
            }
        }

        public void ShowAndRedirect(string Message)
        {
            HttpContext.Current.Response.Write("<script>alert('" + Message + "') ; window.location.href='" + HttpContext.Current.Request.Url.PathAndQuery + "'</script>");
        }
    }
    public class Menu
    {
        public int Ma;
        public string TenMenu;
        public int Me;

        public string LoadMenu(int Me, int level)
        {
            string KetQua = string.Empty;
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
            SqlCommand Lenh = new SqlCommand("Menu_Lay", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@Me", Me);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (!DocDL.HasRows)
            {
                return KetQua;
            }
            else
            {
                if (level == 0)
                {
                    KetQua = "<ul id='nav'>";
                }
                else
                     KetQua += "<ul>";
                while (DocDL.Read())
                {
                    KetQua += "<li><a href='" + DocDL["Link"] + "'><span>" + DocDL["TenMenu"] + "</span></a>";
                    KetQua += LoadMenu(Convert.ToInt32(DocDL["Ma"]), level + 1);
                    KetQua += "</li>";
                }
                KetQua += "</ul>";
                BaoVe.Close();
            }
            return KetQua;
        }

    }
}
