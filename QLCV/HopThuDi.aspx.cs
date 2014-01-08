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
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {
            pnlChiTiet.Visible = false;
            griCongVanDi.DataSource = cv.DaGui_DS(int.Parse(Session["Ma"].ToString()));
            griCongVanDi.DataBind();
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
        }
    }
   
    protected void griCongVanDi_SelectedIndexChanged(object sender, EventArgs e)
    {
        griCongVanDi.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griCongVanDi.SelectedValue.ToString());
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
        lnkbtnTaiVe.Text = cv.TenFile;
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/HopThuDi.aspx");
    }
    protected void griCongVanDi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griCongVanDi.PageIndex = e.NewPageIndex;
        griCongVanDi.DataSource = cv.DaGui_DS(int.Parse(Session["Ma"].ToString()));
        griCongVanDi.DataBind();
    }
    protected void griCongVanDi_RowCommand(object sender, GridViewCommandEventArgs e)
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
