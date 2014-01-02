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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            pnlChiTiet.Visible = false;
            griChuaDoc.DataSource = cv.ChuaDoc_DS(int.Parse(Session["Ma"].ToString()));
            griChuaDoc.DataBind();
            droUserN.DataSource = u.DS();
            droUserN.DataBind();
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
        }
        //u.Ma = int.Parse(Session["Ma"].ToString());
    }
   /* protected void Button1_Click(object sender, EventArgs e)
    {
        Label4.Text = DateTime.Now.ToString();
        Label4.Visible = true;
        cut.ThoiGianGui = DateTime.Now.ToString();
    }*/
  /*  protected void btnTrinhDuyet_Click(object sender, EventArgs e)
    {
        if (fileTep.HasFile == true)
        {
            cv.So = griCongVanDenDaDoc.SelectedValue.ToString();
            cv.TenCV = txtTenCV.Text;
            bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
            if (bTrichYeu == true)
                cv.TrichYeu = " ";
            else
                cv.TrichYeu = txtTomTat.Text;
            bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
            if (bYKienCV == true)
                cv.YKienCV = " ";
            else
                cv.YKienCV = txtGopY.Text;
            bool bYKienLD = string.IsNullOrWhiteSpace(txtYKienLD.Text);
            if (bYKienLD == true)
                cv.YKienLD = " ";
            else
                cv.YKienLD = txtYKienLD.Text;
            cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
            cv.NgayPH = txtNgayPH.Text;
            string DuongDan = "";
            DuongDan = Server.MapPath("~/src/products/");
            DuongDan = DuongDan + fileTep.FileName;
            fileTep.SaveAs(DuongDan);
            cv.TenFile = fileTep.FileName;
            //cut.ThoiGianGui = DateTime.Now.ToString();
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
            cv.Sua();
            cut.LaySo(cv.So, cut.Ma_User);
            cut.Sua();
            lblTB.Visible = true;
            lblTB1.Visible = true;
            lblTB.Text = cv.ThongBao;
            lblTB1.Text = cut.ThongBao;
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            // droLCV.Text = "";
            txtNgayPH.Text = "";
            //fileTep.;
        }
        else
        {
            cv.So = griCongVanDenDaDoc.SelectedValue.ToString();
            cv.CT();
            string temp = cv.TenFile.ToString();
            cv.TenCV = txtTenCV.Text;
            bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
            if (bTrichYeu == true)
                cv.TrichYeu = " ";
            else
                cv.TrichYeu = txtTomTat.Text;
            bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
            if (bYKienCV == true)
                cv.YKienCV = " ";
            else
                cv.YKienCV = txtGopY.Text;
            bool bYKienLD = string.IsNullOrWhiteSpace(txtYKienLD.Text);
            if (bYKienLD == true)
                cv.YKienLD = " ";
            else
                cv.YKienLD = txtYKienLD.Text;
            cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
            cv.NgayPH = txtNgayPH.Text;
            cv.TenFile = temp;
            cut.ThoiGianGui = DateTime.Now.ToString();
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);          
            cv.Sua();
            cut.LaySo(cv.So, cut.Ma_User);
            cut.Sua();
            lblTB.Visible = true;
            lblTB1.Visible = true;
            lblTB.Text = cv.ThongBao;
            lblTB1.Text = cut.ThongBao;
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            // droLCV.Text = "";
            txtNgayPH.Text = "";
            //fileTep.;
        }
    }
    protected void btnHuyDuThao_Click(object sender, EventArgs e)
    {
        cv.So = griCongVanDenDaDoc.SelectedValue.ToString();
        cv.CT();
        cut.LaySo(cv.So, cut.Ma_User);
        cut.Xoa();
        lblTB1.Visible = true;
        lblTB1.Text = cut.ThongBao;
        cv.Xoa();
        lblTB.Visible = true;
        lblTB.Text = cv.ThongBao;
        /*griDuThao.DataSource = cv.DS();
        griDuThao.DataBind();
        griDuThao.DataSource = cut.DS();
        griDuThao.DataBind();*/
       /* txtTenCV.Text = "";
        txtTomTat.Text = "";
        txtYKienLD.Text = "";
        txtGopY.Text = "";
        txtMaCV.Text = "";
        txtSoCV.Text = "";
        txtNgayPH.Text = "";
    }*/
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
    /*protected void btnLuuDuThao_Click(object sender, EventArgs e)
    {
        if (fileTep.HasFile == true)
        {
            cv.So = griCongVanDenDaDoc.SelectedValue.ToString();
            cv.Ma = " ";
            cv.TenCV = txtTenCV.Text;
            bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
            if (bTrichYeu == true)
                cv.TrichYeu = " ";
            else
                cv.TrichYeu = txtTomTat.Text;
            bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
            if (bYKienCV == true)
                cv.YKienCV = " ";
            else
                cv.YKienCV = txtGopY.Text;
            bool bYKienLD = string.IsNullOrWhiteSpace(txtYKienLD.Text);
            if (bYKienLD == true)
                cv.YKienLD = " ";
            else
                cv.YKienLD = txtYKienLD.Text;
            cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
            //cv.NgayPH = txtNgayPH.Text;
            string DuongDan = "";
            DuongDan = Server.MapPath("~/src/products/");
            DuongDan = DuongDan + fileTep.FileName;
            fileTep.SaveAs(DuongDan);
            cv.TenFile = fileTep.FileName;
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
            cv.Sua();
            cut.LaySo(cv.So, cut.Ma_User);
            cut.LuuDuThao();
            lblTB.Visible = true;
            lblTB1.Visible = true;
            lblTB.Text = cv.ThongBao;
            lblTB1.Text = cut.ThongBao;
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            // droLCV.Text = "";
            txtNgayPH.Text = "";
            Response.Redirect("~/DuThao.aspx");
            //fileTep.;
        }
        else
        {
            cv.So = griCongVanDenDaDoc.SelectedValue.ToString();
            cv.CT();
            cv.Ma = " ";
            string temp = cv.TenFile.ToString();
            cv.TenCV = txtTenCV.Text;
            bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
            if (bTrichYeu == true)
                cv.TrichYeu = " ";
            else
                cv.TrichYeu = txtTomTat.Text;
            bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
            if (bYKienCV == true)
                cv.YKienCV = " ";
            else
                cv.YKienCV = txtGopY.Text;
            bool bYKienLD = string.IsNullOrWhiteSpace(txtYKienLD.Text);
            if (bYKienLD == true)
                cv.YKienLD = " ";
            else
                cv.YKienLD = txtYKienLD.Text;
            cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
            //cv.NgayPH = txtNgayPH.Text;
            cv.TenFile = temp;
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
            cv.Sua();
            cut.LaySo(cv.So, cut.Ma_User);
            cut.LuuDuThao();
            lblTB.Text = cv.ThongBao;
            lblTB1.Text = cut.ThongBao;
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            // droLCV.Text = "";
            txtNgayPH.Text = "";
            Response.Redirect("~/DuThao.aspx");
            //fileTep.;
        }
    }*/
    protected void griChuaDoc_SelectedIndexChanged(object sender, EventArgs e)
    {

        //Session["Temp"] = int.Parse(griDuThao.SelectedValue.ToString());
        griChuaDoc.Visible = false;
        pnlChiTiet.Visible = true;
        cv.So = griChuaDoc.SelectedValue.ToString();
        cv.CT();
        cut.LaySo(cv.So, int.Parse(Session["Ma"].ToString()));
        cut.CT();
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
        //fileTep. = cv.TenFile;
    }
}