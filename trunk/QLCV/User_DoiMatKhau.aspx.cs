using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_DoiMatKhau : System.Web.UI.Page
{
    lanhnt.UserN u = new lanhnt.UserN();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDoiMatKhau_Click(object sender, EventArgs e)
    {
        bool bEmail = string.IsNullOrWhiteSpace(txtEmail.Text);
        bool bMatKhauCu = string.IsNullOrWhiteSpace(txtMatKhauCu.Text);
        bool bMatKhauMoi = string.IsNullOrWhiteSpace(txtMatKhauMoi.Text);
        bool bMatKhauXN = string.IsNullOrWhiteSpace(txtMatKhauXN.Text);
        if (bEmail == false && bMatKhauCu == false && bMatKhauMoi == false & bMatKhauXN == false)
        {
            u.Ten = txtEmail.Text;
            u.MatKhauCu = txtMatKhauCu.Text;
            u.MatKhauMoi = txtMatKhauMoi.Text;
            u.MatKhauXN = txtMatKhauXN.Text;
            u.DoiMatKhau();
            lblTB.Visible = true;
            lblTB.Text = u.ThongBao;
            txtEmail.Text = "";
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "BẠN CHƯA NHẬP ĐẦY ĐỦ THÔNG TIN.";
        }
    }
}