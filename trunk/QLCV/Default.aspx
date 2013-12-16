<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td style="font-weight: 700; font-size: 20px; text-align: center; color: #FFFFFF; background-image: none;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:CommandField EditText="Chọn" HeaderText="Chọn" ShowSelectButton="True">
                        <ControlStyle Font-Underline="False" />
                        </asp:CommandField>
                        <asp:BoundField HeaderText="Người gửi" />
                        <asp:BoundField HeaderText="Tiêu đề" />
                        <asp:BoundField HeaderText="Trích yếu" />
                        <asp:BoundField HeaderText="Ngày gửi" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

