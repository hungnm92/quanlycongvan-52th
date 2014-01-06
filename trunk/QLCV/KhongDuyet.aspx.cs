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
            griKhongDuyet.DataSource = cv.KhongDuyet_DS(int.Parse(Session["Ma"].ToString()));
            griKhongDuyet.DataBind();
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/KhongDuyet.aspx");
    }
    protected void griKhongDuyet_SelectedIndexChanged(object sender, EventArgs e)
    {
        griKhongDuyet.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griKhongDuyet.SelectedValue.ToString());
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
        if (Convert.ToInt16(Session["Ma"]) == cut.Ma_UserNhan)
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
    protected void griKhongDuyet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griKhongDuyet.PageIndex = e.NewPageIndex;
        griKhongDuyet.DataSource = cv.KhongDuyet_DS(int.Parse(Session["Ma"].ToString()));
        griKhongDuyet.DataBind();
    }
    protected void griKhongDuyet_RowCommand(object sender, GridViewCommandEventArgs e)
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
