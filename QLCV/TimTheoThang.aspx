<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TimTheoThang.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td style="font-weight: 700; font-size: 20px; text-align: center; color: #FFFFFF; background-image: none;">
                <table style="width:100%; color: #000000;">
        <tr>
            <td style="font-weight: 700; font-size: 20px; text-align: center; color: #FFFFFF; background-image: none;">
                <asp:GridView ID="griTimTheoThang" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="False" DataKeyNames="So" OnSelectedIndexChanged="griCongVanDi_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="griCongVanDi_PageIndexChanging" OnRowCommand ="griCongVanDi_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" SelectText="Ch&#7885;n" ShowSelectButton="True" />
                        <asp:BoundField DataField="NguoiGui" HeaderText="Ng&#432;&#7901;i g&#7917;i" />
                        <asp:BoundField DataField="NguoiNhan" HeaderText="Ng&#432;&#7901;i nh&#7853;n" />
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
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style7" style="vertical-align: top; color: #000000; font-size: medium; font-weight: normal;">
                                <table style="border: thin outset #0099FF; width:100%; height: 56px;">
                                    <tr>
                                        <td class="auto-style64" style="width: 10%;">Ng&#432;&#7901;i nh&#7853;n:&nbsp; </td>
                                        <td class="auto-style81" style="width: 90%">
                                            <asp:DropDownList ID="droUserN" runat="server" DataTextField="TenUser" DataValueField="Ma" Height="30px" Width="90%" ForeColor="Black">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style64" style="width: 10%;">
                                            <asp:Label ID="Label3" runat="server" Text="Tiêu &#273;&#7873;"></asp:Label>
                                            : </td>
                                        <td class="auto-style81" style="width: 90%">
                                            <asp:TextBox ID="txtTenCV" runat="server" Height="37px" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99" style="width: 10%;">
                                            <asp:Label ID="Label5" runat="server" Text="N&#7897;i dung"></asp:Label>
                                            : </td>
                                        <td class="auto-style100" style="width: 90%;">
                                            <asp:TextBox ID="txtTomTat" runat="server" Height="140px" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99" style="width: 10%;">&nbsp;T&#7843;i v&#7873;: </td>
                                        <td class="auto-style100" style="width: 90%;">
                                            <asp:LinkButton ID="lnkbtnTaiVe" runat="server" OnClick="lnkbtnTaiVe_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99" style="width: 10%;">&nbsp;</td>
                                        <td class="auto-style100" style="width: 90%;">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="text-align: center">
                                            <asp:Button ID="btnThoat" runat="server" Font-Bold="True" Height="32px" Text="Thoát" Width="100px" OnClick="btnThoat_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

