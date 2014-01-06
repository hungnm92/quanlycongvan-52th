<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HopThuDen.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td style="font-weight: 700; font-size: 20px; text-align: center; color: #FFFFFF; background-image: none;">
                <table style="width:100%; color: #000000;">
        <tr>
            <td style="font-weight: 700; font-size: 20px; text-align: center; color: #FFFFFF; background-image: none;">
                <asp:GridView ID="griCongVanDen" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="False" DataKeyNames="So" OnSelectedIndexChanged="griCongVanDen_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="griCongVanDen_PageIndexChanging" OnRowCommand="griCongVanDen_RowCommand">
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
                <asp:Panel ID="pnlChiTiet" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style7" style="vertical-align: top; color: #000000;">
                                <table style="width:100%; height: 56px;">
                                    <tr>
                                        <td class="auto-style64" style="white-space: nowrap">Gửi tới:&nbsp; </td>
                                        <td class="auto-style81">
                                            <asp:DropDownList ID="droUserN" runat="server" DataTextField="TenUser" DataValueField="Ma" ForeColor="Black" Height="30px" Width="715px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style4" rowspan="5" style="vertical-align: top">
                                            <table style="width: 100%; height: 224px;">
                                                <tr>
                                                    <td class="auto-style96" style="text-align: right">Mã Công văn: </td>
                                                    <td class="auto-style97">
                                                        <asp:TextBox ID="txtMaCV" runat="server" Height="24px" Width="156px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style96" style="text-align: right">Số Công văn</td>
                                                    <td class="auto-style97">
                                                        <asp:TextBox ID="txtSoCV" runat="server" Height="24px" style="margin-left: 0px" Width="156px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style95" style="text-align: right">Loại Công văn: </td>
                                                    <td class="auto-style95">
                                                        <asp:DropDownList ID="droLCV" runat="server" DataTextField="TenLCV" DataValueField="Ma">
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
                                                    <td class="auto-style93" style="text-align: right; color: #000000;">Tệp đính kèm: </td>
                                                    <td class="auto-style94">
                                                        <asp:FileUpload ID="fileTep" runat="server" Width="247px" Height="21px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style103" style="text-align: right; vertical-align: top;">&nbsp;</td>
                                                    <td class="auto-style103" style="vertical-align: top">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style64" style="white-space: nowrap">
                                            <asp:Label ID="Label3" runat="server" Text="Tiêu đề"></asp:Label>
                                            : </td>
                                        <td class="auto-style81">
                                            <asp:TextBox ID="txtTenCV" runat="server" Height="37px" TextMode="MultiLine" Width="715px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99" style="white-space: nowrap;">
                                            <asp:Label ID="Label5" runat="server" Text="Tóm tắt"></asp:Label>
                                            : </td>
                                        <td class="auto-style100" style="height: 19px; vertical-align: top;">
                                            <asp:TextBox ID="txtTomTat" runat="server" Height="140px" TextMode="MultiLine" Width="715px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99" style="height: 19px; white-space: nowrap;">Chỉ đạo: </td>
                                        <td class="auto-style100" style="height: 19px; vertical-align: top;">
                                            <asp:TextBox ID="txtChiDao" runat="server" Height="37px" TextMode="MultiLine" Width="715px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99" style="height: 19px">Góp ý: </td>
                                        <td class="auto-style100" style="height: 19px; vertical-align: top;">
                                            <asp:TextBox ID="txtGopY" runat="server" Height="37px" TextMode="MultiLine" Width="715px"></asp:TextBox>
                                        </td>
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
                                            <asp:Button ID="btnTraLoi" runat="server" Font-Bold="True" Height="32px" Text="Trả lời" Width="100px" OnClick="btnTraLoi_Click" />
                                            <asp:Button ID="btnLuuDuThao" runat="server" Font-Bold="True" Height="32px" OnClick="btnLuuDuThao_Click" Text="Lưu dự thảo" Visible="False" Width="100px" />
                                            <asp:Button ID="btnThoat" runat="server" Font-Bold="True" Height="32px" OnClick="btnThoat_Click" Text="Thoát" Width="100px" />
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

