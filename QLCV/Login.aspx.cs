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
        u.TenUser = txtTen.Text;
        u.MatKhau = txtMatKhau.Text;
        if ((string.IsNullOrWhiteSpace(txtMatKhau.Text) == false) && (string.IsNullOrWhiteSpace(txtTen.Text) == false))
        {
            if (u.DangNhap() == true)
            {
                //Session["MaNV"] = nv.Ma;
               // Session["HoTenNV"] = nv.HoNVa + " " + nv.TenNV;
                //Session["Ten"] = nv.Ten;
                //Session["MaPB"] = nv.MaPB;
                //Session["TenPB"] = nv.TenPB;
                Response.Redirect("~/Default.aspx");
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