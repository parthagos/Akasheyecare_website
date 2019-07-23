<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="extra_charged.aspx.cs" Inherits="extra_charged" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<h2>Extra Charged Bill</h2><br />
    <asp:Panel ID="Panel1" runat="server" Height="246px" Width="470px">
    <table>
    <tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="Type 1" Font-Bold="True"></asp:Label></td>
     <td><asp:DropDownList ID="DropDownList1" runat="server" Width="182px"></asp:DropDownList></td>
     <td>
         <asp:TextBox ID="TextBox1" runat="server" Width="47px" Enabled="False"></asp:TextBox></td>
    </tr>
    <tr></tr>
    <tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Type 2" Visible="False" Font-Bold="True"></asp:Label></td>
    <td>
        <asp:DropDownList ID="DropDownList2" runat="server" Width="182px" Visible="False"></asp:DropDownList></td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" Width="47px" Enabled="False" Visible="False"></asp:TextBox></td>
    </tr>
    <tr></tr>
    <tr>
    <td>
        <asp:Label ID="Label3" runat="server" Text="Type 3" Visible="False" Font-Bold="True"></asp:Label></td>
    <td>
        <asp:DropDownList ID="DropDownList3" runat="server" Width="182px" Visible="False"></asp:DropDownList></td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server" Width="47px" Enabled="False" Visible="False"></asp:TextBox></td>
    </tr>
    <tr></tr>
    <tr>
    <td>
        <asp:Label ID="Label4" runat="server" Text="Type 4" Visible="False" Font-Bold="True"></asp:Label></td>
    <td>
        <asp:DropDownList ID="DropDownList4" runat="server" Width="182px" Visible="False"></asp:DropDownList></td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server" Width="47px" Visible="False"></asp:TextBox></td>
    </tr>
    <tr></tr>
    </table>
    
    </asp:Panel>
</center>
</asp:Content>

