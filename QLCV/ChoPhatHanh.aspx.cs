using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    lanhnt.UserN u = new lanhnt.UserN();
    lanhnt.CV_User_TT cut = new lanhnt.CV_User_TT();
    lanhnt.LoaiCV lcv = new lanhnt.LoaiCV();
    lanhnt.CongVan cv = new lanhnt.CongVan();
    lanhnt.WebMsgBox msg = new lanhnt.WebMsgBox();
    public static int SoLuongDaChon = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {
            pnlChiTiet.Visible = false;
            griChoPhatHanh.DataSource = cv.ChoPhatHanh_DS(int.Parse(Session["Ma"].ToString()));
            griChoPhatHanh.DataBind();
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
            cblUser.DataSource = u.NhanVien_DS();
            cblUser.DataBind();
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChoPhatHanh.aspx");
    }
    protected void btnPhatHanh_Click(object sender, EventArgs e)
    {
        if (SoLuongDaChon != 0)
        {
                cut.So = int.Parse(griChoPhatHanh.SelectedValue.ToString());//Gán Số cho bảng CUT khi click vào griview
                cut.CT();// Lấy ra chi tiết của bảng CUT để sử dụng cho việc thêm bảng mới
                cv.So = cut.So_CV;
                cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
                cut.Ma_User = int.Parse(Session["Ma"].ToString());
                for (int i = 0; i <= cblUser.Items.Count - 1; i++)
                {
                    if (cblUser.Items[i].Selected == true)
                    {
                        cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                        cv.Them_NgayPH();//Thêm giá trị ngày phát hành vào bảng công văn
                        cv.Them_Ma();//Tự động đánh số cho công văn dựa vào loại công văn
                        cv.Sua();
                        cut.PhatHanh();//Thêm bảng CUT với tình trạng là đã phát hành
                    }
                }
                msg.Show(cut.ThongBao);
                SoLuongDaChon = 0;
                txtTenCV.Text = "";
                txtTomTat.Text = "";
                txtMaCV.Text = "";
                txtSoCV.Text = "";
                txtNgayPH.Text = "";
        }
        else
            msg.Show("Bạn chưa nhập người nhận.");
    }
    protected void griChoPhatHanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["MaNhom"]) == 3)//Nếu user thuộc nhóm chuyên viên thì hiển thị nút phát hành.
        {
            btnPhatHanh.Visible = true;
            cblUser.DataSource = u.NhanVien_DS();
            cblUser.DataBind();
        }
        griChoPhatHanh.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griChoPhatHanh.SelectedValue.ToString());
        cut.CT();
        cv.So = cut.So_CV;
        cv.CT();
        txtSoCV.ReadOnly = true;
        txtTenCV.Text = cv.TenCV;
        txtTomTat.Text = cv.TrichYeu;
        txtYKienLD.Text = cv.YKienLD;
        txtMaCV.Text = cv.Ma;
        txtSoCV.Text = cv.So;
        lcv.Ma = cv.Ma_LCV;
        droLCV.SelectedValue = lcv.Ma.ToString();
        txtNgayPH.Text = cut.NgayPH;
        lnkbtnTaiVe.Text = cv.TenFile;
        if (Convert.ToInt16(Session["Ma"]) == cut.Ma_UserNhan)// Nếu user đang đăng nhập là người nhận thì sẽ update thời gian đọc
        {
            string TimeDoc = cut.ThoiGianDoc;
            bool bThoiGianDoc = string.IsNullOrEmpty(TimeDoc);
            if (bThoiGianDoc == true)
            {
                cut.Update_TGDoc();
                cut.CT();
                cut.Doc();
            }
        }
    }
    protected void griChoPhatHanh_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griChoPhatHanh.PageIndex = e.NewPageIndex;
        griChoPhatHanh.DataSource = cv.ChoPhatHanh_DS(int.Parse(Session["Ma"].ToString()));
        griChoPhatHanh.DataBind();
    }
    protected void btnXong_Click(object sender, EventArgs e)
    {
        txtNguoiNhan.Text = "Đã chọn:" + "\r\n";
        for (int i = 0; i <= cblUser.Items.Count - 1; i++)
        {
            if (cblUser.Items[i].Selected == true)
            {
                txtNguoiNhan.Text += cblUser.Items[i].Text.ToString() + "\r\n";
                txtNguoiNhan.Visible = true;
                SoLuongDaChon += 1;
            }
        }
    }

    protected void griChoPhatHanh_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/src/products/") + e.CommandArgument);
            Response.End();
        }
    }
    protected void lnkbtnTaiVe_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/octect-stream";
        Response.AppendHeader("content-disposition", "filename=" + lnkbtnTaiVe.Text);
        Response.TransmitFile(Server.MapPath("~/src/products/") + lnkbtnTaiVe.Text);
        Response.End();    
    }
}
