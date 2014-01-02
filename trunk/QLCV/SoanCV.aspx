<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SoanCV.aspx.cs" Inherits="SoanCV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;" __designer:mapid="56">
        <tr __designer:mapid="57">
            <td class="auto-style7" colspan="3" style="vertical-align: top" __designer:mapid="58">
                <table style="width:100%; height: 56px;" __designer:mapid="59">
                    <tr __designer:mapid="5a">
                        <td class="auto-style64" __designer:mapid="5b" style="white-space: nowrap">
                            Người nhận:&nbsp;(*) </td>
                        <td class="auto-style81" __designer:mapid="5d">
                                        <asp:DropDownList ID="droUserN" runat="server" DataTextField="TenUser" DataValueField="Ma" Height="30px" Width="715px">
                                        </asp:DropDownList>
                                    </td>
                        <td class="auto-style4" rowspan="5" style="vertical-align: top" __designer:mapid="5f">
                            <table style="width: 100%; height: 224px;" __designer:mapid="60">
                                <tr __designer:mapid="61">
                                    <td class="auto-style96" style="text-align: right" __designer:mapid="62">Mã Công văn:
                                                            </td>
                                    <td class="auto-style97" __designer:mapid="63">
                                        <asp:TextBox ID="txtMaCV" runat="server" Height="24px" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr __designer:mapid="61">
                                    <td class="auto-style96" style="text-align: right" __designer:mapid="62">Số Công văn</td>
                                    <td class="auto-style97" __designer:mapid="63">
                                        <asp:TextBox ID="txtSoCV" runat="server" Height="24px" style="margin-left: 0px" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr __designer:mapid="65">
                                    <td class="auto-style95" style="text-align: right" __designer:mapid="66">Loại Công văn:
                                                            </td>
                                    <td class="auto-style95" __designer:mapid="67">
                                        <asp:DropDownList ID="droLCV" runat="server" DataTextField="TenLCV" DataValueField="Ma">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr __designer:mapid="65">
                                    <td class="auto-style95" style="text-align: right; white-space: nowrap;" __designer:mapid="66">Ngày phát hành</td>
                                    <td class="auto-style95" __designer:mapid="67">
                                        <asp:TextBox ID="txtNgayPH" runat="server" Height="24px" style="margin-left: 0px" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr __designer:mapid="69">
                                    <td class="auto-style93" style="text-align: right; white-space: nowrap;" __designer:mapid="6a">Tệp đính kèm:(*)
                                                            </td>
                                    <td class="auto-style94" __designer:mapid="6b">
                                        <asp:FileUpload ID="fileTep" runat="server" Width="247px" Height="21px" />
                                    </td>
                                </tr>
                                <tr __designer:mapid="6d">
                                    <td class="auto-style103" style="text-align: right; vertical-align: top;" __designer:mapid="6e">&nbsp;</td>
                                    <td class="auto-style103" style="vertical-align: top" __designer:mapid="6f">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr __designer:mapid="5a">
                        <td class="auto-style64" __designer:mapid="5b" style="white-space: nowrap">
                            <asp:Label ID="Label3" runat="server" Text="Tiêu đề"></asp:Label>
                                                    :
                                                (*)</td>
                        <td class="auto-style81" __designer:mapid="5d">
                            <asp:TextBox ID="txtTenCV" runat="server" Height="37px" TextMode="MultiLine" Width="715px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="70">
                        <td class="auto-style99" style="white-space: nowrap;" __designer:mapid="71">
                            <asp:Label ID="Label4" runat="server" Text="Tóm tắt"></asp:Label>
                                                    :
                                                (*)</td>
                        <td class="auto-style100" style="height: 19px; vertical-align: top;" __designer:mapid="73">
                            <asp:TextBox ID="txtTomTat" runat="server" Height="140px" TextMode="MultiLine" Width="715px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="70">
                        <td class="auto-style99" style="height: 19px; white-space: nowrap;" __designer:mapid="71">
                            Chỉ đạo: </td>
                        <td class="auto-style100" style="height: 19px; vertical-align: top;" __designer:mapid="73">
                            <asp:TextBox ID="txtChiDao" runat="server" Height="37px" TextMode="MultiLine" Width="715px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="70">
                        <td class="auto-style99" style="height: 19px" __designer:mapid="71">
                            Góp ý: </td>
                        <td class="auto-style100" style="height: 19px; vertical-align: top;" __designer:mapid="73">
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
                            <asp:Button ID="btnTrinhDuyet" runat="server" Font-Bold="True" Height="32px" Text="Trình duyệt" Width="100px" OnClick="btnTrinhDuyet_Click" />
                            <asp:Button ID="btnThoat" runat="server" Font-Bold="True" Height="32px" Text="Thoát" Width="100px" OnClick="btnThoat_Click" />
                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>
       
    </table>
</asp:Content>

