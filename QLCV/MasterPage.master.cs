using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    //lanhnt.Menu mn = new lanhnt.Menu();
    lanhnt.LoaiCV lcv = new lanhnt.LoaiCV();
    lanhnt.TinhTrang tt = new lanhnt.TinhTrang();
    lanhnt.CongVan cv = new lanhnt.CongVan();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Session["Ma"] == null)
                Response.Redirect("~/Login.aspx");
            lblUser.Text = "Xin chào " + Session["HoTenNV"].ToString() + ".";
            if (Convert.ToInt16(Session["MaNhom"]) == 1)
            {
                lblChuaDoc_CD.Text = "(" + cv.ChoDuyet_ChuaDoc_SL(int.Parse(Session["Ma"].ToString())) + ")";
                lblChuaDoc_CPH.Text = "(" + cv.ChoPhatHanh_ChuaDoc_SL(int.Parse(Session["Ma"].ToString())) + ")";
            }
            if (Convert.ToInt16(Session["MaNhom"]) == 2)
            {
                lblChuaDoc_CD.Text = "(" + cv.ChoDuyet_ChuaDoc_SL(int.Parse(Session["Ma"].ToString())) + ")";
                lblChuaDoc_KD.Text = "(" + cv.KhongDuyet_ChuaDoc_SL(int.Parse(Session["Ma"].ToString())) + ")";
            }
            if (Convert.ToInt16(Session["MaNhom"]) == 3)
            {
                lblChuaDoc_CPH.Text = "(" + cv.ChoPhatHanh_ChuaDoc_SL(int.Parse(Session["Ma"].ToString())) + ")";
            }
            if (Convert.ToInt16(Session["MaNhom"]) == 4)
            {
                lblChuaDoc_CPH.Text = "(" + cv.DaPhatHanh_ChuaDoc_SL(int.Parse(Session["Ma"].ToString())) + ")";
            }
            lblChuaDoc_Den.Text = "(" + cv.Den_ChuaDoc_SL(int.Parse(Session["Ma"].ToString())) + ")";
            lblSoLuong_DT.Text = "(" + cv.DuThao_SL(int.Parse(Session["Ma"].ToString())) + ")";
            //lblMenu.Text = mn.LoadMenu(0, 0);
        }
    }

    protected void btnTimNangCao_Click(object sender, EventArgs e)
    {
        pnlTimKiem.Visible = true;
        droLCV.DataSource = lcv.DS();
        droLCV.DataBind();
        droTinhTrang.DataSource = tt.DS();
        droTinhTrang.DataBind();
    }
    protected void btnTimLCV_Click(object sender, EventArgs e)
    {
        Session["MaLCV"] = droLCV.SelectedValue;
        Response.Redirect("~/TimLCV.aspx");
        //cv.TimTheoLCV(int.Parse(Session["MaLCV"].ToString()));
        pnlTimKiem.Visible = false;
    }
    protected void btnTimTT_Click(object sender, EventArgs e)
    {
        Session["MaTT"] = droTinhTrang.SelectedValue;
        Response.Redirect("~/TimTheoTinhTrang.aspx");
        //cv.TimTheoLCV(int.Parse(Session["MaLCV"].ToString()));
        pnlTimKiem.Visible = false;
    }
    protected void btnTimTen_Click(object sender, EventArgs e)
    {
        Session["TenCV"] = txtTenCV.Text;
        Response.Redirect("~/TimTheoTen.aspx");
        //cv.TimTheoLCV(int.Parse(Session["MaLCV"].ToString()));
        pnlTimKiem.Visible = false;
    }
    protected void btnTimThang_Click(object sender, EventArgs e)
    {
        Session["Thang"] = txtThang.Text;
        Response.Redirect("~/TimTheoThang.aspx");
        //cv.TimTheoLCV(int.Parse(Session["MaLCV"].ToString()));
        pnlTimKiem.Visible = false;
    }
    protected void btnThoatTK_Click(object sender, EventArgs e)
    {
        pnlTimKiem.Visible = false;
    }
    protected void btnTimTongHop_Click(object sender, EventArgs e)
    {
        Session["Thang"] = txtThang.Text;
        Session["TenCV"] = txtTenCV.Text;
        Session["MaTT"] = droTinhTrang.SelectedValue;
        Session["MaLCV"] = droLCV.SelectedValue;
        Response.Redirect("~/TimTongHop.aspx");
    }
}
