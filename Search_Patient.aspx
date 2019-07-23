<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search_Patient.aspx.cs" Inherits="Search_Patient" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center><h2>Search Patients</h2>
<table>
<tr>
    <td><asp:Label ID="Label1" runat="server" Text="Name"></asp:Label></td>
    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
    <td><asp:RequiredFieldValidator ID="name_valid" runat="server" ControlToValidate="TextBox1" ToolTip="Name can not be left blank">*</asp:RequiredFieldValidator></td>
    <td><asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" /></td>
    </tr>
    </table>
    <table><tr><td><asp:GridView ID="GridView1" runat="server"></asp:GridView></td></tr></table>
</center>
</asp:Content>

