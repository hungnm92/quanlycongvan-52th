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
    public static int SoLuongDaChon = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            droLCV.DataSource = lcv.DS();
            droLCV.DataBind();
            txtMaCV.ReadOnly = true;
            txtSoCV.ReadOnly = true;
            txtNgayPH.ReadOnly = true;
            cblUser.DataSource = u.DS();
            cblUser.DataBind();
            if (Convert.ToInt16(Session["MaNhom"]) == 1)
            {
                txtChiDao.ReadOnly = false;
            }
            if (Convert.ToInt16(Session["MaNhom"]) == 2)
            {
                btnTrinhDuyet.Visible = true;
                txtGopY.ReadOnly = false;
            }

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
            cut.Ma_User = int.Parse(Session["Ma"].ToString());
                cv.Them();
                cut.So_CV = cv.LayMa().ToString();
                cv.So = cut.So_CV;
                for (int i = 0; i <= cblUser.Items.Count - 1; i++)
                {
                    if (cblUser.Items[i].Selected == true)
                    {
                        cut.Ma_UserNhan = Convert.ToInt32(cblUser.Items[i].Value);
                        if (u.LayMaNhom(cut.Ma_UserNhan) == 1)
                        {
                            cut.TrinhDuyet();
                        }
                        else
                        {
                            cv.Xoa();
                            msg.Show("Không được trình tới chuyên viên.");
                            break;
                        }
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
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        bool bTenCV = string.IsNullOrWhiteSpace(txtTenCV.Text);
        bool bTrichYeu = string.IsNullOrWhiteSpace(txtTomTat.Text);
        bool bYKienCV = string.IsNullOrWhiteSpace(txtGopY.Text);
        bool bYKienLD = string.IsNullOrWhiteSpace(txtChiDao.Text);
        if (bTenCV == true && bTrichYeu == true && bYKienCV == true && bYKienLD == true && fileTep.HasFile == false)
            Response.Redirect("~/HopThuDen.aspx");
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
                cut.Ma_User = int.Parse(Session["Ma"].ToString());
                cv.Them();
                cut.So_CV = cv.LayMa().ToString();
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
                cut.Ma_User = int.Parse(Session["Ma"].ToString());
                cv.Them();
                cut.So_CV = cv.LayMa().ToString();
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
    protected void btnGui_Click(object sender, EventArgs e)
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
            cv.Ma_LCV = 10;
            string DuongDan = "";
            string ReName = DateTime.Now.ToString().Replace("/", "").Replace(":","").Replace(" ", "-");
            DuongDan = Server.MapPath("~/src/products/");
            DuongDan = DuongDan + ReName + fileTep.FileName;
            fileTep.SaveAs(DuongDan);
            cv.TenFile = ReName + fileTep.FileName;
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
                cv.Ma_LCV = 10;      
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
    protected void btnXong_Click(object sender, EventArgs e)
    {
        txtNguoiNhan.Text = "Đã chọn:" + "\r\n";
        for (int i = 0; i <= cblUser.Items.Count - 1; i++)
        {
            if (cblUser.Items[i].Selected == true)
            {
                txtNguoiNhan.Text += cblUser.Items[i].Text.ToString() +"\r\n";
                txtNguoiNhan.Visible = true;
                SoLuongDaChon += 1;
            }
        }
    }
}
  