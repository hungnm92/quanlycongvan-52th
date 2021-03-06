﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    lanhnt.UserN u = new lanhnt.UserN();
    lanhnt.CV_User_TT cut = new lanhnt.CV_User_TT();
    lanhnt.LoaiCV lcv = new lanhnt.LoaiCV();
    lanhnt.CongVan cv = new lanhnt.CongVan();
    lanhnt.WebMsgBox msg = new lanhnt.WebMsgBox();
    public static string duongdan;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {
            pnlChiTiet.Visible = false;
            griCongVanDen.DataSource = cv.Den_DS(int.Parse(Session["Ma"].ToString()));
            griCongVanDen.DataBind();

            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label4.Text = DateTime.Now.ToString();
        Label4.Visible = true;
    }
    protected void griCongVanDen_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["MaNhom"]) == 1)
        {
            btnPheDuyet.Visible = true;
            btnKhongDuyet.Visible = true;
            droUserN.DataSource = u.VT_CV_DS();
            droUserN.DataBind();
        }
        if (Convert.ToInt16(Session["MaNhom"]) == 2)
        {
            btnTrinhDuyet.Visible = true;
            btnLuuDuThao.Visible = true;
            droUserN.DataSource = u.LanhDao_DS();
            droUserN.DataBind();
        }
        if (Convert.ToInt16(Session["MaNhom"]) == 3)
        {
            btnPhatHanh.Visible = true;
            droUserN.DataSource = u.NhanVien_DS();
            droUserN.DataBind();
        }
        griCongVanDen.Visible = false;
        pnlChiTiet.Visible = true;
        cv.So = griCongVanDen.SelectedValue.ToString();
        cv.CT();
        cut.LaySo(cv.So, cut.Ma_User);
        cut.CT();
        txtSoCV.ReadOnly = true;
        txtTenCV.Text = cv.TenCV;
        txtTomTat.Text = cv.TrichYeu;
        txtYKienLD.Text = cv.YKienLD;
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

    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
    protected void btnPheDuyet_Click(object sender, EventArgs e)
    {
        cut.Ma_User = int.Parse(Session["Ma"].ToString());
        cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
        cv.So = griCongVanDen.SelectedValue.ToString();
        cut.So_CV = cv.So;
        cut.LaySo(cv.So, cut.Ma_User);
        cut.PheDuyet();
        cut.PheDuyet_ChoPH();
        msg.Show(cut.ThongBao);
        // Response.Redirect("~/Default.aspx");
    }
    protected void btnKhongDuyet_Click(object sender, EventArgs e)
    {
        cut.Ma_User = int.Parse(Session["Ma"].ToString());
        cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
        cv.So = griCongVanDen.SelectedValue.ToString();
        cut.So_CV = cv.So;
        cut.LaySo(cv.So, cut.Ma_User);
        cut.KhongDuyet();
        msg.Show(cut.ThongBao);
        //Response.Redirect("~/Default.aspx");
    }
    protected void btnTrinhDuyet_Click(object sender, EventArgs e)
    {
        if (fileTep.HasFile == true)
        {
            cv.So = griCongVanDen.SelectedValue.ToString();
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
            cut.So_CV = cv.So;
            cut.TrinhDuyet();
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
            cv.So = griCongVanDen.SelectedValue.ToString();
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
            cut.So_CV = cv.So;
            cut.TrinhDuyet();
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
    protected void btnPhatHanh_Click(object sender, EventArgs e)
    {

    }
    protected void btnLuuDuThao_Click(object sender, EventArgs e)
    {

        if (fileTep.HasFile == true)
        {
            cv.So = griCongVanDen.SelectedValue.ToString();
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
            cut.So_CV = cv.So;
            cut.DuThao();
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
            cv.So = griCongVanDen.SelectedValue.ToString();
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
            cut.So_CV = cv.So;
            cut.DuThao();
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
        }
    }
    protected void griCongVanDen_RowCommand(object sender, GridViewCommandEventArgs e)
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
}
//store công văn đến.