using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    lanhnt.UserN u = new lanhnt.UserN();
    lanhnt.CV_User_TT cut = new lanhnt.CV_User_TT();
    lanhnt.LoaiCV lcv = new lanhnt.LoaiCV();
    lanhnt.CongVan cv = new lanhnt.CongVan();
    lanhnt.WebMsgBox msg = new lanhnt.WebMsgBox();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            pnlChiTiet.Visible = false;
            griChuaDoc.DataSource = cv.ChuaDoc_DS(int.Parse(Session["Ma"].ToString()));
            griChuaDoc.DataBind();
            droUserN.DataSource = u.DS();
            droUserN.DataBind();
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChuaDoc.aspx");
    }
    protected void griChuaDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        griChuaDoc.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griChuaDoc.SelectedValue.ToString());
        cut.CT();
        cv.So = cut.So_CV;
        cv.CT();
        txtSoCV.ReadOnly = true;
        txtTenCV.Text = cv.TenCV;
        txtTomTat.Text = cv.TrichYeu;
        txtChiDao.Text = cv.YKienLD;
        txtGopY.Text = cv.YKienCV;
        txtMaCV.Text = cv.Ma;
        txtSoCV.Text = cv.So;
        lcv.Ma = cv.Ma_LCV;
        droLCV.SelectedValue = lcv.Ma.ToString();
        txtNgayPH.Text = cut.NgayPH;
        string TimeDoc = cut.ThoiGianDoc;
        lnkbtnTaiVe.Text = cv.TenFile;
        bool bThoiGianDoc = string.IsNullOrEmpty(TimeDoc);
        if (bThoiGianDoc == true)
        {
            cut.Update_TGDoc();
            cut.CT();
            cut.Doc();
        }

    }
    protected void btnLuuDuThao_Click(object sender, EventArgs e)
    {

        if (fileTep.HasFile == true)
        {
            cut.So = int.Parse(griChuaDoc.SelectedValue.ToString());
            cut.CT();
            cv.So = cut.So_CV;
            cv.Ma = " ";
            cv.TenCV = txtTenCV.Text;
            bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
            if (bTrichYeu == true)
                cv.TrichYeu = " ";
            else
                cv.TrichYeu = txtTomTat.Text;
            bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
            if (bYKienCV == true)
                cv.YKienCV = " ";
            else
                cv.YKienCV = txtGopY.Text;
            bool bYKienLD = string.IsNullOrWhiteSpace(txtChiDao.Text);
            if (bYKienLD == true)
                cv.YKienLD = " ";
            else
                cv.YKienLD = txtChiDao.Text;
            cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
            //cv.NgayPH = txtNgayPH.Text;
            string DuongDan = "";
            string ReName = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "-");
            DuongDan = Server.MapPath("~/src/products/");
            DuongDan = DuongDan + ReName + fileTep.FileName;
            fileTep.SaveAs(DuongDan);
            cv.TenFile = ReName + fileTep.FileName;
            cut.So = int.Parse(griChuaDoc.SelectedValue.ToString());
            cut.CT();
            cv.Me = cut.So_CV;
            cv.Them_Me();
            cut.So_CV = cv.LayMa().ToString();
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
            cut.DuThao();
            msg.Show(cut.ThongBao);
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            // droLCV.Text = "";
            txtNgayPH.Text = "";
            Response.Redirect("~/ChuaDoc.aspx");
            //fileTep.;
        }
        else
        {
            cut.So = int.Parse(griChuaDoc.SelectedValue.ToString());
            cut.CT();
            cv.So = cut.So_CV;
            cv.CT();
            cv.Ma = " ";
            string temp = cv.TenFile.ToString();
            cv.TenCV = txtTenCV.Text;
            bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
            if (bTrichYeu == true)
                cv.TrichYeu = " ";
            else
                cv.TrichYeu = txtTomTat.Text;
            bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
            if (bYKienCV == true)
                cv.YKienCV = " ";
            else
                cv.YKienCV = txtGopY.Text;
            bool bYKienLD = string.IsNullOrWhiteSpace(txtChiDao.Text);
            if (bYKienLD == true)
                cv.YKienLD = " ";
            else
                cv.YKienLD = txtChiDao.Text;
            cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
            //cv.NgayPH = txtNgayPH.Text;
            cv.TenFile = temp;
            cut.So = int.Parse(griChuaDoc.SelectedValue.ToString());
            cut.CT();
            cv.Me = cut.So_CV;
            cv.Them_Me();
            cut.So_CV = cv.LayMa().ToString();
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
            cut.DuThao();
            msg.Show(cut.ThongBao);
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            // droLCV.Text = "";
            txtNgayPH.Text = "";
            Response.Redirect("~/ChuaDoc.aspx");
        }
    }
    protected void griChuaDoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griChuaDoc.PageIndex = e.NewPageIndex;
        griChuaDoc.DataSource = cv.ChuaDoc_DS(int.Parse(Session["Ma"].ToString()));
        griChuaDoc.DataBind();
    }
    protected void griChuaDoc_RowCommand(object sender, GridViewCommandEventArgs e)
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
    protected void btnTraLoi_Click(object sender, EventArgs e)
    {

        bool bTenCV = string.IsNullOrWhiteSpace(txtTenCV.Text);
        bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
        bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
        bool bYKienLD = string.IsNullOrWhiteSpace(txtChiDao.Text);
        if (bTenCV == false && bTrichYeu == false && fileTep.HasFile == true)
        {
            cv.TenCV = txtTenCV.Text;
            cv.TrichYeu = txtTomTat.Text;
            if (bYKienCV == true)
                cv.YKienCV = " ";
            else
                cv.YKienCV = txtGopY.Text;
            if (bYKienLD == true)
                cv.YKienLD = " ";
            else
                cv.YKienLD = txtChiDao.Text;
            cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
            string DuongDan = "";
            string ReName = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "-");
            DuongDan = Server.MapPath("~/src/products/");
            DuongDan = DuongDan + ReName + fileTep.FileName;
            fileTep.SaveAs(DuongDan);
            cv.TenFile = ReName + fileTep.FileName;
            cut.So = int.Parse(griChuaDoc.SelectedValue.ToString());
            cut.CT();
            cv.Me = cut.So_CV;
            cv.Them_Me();
            cut.So_CV = cv.LayMa().ToString();
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue.ToString());
            cut.Gui();
            msg.ShowAndRedirect(cut.ThongBao);
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            txtNgayPH.Text = "";
        }
        else
            if (bTenCV == false && bTrichYeu == false && fileTep.HasFile == false)
            {
                cv.TenCV = txtTenCV.Text;
                cv.TrichYeu = txtTomTat.Text;
                if (bYKienCV == true)
                    cv.YKienCV = " ";
                else
                    cv.YKienCV = txtGopY.Text;
                if (bYKienLD == true)
                    cv.YKienLD = " ";
                else
                    cv.YKienLD = txtChiDao.Text;
                cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
                cv.TenFile = " ";
                cut.So = int.Parse(griChuaDoc.SelectedValue.ToString());
                cut.CT();
                cv.Me = cut.So_CV;
                cv.Them_Me();
                cut.So_CV = cv.LayMa().ToString();
                cut.Ma_User = int.Parse(Session["Ma"].ToString());
                cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue.ToString());
                cut.Gui();
                msg.ShowAndRedirect(cut.ThongBao);
                txtTenCV.Text = "";
                txtTomTat.Text = "";
                txtGopY.Text = "";
                txtMaCV.Text = "";
                txtSoCV.Text = "";
                txtNgayPH.Text = "";
            }
            else
                msg.Show("Bạn chưa nhập đầy đủ thông tin bắt buộc");
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