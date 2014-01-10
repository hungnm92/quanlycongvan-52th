<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChuaDoc.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%; color: #000000;">
        <tr>
            <td style="font-weight: 700; font-size: 20px; text-align: center; color: #FFFFFF; background-image: none;">
                <asp:GridView ID="griChuaDoc" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="False" OnSelectedIndexChanged="griChuaDoc_SelectedIndexChanged" DataKeyNames="So" AllowPaging="True" OnPageIndexChanging="griChuaDoc_PageIndexChanging" OnRowCommand ="griChuaDoc_RowCommand">
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
                        <asp:BoundField DataField="ThoiGianSoan" HeaderText="Th&#7901;i gian so&#7841;n" />
                        <asp:BoundField DataField="ThoiGianGui" HeaderText="Th&#7901;i gian g&#7917;i" />
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
                                <table style="width:100%; height: 56px;">
                                    <tr>
                                        <td class="auto-style64" style="white-space: nowrap">G&#7917;i t&#7899;i:&nbsp; </td>
                                        <td class="auto-style81">
                                            <asp:DropDownList ID="droUserN" runat="server" DataTextField="TenUser" DataValueField="Ma" ForeColor="Black" Height="30px" Width="715px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style4" rowspan="5" style="vertical-align: top">
                                            <table style="width: 100%; height: 224px;">
                                                <tr>
                                                    <td class="auto-style96" style="text-align: right">Mã Công v&#259;n: </td>
                                                    <td class="auto-style97">
                                                        <asp:TextBox ID="txtMaCV" runat="server" Height="24px" Width="156px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style96" style="text-align: right">S&#7889; Công v&#259;n</td>
                                                    <td class="auto-style97">
                                                        <asp:TextBox ID="txtSoCV" runat="server" Height="24px" style="margin-left: 0px" Width="156px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style95" style="text-align: right">Lo&#7841;i Công v&#259;n: </td>
                                                    <td class="auto-style95">
                                                        <asp:DropDownList ID="droLCV" runat="server" DataTextField="TenLCV" DataValueField="Ma" Height="26px" Width="160px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style95" style="text-align: right; white-space: nowrap;">Ngày phát hành</td>
                                                    <td class="auto-style95">
                                                        <asp:TextBox ID="txtNgayPH" runat="server" Height="24px" style="margin-left: 0px" Width="156px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style93" style="text-align: right; color: #000000;">Thêm t&#7879;p m&#7899;i: </td>
                                                    <td class="auto-style94">
                                                        <asp:FileUpload ID="fileTep" runat="server" Width="160px" Height="28px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style103" style="text-align: right; vertical-align: top;">T&#7843;i v&#7873;: </td>
                                                    <td class="auto-style103" style="vertical-align: top">
                                                        <asp:LinkButton ID="lnkbtnTaiVe" runat="server" OnClick="lnkbtnTaiVe_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style64" style="white-space: nowrap">
                                            <asp:Label ID="Label3" runat="server" Text="Tiêu &#273;&#7873;"></asp:Label>
                                            : </td>
                                        <td class="auto-style81">
                                            <asp:TextBox ID="txtTenCV" runat="server" Height="37px" TextMode="MultiLine" Width="715px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99" style="white-space: nowrap;">
                                            <asp:Label ID="Label5" runat="server" Text="Tóm t&#7855;t"></asp:Label>
                                            : </td>
                                        <td class="auto-style100" style="height: 19px; vertical-align: top;">
                                            <asp:TextBox ID="txtTomTat" runat="server" Height="140px" TextMode="MultiLine" Width="715px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99" style="height: 19px; white-space: nowrap;">&nbsp;</td>
                                        <td class="auto-style100" style="height: 19px; vertical-align: top;">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99" style="height: 19px">&nbsp;</td>
                                        <td class="auto-style100" style="height: 19px; vertical-align: top;">
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
                                            <asp:Button ID="btnTraLoi" runat="server" Font-Bold="True" Height="32px" OnClick="btnTraLoi_Click" Text="Tr&#7843; l&#7901;i" Width="100px" />
                                            <asp:Button ID="btnLuuDuThao" runat="server" Font-Bold="True" Height="32px" Text="L&#432;u d&#7921; th&#7843;o" Width="100px" OnClick="btnLuuDuThao_Click" Visible="False" />
                                            <asp:Button ID="btnThoat" runat="server" Font-Bold="True" Height="32px" Text="Thoát" Width="100px" OnClick="btnThoat_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

