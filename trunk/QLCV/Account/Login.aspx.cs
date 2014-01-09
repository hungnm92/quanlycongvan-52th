using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Login : System.Web.UI.Page
{
    lanhnt.UserN u = new lanhnt.UserN();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnDangNhap_Click(object sender, EventArgs e)
    {
        u.TenUser = txtTenUser.Text;
        u.MatKhau = txtMatKhau.Text;
        if ((string.IsNullOrWhiteSpace(txtMatKhau.Text) == false) && (string.IsNullOrWhiteSpace(txtTenUser.Text) == false))
        {
            if (u.DangNhap() == true)
            {
                Session["Ma"] = u.Ma;
                Session["IsUser"] = u.IsUser;
                Session["HoTenNV"] = u.Ho + " " + u.TenNV;
                Session["MaNhom"] = u.MaNhom;
                Response.Redirect("~/HopThuDen.aspx");
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = u.ThongBao;
            }
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Bạn chưa nhập email hoặc mật khẩu.";
        }
    }
}