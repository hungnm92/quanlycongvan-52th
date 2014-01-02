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
            griChoDuyet.DataSource = cv.ChoDuyet_DS(int.Parse(Session["Ma"].ToString()));
            griChoDuyet.DataBind();
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
    protected void btnPheDuyet_Click(object sender, EventArgs e)
    {
        cut.So = int.Parse(griChoDuyet.SelectedValue.ToString());
        cut.CT();
        cut.Ma_User = int.Parse(Session["Ma"].ToString());
        cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
        cv.So = cut.So_CV;
        cut.PheDuyet();
        cut.PheDuyet_ChoPH();
        msg.Show(cut.ThongBao);
        // Response.Redirect("~/Default.aspx");
    }
    protected void btnKhongDuyet_Click(object sender, EventArgs e)
    {
        cut.So = int.Parse(griChoDuyet.SelectedValue.ToString());
        cut.CT();
        cut.Ma_User = int.Parse(Session["Ma"].ToString());
        cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
        cv.So = cut.So_CV;
        cut.KhongDuyet();
        msg.Show(cut.ThongBao);
        //Response.Redirect("~/Default.aspx");
    }
    protected void griChoDuyet_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["MaNhom"]) == 1)
        {
            btnPheDuyet.Visible = true;
            btnKhongDuyet.Visible = true;
            droUserN.DataSource = u.VT_CV_DS();
            droUserN.DataBind();
        }
        griChoDuyet.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griChoDuyet.SelectedValue.ToString());
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
    }
}