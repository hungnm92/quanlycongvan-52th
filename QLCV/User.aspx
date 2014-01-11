<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style2 {
            text-align: center;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style3 {
            height: 10%;
        }
        .auto-style3 {
            text-align: right;
            width: 207px;
            height: 23px;
        }
        .auto-style4 {
            text-align: right;
            height: 25px;
        }
        .auto-style5 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ToolkitScriptManager>
    <table style="width:100%;">
        <tr>
            <td style="font-weight: 700; font-size: 20px; text-align: center; color: #FFFFFF; background-image: none;">
                <table style="width:100%; color: #000000;">
        <tr>
            <td style="font-weight: 700; font-size: 20px; text-align: center; color: #FFFFFF; background-image: none;">
        <asp:GridView ID="griNhanVien" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Ma_User" OnSelectedIndexChanged="griNhanVien_SelectedIndexChanged" Width="100%">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField HeaderText="Tùy ch&#7885;n" SelectText="Ch&#7885;n" ShowSelectButton="True" ButtonType="Button">
                <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:CommandField>
                <asp:BoundField DataField="Ma_User" HeaderText="Mã User " />
                <asp:BoundField DataField="Ma" HeaderText="Mã S&#7889;">
                <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="HoTenNV" HeaderText="H&#7885; và Tên">
                <FooterStyle Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" Width="1%" />
                </asp:BoundField>
                <asp:BoundField DataField="TenUser" HeaderText="Email">
                <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="15%" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" Width="1%" />
                </asp:BoundField>
                <asp:BoundField DataField="DiaChi" HeaderText="&#272;&#7883;a ch&#7881;" />
                <asp:BoundField DataField="DienThoai" HeaderText="S&#7889; &#272;i&#7879;n Tho&#7841;i">
                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="&#7842;nh">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("AnhNV") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("AnhNV", "~/src/img/User/{0}") %>' Width="50px" />
                    </ItemTemplate>
                    <HeaderStyle Width="1%" Wrap="False" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:TemplateField>
                <asp:BoundField DataField="TenPB" HeaderText="Phòng Ban">
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
                <br />
        <asp:LinkButton ID="lbtThemMoi" runat="server" Font-Bold="True" BorderColor="#3333FF" Font-Overline="False" Font-Underline="True" OnClick="lbtThemMoi_Click" Visible="False">Thêm M&#7899;i</asp:LinkButton>
                <br />
        <asp:Panel ID="pnlCapNhat" runat="server" BorderColor="#FF6600" BorderStyle="Double" Visible="False" style="margin-left: 112px" Width="80%">
            <table style="width:100%;">
                <tr>
                    <td colspan="2" style="background-color: #0000FF; color: #FFFF00;">C&#7852;P NH&#7852;T D&#7918; LI&#7878;U:</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #6699FF">Mã s&#7889; :</td>
                    <td style="background-color: #99CCFF">
                        <asp:TextBox ID="txtMa" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #6699FF">H&#7885; nhân viên:</td>
                    <td style="background-color: #99CCFF">
                        &nbsp;
                        <asp:TextBox ID="txtHo" runat="server"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #6699FF">Tên nhân viên:</td>
                    <td style="background-color: #99CCFF">
                        <asp:TextBox ID="txtTenNV" runat="server"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #6699FF">Ngày sinh:</td>
                    <td style="background-color: #99CCFF">
                        <asp:TextBox ID="txtNgaySinh" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtNgaySinh" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                        *</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #6699FF">IsUser:</td>
                    <td style="background-color: #99CCFF">
                        <asp:CheckBox ID="chkIsUser" runat="server" ForeColor="Black" Text="Nhóm" Font-Bold="False" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #6699FF">Email:</td>
                    <td style="background-color: #99CCFF">
                        <asp:TextBox ID="txtTenUser" runat="server"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #6699FF">&#272;&#7883;a ch&#7881;:</td>
                    <td style="background-color: #99CCFF">
                        <asp:TextBox ID="txtDiaChi" runat="server"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #6699FF">&#272;i&#7879;n tho&#7841;i:</td>
                    <td style="background-color: #99CCFF">
                        <asp:TextBox ID="txtDienThoai" runat="server"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #6699FF">&#7842;nh:</td>
                    <td style="background-color: #99CCFF">
                        <asp:FileUpload ID="fileAnhNV" runat="server" />
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td class="auto-style4" style="background-color: #6699FF">Phòng ban:</td>
                    <td style="background-color: #99CCFF" class="auto-style5">
                        <asp:DropDownList ID="droPhongBan" runat="server" DataTextField="TenPB" DataValueField="Ma">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #6699FF">Nhóm User :</td>
                    <td style="background-color: #99CCFF">
                        <asp:DropDownList ID="droNhomUser" runat="server" DataTextField="TenNhom" DataValueField="Ma">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="background-color: #6699FF">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #99CCFF">
                        <asp:Button ID="btnThem" runat="server" BackColor="Yellow" Text="Thêm" Width="14%" OnClick="btnThem_Click" Visible="False" />
                        &nbsp;
                        <asp:Button ID="btnXoa" runat="server" BackColor="Yellow" Text="Xóa" Width="14%" OnClick="btnXoa_Click" Visible="False" />
                        &nbsp;
                        <asp:Button ID="btnSua" runat="server" BackColor="Yellow" Text="S&#7917;a" Width="14%" OnClick="btnSua_Click" Visible="False" />
                        &nbsp;
                        <asp:Button ID="btnThoat" runat="server" BackColor="Yellow" Text="Thoát" Width="14%" OnClick="btnThoat_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
                <br />
                        <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." style="text-align: center" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="lblTBU" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." style="text-align: center" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="lblTBNU" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." style="text-align: center" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

