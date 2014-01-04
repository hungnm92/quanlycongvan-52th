using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SoanCV : System.Web.UI.Page
{
    lanhnt.LoaiCV lcv = new lanhnt.LoaiCV();
    lanhnt.TinhTrang tt = new lanhnt.TinhTrang();
    lanhnt.CongVan cv = new lanhnt.CongVan();
    lanhnt.CV_User_TT cut = new lanhnt.CV_User_TT();
    lanhnt.UserN u = new lanhnt.UserN();
    lanhnt.WebMsgBox msg = new lanhnt.WebMsgBox();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
            droUserN.DataSource = u.LanhDao_DS();
            droUserN.DataBind();
           //lblTB1.Text = cv.LayMa().ToString();
            txtMaCV.ReadOnly = true;
            txtSoCV.ReadOnly = true;
            txtNgayPH.ReadOnly = true;
            cblUser.DataSource = u.LanhDao_DS();
            cblUser.DataBind();
        }
    }
    protected void btnTrinhDuyet_Click(object sender, EventArgs e)
    {
        bool bTenCV = string.IsNullOrWhiteSpace(txtTenCV.Text);
        bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
        bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
        bool bYKienLD = string.IsNullOrWhiteSpace(txtChiDao.Text);
        if (bTenCV == false && bTrichYeu == false && fileTep.HasFile == true)
        {
            cv.TenCV = txtTenCV.Text; 
            cv.TrichYeu = txtTomTat.Text;
            if (bYKienCV == true)
                cv.YKienCV = " ";
            else
                cv.YKienCV = txtGopY.Text;
            if (bYKienLD == true)
                cv.YKienLD = " ";
            else
                cv.YKienLD = txtChiDao.Text;
            //cv.Ma = txtMaCV.Text;
            //cv.So = int.Parse(txtSoCV.Text);
            cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
            string DuongDan = "";
            DuongDan = Server.MapPath("~/src/products/");
            DuongDan = DuongDan + fileTep.FileName;
            fileTep.SaveAs(DuongDan);
            cv.TenFile = fileTep.FileName;
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
            cv.Them();
            cut.So_CV = cv.LayMa().ToString();
            cut.TrinhDuyet();
            msg.ShowAndRedirect(cut.ThongBao);
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            // droLCV.Text = "";
            txtNgayPH.Text = "";
            //Redirect("~/Default.aspx");
        }
        else
            msg.Show("Bạn chưa nhập đầy đủ thông tin bắt buộc");
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        bool bTenCV = string.IsNullOrWhiteSpace(txtTenCV.Text);
        bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
        bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
        bool bYKienLD = string.IsNullOrWhiteSpace(txtChiDao.Text);
        if (bTenCV == true && bTrichYeu == true && bYKienCV == true && bYKienLD == true && fileTep.HasFile == false)
            Response.Redirect("~/HopThuDen.aspx");
        else
            if (bTenCV == true && fileTep.HasFile == true)
            {
                cv.TenCV = txtTenCV.Text;
                if (bTrichYeu == true)
                    cv.TrichYeu = " ";
                else
                    cv.TrichYeu = txtTomTat.Text;
                if (bYKienCV == true)
                    cv.YKienCV = " ";
                else
                    cv.YKienCV = txtGopY.Text;
                if (bYKienLD == true)
                    cv.YKienLD = " ";
                else
                    cv.YKienLD = txtChiDao.Text;
                //cv.Ma = txtMaCV.Text;
                //cv.So = int.Parse(txtSoCV.Text);
                cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
                string DuongDan = "";
                DuongDan = Server.MapPath("~/src/products/");
                DuongDan = DuongDan + fileTep.FileName;
                fileTep.SaveAs(DuongDan);
                cv.TenFile = fileTep.FileName;
                cut.Ma_User = int.Parse(Session["Ma"].ToString());
                cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
                cv.Them();
                cut.So_CV = cv.LayMa().ToString();
                cut.DuThao();
                msg.ShowAndRedirect(cut.ThongBao);
                txtTenCV.Text = "";
                txtTomTat.Text = "";
                txtGopY.Text = "";
                txtMaCV.Text = "";
                txtSoCV.Text = "";
                // droLCV.Text = "";
                txtNgayPH.Text = "";
                //fileTep. = "";
                // Response.Redirect("~/Default.aspx");
            }
            else
            {
                cv.TenCV = txtTenCV.Text;
                if (bTrichYeu == true)
                    cv.TrichYeu = " ";
                else
                    cv.TrichYeu = txtTomTat.Text;
                if (bYKienCV == true)
                    cv.YKienCV = " ";
                else
                    cv.YKienCV = txtGopY.Text;
                if (bYKienLD == true)
                    cv.YKienLD = " ";
                else
                    cv.YKienLD = txtChiDao.Text;
                //cv.Ma = txtMaCV.Text;
                //cv.So = int.Parse(txtSoCV.Text);
                cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
                cv.TenFile = " ";
                cut.Ma_User = int.Parse(Session["Ma"].ToString());
                cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
                cv.Them();
                cut.So_CV = cv.LayMa().ToString();
                cut.DuThao();
                msg.ShowAndRedirect(cut.ThongBao);
                txtTenCV.Text = "";
                txtTomTat.Text = "";
                txtGopY.Text = "";
                txtMaCV.Text = "";
                txtSoCV.Text = "";
                // droLCV.Text = "";
                txtNgayPH.Text = "";
                //fileTep. = "";
                // Response.Redirect("~/Default.aspx");
            }
    }
    protected void btnGui_Click(object sender, EventArgs e)
    {
        bool bTenCV = string.IsNullOrWhiteSpace(txtTenCV.Text);
        bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
        bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
        bool bYKienLD = string.IsNullOrWhiteSpace(txtChiDao.Text);
        if (bTenCV == false && bTrichYeu == false && fileTep.HasFile == true)
        {
            cv.TenCV = txtTenCV.Text;
            cv.TrichYeu = txtTomTat.Text;
            if (bYKienCV == true)
                cv.YKienCV = " ";
            else
                cv.YKienCV = txtGopY.Text;
            if (bYKienLD == true)
                cv.YKienLD = " ";
            else
                cv.YKienLD = txtChiDao.Text;
            //cv.Ma = txtMaCV.Text;
            //cv.So = int.Parse(txtSoCV.Text);
            cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
            string DuongDan = "";
            DuongDan = Server.MapPath("~/src/products/");
            DuongDan = DuongDan + fileTep.FileName;
            fileTep.SaveAs(DuongDan);
            cv.TenFile = fileTep.FileName;
            cv.Them();
            cut.So_CV = cv.LayMa().ToString();
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
            cut.Gui();
            msg.ShowAndRedirect(cut.ThongBao);
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            // droLCV.Text = "";
            txtNgayPH.Text = "";
            //Redirect("~/Default.aspx");
        }
        else
            if (bTenCV == false && bTrichYeu == false && fileTep.HasFile == false)
            {
                cv.TenCV = txtTenCV.Text;
                cv.TrichYeu = txtTomTat.Text;
                if (bYKienCV == true)
                    cv.YKienCV = " ";
                else
                    cv.YKienCV = txtGopY.Text;
                if (bYKienLD == true)
                    cv.YKienLD = " ";
                else
                    cv.YKienLD = txtChiDao.Text;
                //cv.Ma = txtMaCV.Text;
                //cv.So = int.Parse(txtSoCV.Text);
                cv.Ma_LCV = int.Parse(droLCV.SelectedValue);      
                cv.TenFile = " ";
                cv.Them();
                cut.So_CV = cv.LayMa().ToString();
                cut.Ma_User = int.Parse(Session["Ma"].ToString());
                cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
                cut.Gui();
                msg.ShowAndRedirect(cut.ThongBao);
                txtTenCV.Text = "";
                txtTomTat.Text = "";
                txtGopY.Text = "";
                txtMaCV.Text = "";
                txtSoCV.Text = "";
                // droLCV.Text = "";
                txtNgayPH.Text = "";
                //Redirect("~/Default.aspx");
            }
            else 
                msg.Show("Bạn chưa nhập đầy đủ thông tin bắt buộc");
    }
    protected void btnXong_Click(object sender, EventArgs e)
    {
        txtNguoiNhan.Text = "Đã chọn:" + "\r\n";
        for (int i = 0; i <= cblUser.Items.Count - 1; i++)
        {
            if (cblUser.Items[i].Selected == true)
            {
                txtNguoiNhan.Text += cblUser.Items[i].Text.ToString() +"\r\n";
                txtNguoiNhan.Visible = true;
            }
        }
    }
}
  