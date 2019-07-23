<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="update_patient_details.aspx.cs" Inherits="update_patient_details" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<h2>Update Patient Details</h2><br />
    <asp:Panel ID="Panel1" runat="server" Height="256px" Width="453px">
    <table>
    <tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="Registration No:"></asp:Label></td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="154px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true">
            </asp:DropDownList></td>
    </tr>
    <tr></tr>
    <tr>
    <td><asp:Label ID="Label2" runat="server" Text="Name"></asp:Label></td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator ID="Name_valid" runat="server" ControlToValidate="TextBox1" ToolTip="Name field can not be left Blank">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr></tr>
    <tr>
    <td><asp:Label ID="Label3" runat="server" Text="Age"></asp:Label></td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
    <td><asp:RequiredFieldValidator ID="age_valid" runat="server" ControlToValidate="TextBox2" ToolTip="Age can not be left blank">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr></tr>
    <tr>
    <td>
        <asp:Label ID="Label4" runat="server" Text="Sex"></asp:Label></td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server" Width="156px">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr></tr>
    <tr>
    <td>
        <asp:Label ID="Label5" runat="server" Text="Full Address"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="Address_valid" runat="server" ControlToValidate ="TextBox3" ToolTip="Address field can not be left blank">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr></tr>
    <tr>
    <td>
        <asp:Label ID="Label6" runat="server" Text="Phone Number"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
    <td><asp:RequiredFieldValidator ID="ph_valid" ControlToValidate="TextBox4" runat="server" ToolTip="Please enter phone number">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr></tr>
    <tr>
    <td>
        <asp:Label ID="Label8" runat="server" Text="Doctor Name"></asp:Label></td>
    <td>
        <asp:DropDownList ID="DropDownList3" runat="server" Width="154px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
        </asp:DropDownList></td>
        
    </tr>
    <tr></tr>
    </table>
    <table>
    <tr><td style="width: 37px">
        <asp:Button ID="Button1" runat="server" Text="Edit" Width="58px" OnClick="Button1_Click" /></td>
        <td>
            <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" /></td></tr></table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="110px" Width="453px">
        <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
    </asp:Panel>

</center>
</asp:Content>

