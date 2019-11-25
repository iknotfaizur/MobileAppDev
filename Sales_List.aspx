<%@ Page Title="Sales List" Language="C#" MasterPageFile="~/Purchase_Sales_Menu.Master" AutoEventWireup="true" CodeBehind="Sales_List.aspx.cs" Inherits="SMS.Sales_List" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
<script type="text/javascript">
    window.onload = function () {
        document.getElementById('<%= txt_Search.ClientID%>').focus();
    };
</script>
<style>
.mydatagrid
{
	width: 100%;
	border: solid 2px black;
	min-width: 80%;
}
.header
{
	background-color: #000;
	font-family: Arial;
	color: White;
	height: 25px;
	text-align: center;
	font-size: 16px;
}

.rows
{
	background-color: #fff;
	font-family: Arial;
	font-size: 14px;
	color: #000;
	min-height: 25px;
	text-align: left;
}
.rows:hover
{
	background-color: #5badff;
	color: #fff;
}

.mydatagrid a /** FOR THE PAGING ICONS  **/
{
	background-color: Transparent;
	padding: 5px 5px 5px 5px;
	color: #000;
	text-decoration: none;
	font-weight: bold;
}

.mydatagrid a:hover /** FOR THE PAGING ICONS  HOVER STYLES**/
{
	background-color: #000;
	color: #fff;
}
.mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/
{
	
	color: #000;
	padding: 5px 5px 5px 5px;
}
.pager
{
	background-color: #5badff;
	font-family: Arial;
	color: White;
	height: 30px;
	text-align: left;
}

.mydatagrid td
{
	padding: 5px;
}
.mydatagrid th
{
	padding: 5px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
<h3>&nbsp;Sales List</h3>
<hr>
<table width="50%" border="0">
<tr style="height:40px">
<td>
Search
</td>
<td>
    <asp:TextBox ID="txt_Search" runat="server"></asp:TextBox>
</td>
<td>
    <asp:Button ID="btn_Go" runat="server" Text="Go" OnClick="btn_Go_Click" />
</td>
<td>
    <asp:Button ID="btn_Add" runat="server" Text="+ Add New" OnClick="btn_Add_Click" />
</td>
</tr>
</table>
<table width="100%">
<tr>
                <td colspan="2">
                <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AllowPaging="true" PageSize="20" AutoGenerateColumns="False" DataKeyNames="Invoice_No" Width="100%" OnPageIndexChanging="OnPageIndexChanging" OnSelectedIndexChanged="OnSelectedIndexChanged">  
                <Columns>
                <asp:TemplateField HeaderText="Account No">
                <ItemTemplate>  
                <asp:Label ID="lbl_Account_No" runat="server" Font-Bold Text='<%#Bind("Account_No") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Invoice No">
                <ItemTemplate>  
                <asp:Label ID="lbl_Invoice_No" runat="server" Font-Bold Text='<%#Bind("Invoice_No") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                <ItemTemplate>  
                <asp:Label ID="lbl_Invoice_Date" runat="server" Font-Bold Text='<%#Bind("Invoice_Dates") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer Id">
                <ItemTemplate>  
                <asp:Label ID="lbl_Supplier_Id" runat="server" Font-Bold Text='<%#Bind("Customer_Id") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer Name">
                <ItemTemplate>  
                <asp:Label ID="lbl_Supplier_Name" runat="server" Font-Bold Text='<%#Bind("Customer_Name") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Closing Balance">
                <ItemTemplate>  
                <asp:Label ID="lbl_Closing_Balance" runat="server" Font-Bold Text='<%#Bind("Closing_Balance") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account Status">
                <ItemTemplate>  
                <asp:Label ID="lbl_Account_Status" runat="server" Font-Bold Text='<%#Bind("Account_Status") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                <ItemTemplate>
                <asp:LinkButton Text="Edit/View" ID="lnkSelect" runat="server" CommandName="Select" />
                </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField>
                 <ItemTemplate>
                    <asp:LinkButton Text="Delete" ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?');" />
                 </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                </asp:GridView>  
                </td>
                </tr>
</table>
</asp:Content>
