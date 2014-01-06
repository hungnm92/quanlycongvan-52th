<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DMK.aspx.cs" Inherits="DMK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link href="../Styles/style_Login.css" rel="stylesheet" />
    <title>Trang Đổi Mật Khẩu</title>
</head>
<body>
 <section class="container">
        <div class="login">
            <h1>Đổi Mật Khẩu </h1>
            <form id="form2" runat="server">
                <p><asp:TextBox ID="txtTenUser" runat="server" placeholder="UserName hoặc Email"></asp:TextBox></p>
                <p><asp:TextBox ID="txtMatKhauCu" runat="server" placeholder="Password" AutoCompleteType="None" TextMode="Password"></asp:TextBox></p>
                <p><asp:TextBox ID="txtMatKhauMoi" runat="server" placeholder="Mật khẩu mới" AutoCompleteType="None" TextMode="Password"></asp:TextBox></p>
                <p><asp:TextBox ID="txtMatKhauXN" runat="server" placeholder="Mật khẩu xác nhận" AutoCompleteType="None" TextMode="Password"></asp:TextBox></p>
                    <p class="submit"><asp:Button ID="btnTrangChu" runat="server" Text="Về Trang Chủ" Height="29px" PostBackUrl="~/Default.aspx" Width="116px" /> <asp:Button ID="btnDoiMatKhau" runat="server" Text="Đổi Mật Khẩu" OnClick="btnDoiMatKhau_Click" Height="29px" Width="116px" /></p>
                <asp:Label ID="lblTB" runat="server" ForeColor="Red"></asp:Label>
            </form>
        </div>
    </section>    
</body>
</html>
