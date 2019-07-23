<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Print_prescription.aspx.cs" Inherits="Print_prescription" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<h2>Print Prescription</h2>
    <asp:Panel ID="Panel1" runat="server" Height="246px" Width="449px">
    <table>
    <tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="Registration No:"></asp:Label>
    </td>
    <td style="width: 165px">
        <asp:DropDownList ID="DropDownList1" runat="server" Width="164px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true">
        </asp:DropDownList></td>
    </tr>
    <tr></tr>
    <tr><td>
        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label></td>
        <td style="width: 165px">
            <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Width="159px"></asp:TextBox></td>
        </tr>
        <tr></tr>
        <tr><td>
            <asp:Label ID="Label3" runat="server" Text="Age"></asp:Label></td>
            <td style="width: 165px">
                <asp:TextBox ID="TextBox2" runat="server" Enabled="False" Width="159px"></asp:TextBox></td></tr>
                <tr></tr>
                <tr><td>
                    <asp:Label ID="Label4" runat="server" Text="Sex"></asp:Label></td>
                   <td style="width: 165px"> <asp:TextBox ID="TextBox3" runat="server" Enabled="False" Width="159px"></asp:TextBox></td></tr>
                   <tr></tr>
                   <tr><td>
                       <asp:Label ID="Label5" runat="server" Text="Address"></asp:Label></td>
                       <td style="width: 165px">
                           <asp:TextBox ID="TextBox4" runat="server" Enabled="False" Width="157px"></asp:TextBox></td></tr>
                           <tr></tr>
                           <tr><td>
                               <asp:Label ID="Label6" runat="server" Text="Doctor Name"></asp:Label></td>
                               <td style="width: 165px">
                                   <asp:TextBox ID="TextBox5" runat="server" Enabled="False" Width="157px"></asp:TextBox></td></tr>
                                   <tr></tr>
    </table>
    <table><tr><td>
        <asp:Button ID="Button1" runat="server" Text="Print" OnClick="Button1_Click" /></td></tr></table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="123px" Width="449px">
        <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
    </asp:Panel>
</center>
</asp:Content>

