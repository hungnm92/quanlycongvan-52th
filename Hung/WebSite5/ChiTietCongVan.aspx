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
                        <asp:CommandField ButtonType="Button" SelectText="Chọn" ShowSelectButton="True" />
                        <asp:BoundField DataField="NguoiGui" HeaderText="Người gửi" />
                        <asp:BoundField DataField="TenCV" HeaderText="Tên Công văn" />
                        <asp:BoundField DataField="TrichYeu" HeaderText="Trích yếu" />
                        <asp:BoundField DataField="ThoiGianGui" HeaderText="Thời gian gửi" />
                        <asp:BoundField DataField="ThoiGianDoc" HeaderText="Thời gian đọc" />
                        <asp:TemplateField HeaderText="File">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbtnTaiVe" runat="server" CommandArgument='<%# Eval("TenFile") %>' CommandName="Download" Text='<%# Eval("TenFile") %>'>LinkButton</asp:LinkButton>
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
                            <asp:BoundField DataField="NguoiGui" HeaderText="Người gửi" />
                            <asp:BoundField DataField="NguoiNhan" HeaderText="Người nhận" />
                            <asp:BoundField DataField="TenTT" HeaderText="Tên tình trạng" />
                            <asp:BoundField DataField="ThoiGianSoan" HeaderText="Thời gian soạn" />
                            <asp:BoundField DataField="ThoiGianGui" HeaderText="Thời gian gửi" />
                            <asp:BoundField DataField="ThoiGianDoc" HeaderText="Thời gian đọc" />
                            <asp:BoundField DataField="ThoiGianDuyet" HeaderText="Thời gian duyệt" />
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

