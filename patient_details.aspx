<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="patient_details.aspx.cs" Inherits="patient_details" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<h2>Patient Registration Details</h2>
<asp:Panel ID="Panel1" runat="server" Height="307px" Width="451px">


<table>
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="Registration No:"></asp:Label></td>
    <td>
    <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox></td>
    </tr>
    <tr></tr>
    <tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="name_valid" runat="server" ControlToValidate="TextBox2" ToolTip="Name can not be left blank">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr></tr>
    <tr>
    <td>
        <asp:Label ID="Label3" runat="server" Text="Age"></asp:Label></td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </td>
    <td><asp:RequiredFieldValidator runat="server" ID="Age_valid" ControlToValidate="TextBox3" ToolTip="Age can not be left blank">*</asp:RequiredFieldValidator></td></tr>
    <tr></tr>
    <tr>
    <td>
        <asp:Label ID="Label4" runat="server" Text="Sex"></asp:Label></td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="156px">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr></tr>
    <tr>
    <td>
        <asp:Label ID="Label5" runat="server" Text="Full Address"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ID="address_valid" ControlToValidate="TextBox4" ToolTip="Address can not be left blank">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr></tr>
    <tr><td>
        <asp:Label ID="Label6" runat="server" Text="Phone Number"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="ph_valid" runat="server" ControlToValidate="TextBox5" ToolTip="Phone Number can not be left blank">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr></tr>
            <tr><td>
                <asp:Label ID="Label7" runat="server" Text="Doctor's Name"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="156px">
                     <asp:ListItem> </asp:ListItem>
                     <asp:ListItem>Dr. Abhijit Bandyopadhyay</asp:ListItem>
                     <asp:ListItem>Dr. Biswajit Mondal</asp:ListItem>
                     <asp:ListItem>Dr. Debobrata Dutta</asp:ListItem>
                     <asp:ListItem>Dr. Dibyendu Roy</asp:ListItem>
                     <asp:ListItem>Dr. Kaushik Sadhu Khan</asp:ListItem>
                     <asp:ListItem>Dr. Soumen Ghara</asp:ListItem>
                     <asp:ListItem>Dr. Subhasis Jana</asp:ListItem>
                     <asp:ListItem>Dr. Nisha Samaddar(Sahana)</asp:ListItem>
                     <asp:ListItem>Optm. Arijit Das</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr></tr>
    </table>
    
    <table>
    <tr><td>
        <asp:Button ID="Button1" runat="server" Text="Save & Print" OnClick="Button1_Click" /></td></tr>
    </table>
    
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
    <center>
        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
    </center>
    </asp:Panel>
</center>
</asp:Content>

