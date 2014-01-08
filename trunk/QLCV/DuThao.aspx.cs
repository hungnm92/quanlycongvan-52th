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
            griDuThao.DataSource = cv.DuThao_DS(int.Parse(Session["Ma"].ToString()));
            griDuThao.DataBind();
            cblUser.DataSource = u.DS();
            cblUser.DataBind();
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
        }
    }
   
    protected void griDuThao_SelectedIndexChanged(object sender, EventArgs e)
    {
        griDuThao.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griDuThao.SelectedValue.ToString());
        cut.CT();
        cv.So = cut.So_CV;
        cv.CT();
        txtSoCV.ReadOnly = true;
        txtTenCV.Text = cv.TenCV;
        txtTomTat.Text = cv.TrichYeu;
        txtYKienLD.Text = cv.YKienLD;
        txtGopY.Text = cv.YKienCV;
        txtMaCV.Text = cv.Ma;
        txtSoCV.Text = cv.So;
        u.Ma = cut.Ma_UserNhan;
        cblUser.Items[u.Ma].Selected = true;
        btnXong_Click(sender,e);
        lcv.Ma = cv.Ma_LCV;
        droLCV.SelectedValue = lcv.Ma.ToString();
        txtNgayPH.Text = cut.NgayPH;
        lnkbtnTaiVe.Text = cv.TenFile;
        lnkbtnTaiVe.Text = cv.TenFile;
    }
    protected void btnTrinhDuyet_Click(object sender, EventArgs e)
    {
        if (SoLuongDaChon != 0)
        {
            if (fileTep.HasFile == true)
            {
                cut.So = int.Parse(griDuThao.SelectedValue.ToString());
                cut.CT();
                cv.So = cut.So_CV;
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
                string ReName = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "-");
                DuongDan = Server.MapPath("~/src/products/");
                DuongDan = DuongDan + ReName + fileTep.FileName;
                fileTep.SaveAs(DuongDan);
                cv.TenFile = ReName + fileTep.FileName;
                cut.Ma_User = int.Parse(Session["Ma"].ToString());
                for (int i = 0; i <= cblUser.Items.Count - 1; i++)
                {
                    if (cblUser.Items[i].Selected == true)
                    {
                        cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                        cv.Sua();
                        cut.Sua();
                    }
                }
                msg.Show(cut.ThongBao);
                SoLuongDaChon = 0;
                txtTenCV.Text = "";
                txtTomTat.Text = "";
                txtGopY.Text = "";
                txtMaCV.Text = "";
                txtSoCV.Text = "";
                txtNgayPH.Text = "";
            }
            else
            {
                cut.So = int.Parse(griDuThao.SelectedValue.ToString());
                cut.CT();
                cv.So = cut.So_CV;
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
                for (int i = 0; i <= cblUser.Items.Count - 1; i++)
                {
                    if (cblUser.Items[i].Selected == true)
                    {
                        cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                        cv.Sua();
                        cut.Sua();
                    }
                }
                msg.Show(cut.ThongBao);
                SoLuongDaChon = 0;
                txtTenCV.Text = "";
                txtTomTat.Text = "";
                txtGopY.Text = "";
                txtMaCV.Text = "";
                txtSoCV.Text = "";
                txtNgayPH.Text = "";
            }
        }
        else
            msg.Show("Bạn chưa nhập người nhận.");
    
    }
    protected void btnHuyDuThao_Click(object sender, EventArgs e)
    {
        cut.So = int.Parse(griDuThao.SelectedValue.ToString());
        cut.CT();
        cv.So = cut.So_CV;
        cv.CT();
        cut.Xoa();
        msg.Show(cut.ThongBao);
        cv.Xoa();
        txtTenCV.Text = "";
        txtTomTat.Text = "";
        txtYKienLD.Text = "";
        txtGopY.Text = "";
        txtMaCV.Text = "";
        txtSoCV.Text = "";
        txtNgayPH.Text = "";
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/DuThao.aspx");
    }
    protected void btnLuuDuThao_Click(object sender, EventArgs e)
    {
        if (fileTep.HasFile == true)
        {
            cut.So = int.Parse(griDuThao.SelectedValue.ToString());
            cut.CT();
            cv.So = cut.So_CV;
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
            string DuongDan = "";
            string ReName = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "-");
            DuongDan = Server.MapPath("~/src/products/");
            DuongDan = DuongDan + ReName + fileTep.FileName;
            fileTep.SaveAs(DuongDan);
            cv.TenFile = ReName + fileTep.FileName;
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            if (SoLuongDaChon != 0)
                for (int i = 0; i <= cblUser.Items.Count - 1; i++)
                {
                    if (cblUser.Items[i].Selected == true)
                    {
                        cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                        cv.Sua();
                        cut.LuuDuThao();
                    }
                }
            else
                {
                    cut.Ma_UserNhan = 0;
                    cv.Sua();
                    cut.LuuDuThao();
                }
            msg.Show(cut.ThongBao);
            SoLuongDaChon = 0;
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            txtNgayPH.Text = "";
            Response.Redirect("~/DuThao.aspx");
        }
        else
        {
            cut.So = int.Parse(griDuThao.SelectedValue.ToString());
            cut.CT();
            cv.So = cut.So_CV;
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
            cv.TenFile = temp;
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            if (SoLuongDaChon != 0)
                for (int i = 0; i <= cblUser.Items.Count - 1; i++)
                {
                    if (cblUser.Items[i].Selected == true)
                    {
                        cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                        cv.Sua();
                        cut.LuuDuThao();
                    }
                }
            else
            {
                cut.Ma_UserNhan = 0;
                cv.Sua();
                cut.LuuDuThao();
            }
            msg.Show(cut.ThongBao);
            SoLuongDaChon = 0;
            txtTenCV.Text = "";
            txtTomTat.Text = "";
            txtGopY.Text = "";
            txtMaCV.Text = "";
            txtSoCV.Text = "";
            txtNgayPH.Text = "";
            Response.Redirect("~/DuThao.aspx");
        }
    }
    protected void griDuThao_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griDuThao.PageIndex = e.NewPageIndex;
        griDuThao.DataSource = cv.DuThao_DS(int.Parse(Session["Ma"].ToString()));
        griDuThao.DataBind();
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

    protected void griDuThao_RowCommand(object sender, GridViewCommandEventArgs e)
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
    protected void lnkbtnTaiVe_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/octect-stream";
        Response.AppendHeader("content-disposition", "filename=" + lnkbtnTaiVe.Text);
        Response.TransmitFile(Server.MapPath("~/src/products/") + lnkbtnTaiVe.Text);
        Response.End();    
    }
}