<%@ Page Title="Company Master" Language="C#" MasterPageFile="~/Main_Master.Master" AutoEventWireup="true" CodeBehind="Company_Master.aspx.cs" Inherits="SMS.Company_Master" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
<script type="text/javascript">
    window.onload = function () {
        document.getElementById('<%= txt_Company_Name.ClientID%>').focus();
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
<h3>&nbsp;Company Master</h3>
<hr>
<table width="80%" border="0">
<tr style="height:40px">
<td>
Branch Code
</td>
<td colspan="3">
    <asp:TextBox ID="txt_Company_Code" runat="server" Enabled="false" Text="201"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
Company Name
</td>
<td colspan="3">
    <asp:TextBox ID="txt_Company_Name" runat="server" Width="570px"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
Address Line 1
</td>
<td colspan="3">
    <asp:TextBox ID="txt_Address_Line1" runat="server" Width="570px"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
Address Line 2
</td>
<td colspan="3">
    <asp:TextBox ID="txt_Address_Line2" runat="server" Width="570px"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
Town / City
</td>
<td>
    <asp:TextBox ID="txt_City_Town" runat="server"></asp:TextBox>
</td>
<td>
District
</td>
<td>
    <asp:TextBox ID="txt_District" runat="server"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
State
</td>
<td>
    <asp:TextBox ID="txt_State" runat="server"></asp:TextBox>
</td>
<td>
Pincode
</td>
<td>
    <asp:TextBox ID="txt_Pincode" runat="server"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
Phone / Mobile
</td>
<td colspan="3">
    <asp:TextBox ID="txt_Phone" runat="server" Width="570px"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
GST TIN NO
</td>
<td colspan="3">
    <asp:TextBox ID="txt_Com_Gst_No" runat="server" Width="570px"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
</td>
<td>
    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" />
</td>
<td>
<asp:Label ID="lbl_Status" runat="server" ForeColor="Red"></asp:Label>
</td>
</tr>
</table>
</asp:Content>
