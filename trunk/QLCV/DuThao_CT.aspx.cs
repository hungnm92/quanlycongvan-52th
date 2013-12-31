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
            droUserN.DataSource = u.DS();
            droUserN.DataBind();
              cut.So = int.Parse(Session["Temp"].ToString());
              cut.CT();
              txtSoCV.ReadOnly = true;
              txtTenCV.Text = cut.TenCV;
              txtTomTat.Text = cut.TrichYeu;
              txtYKienLD.Text = cut.YKienLD;
              txtGopY.Text = cut.YKienCV;
              txtMaCV.Text = cv.Ma;
              txtSoCV.Text = cut.So_CV;
              cut.Ma_UserNhan = u.Ma;
              droUserN.SelectedValue = u.Ma.ToString();
              lcv.Ma = cv.Ma_LCV;
              droLCV.SelectedValue = lcv.Ma.ToString();
              txtNgayPH.Text = cut.NgayPH;
              //string DuongDan = "";
             // DuongDan = Server.MapPath(cut.TenFile.ToString());
             // fileTep.s = DuongDan;
               //lblTB1.Text = cv.LayMa().ToString();
           // txtMaCV.ReadOnly = true;
           // txtSoCV.ReadOnly = true;
          //  txtNgayPH.ReadOnly = true;
          
        }
    }
    protected void btnTrinhDuyet_Click(object sender, EventArgs e)
    {
         if (fileTep.HasFile == true)
        {
            //cv.So = griDuThao.SelectValue.ToString();
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
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
            cv.Sua();
            cut.So_CV = cv.LayMa().ToString();
            cut.Sua();
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
            //cv.So = griDuThao.SelectValue.ToString();
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
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
            cv.Sua();
            cut.So_CV = cv.LayMa().ToString();
            cut.Sua();
            lblTB.Text = cv.ThongBao;
            //lblTB1.Text = cut.ThongBao;
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
        //cut.So = griDuThao.SelectedValue.ToString();
        cut.Xoa();
        lblTB1.Visible = true;
        lblTB1.Text = cut.ThongBao;
        //cv.So = griDuThao.SelectedValue.ToString();
        cv.Xoa();
        lblTB.Visible = true;
        lblTB.Text = cv.ThongBao;
        /*griDuThao.DataSource = cv.DS();
        griDuThao.DataBind();
        griDuThao.DataSource = cut.DS();
        griDuThao.DataBind();*/
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
            //cv.So = griDuThao.SelectValue.ToString();
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
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
            cv.Sua();
            //cut.So_CV = cv.LayMa().ToString();
            // cut.DuThao();
            lblTB.Text = cv.ThongBao;
            //lblTB1.Text = cut.ThongBao;
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
            //cv.So = griDuThao.SelectValue.ToString();
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
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
            cut.Ma_UserNhan = int.Parse(droUserN.SelectedValue);
            cv.Sua();
            //cut.So_CV = cv.LayMa().ToString();
            // cut.DuThao();
            lblTB.Text = cv.ThongBao;
            //lblTB1.Text = cut.ThongBao;
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
}
/*  protected void griTinTuc_SelectedIndexChanged(object sender, EventArgs e)
  {
          cut.So = griTinTuc.SelectedValue.ToString();
          cut.CT();
          txtSoCV.ReadOnly = true;
          txtTenCV.Text = cut.TenCV;
          txtTomTat.Text = cut.TrichYeu;
          txtYKienLD.Text = cut.YKienLD;
          txtGopY.Text = cut.YKienCV;
          txtMaCV.Text = cut.MaCV;
          txtSoCV.Text = cut.SoCV;
          lcv.MaLCV = cv.MaLCV;
          droLCV.SelectedValue = lcv.MaLCV.ToString();
          txtNgayPH.Text = cut.NgayPH
          fileTep.FileName = cut.TenFile.ToString();
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
