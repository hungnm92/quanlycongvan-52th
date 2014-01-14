using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    lanhnt.NhanVien nv = new lanhnt.NhanVien();
    lanhnt.UserN u = new lanhnt.UserN();
    lanhnt.NhomUser nu = new lanhnt.NhomUser();
    lanhnt.PhongBan pb = new lanhnt.PhongBan();
    lanhnt.WebMsgBox msg = new lanhnt.WebMsgBox();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            griNhanVien.DataSource = nv.DS();
            griNhanVien.DataBind();
            droPhongBan.DataSource = pb.DS();
            droPhongBan.DataBind();
            droNhomUser.DataSource = nu.DS();
            droNhomUser.DataBind();
            if (Convert.ToInt16(Session["MaNhom"]) == 1)
            {
                lbtThemMoi.Visible = true;
            }
        }
    }

    protected void griNhanVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkIsUser.Checked = false;
        pnlCapNhat.Visible = true;
        droNhomUser.Visible = false;
        if (Convert.ToInt16(Session["MaNhom"]) == 1)
        {
            btnXoa.Visible = true;
            btnSua.Visible = true;
            btnThem.Visible = false;
            lblTB.Visible = false;
            lbtThemMoi.Visible = false;
        }
        nv.Ma_User = int.Parse(griNhanVien.SelectedValue.ToString());
        nv.IsUser_CT();
        if (nv.IsUser == true)
        {
            droNhomUser.Visible = true;
            nv.CT();
            chkIsUser.Checked = nv.IsUser;
            u.Ma_NV = nv.Ma;
            nu.Ma_User = u.Ma;
            droNhomUser.SelectedValue = nv.Ma_Nhom.ToString();
        }
        txtMa.Text = nv.Ma_User.ToString();
        txtMa.ReadOnly = true;
        txtHo.Text = nv.Ho;
        txtTenNV.Text = nv.TenNV;
        txtNgaySinh.Text = nv.NgaySinh;
        txtTenUser.Text = nv.TenUser;
        txtDiaChi.Text = nv.DiaChi;
        txtDienThoai.Text = nv.DienThoai;
        pb.Ma = nv.Ma_PB;
        droPhongBan.SelectedValue = pb.Ma.ToString();
    }
    protected void lbtThemMoi_Click(object sender, EventArgs e)
    {

        pnlCapNhat.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = true;
        btnXoa.Visible = false;
        btnSua.Visible = false;
        lblTB.Visible = false;
        txtMa.Text = "";
        txtMa.ReadOnly = true;
        txtHo.Text = "";
        txtTenNV.Text = "";
        txtNgaySinh.Text = "";
        txtTenUser.Text = "";
        txtDiaChi.Text = "";
        txtDienThoai.Text = "";
        chkIsUser.Checked = false;
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        
            bool bHo = string.IsNullOrWhiteSpace(txtHo.Text);
            bool bTenNV = string.IsNullOrWhiteSpace(txtTenNV.Text);
            bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
            bool bTenUser = string.IsNullOrWhiteSpace(txtTenUser.Text);
            bool bDiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text);
            bool bDienThoai = string.IsNullOrWhiteSpace(txtDienThoai.Text);
            if (bHo == false && bTenNV == false  && bNgaySinh == false && bTenUser == false  
                && bDiaChi == false&& bDienThoai == false && fileAnhNV.HasFile == true)
            {
                nv.Ho = txtHo.Text;
                nv.TenNV = txtTenNV.Text;
                nv.NgaySinh = txtNgaySinh.Text;
                nv.TenUser = txtTenUser.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.DienThoai = txtDienThoai.Text;
                u.IsUser = chkIsUser.Checked;
                nu.Ma = int.Parse(droNhomUser.SelectedValue);
                nv.Ma_PB = int.Parse(droPhongBan.SelectedValue);
                string DuongDan = "";
                DuongDan = Server.MapPath("~/src/img/User/");
                DuongDan = DuongDan + fileAnhNV.FileName;
                fileAnhNV.SaveAs(DuongDan);
                nv.AnhNV = fileAnhNV.FileName;
                u.TenUser = txtTenUser.Text;
               // u.IsUser = bool.Parse(droIsUser.SelectedValue);
                if(u.IsUser == false)
                {
                    //không thêm nhóm
                    nv.Them();
                    nv.LayMa();
                    u.Ma_NV = nv.Ma;
                    u.Them();
                    //thêm mã nhóm là 4
                    u.TenUser = nv.TenUser;
                    u.LayMa();
                    nu.Ma_User = u.Ma;
                    nu.Ma = 4;
                    nu.Them();
                }
                else
                {
                    nv.Them();
                    nv.LayMa();
                    u.Ma_NV = nv.Ma;
                    u.Them();
                    //lấy cái mã mới nhất
                    u.TenUser = nv.TenUser;
                    u.LayMa();
                    nu.Ma_User = u.Ma;
                    nu.Them();
                }
                lblTB.Visible = true;
                lblTB.Text = nv.ThongBao;
                lblTBU.Visible = true;
                lblTBU.Text = u.ThongBao;
                lblTBNU.Visible = true;
                lblTBNU.Text = u.ThongBao;
                griNhanVien.DataSource = nv.DS();
                griNhanVien.DataBind();
                txtHo.Text = "";
                txtTenNV.Text = "";
                txtNgaySinh.Text = "";
                txtTenUser.Text = "";
                chkIsUser.Checked = false;
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
                pnlCapNhat.Visible = false;
                lbtThemMoi.Visible = true;
                btnThem.Visible = false;
            }
            else
                if (fileAnhNV.HasFile == false)
                {
                    lblTB.Visible = true;
                    lblTB.Text = "BẠN CHƯA CHỌN ẢNH NHÂN VIÊN";
                }
                else
                {
                    lblTB.Visible = true;
                    lblTB.Text = "Ở CÁC VỊ TRÍ * BẮT BUỘC BẠN PHẢI NHẬP";
                }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
            nv.Ma_User = int.Parse(griNhanVien.SelectedValue.ToString());
            nv.CT();
            u.Ma = nv.Ma_User;
            u.CT();
            if (u.IsUser == false)
            {
                u.Xoa();
                nv.Xoa();
            }
            else
            {
                nu.Ma_User = u.Ma;
                nu.Ma = int.Parse(droNhomUser.SelectedValue);
                nu.Xoa();
                u.Xoa();
                nv.Xoa();              
            }
            lblTB.Visible = true;
            lblTB.Text = nv.ThongBao;
            lblTBU.Visible = true;
            lblTBU.Text = u.ThongBao;
            lblTBNU.Visible = true;
            lblTBNU.Text = u.ThongBao;
            griNhanVien.DataSource = nv.DS();
            griNhanVien.DataBind();
            txtMa.Text = "";
            txtHo.Text = "";
            txtTenNV.Text = "";
            txtNgaySinh.Text = "";
            txtTenUser.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            pnlCapNhat.Visible = false;
            lbtThemMoi.Visible = true;   
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlCapNhat.Visible = false;
        if (Convert.ToInt16(Session["MaNhom"]) == 1)
        {
            lbtThemMoi.Visible = true;
        }
        lblTB.Visible = false;
        lblTBU.Visible = false;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
            bool bHo = string.IsNullOrWhiteSpace(txtHo.Text);
            bool bTenNV = string.IsNullOrWhiteSpace(txtTenNV.Text);
            bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
            bool bTenUser = string.IsNullOrWhiteSpace(txtTenUser.Text);
            bool bDiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text);
            bool bDienThoai = string.IsNullOrWhiteSpace(txtDienThoai.Text);
            if (bHo == false && bTenNV == false  && bNgaySinh == false && bTenUser == false  
                && bDiaChi == false&& bDienThoai == false && fileAnhNV.HasFile == true)
            {
                nv.Ma_User = int.Parse(griNhanVien.SelectedValue.ToString());
                nv.CT();
                u.Ma = nv.Ma_User;
                u.CT();
                nu.Ma_User = u.Ma;
                nv.Ho = txtHo.Text;
                nv.TenNV = txtTenNV.Text;
                nv.NgaySinh = txtNgaySinh.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.DienThoai = txtDienThoai.Text;
                nv.Ma_PB = int.Parse(droPhongBan.SelectedValue);
                string DuongDan = "";
                DuongDan = Server.MapPath("~/src/img/User/");
                DuongDan = DuongDan + fileAnhNV.FileName;
                fileAnhNV.SaveAs(DuongDan);
                nv.AnhNV = fileAnhNV.FileName;
                //u.IsUser = bool.Parse(droIsUser.SelectedValue);
                if (chkIsUser.Checked == false)
                {
                    nv.Sua();
                    if (u.IsUser == true)
                    {
                        nu.Ma = nv.Ma_Nhom;
                        nu.Xoa();
                    }
                    u.IsUser = false;
                    u.Sua();                    
                }
                else
                {
                    nv.Sua();
                    nu.Ma = nv.Ma_Nhom;
                    nu.Xoa();
                    nu.Ma = int.Parse(droNhomUser.SelectedValue);
                    nu.Them();
                }
                lblTB.Visible = true;
                lblTB.Text = nv.ThongBao;
                lblTBU.Visible = true;
                lblTBU.Text = u.ThongBao;
                griNhanVien.DataSource = nv.DS();
                griNhanVien.DataBind();
                txtHo.Text = "";
                txtTenNV.Text = "";
                txtNgaySinh.Text = "";
                txtTenUser.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
                pnlCapNhat.Visible = false;
                lbtThemMoi.Visible = true;
             }
        else
           if (bHo == false && bTenNV == false && bNgaySinh == false && bTenUser == false
                 && bDiaChi == false && bDienThoai == false && fileAnhNV.HasFile == false)
            {
                nv.Ma_User = int.Parse(griNhanVien.SelectedValue.ToString());
                nv.CT();
                string temp = nv.AnhNV.ToString();
                u.Ma = nv.Ma_User;
                u.CT();
                nu.Ma_User = u.Ma;
                nv.Ho = txtHo.Text;
                nv.TenNV = txtTenNV.Text;
                nv.NgaySinh = txtNgaySinh.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.DienThoai = txtDienThoai.Text;
                nv.AnhNV = temp;
                nv.Ma_PB = int.Parse(droPhongBan.SelectedValue);
                if (chkIsUser.Checked == false)
                {
                    nv.Sua();
                    if (u.IsUser == true)
                    {
                        nu.Ma = nv.Ma_Nhom;
                        nu.Xoa();
                    }
                    u.IsUser = false;
                    u.Sua();
                }
                else
                {
                    nv.Sua();
                    nu.Ma = nv.Ma_Nhom;
                    nu.Xoa();
                    nu.Ma = int.Parse(droNhomUser.SelectedValue);
                    nu.Them();
                }
                lblTB.Visible = true;
                lblTB.Text = nv.ThongBao;
                lblTBU.Visible = true;
                lblTBU.Text = u.ThongBao;
                griNhanVien.DataSource = nv.DS();
                griNhanVien.DataBind();
                txtHo.Text = "";
                txtTenNV.Text = "";
                txtNgaySinh.Text = "";
                txtTenUser.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
                pnlCapNhat.Visible = false;
                lbtThemMoi.Visible = false;
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = "CÁC VỊ TRÍ * LÀ CÁC BẮT BUỘC NHẬP.";
            }
    }
 
}
