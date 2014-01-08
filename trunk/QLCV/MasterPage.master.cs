using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    lanhnt.Menu mn = new lanhnt.Menu();
    lanhnt.CongVan cv = new lanhnt.CongVan();
    protected void Page_Load(object sender, EventArgs e)
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
        }
        if (Convert.ToInt16(Session["MaNhom"]) == 3)
        {
            lblChuaDoc_CPH.Text = "(" + cv.ChoPhatHanh_ChuaDoc_SL(int.Parse(Session["Ma"].ToString())) + ")";
        }
        lblChuaDoc_Den.Text = "(" + cv.Den_ChuaDoc_SL(int.Parse(Session["Ma"].ToString())) + ")";
        lblSoLuong_DT.Text = "(" + cv.DuThao_SL(int.Parse(Session["Ma"].ToString())) + ")";
        //lblMenu.Text = mn.LoadMenu(0, 0);
    }
    
}
