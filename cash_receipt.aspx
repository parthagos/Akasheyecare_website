<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cash_receipt.aspx.cs" Inherits="cash_receipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<center>
    <div title="Cash Receipt">
       <h2>Cash Receipt of Patient&nbsp;
       </h2>
       <asp:Panel ID="Panel1" runat="server" Height="246px" Width="449px">
       <table>
       <tr>
       <td>
           <asp:Label ID="Label1" runat="server" Text="Bill No :"></asp:Label>
           </td>
           <td>
           <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
           </td>
           </tr>
           <tr></tr>
           <tr>
           <td>
            <asp:Label ID="Label2" runat="server" Text="Registration No:"></asp:Label>
            </td>
            <td>
           <asp:DropDownList ID="DropDownList1" runat="server" Width="153px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true">
            </asp:DropDownList>
            </td>
            </tr>
             <tr></tr>
           <tr>
           <td>
            <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
            <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox>
            </td>
          </tr>
           <tr></tr>
          <tr>
          <td>
            <asp:Label ID="Label4" runat="server" Text="Full Address"></asp:Label>
            </td>
          <td>
            <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
            </td>
           </tr>
            <tr></tr>
           <tr>
           <td>
            <asp:Label ID="Label5" runat="server" Text="Cash"></asp:Label>
            </td>
           <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
            <td>
            <asp:RequiredFieldValidator ID="cash_validator" runat ="server" ControlToValidate="TextBox4" ToolTip="This field can not be left blank">*</asp:RequiredFieldValidator>
            </td>
           </tr>
            <tr></tr>
           </table>
           <table>
           <tr>
           <td>
            <asp:Button ID="Button1" runat="server" Text="Save & Print" OnClick="Button1_Click" />
            </td>
            </tr>
            </table>
            </asp:Panel>
       <br />
            <asp:Label ID="Label6" runat="server" Height="85px" Width="448px"></asp:Label>
            </div>
        </center>
  
     </asp:Content>