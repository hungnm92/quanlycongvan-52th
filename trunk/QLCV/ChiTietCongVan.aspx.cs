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
            griCV_Me_DS.DataSource = cv.Me_DS();
            griCV_Me_DS.DataBind();
            pnlChiTiet.Visible = false;
            griCV_Me_DS.Visible = true;
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChiTietCongVan.aspx");
    }

    protected void griCV_Me_DS_SelectedIndexChanged(object sender, EventArgs e)
    {
        griCV_Me_DS.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griCV_Me_DS.SelectedValue.ToString());
        cut.CT();
        cv.So = cut.So_CV;
        cv.CT();
        griChiTiet.DataSource = cv.ChiTietCongVan(cv.HoiThoai);
        griChiTiet.DataBind();
    }
    protected void griCV_Me_DS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griCV_Me_DS.PageIndex = e.NewPageIndex;
        griCV_Me_DS.DataSource = cv.KhongDuyet_DS(int.Parse(Session["Ma"].ToString()));
        griCV_Me_DS.DataBind();
    }
    protected void griCV_Me_DS_RowCommand(object sender, GridViewCommandEventArgs e)
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
  
}
