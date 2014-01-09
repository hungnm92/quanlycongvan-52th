<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SoanCV.aspx.cs" Inherits="SoanCV" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <table style="width:100%;" >
        <tr >
            <td class="auto-style7" colspan="3" style="vertical-align: top" >
                <table style="width:100%; height: 56px;" >
                    <tr >
                        <td class="auto-style64" style="white-space: nowrap">
                            Người nhận:&nbsp;(*) </td>
                        <td class="auto-style81" >
                            <asp:TextBox ID="txtNguoiNhan" runat="server" TextMode="MultiLine" Width="656px"></asp:TextBox><asp:Button ID="btnXong" runat="server" Text="Chọn" OnClick="btnXong_Click" />
                            <asp:Panel ID="pnlNguoiNhan" runat="server">
                                <asp:CheckBoxList ID="cblUser" runat="server" DataTextField="TenUser" DataValueField="Ma"></asp:CheckBoxList>
                            </asp:Panel>
                            <asp:PopupControlExtender ID="PopupControlExtender1" runat="server" TargetControlID="txtNGuoiNhan" PopupControlID="pnlNguoiNhan" Position="Bottom"></asp:PopupControlExtender>                           
                                    </td>
                        <td class="auto-style4" rowspan="5" style="vertical-align: top" >
                            <table style="width: 100%; height: 224px;" >
                                <tr >
                                    <td class="auto-style96" style="text-align: right">Số Công văn:
                                                            </td>
                                    <td class="auto-style97" >
                                        <asp:TextBox ID="txtMaCV" runat="server" Height="24px" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr >
                                    <td class="auto-style96" style="text-align: right" >Mã Công văn</td>
                                    <td class="auto-style97">
                                        <asp:TextBox ID="txtSoCV" runat="server" Height="24px" style="margin-left: 0px" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr >
                                    <td class="auto-style95" style="text-align: right" >Loại Công văn:
                                                            </td>
                                    <td class="auto-style95" >
                                        <asp:DropDownList ID="droLCV" runat="server" DataTextField="TenLCV" DataValueField="Ma" Height="26px" Width="160px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr >
                                    <td class="auto-style95" style="text-align: right; white-space: nowrap;" >Ngày phát hành</td>
                                    <td class="auto-style95" >
                                        <asp:TextBox ID="txtNgayPH" runat="server" Height="24px" style="margin-left: 0px" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr >
                                    <td class="auto-style93" style="text-align: right; white-space: nowrap;" >Tệp đính kèm:(*)
                                                            </td>
                                    <td class="auto-style94" >
                                        <asp:FileUpload ID="fileTep" runat="server" Width="160px" Height="28px" />
                                    </td>
                                </tr>
                                <tr >
                                    <td class="auto-style103" style="text-align: right; vertical-align: top;" >&nbsp;</td>
                                    <td class="auto-style103" style="vertical-align: top" >&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr >
                        <td class="auto-style64" style="white-space: nowrap">
                            <asp:Label ID="Label3" runat="server" Text="Tiêu đề"></asp:Label>
                                                    :
                                                (*)</td>
                        <td class="auto-style81">
                            <asp:TextBox ID="txtTenCV" runat="server" Height="37px" TextMode="MultiLine" Width="715px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                        <td class="auto-style99" style="white-space: nowrap;">
                            Nội dung:
                                                (*)</td>
                        <td class="auto-style100" style="height: 19px; vertical-align: top;" >
                            <asp:TextBox ID="txtTomTat" runat="server" Height="140px" TextMode="MultiLine" Width="715px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                        <td class="auto-style99" style="height: 19px; white-space: nowrap;" >
                            Chỉ đạo: </td>
                        <td class="auto-style100" style="height: 19px; vertical-align: top;" >
                            <asp:TextBox ID="txtChiDao" runat="server" Height="37px" TextMode="MultiLine" Width="715px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                        <td class="auto-style99" style="height: 19px" >
                            Góp ý: </td>
                        <td class="auto-style100" style="height: 19px; vertical-align: top;" >
                            <asp:TextBox ID="txtGopY" runat="server" Height="37px" TextMode="MultiLine" Width="715px" ReadOnly="True"></asp:TextBox>
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
                            <asp:Button ID="btnGui" runat="server" Font-Bold="True" Height="32px" Text="Gửi" Width="100px" OnClick="btnGui_Click" />
                            <asp:Button ID="btnTrinhDuyet" runat="server" Font-Bold="True" Height="32px" Text="Trình duyệt" Width="100px" OnClick="btnTrinhDuyet_Click" Visible="False" />
                            <asp:Button ID="btnThoat" runat="server" Font-Bold="True" Height="32px" Text="Thoát" Width="100px" OnClick="btnThoat_Click" />
                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>
       
    </table>
</asp:Content>

