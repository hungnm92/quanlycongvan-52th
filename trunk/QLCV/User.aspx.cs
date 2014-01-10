using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    lanhnt.NhanVien nv = new lanhnt.NhanVien();
    lanhnt.UserN u = new lanhnt.UserN();
    lanhnt.NhomUser nu = new lanhnt.NhomUser();
    lanhnt.PhongBan pb = new lanhnt.PhongBan();
    lanhnt.WebMsgBox msg = new lanhnt.WebMsgBox();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            griNhanVien.DataSource = nv.DS();
            griNhanVien.DataBind();
            droPhongBan.DataSource = pb.DS();
            droPhongBan.DataBind();
            droNhomUser.DataSource = nu.DS();
            droNhomUser.DataBind();
        }
    }

    protected void griNhanVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["MaNhom"]) == 1)
        pnlCapNhat.Visible = true;
        btnThem.Visible = false;
        btnXoa.Visible = true;
        btnSua.Visible = true;
        lblTB.Visible = false;
        nv.Ma = int.Parse(griNhanVien.SelectedValue.ToString());
        nv.CT();
        txtMaNV.Text = nv.MaNV.ToString();
        txtMaNV.ReadOnly = true;
        txtHoNV.Text = nv.HoNV;
        txtTenNV.Text = nv.TenNV;
        txtEmail.Text = nv.Email;
        txtDienThoai.Text = nv.DienThoai;
        pb.MaPB = nv.MaPB;
        droPhongBan.SelectedValue = pb.MaPB.ToString();
    }
}
