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
    public static int SoLuongDaChon = 0;
    lanhnt.WebMsgBox msg = new lanhnt.WebMsgBox();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {
            pnlChiTiet.Visible = false;
            griCongVanDen.DataSource = cv.Den_DS(int.Parse(Session["Ma"].ToString()));
            griCongVanDen.DataBind();
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
            cblUser.DataSource = u.DS();
            cblUser.DataBind();
        }
    }
   
    protected void griCongVanDen_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        griCongVanDen.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griCongVanDen.SelectedValue.ToString());
        cut.CT();
        cv.So = cut.So_CV;
        cv.CT();
        txtSoCV.ReadOnly = true;
        txtTenCV.Text = cv.TenCV;
        txtTomTat.Text = cv.TrichYeu;
        txtChiDao.Text = cv.YKienLD;
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
        cut.CT();
        cut.Doc();

    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/HopThuDen.aspx");
    }

    protected void griCongVanDen_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griCongVanDen.PageIndex = e.NewPageIndex;
        griCongVanDen.DataSource = cv.Den_DS(int.Parse(Session["Ma"].ToString()));
        griCongVanDen.DataBind();
    }
    protected void btnXong_Click(object sender, EventArgs e)
    {
        txtNguoiNhan.Text = "Đã chọn:" + "\r\n";
        for (int i = 0; i <= cblUser.Items.Count - 1; i++)
        {
            if (cblUser.Items[i].Selected == true)
            {
                txtNguoiNhan.Text += cblUser.Items[i].Text.ToString() + "\r\n";
                txtNguoiNhan.Visible = true;
                SoLuongDaChon += 1;
            }
        }
    }

    protected void btnTraLoi_Click(object sender, EventArgs e)
    {

        bool bTenCV = string.IsNullOrWhiteSpace(txtTenCV.Text);
        bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
        bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
        bool bYKienLD = string.IsNullOrWhiteSpace(txtChiDao.Text);
        if (bTenCV == false && bTrichYeu == false && fileTep.HasFile == true && SoLuongDaChon != 0)
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
            cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
            string DuongDan = "";
            DuongDan = Server.MapPath("~/src/products/");
            DuongDan = DuongDan + fileTep.FileName;
            fileTep.SaveAs(DuongDan);
            cv.TenFile = fileTep.FileName;
            cv.Them();
            cut.So_CV = cv.LayMa().ToString();
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            for (int i = 0; i <= cblUser.Items.Count - 1; i++)
            {
                if (cblUser.Items[i].Selected == true)
                {
                    cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                    cut.Gui();
                }
            }
            msg.ShowAndRedirect(cut.ThongBao);
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            txtNgayPH.Text = "";
            SoLuongDaChon = 0;
        }
        else
            if (bTenCV == false && bTrichYeu == false && fileTep.HasFile == false && SoLuongDaChon != 0)
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
                cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
                cv.TenFile = " ";
                cv.Them();
                cut.So_CV = cv.LayMa().ToString();
                cut.Ma_User = int.Parse(Session["Ma"].ToString());
                for (int i = 0; i <= cblUser.Items.Count - 1; i++)
                {
                    if (cblUser.Items[i].Selected == true)
                    {
                        cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                        cut.Gui();
                    }
                }
                msg.ShowAndRedirect(cut.ThongBao);
                txtTenCV.Text = "";
                txtTomTat.Text = "";
                txtGopY.Text = "";
                txtMaCV.Text = "";
                txtSoCV.Text = "";
                txtNgayPH.Text = "";
                SoLuongDaChon = 0;
            }
            else
                msg.Show("Bạn chưa nhập đầy đủ thông tin bắt buộc");
    }
}
//store công văn đến.