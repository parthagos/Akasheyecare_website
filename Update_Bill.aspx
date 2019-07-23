<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Update_Bill.aspx.cs" Inherits="Update_Bill" Title="Update Bill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<h2>Update Patient Bill</h2>
    <asp:Panel ID="Panel1" runat="server" Height="258px" Width="465px">
    <table>
    <tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="Bill No."></asp:Label>
        </td>
        <td>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="152px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true">
        </asp:DropDownList>
        </td>
        </tr>
        <tr></tr>
        <tr>
        <td>
        <asp:Label ID="Label2" runat="server" Text="Registration No."></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
        <asp:RequiredFieldValidator ID="reg_valid" runat="server" ControlToValidate="TextBox1" ToolTip="Registration field can not be left blank">*</asp:RequiredFieldValidator>
        </td>
        </tr>
        <tr></tr>
        <tr>
        <td>
        <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
        <td>
        <asp:RequiredFieldValidator ID="name_valid" runat="server" ControlToValidate="TextBox2" ToolTip="Name field can not be left blank">*</asp:RequiredFieldValidator>
        </td>
        </tr>
        <tr></tr>
        <tr>
        <td>
        <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
        </td>
       <td>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
        <td>
        <asp:RequiredFieldValidator ID="address_valid" runat="server" ControlToValidate="TextBox3" ToolTip="Address field can not be left blank">*</asp:RequiredFieldValidator>
        </td>
        </tr>
        <tr></tr>
        <tr>
        <td>
        <asp:Label ID="Label5" runat="server" Text="Amount"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
        <td>
        <asp:RequiredFieldValidator ID="Amount_valid" runat="server" ControlToValidate="TextBox4" ToolTip="Amount field can not be left blank">*</asp:RequiredFieldValidator>
        </td>
        </tr>
        <tr></tr>
        </table>
        <table>
        <tr>
        <td>
        <asp:Button ID="Button1" runat="server" Text="Edit" Width="64px" OnClick="Button1_Click" />
        </td>
        <td>
        <asp:Button ID="Button2" runat="server" Text="Update" Width="71px" OnClick="Button2_Click" />
        </td>
        </tr>
        </table>
        </asp:Panel>

</center>
    <center>
<br />
        <asp:Label ID="Label6" runat="server" Height="61px" Width="470px"></asp:Label></center>
</asp:Content>

