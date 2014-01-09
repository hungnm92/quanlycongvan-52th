using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    lanhnt.UserN u = new lanhnt.UserN();
    lanhnt.CV_User_TT cut = new lanhnt.CV_User_TT();
    lanhnt.LoaiCV lcv = new lanhnt.LoaiCV();
    lanhnt.CongVan cv = new lanhnt.CongVan();
    lanhnt.WebMsgBox msg = new lanhnt.WebMsgBox();
    public static int SoLuongDaChon = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {
            pnlChiTiet.Visible = false;
            griKhongDuyet.DataSource = cv.KhongDuyet_DS(int.Parse(Session["Ma"].ToString()));
            griKhongDuyet.DataBind();
            cblUser.DataSource = u.DS();
            cblUser.DataBind();
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
            if (Convert.ToInt16(Session["MaNhom"]) == 2)
            {
                btnTrinhDuyet.Visible = true;
                btnLuuDuThao.Visible = true;
                txtGopY.ReadOnly = false;
            }
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/KhongDuyet.aspx");
    }
    protected void griKhongDuyet_SelectedIndexChanged(object sender, EventArgs e)
    {
        griKhongDuyet.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griKhongDuyet.SelectedValue.ToString());
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
        lcv.Ma = cv.Ma_LCV;
        droLCV.SelectedValue = lcv.Ma.ToString();
        txtNgayPH.Text = cut.NgayPH;
        lnkbtnTaiVe.Text = cv.TenFile;
        if (Convert.ToInt16(Session["Ma"]) == cut.Ma_UserNhan)
        {
            string TimeDoc = cut.ThoiGianDoc;
            bool bThoiGianDoc = string.IsNullOrEmpty(TimeDoc);
            if (bThoiGianDoc == true)
            {
                cut.Update_TGDoc();
                cut.CT();
                cut.Doc();
            }
        }
    }
    protected void griKhongDuyet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griKhongDuyet.PageIndex = e.NewPageIndex;
        griKhongDuyet.DataSource = cv.KhongDuyet_DS(int.Parse(Session["Ma"].ToString()));
        griKhongDuyet.DataBind();
    }
    protected void griKhongDuyet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/src/products/") + e.CommandArgument);
            Response.End();
        }
    }
    protected void btnTrinhDuyet_Click(object sender, EventArgs e)
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
            string ReName = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "-");
            DuongDan = Server.MapPath("~/src/products/");
            DuongDan = DuongDan + ReName + fileTep.FileName;
            fileTep.SaveAs(DuongDan);
            cv.TenFile = ReName + fileTep.FileName;
            cut.So = int.Parse(griKhongDuyet.SelectedValue.ToString());
            cut.CT();
            cv.Me = cut.So_CV;
            cv.Them_Me();
            cut.So_CV = cv.LayMa().ToString();
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cv.So = cut.So_CV;
            for (int i = 0; i <= cblUser.Items.Count - 1; i++)
            {
                if (cblUser.Items[i].Selected == true)
                {
                    cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                    cut.TrinhDuyet();
                }
            }
            msg.Show(cut.ThongBao);
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
    protected void btnLuuDuThao_Click(object sender, EventArgs e)
    {
        bool bTenCV = string.IsNullOrWhiteSpace(txtTenCV.Text);
        bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
        bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
        bool bYKienLD = string.IsNullOrWhiteSpace(txtChiDao.Text);
        if (bTenCV == true && bTrichYeu == true && bYKienCV == true && bYKienLD == true && fileTep.HasFile == false)
            Response.Redirect("~/KhongDuyet.aspx");
        if (bTenCV == false && fileTep.HasFile == true)
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
            cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
            string DuongDan = "";
            string ReName = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "-");
            DuongDan = Server.MapPath("~/src/products/");
            DuongDan = DuongDan + ReName + fileTep.FileName;
            fileTep.SaveAs(DuongDan);
            cv.TenFile = ReName + fileTep.FileName;
            cut.So = int.Parse(griKhongDuyet.SelectedValue.ToString());
            cut.CT();
            cv.Me = cut.So_CV;
            cv.Them_Me();
            cut.So_CV = cv.LayMa().ToString();
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            if (SoLuongDaChon != 0)
                for (int i = 0; i <= cblUser.Items.Count - 1; i++)
                {
                    if (cblUser.Items[i].Selected == true)
                    {
                        cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                        cut.DuThao();
                    }
                    SoLuongDaChon = 0;
                }
            else
            {
                cut.Ma_UserNhan = 0;
                cut.DuThao();
            }
            msg.Show(cut.ThongBao);
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            txtNgayPH.Text = "";
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
            cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
            cv.TenFile = " ";
            cut.So = int.Parse(griKhongDuyet.SelectedValue.ToString());
            cut.CT();
            cv.Me = cut.So_CV;
            cv.Them_Me();
            cut.So_CV = cv.LayMa().ToString();
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            if (SoLuongDaChon != 0)
                for (int i = 0; i <= cblUser.Items.Count - 1; i++)
                {
                    if (cblUser.Items[i].Selected == true)
                    {
                        cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                        cut.DuThao();
                    }
                    SoLuongDaChon = 0;
                }
            else
            {
                cut.Ma_UserNhan = 0;
                cut.DuThao();
            }
            msg.Show(cut.ThongBao);
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            txtNgayPH.Text = "";
        }
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
    protected void lnkbtnTaiVe_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/octect-stream";
        Response.AppendHeader("content-disposition", "filename=" + lnkbtnTaiVe.Text);
        Response.TransmitFile(Server.MapPath("~/src/products/") + lnkbtnTaiVe.Text);
        Response.End();    
    }
}
