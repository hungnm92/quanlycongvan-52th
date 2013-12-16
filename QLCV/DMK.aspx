<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DMK.aspx.cs" Inherits="DMK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style8 {
            height: 23px;
            text-align: center;
        }
        .auto-style4 {
            height: 23px;
            width: 26%;
            text-align: right;
        }
        .auto-style5 {
            height: 23px;
            width: 413px;
            text-align: left;
        }
        .auto-style6 {
            height: 34px;
            width: 26%;
            text-align: right;
        }
        .auto-style7 {
            height: 34px;
            width: 413px;
            text-align: left;
        }
        

        .auto-style2 {
            height: 23px;
            text-align: right;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <div style="text-align: center">
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table style="width:60%; margin-left: 141px;">
            <tr>
                <td class="auto-style8" colspan="2" style="background-color: #0000FF; color: #FFFF00;">ĐỔI MẬT KHẨU&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4" style="background-color: #0099FF">Email đăng nhập: </td>
                <td class="auto-style5" style="background-color: #99CCFF">&nbsp;<asp:TextBox ID="txtEmail" runat="server" style="margin-left: 0px" Width="60%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="background-color: #0099FF">Mật khẩu cũ:</td>
                <td class="auto-style7" style="background-color: #99CCFF">&nbsp;<asp:TextBox ID="txtMatKhauCu" runat="server" TextMode="Password" style="text-align: left" Width="60%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="background-color: #0099FF">Mật khẩu mới:</td>
                <td class="auto-style7" style="background-color: #99CCFF">
                    <asp:TextBox ID="txtMatKhauMoi" runat="server" style="margin-left: 0px" Width="60%" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="background-color: #0099FF">Mật khẩu xác nhận:</td>
                <td class="auto-style7" style="background-color: #99CCFF">
                    <asp:TextBox ID="txtMatKhauXN" runat="server" style="margin-left: 0px" Width="60%" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="background-color: #0099FF" colspan="2">
                    <asp:Button ID="btnDoiMatKhau" runat="server" BackColor="Yellow" OnClick="btnDoiMatKhau_Click" Text="OK" />
                    &nbsp; &nbsp;</td>
            </tr>
            </table>
        <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    
    </div>
    </form>
</body>
</html>
