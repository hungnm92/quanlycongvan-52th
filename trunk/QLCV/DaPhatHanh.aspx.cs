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
            griDaPhatHanh.DataSource = cv.DaPhatHanh_DS(int.Parse(Session["Ma"].ToString()));
            griDaPhatHanh.DataBind();
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/DaPhatHanh.aspx");
    }
    protected void griDaPhatHanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        griDaPhatHanh.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griDaPhatHanh.SelectedValue.ToString());
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
        u.Ma = cut.Ma_UserNhan;
        droUserN.SelectedValue = u.Ma.ToString();
        lcv.Ma = cv.Ma_LCV;
        droLCV.SelectedValue = lcv.Ma.ToString();
        txtNgayPH.Text = cut.NgayPH;
    }
    protected void griDaPhatHanh_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griDaPhatHanh.PageIndex = e.NewPageIndex;
        griDaPhatHanh.DataSource = cv.DaPhatHanh_DS(int.Parse(Session["Ma"].ToString()));
        griDaPhatHanh.DataBind();
    }
}
