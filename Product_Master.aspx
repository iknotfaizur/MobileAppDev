<%@ Page Title="Product Master" Language="C#" MasterPageFile="~/Full_Width.Master" AutoEventWireup="true" CodeBehind="Product_Master.aspx.cs" Inherits="SMS.Product_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
<script type="text/javascript">
    window.onload = function () {
        document.getElementById('<%= txt_Product_Name.ClientID%>').focus();
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

<h3>&nbsp;Product Master</h3>
<hr>
<table width="100%" border="0">
<tr style="height:40px">
<td>
Product Code
</td>
<td>
    <asp:TextBox ID="txt_Product_Code" runat="server" Enabled="false"></asp:TextBox>
    <asp:HiddenField ID="hd_Id" runat="server" />
</td>
</tr>
<tr style="height:40px">
<td>
Product Category
</td>
<td>
    <asp:DropDownList ID="ddl_Category" runat="server" Width="58%">
    </asp:DropDownList>
</td>
</tr>
<tr style="height:40px">
<td>
Product Name
</td>
<td>
    <asp:TextBox ID="txt_Product_Name" runat="server"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
Unit Name
</td>
<td>
    <asp:DropDownList ID="ddl_Unit_Name" runat="server"  Width="58%">
    </asp:DropDownList>
</td>
</tr>
<tr style="height:40px">
<td>
Purchase Price
</td>
<td>
    <asp:TextBox ID="txt_Purchase_Price" runat="server" Text="0.00" Style="text-align:right;"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
Market Price
</td>
<td>
    <asp:TextBox ID="txt_Market_Price" runat="server" Text="0.00" Style="text-align:right;"></asp:TextBox>
</td>
<td bgcolor="Teal" colspan="6" align="center">
<font color="white"><b>GST Details</b></font>
</td>
</tr>
<tr style="height:40px">
<td>
Sales Price
</td>
<td>
    <asp:TextBox ID="txt_Sales_Price" runat="server" Text="0.00" Style="text-align:right;"></asp:TextBox>
</td>
<td>
CGST %
</td>
<td>
    <asp:TextBox ID="txt_CGST_PER" runat="server" Width="50px" Text="0"></asp:TextBox>
</td>
<td>
SGST %
</td>
<td>
    <asp:TextBox ID="txt_SGST_PER" runat="server" Width="50px" Text="0"></asp:TextBox>
</td>
<td>
IGST %
</td>
<td>
    <asp:TextBox ID="txt_IGST_PER" runat="server" Width="50px" Text="0"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td align="right">
    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" />
</td>
<td colspan="2">
    <asp:Label ID="lbl_Status" runat="server" ForeColor="Red"></asp:Label>
</td>
</tr>
</table>
<hr>
<table width="100%" border="0">
<tr style="height:40px">
<td>
<b>Search</b>
</td>
<td>
<asp:TextBox ID="txt_Search" runat="server" OnTextChanged="txt_Search_Change" AutoPostBack="true" Width="300px"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
                <td colspan="2">
                <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AllowPaging="true" PageSize="20" AutoGenerateColumns="False" DataKeyNames="Product_Code" Width="100%" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged = "OnSelectedIndexChanged" OnPageIndexChanging="OnPageIndexChanging">  
                <Columns>  
                <asp:TemplateField HeaderText="Id" Visible="false">
                <ItemTemplate>  
                <asp:Label ID="lbl_Id" runat="server" Text='<%#Bind("Id") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Code">
                <ItemTemplate>  
                <asp:Label ID="lbl_Product_Code" runat="server" Font-Bold Text='<%#Bind("Product_Code") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category">
                <ItemTemplate>  
                <asp:Label ID="lbl_Category" runat="server" Font-Bold Text='<%#Bind("Product_Category") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>  
                <asp:Label ID="lbl_Product_Name" runat="server" Font-Bold Text='<%#Bind("Product_Name") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit">
                <ItemTemplate>  
                <asp:Label ID="lbl_Unit" runat="server" Font-Bold Text='<%#Bind("Unit_Name") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Purchase Price">
                <ItemTemplate>  
                <asp:Label ID="lbl_Purchase_Price" runat="server" Font-Bold Text='<%#Bind("Purchase_Price") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Market Price">
                <ItemTemplate>  
                <asp:Label ID="lbl_Market_Price" runat="server" Font-Bold Text='<%#Bind("Market_Price") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Sales Price">
                <ItemTemplate>  
                <asp:Label ID="lbl_Sales_Price" runat="server" Font-Bold Text='<%#Bind("Sales_Price") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="CGST %">
                <ItemTemplate>  
                <asp:Label ID="lbl_CGST_Per" runat="server" Font-Bold Text='<%#Bind("CGST_PER") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="SGST %">
                <ItemTemplate>  
                <asp:Label ID="lbl_SGST_Per" runat="server" Font-Bold Text='<%#Bind("SGST_PER") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="IGST %">
                <ItemTemplate>  
                <asp:Label ID="lbl_IGST_Per" runat="server" Font-Bold Text='<%#Bind("IGST_PER") %>'></asp:Label>
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
