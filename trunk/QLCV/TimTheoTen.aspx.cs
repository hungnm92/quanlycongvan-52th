using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    lanhnt.CV_User_TT cut = new lanhnt.CV_User_TT();
    lanhnt.CongVan cv = new lanhnt.CongVan();
    lanhnt.UserN u = new lanhnt.UserN();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {
            pnlChiTiet.Visible = false;
            griTimTheoTen.DataSource = cv.TimTheoTen((Session["TenCV"].ToString()));
            griTimTheoTen.DataBind();
            droUserN.DataSource = u.DS();
            droUserN.DataBind();
        }
    }
   
    protected void griCongVanDi_SelectedIndexChanged(object sender, EventArgs e)
    {
        griTimTheoTen.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griTimTheoTen.SelectedValue.ToString());
        cut.CT();
        u.Ma = cut.Ma_UserNhan;
        droUserN.SelectedValue = u.Ma.ToString();
        cv.So = cut.So_CV;
        cv.CT();
        txtTenCV.Text = cv.TenCV;
        txtTomTat.Text = cv.TrichYeu;
        lnkbtnTaiVe.Text = cv.TenFile;
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/TimTheoTen.aspx");
    }
    protected void griCongVanDi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griTimTheoTen.PageIndex = e.NewPageIndex;
        griTimTheoTen.DataSource = cv.TimTheoTen((Session["TenCV"].ToString()));
        griTimTheoTen.DataBind();
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
