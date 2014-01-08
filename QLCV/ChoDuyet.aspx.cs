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
            griChoDuyet.DataSource = cv.ChoDuyet_DS(int.Parse(Session["Ma"].ToString()));
            griChoDuyet.DataBind();
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChoDuyet.aspx");
    }
    protected void btnPheDuyet_Click(object sender, EventArgs e)
    {
        if (SoLuongDaChon != 0)
        {
            cut.So = int.Parse(griChoDuyet.SelectedValue.ToString());
            cut.CT();
            cv.So = cut.So_CV;
            cv.YKienLD = txtYKienLD.Text;
            cv.Sua_YKien();
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            for (int i = 0; i <= cblUser.Items.Count - 1; i++)
            {
                if (cblUser.Items[i].Selected == true)
                {
                    cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                    cut.PheDuyet();
                    cut.PheDuyet_ChoPH();
                }
            }
            msg.Show(cut.ThongBao);
            SoLuongDaChon = 0;
        }
        else
            msg.Show("Bạn chưa nhập người nhận.");
    }
    protected void btnKhongDuyet_Click(object sender, EventArgs e)
    {
        if (SoLuongDaChon != 0)
        {
        cut.So = int.Parse(griChoDuyet.SelectedValue.ToString());
        cut.CT();
        cv.So = cut.So_CV;
        cv.YKienLD = txtYKienLD.Text;
        cv.Sua_YKien();
        cut.Ma_User = int.Parse(Session["Ma"].ToString());
         for (int i = 0; i <= cblUser.Items.Count - 1; i++)
            {
                if (cblUser.Items[i].Selected == true)
                {
                    cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                    cut.KhongDuyet();
                }
            }
         msg.Show(cut.ThongBao);
         SoLuongDaChon = 0;
        }
        else
            msg.Show("Bạn chưa nhập người nhận.");
    }
    protected void griChoDuyet_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["MaNhom"]) == 1)
        {
            btnPheDuyet.Visible = true;
            btnKhongDuyet.Visible = true;
            cblUser.DataSource = u.VT_CV_DS();
            cblUser.DataBind();
        }
        griChoDuyet.Visible = false;
        pnlChiTiet.Visible = true;
        cut.So = int.Parse(griChoDuyet.SelectedValue.ToString());
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
    protected void griChoDuyet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griChoDuyet.PageIndex = e.NewPageIndex;
        griChoDuyet.DataSource = cv.ChoDuyet_DS(int.Parse(Session["Ma"].ToString()));
        griChoDuyet.DataBind();
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

    protected void griChoDuyet_RowCommand(object sender, GridViewCommandEventArgs e)
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