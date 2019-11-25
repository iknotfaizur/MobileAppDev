<%@ Page Title="Calendar Settings" Language="C#" MasterPageFile="~/Main_Master.Master" AutoEventWireup="true" CodeBehind="Calendar_Settings.aspx.cs" Inherits="SMS.Calendar_Settings" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
<script type="text/javascript">
    window.onload = function () {
        document.getElementById('<%= txt_Software_Date.ClientID%>').focus();
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
<h3>&nbsp;Calendar Settings</h3>
<hr>
<table width="50%" border="0">
<tr style="height:40px">
<td>
Software Date
</td>
<td>
    <asp:TextBox ID="txt_Software_Date" runat="server"></asp:TextBox>
     <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="txt_Software_Date" runat="server"
                    TargetControlID="txt_Software_Date" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
    <asp:HiddenField ID="hd_Id" runat="server" />
</td>
</tr>
<tr style="height:40px">
<td align="right">
    <asp:Button ID="btn_Save" runat="server" Text="Update" OnClick="btn_Save_Click" />
</td>
<td colspan="2">
    <asp:Label ID="lbl_Status" runat="server" ForeColor="Red"></asp:Label>
</td>
</tr>
</table>
</asp:Content>
