﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="btnLayCV" runat="server" Text="Button" OnClick="btnLayCV_Click" />
        <asp:GridView ID="griCongVan" runat="server"></asp:GridView>

        <asp:Label ID="lblMenu" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
