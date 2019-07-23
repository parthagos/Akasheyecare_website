<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="Receipt_Print.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
        <div title="Print Receipt">
         <h1><strong>Receipt Print</strong></h1>
            <asp:Panel ID="Panel1" runat="server" Height="154px" Width="369px">
            <table>
            <tr>
            <td>
        <asp:Label ID="Label1" runat="server" Text="Bill No"></asp:Label>
        </td>
        <td>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" Width="156px">
        </asp:DropDownList>
        </td>
        </tr>
        <tr></tr>
        <tr>
        <td>
        <asp:Label ID="Label2" runat="server" Text="Registration No"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TabIndex="1" Enabled="False"></asp:TextBox>
                </td>
                </tr>
                <tr></tr>
                <tr>
                <td>
        <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" TabIndex="2" Enabled="False"></asp:TextBox>
                </td>    
                </tr>
                <tr></tr>
                <tr>
                <td>
        <asp:Label ID="Label4" runat="server" Text="Full Address"></asp:Label>
        </td>
             <td>
        <asp:TextBox ID="TextBox4" runat="server" TabIndex="3" Enabled="False"></asp:TextBox>
              </td>
                </tr>
                <tr></tr>
                <tr>
                <td>
        <asp:Label ID="Label5" runat="server" Text="Cash"></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="TextBox5" runat="server" TabIndex="4" Enabled="False"></asp:TextBox>
               </td>
               </tr>
               <tr></tr>
                </table>
                <table>
                <tr>
                <td>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Print" TabIndex="5" />
        </td>
        </tr>
        </table>
        </asp:Panel>
        <asp:Label ID="Label6" runat="server" Height="188px" Width="589px"></asp:Label></div>
</center>
</asp:Content>