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
    }
    public class CongVan
    {
        public string Ma;
        public int So;        
        public string TenCV;
        public string TrichYeu;
        public string TenFile;
        public string NgayPH;
        public string YKienLD;
        public string YKienCV;
        public int Ma_LCV;
        public string ThongBao;
        public string SoCV;
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
                //ThamSo = Lenh.Parameters.AddWithValue("@Ma", Ma);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_LCV", Ma_LCV);
                ThamSo = Lenh.Parameters.AddWithValue("@TenCV", TenCV);
                ThamSo = Lenh.Parameters.AddWithValue("@TrichYeu", TrichYeu);
                ThamSo = Lenh.Parameters.AddWithValue("@TenFile", TenFile);
                //ThamSo = Lenh.Parameters.AddWithValue("@NgayPH", NgayPH);
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
                ThamSo = Lenh.Parameters.AddWithValue("@Ma", Ma);
                ThamSo = Lenh.Parameters.AddWithValue("@So", So);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_LCV", Ma_LCV);
                ThamSo = Lenh.Parameters.AddWithValue("@TenCV", TenCV);
                ThamSo = Lenh.Parameters.AddWithValue("@TrichYeu", TrichYeu);
                ThamSo = Lenh.Parameters.AddWithValue("@TenFile", TenFile);
                ThamSo = Lenh.Parameters.AddWithValue("@NgayPH", NgayPH);
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
                So = int.Parse(DocDL["So"].ToString());
                Ma_LCV = int.Parse(DocDL["Ma_LCV"].ToString());
                TenCV = DocDL["TenCV"].ToString();
                TrichYeu = DocDL["NgayDang"].ToString();
                TenFile = DocDL["AnhMH"].ToString();
                NgayPH = DocDL["NoiBat"].ToString();
                YKienLD = DocDL["NgayDuyet"].ToString();
                YKienCV = DocDL["KQDuyet"].ToString();
                //MaNT = int.Parse(DocDL["MaNT"].ToString());
                //MaNVDang = int.Parse(DocDL["MaNVDang"].ToString());
                //MaNVDuyet = int.Parse(DocDL["MaNVDuyet"].ToString());
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
                Ma_CV = DocDL["Ma_CV"].ToString();
                So = int.Parse(DocDL["So"].ToString());
                So_CV = DocDL["So_CV"].ToString();
                TenCV = DocDL["TenCV"].ToString();
                TenTT = DocDL["TenTT"].ToString();
                TenUser = DocDL["TenUser"].ToString();
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
                //ThamSo = Lenh.Parameters.AddWithValue("@ThoiGianSoan", ThoiGianSoan);
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
                SqlCommand Lenh = new SqlCommand("CV_UserN_TT_TrinhDuyet", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@So_CV", So_CV);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_User", Ma_User);
                ThamSo = Lenh.Parameters.AddWithValue("@Ma_UserNhan", Ma_UserNhan);
                //ThamSo = Lenh.Parameters.AddWithValue("@ThoiGianSoan", ThoiGianSoan);
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
}
