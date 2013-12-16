<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SoanVB.aspx.cs" Inherits="SoanVB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblTBDuyet" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>

        <asp:Panel ID="pnlCapNhat" runat="server" BorderColor="#FF6600" BorderStyle="Double" style="margin-left: 112px" Width="600px">
            <table style="width:100%;">
                <tr>
                    <td colspan="2" style="background-color: #0000FF; color: #FFFF00;">CẬP NHẬT DỮ LIỆU:</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #6699FF">Mã số :</td>
                    <td style="background-color: #99CCFF">
                        <asp:TextBox ID="txtMaTT" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="auto-style1" style="background-color: #6699FF">Tiêu đề:</td>
                    <td style="background-color: #99CCFF" class="auto-style1">
                        <asp:TextBox ID="txtTieuDe" runat="server"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="auto-style1" style="background-color: #6699FF">Tóm tắt:</td>
                    <td style="background-color: #99CCFF" class="auto-style1">
                        <asp:TextBox ID="txtTomTat" runat="server"></asp:TextBox>
                        *</td>
                </tr>

                <tr>
                    <td class="auto-style2" style="background-color: #6699FF">Ảnh:</td>
                    <td style="background-color: #99CCFF">
                        <asp:FileUpload ID="fileAnhMH" runat="server" />
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="background-color: #6699FF">Nhóm tin:</td>
                    <td class="auto-style1" style="background-color: #99CCFF">
                        <asp:DropDownList ID="droNhomTin" runat="server" DataTextField="TenNT" DataValueField="MaNT">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="background-color: #6699FF">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #99CCFF">
                        <asp:Button ID="btnThem" runat="server" BackColor="Yellow" Text="Thêm" Width="14%" />
                        &nbsp;
                        <asp:Button ID="btnXoa" runat="server" BackColor="Yellow" Text="Xóa" Width="14%" />
                        &nbsp;
                        <asp:Button ID="btnSua" runat="server" BackColor="Yellow" Text="Sửa" Width="14%" />
                        &nbsp;
                        <asp:Button ID="btnThoat" runat="server" BackColor="Yellow" Text="Thoát" Width="14%" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2" style="background-color: #6699FF">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
</asp:Content>

