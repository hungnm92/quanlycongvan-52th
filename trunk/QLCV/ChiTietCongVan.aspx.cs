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
            griChiTiet.DataSource = cv.ChiTietCongVan(Session["SoCV"].ToString());
            griChiTiet.DataBind();
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/HopThuDen.aspx");
    }
}
