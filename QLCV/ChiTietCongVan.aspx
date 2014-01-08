<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChiTietCongVan.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td style="font-weight: 700; font-size: 20px; text-align: center; color: #FFFFFF; background-image: none;">
                <table style="width:100%; color: #000000;">
        <tr>
            <td style="font-weight: 700; font-size: 20px; text-align: center; color: #FFFFFF; background-image: none;">
                <asp:GridView ID="griCV_Me_DS" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="False" DataKeyNames="So" OnSelectedIndexChanged="griCV_Me_DS_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="griCV_Me_DS_PageIndexChanging" OnRowCommand="griCV_Me_DS_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" SelectText="Ch&#7885;n" ShowSelectButton="True" />
                        <asp:BoundField DataField="NguoiGui" HeaderText="Ng&#432;&#7901;i g&#7917;i" />
                        <asp:TemplateField HeaderText="Tên Công v&#259;n">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenCV").ToString().Length > 20 ? Eval("TenCV").ToString().Substring(0,20) +"..." : Eval("TenCV") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trích y&#7871;u">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TrichYeu").ToString().Length > 20 ? Eval("TrichYeu").ToString().Substring(0,20) +"..." : Eval("TrichYeu") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ThoiGianGui" HeaderText="Th&#7901;i gian g&#7917;i" />
                        <asp:BoundField DataField="ThoiGianDoc" HeaderText="Th&#7901;i gian &#273;&#7885;c" />
                        <asp:TemplateField HeaderText="File">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbtnTaiVe" runat="server" CommandArgument='<%# Eval("TenFile") %>' CommandName="Download" Text='<%# Eval("TenFile").ToString().Length > 21 ? Eval("TenFile").ToString().Substring(17,5) +"..." : Eval("TenFile") %>'>LinkButton</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <br />
                <br />
                <asp:Panel ID="pnlChiTiet" runat="server">
                    <asp:GridView ID="griChiTiet" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" Font-Bold="False" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="NguoiGui" HeaderText="Ng&#432;&#7901;i g&#7917;i" />
                            <asp:BoundField DataField="NguoiNhan" HeaderText="Ng&#432;&#7901;i nh&#7853;n" />
                            <asp:BoundField DataField="TenTT" HeaderText="Tên tình tr&#7841;ng" />
                            <asp:BoundField DataField="ThoiGianSoan" HeaderText="Th&#7901;i gian so&#7841;n" />
                            <asp:BoundField DataField="ThoiGianGui" HeaderText="Th&#7901;i gian g&#7917;i" />
                            <asp:BoundField DataField="ThoiGianDoc" HeaderText="Th&#7901;i gian &#273;&#7885;c" />
                            <asp:BoundField DataField="ThoiGianDuyet" HeaderText="Th&#7901;i gian duy&#7879;t" />
                            <asp:BoundField DataField="NgayPH" HeaderText="Ngày phát hành" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <br />
                    <asp:Button ID="btnThoat" runat="server" OnClick="btnThoat_Click" Text="Thoát" />
                </asp:Panel>
            </td>
        </tr>
    </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

