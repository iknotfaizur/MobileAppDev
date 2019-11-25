<%@ Page Title="Category Master" Language="C#" MasterPageFile="~/Main_Master.Master" AutoEventWireup="true" CodeBehind="Category_Master.aspx.cs" Inherits="SMS.Category_Master" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
<script type="text/javascript">
    window.onload = function () {
        document.getElementById('<%= txt_Category.ClientID%>').focus();
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
<h3>&nbsp;Category Master</h3>
<hr>
<table width="50%" border="0">
<tr style="height:40px">
<td>
Category Name
</td>
<td>
    <asp:TextBox ID="txt_Category" runat="server"></asp:TextBox>
    <asp:HiddenField ID="hd_Id" runat="server" />
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
<table width="40%">
<tr>
                <td colspan="2">
                <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="Id" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged = "OnSelectedIndexChanged" OnPageIndexChanging="OnPageIndexChanging" Width="100%">  
                <Columns>  
                <asp:TemplateField HeaderText="Id" Visible="false">
                <ItemTemplate>  
                <asp:Label ID="lbl_Id" runat="server" Text='<%#Bind("Id") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category Name">
                <ItemTemplate>  
                <asp:Label ID="lbl_Category" runat="server" Font-Bold Text='<%#Bind("Category") %>'></asp:Label>  
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
