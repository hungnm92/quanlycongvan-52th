<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChiTietCV.aspx.cs" Inherits="ChiTietCV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style7 {
            text-align: center;
            height: 417px;
        }
        .auto-style8 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;" __designer:mapid="56">
        <tr __designer:mapid="57">
            <td class="auto-style7" colspan="3" style="vertical-align: top" __designer:mapid="58">
                <table style="width:100%; height: 56px;" __designer:mapid="59">
                    <tr __designer:mapid="5a">
                        <td class="auto-style64" __designer:mapid="5b">
                            <asp:Label ID="Label3" runat="server" Text="Tiêu đề"></asp:Label>
                                                    :
                                                </td>
                        <td class="auto-style81" __designer:mapid="5d">
                            <asp:TextBox ID="txtTieuDe" runat="server" Height="37px" TextMode="MultiLine" Width="429px"></asp:TextBox>
                        </td>
                        <td class="auto-style4" rowspan="4" style="vertical-align: top" __designer:mapid="5f">
                            <table style="width: 100%; height: 224px;" __designer:mapid="60">
                                <tr __designer:mapid="61">
                                    <td class="auto-style96" style="text-align: right" __designer:mapid="62">Mã Công văn:
                                                            </td>
                                    <td class="auto-style97" __designer:mapid="63">
                                        <asp:TextBox ID="txtMaTT" runat="server" Height="24px" Width="156px" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr __designer:mapid="61">
                                    <td class="auto-style96" style="text-align: right" __designer:mapid="62">Số Công văn</td>
                                    <td class="auto-style97" __designer:mapid="63">
                                        <asp:TextBox ID="TextBox2" runat="server" Height="24px" style="margin-left: 0px" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr __designer:mapid="65">
                                    <td class="auto-style95" style="text-align: right" __designer:mapid="66">Loại Công văn:
                                                            </td>
                                    <td class="auto-style95" __designer:mapid="67">
                                        <asp:DropDownList ID="droNhomTin" runat="server" Height="24px" Width="156px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr __designer:mapid="65">
                                    <td class="auto-style95" style="text-align: right" __designer:mapid="66">Ngày phát hành</td>
                                    <td class="auto-style95" __designer:mapid="67">
                                        <asp:TextBox ID="TextBox3" runat="server" Height="24px" style="margin-left: 0px" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr __designer:mapid="69">
                                    <td class="auto-style93" style="text-align: right" __designer:mapid="6a">Tệp đính kèm:
                                                            </td>
                                    <td class="auto-style94" __designer:mapid="6b">
                                        <asp:FileUpload ID="fileAnhTT" runat="server" Width="247px" Height="21px" />
                                    </td>
                                </tr>
                                <tr __designer:mapid="6d">
                                    <td class="auto-style103" style="text-align: right; vertical-align: top;" __designer:mapid="6e">&nbsp;</td>
                                    <td class="auto-style103" style="vertical-align: top" __designer:mapid="6f">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr __designer:mapid="70">
                        <td class="auto-style99" style="height: 19px" __designer:mapid="71">
                            <asp:Label ID="Label4" runat="server" Text="Tóm tắt"></asp:Label>
                                                    :
                                                </td>
                        <td class="auto-style100" style="height: 19px; vertical-align: top;" __designer:mapid="73">
                            <asp:TextBox ID="txtTomTat" runat="server" Height="140px" TextMode="MultiLine" Width="429px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="70">
                        <td class="auto-style99" style="height: 19px" __designer:mapid="71">
                            Ý kiến chỉ đạo&nbsp;</td>
                        <td class="auto-style100" style="height: 19px; vertical-align: top;" __designer:mapid="73">
                            <asp:TextBox ID="txtTieuDe0" runat="server" Height="37px" TextMode="MultiLine" Width="429px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="70">
                        <td class="auto-style99" style="height: 19px" __designer:mapid="71">
                            Góp ý</td>
                        <td class="auto-style100" style="height: 19px; vertical-align: top;" __designer:mapid="73">
                            <asp:TextBox ID="txtTieuDe1" runat="server" Height="37px" TextMode="MultiLine" Width="429px"></asp:TextBox>
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
                        <td colspan="3">
                            <asp:Button ID="Button1" runat="server" Font-Bold="True" Height="32px" Text="Trình duyệt" Width="100px" />
                            <asp:Button ID="Button2" runat="server" Font-Bold="True" Height="32px" Text="Duyệt" Width="100px" />
                            <asp:Button ID="Button3" runat="server" Font-Bold="True" Height="32px" Text="Không duyệt" Width="100px" />
                            <asp:Button ID="Button4" runat="server" Font-Bold="True" Height="32px" Text="Để sau" Width="100px" />
                            <asp:Button ID="Button5" runat="server" Font-Bold="True" Height="32px" Text="Phát hành" Width="100px" />
                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>
       
    </table>
</asp:Content>

