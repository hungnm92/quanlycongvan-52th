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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
            txtMaCV.ReadOnly = true;
            txtSoCV.ReadOnly = true;
            txtNgayPH.ReadOnly = true;

        }
    }
    protected void btnTrinhDuyet_Click(object sender, EventArgs e)
    {

    }
    protected void btnHuyDuThao_Click(object sender, EventArgs e)
    {

    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        cv.TenCV = txtTenCV.Text.Trim().Replace("  ", " ");
        cv.TrichYeu = txtTomTat.Text.Trim().Replace("  ", " ");
        cv.YKienCV = txtGopY.Text.Trim().Replace("  ", " ");
        //tt.ChiTiet = fckTinTuc.Text;
        cv.Ma = txtMaCV.Text;
        //cv.So = int.Parse(txtSoCV.Text);
        cv.Ma_LCV = int.Parse(droLCV.SelectedValue);
        cv.NgayPH = txtNgayPH.Text;
        string DuongDan = "";
        DuongDan = Server.MapPath("~/src/product/");
        DuongDan = DuongDan + fileTep.FileName;
        fileTep.SaveAs(DuongDan);
        cv.TenFile = fileTep.FileName;
        cut.Ma_User = int.Parse(Session["Ma"].ToString());
        cut.DuThao();
        cv.Them();
        txtTenCV.Text = "";
        txtTomTat.Text = "";
        txtGopY.Text = "";
        txtMaCV.Text = "";
        txtSoCV.Text = "";
        // droLCV.Text = "";
        txtNgayPH.Text = "";
        //fileTep. = "";
        Response.Redirect("~/Default.aspx");
    }
}
  /*  protected void griTinTuc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(Convert.ToInt16(Session["MaPB"])==1)
        {
            //chkKQDuyet.Checked = true;
            //chkNoiBat.Checked = true;
            btnDuyet.Visible = true;
            chkKQDuyet.Visible = true;
            chkNoiBat.Visible = true;
            pnlCapNhat.Visible = true;
            lbtThemMoi.Visible = false;
            btnThem.Visible = false;
            btnXoa.Visible = true;
            btnSua.Visible = true;
            lblTB.Visible = false;
            lblTBDuyet.Visible = false;
            tt.MaTT = griTinTuc.SelectedValue.ToString();
            tt.CT();
            txtMaTT.Text = tt.MaTT;
            txtMaTT.ReadOnly = true;
            txtTieuDe.Text = tt.TieuDe;
            txtTomTat.Text = tt.TomTat;
            //txtChiTiet.Text = tt.ChiTiet;
            fckTinTuc.Text = tt.ChiTiet;
            nt.MaNT = tt.MaNT;
            droNhomTin.SelectedValue = nt.MaNT.ToString();
            //chkKQDuyet.Checked = tt.KQDuyet;
            if (tt.KQDuyet == null)
            {
                chkKQDuyet.Checked = false;
            }
            else
                chkKQDuyet.Checked = tt.KQDuyet;
            chkNoiBat.Checked = tt.NoiBat;
            //nv.MaNV = tt.MaNVDang;
            //droNhanVien.SelectedValue = nv.MaNV.ToString();
        }
        else
        {
            tt.MaTT = griTinTuc.SelectedValue.ToString();
            Session["URL"] = "TT_" + tt.MaTT + "File";
            tt.CT();
            if(tt.KQDuyet == true)
            {
                pnlCapNhat.Visible = false;
                btnDuyet.Visible = false;
                lblTB.Visible = true;
                lblTB.Text = "TIN ĐÃ ĐƯỢC DUYỆT.";
            }
            else
            {
                btnDuyet.Visible = false;
                tt.MaTT = griTinTuc.SelectedValue.ToString();
                tt.CT();
                if (tt.MaNVDang.ToString() == Convert.ToString(Session["MaNV"]))
                {
                    lblTB.Visible = false;
                    lblTBDuyet.Visible = false;
                    lbtThemMoi.Visible = true;
                    pnlCapNhat.Visible = true;
                    btnSua.Visible = true;
                    btnXoa.Visible = true;
                    btnThem.Visible = false;
                    tt.MaTT = griTinTuc.SelectedValue.ToString();
                    tt.CT();
                    txtMaTT.Text = tt.MaTT;
                    txtTieuDe.Text = tt.TieuDe;
                    txtTomTat.Text = tt.TomTat;
                    fckTinTuc.Text = tt.ChiTiet;
                    nt.MaNT = tt.MaNT;
                    droNhomTin.SelectedValue = nt.MaNT.ToString();
                    //nv.MaNV = tt.MaNVDang;
                    //droNhanVien.SelectedValue = nv.MaNV.ToString();
                }
                else
                {
                    lblTB.Visible = true;
                    lblTB.Text = "KHÔNG PHẢI BÀI CỦA BẠN-BẠN CHỈ ĐƯỢC XEM.";
                    pnlCapNhat.Visible = true;
                    btnThem.Visible = false;
                    btnSua.Visible = false;
                    btnXoa.Visible = false;
                    tt.MaTT = griTinTuc.SelectedValue.ToString();
                    tt.CT();
                    txtMaTT.Text = tt.MaTT;
                    txtTieuDe.Text = tt.TieuDe;
                    txtTomTat.Text = tt.TomTat;
                    fckTinTuc.Text = tt.ChiTiet;
                    nt.MaNT = tt.MaNT;
                    droNhomTin.SelectedValue = nt.MaNT.ToString();
                }
                }
            }
        }
    protected void lbtThemMoi_Click(object sender, EventArgs e)
    {
        tt.GetID();
        Session["URL"] = "TT_" + tt.TempID + "file";
        pnlCapNhat.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = true;
        btnXoa.Visible = false;
        btnSua.Visible = false;
        lblTB.Visible = false;
        lblTBDuyet.Visible = false;
        txtMaTT.Text = "";
        txtMaTT.ReadOnly = true;
        txtTieuDe.Text = "";
        txtTomTat.Text = "";
        //txtChiTiet.Text = "";
        fckTinTuc.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool bTieuDe = string.IsNullOrWhiteSpace(txtTieuDe.Text);
        bool bTomTat = string.IsNullOrWhiteSpace(txtTomTat.Text);
        bool bChiTiet = string.IsNullOrWhiteSpace(fckTinTuc.Text);
        if (bTieuDe == false && bTomTat == false && bChiTiet == false && fileAnhMH.HasFile == true)
        {
            tt.TieuDe = txtTieuDe.Text.Trim().Replace("  ", " ");
            tt.TomTat = txtTomTat.Text.Trim().Replace("  ", " ");
           // tt.ChiTiet = txtChiTiet.Text.Trim().Replace("  ", " ");
            tt.ChiTiet = fckTinTuc.Text;
            string DuongDan = "";
            DuongDan = Server.MapPath("~/src/product/");
            DuongDan = DuongDan + fileAnhMH.FileName;
            fileAnhMH.SaveAs(DuongDan);
            tt.AnhMH = fileAnhMH.FileName;
            tt.MaNT = int.Parse(droNhomTin.SelectedValue);
            tt.MaNVDang = int.Parse(Session["MaNV"].ToString());
            //tt.MaNVDang = int.Parse(droNhanVien.SelectedValue);
            tt.Them();
            tt.KQDuyet = false;
            tt.NoiBat = false;
            lblTB.Visible = true;
            lblTB.Text = tt.ThongBao;
            griTinTuc.DataSource = tt.DS();
            griTinTuc.DataBind();
            /*txtTieuDe.Text = "";
            txtTomTat.Text = "";
            txtChiTiet.Text = "";*/
          /*  pnlCapNhat.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
        {
            if (fileAnhMH.HasFile == false)
            {
                lblTB.Visible = true;
                lblTB.Text = "BẠN CHƯA CHỌN ẢNH MINH HỌA";
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = "Ở CÁC VỊ TRÍ * BẮT BUỘC BẠN PHẢI NHẬP";
            }
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        tt.MaTT = griTinTuc.SelectedValue.ToString();
        tt.Xoa();
        lblTB.Visible = true;
        lblTB.Text = tt.ThongBao;
        griTinTuc.DataSource = tt.DS();
        griTinTuc.DataBind();
        /*txtMaTT.Text = "";
        txtTomTat.Text = "";
        txtChiTiet.Text = "";*/
       /* pnlCapNhat.Visible = false;
        lbtThemMoi.Visible = true;
        chkKQDuyet.Visible = false;
        chkNoiBat.Visible = false;
        btnDuyet.Visible = false;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bTieuDe = string.IsNullOrWhiteSpace(txtTieuDe.Text);
        bool bTomTat = string.IsNullOrWhiteSpace(txtTomTat.Text);
        bool bChiTiet = string.IsNullOrWhiteSpace(fckTinTuc.Text);
            if (bTieuDe == false && bTomTat == false && bChiTiet == false && fileAnhMH.HasFile == true)
                {
                    tt.MaTT = griTinTuc.SelectedValue.ToString();
                    tt.TieuDe = txtTieuDe.Text.Trim().Replace("  ", " ");
                    tt.TomTat = txtTomTat.Text.Trim().Replace("  "," ");
                    //tt.ChiTiet = txtChiTiet.Text.Trim().Replace("  "," ");
                    tt.ChiTiet = fckTinTuc.Text;
                    string DuongDan = "";
                    DuongDan = Server.MapPath("~/src/product/");
                    DuongDan = DuongDan + fileAnhMH.FileName;
                    fileAnhMH.SaveAs(DuongDan);
                    tt.AnhMH = fileAnhMH.FileName;
                    tt.MaNT = int.Parse(droNhomTin.SelectedValue);
                    //tt.MaNVDang = int.Parse(droNhanVien.SelectedValue);
                    tt.MaNVDang = int.Parse(Session["MaNV"].ToString());
                    tt.Sua();
                    lblTB.Visible = true;
                    lblTB.Text = tt.ThongBao;
                    griTinTuc.DataSource = tt.DS();
                    griTinTuc.DataBind();
                    /*txtMaTT.Text = "";
                    txtTomTat.Text = "";
                    txtChiTiet.Text = "";*/
                  /*  pnlCapNhat.Visible = false;
                    lbtThemMoi.Visible = true;
                    chkKQDuyet.Visible = false;
                    chkNoiBat.Visible = false;
                    btnDuyet.Visible = false;
                }
            else
                if (bTieuDe == false && bTomTat == false && bChiTiet == false && fileAnhMH.HasFile == false)
                {   
                    tt.MaTT = griTinTuc.SelectedValue.ToString();
                    tt.CT();
                    string temp = tt.AnhMH.ToString();
                    tt.TieuDe = txtTieuDe.Text.Trim().Replace("  ", " ");
                    tt.TomTat = txtTomTat.Text.Trim().Replace("  "," ");
                    //tt.ChiTiet = txtChiTiet.Text.Trim().Replace("  "," ");
                    tt.ChiTiet = fckTinTuc.Text;
                    tt.AnhMH = temp;
                    tt.MaNT = int.Parse(droNhomTin.SelectedValue);
                    //tt.MaNVDang = int.Parse(droNhanVien.SelectedValue);
                    tt.MaNVDang = int.Parse(Session["MaNV"].ToString());
                    tt.Sua();
                    lblTB.Visible = true;
                    lblTB.Text = tt.ThongBao;
                    griTinTuc.DataSource = tt.DS();
                    griTinTuc.DataBind();
                    /*txtMaTT.Text = "";
                    txtTieuDe.Text = "";
                    txtTomTat.Text = "";
                    txtChiTiet.Text = "";*/
                  /*  pnlCapNhat.Visible = false;
                    lbtThemMoi.Visible = true;
                    chkKQDuyet.Visible = false;
                    chkNoiBat.Visible = false;
                    btnDuyet.Visible = false;
                }
                else
                {
                    lblTB.Visible = true;
                    lblTB.Text = "CÁC VỊ TRÍ * LÀ CÁC BẮT BUỘC NHẬP.";
                }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlCapNhat.Visible = false;
        lbtThemMoi.Visible = true;
        lblTB.Visible = false;
    }
    protected void btnDuyet_Click(object sender, EventArgs e)
    {
        tt.MaTT = griTinTuc.SelectedValue.ToString();
        tt.CT();
        tt.NoiBat = chkNoiBat.Checked;
        tt.KQDuyet = chkKQDuyet.Checked;
        //tt.MaNVDuyet = int.Parse(droNhanVien.SelectedValue);
        tt.MaNVDuyet = int.Parse(Session["MaNV"].ToString());
        tt.Duyet();
        lblTBDuyet.Visible = true;
        lblTBDuyet.Text = tt.ThongBao;
        griTinTuc.DataSource = tt.DS();
        griTinTuc.DataBind();
        /*txtMaTT.Text = "";
        txtTomTat.Text = "";
        txtChiTiet.Text = "";*/
       /* pnlCapNhat.Visible  = false;
        lbtThemMoi.Visible = true;
        chkKQDuyet.Visible = false;
        chkNoiBat.Visible = false;
        btnDuyet.Visible = false;
    }
    protected void griTinTuc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griTinTuc.PageIndex = e.NewPageIndex;
        griTinTuc.DataSource = tt.DS();
        griTinTuc.DataBind();
    }*/
