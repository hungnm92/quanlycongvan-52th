<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_DoiMatKhau.aspx.cs" Inherits="User_DoiMatKhau" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
            text-align: center;
        }
        .auto-style4 {
            height: 22px;
            width: 174px;
            text-align: right;
        }
        .auto-style3 {
            height: 22px;
            text-align: left;
        }
        .auto-style6 {
            width: 174px;
            height: 24px;
            text-align: right;
        }
        .auto-style7 {
            height: 24px;
            text-align: left;
        }
        .auto-style8 {
            width: 174px;
            text-align: right;
        }
        .auto-style5 {
            width: 174px;
        }
        .auto-style2 {
            width: 73px;
        }
        .auto-style9 {
            width: 174px;
            text-align: right;
            height: 26px;
        }
        .auto-style10 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <table style="width: 51%; margin-left: 212px;">
            <tr>
                <td aria-multiselectable="True" class="auto-style1" colspan="3"><strong>ĐỔI MẬT KHẨU</strong></td>
            </tr>
            <tr>
                <td aria-multiselectable="True" class="auto-style4">Email đăng nhập:</td>
                <td class="auto-style3" colspan="2">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td aria-multiselectable="True" class="auto-style6">Mật khẩu củ:</td>
                <td class="auto-style7" colspan="2">
                    <asp:TextBox ID="txtMatKhauCu" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td aria-multiselectable="True" class="auto-style8">Mật khẩu mới:</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtMatKhauMoi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td aria-multiselectable="True" class="auto-style9">Mật khẩu xác nhận:</td>
                <td colspan="2" style="text-align: left" class="auto-style10">
                    <asp:TextBox ID="txtMatKhauXN" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td aria-multiselectable="True" class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btnDoiMatKhau" runat="server" BackColor="Yellow" OnClick="btnDoiMatKhau_Click" Text="OK" Width="49px" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo."></asp:Label>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
