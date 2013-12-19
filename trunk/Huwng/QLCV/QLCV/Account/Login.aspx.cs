using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLCV.Account
{ 
    public partial class Login : System.Web.UI.Page
    {
        UserN u = new UserN();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Ma"] = null;
            Session["Ten"] = null;
            Session["MatKhau"] = null;
        }

        public int PhanQuyen(string input)
        {

            return 0;
        }
        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            u.Ten = txtEmail.Text;
            u.MatKhau = txtMatKhau.Text;
            if ((txtEmail.Text != "") && (txtMatKhau.Text != ""))
            {
                if (u.DangNhap() == true)
                {
                    Session["Email"] = u.Ten;
                    Response.Redirect("~/Account/Default.aspx");
                }
                else
                {
                    lblThongBao.Visible = true;
                    lblThongBao.Text = u.ThongBao;
                }
            }
            else
            {
                lblThongBao.Visible = true;
                lblThongBao.Text = "Email hoặc mật khẩu không hợp lệ.";
            }
        }
    }
}