<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search_Bill.aspx.cs" Inherits="Search_Bill" Title="Search Bill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center>
<h2>Patient Bill By Name</h2><br />
<asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
<table>
<tr>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:RequiredFieldValidator ID="search_required" ControlToValidate="TextBox1" runat ="server" ToolTip="This field can not be left blank">*</asp:RequiredFieldValidator>
    </td>
    <td>
    <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
    </td>
    </tr>
    <tr></tr>
    </table>
    <table>
    <tr>
    <td>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>    
    </td>
    </tr>
    </table>
    </center>
</asp:Content>

