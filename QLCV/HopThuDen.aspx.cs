using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            griCongVanDen.DataSource = cv.Den_DS(int.Parse(Session["Ma"].ToString()));
            griCongVanDen.DataBind();
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
        }
    }
   
    protected void griCongVanDen_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["MaNhom"]) == 1)
        {
            droUserN.DataSource = u.VT_CV_DS();
            droUserN.DataBind();
        }
        if (Convert.ToInt16(Session["MaNhom"]) == 2)
        {
            droUserN.DataSource = u.LanhDao_DS();
            droUserN.DataBind();
        }
        if (Convert.ToInt16(Session["MaNhom"]) == 3)
        {
            droUserN.DataSource = u.NhanVien_DS();
            droUserN.DataBind();
        }
        griCongVanDen.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griCongVanDen.SelectedValue.ToString());
        cut.CT();
        cv.So = cut.So_CV;
        cv.CT();
        txtSoCV.ReadOnly = true;
        txtTenCV.Text = cv.TenCV;
        txtTomTat.Text = cv.TrichYeu;
        txtYKienLD.Text = cv.YKienLD;
        txtGopY.Text = cv.YKienCV;
        txtMaCV.Text = cv.Ma;
        txtSoCV.Text = cv.So;
        //u.Ma = cut.Ma_UserNhan;
        //droUserN.SelectedValue = u.Ma.ToString();
        lcv.Ma = cv.Ma_LCV;
        droLCV.SelectedValue = lcv.Ma.ToString();
        txtNgayPH.Text = cut.NgayPH;
        string TimeDoc = cut.ThoiGianDoc;
        bool bThoiGianDoc = string.IsNullOrEmpty(TimeDoc);
        if (bThoiGianDoc == true)
        cut.Update_TGDoc();
        cut.CT();
        cut.Doc();

    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/HopThuDen.aspx");
    }

    protected void griCongVanDen_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griCongVanDen.PageIndex = e.NewPageIndex;
        griCongVanDen.DataSource = cv.Den_DS(int.Parse(Session["Ma"].ToString()));
        griCongVanDen.DataBind();
    }
}
//store công văn đến.