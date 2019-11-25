<%@ Page Title="Customer Master" Language="C#" MasterPageFile="~/Main_Master.Master" AutoEventWireup="true" CodeBehind="Customer_Master.aspx.cs" Inherits="SMS.Customer_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
<script type="text/javascript">
    window.onload = function () {
        document.getElementById('<%= txt_Customer_Name.ClientID%>').focus();
    };
</script>
<script type = "text/javascript">
    function Confirm() {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_value";
        if (confirm("Do you want to delete data?")) {
            confirm_value.value = "Yes";
        } else {
            confirm_value.value = "No";
        }
        document.forms[0].appendChild(confirm_value);
    }
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
<h3>&nbsp;Customer Master</h3>
<hr>
<table width="80%" border="0">
<tr style="height:40px">
<td>
Customer Id
</td>
<td>
    <asp:TextBox ID="txt_Customer_Id" runat="server" Enabled="false"></asp:TextBox>
</td>
<td>
Customer Name
</td>
<td>
    <asp:TextBox ID="txt_Customer_Name" runat="server"></asp:TextBox>
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
Contact No 1
</td>
<td>
    <asp:TextBox ID="txt_Contact_No1" runat="server"></asp:TextBox>
</td>
<td>
Contact No 2
</td>
<td>
    <asp:TextBox ID="txt_Contact_No2" runat="server"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
Contact Person
</td>
<td>
    <asp:TextBox ID="txt_Contact_Person" runat="server"></asp:TextBox>
</td>
<td>
Email
</td>
<td>
    <asp:TextBox ID="txt_Email" runat="server"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
GST TIN NO
</td>
<td colspan="3">
    <asp:TextBox ID="txt_Gst_Tin_No" runat="server" Width="570px"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
Remarks
</td>
<td colspan="3">
    <asp:TextBox ID="txt_Remarks" runat="server" Width="570px"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td align="right">
    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click"/>
</td>
<td align="center">
   <asp:Button ID="btn_Delete" runat="server" Text="Delete" OnClick="btn_Delete_Click" OnClientClick="Confirm()" />
</td>
</tr>
<tr style="height:40px">
<td colspan="4">
    <asp:Label ID="lbl_Status" runat="server" ForeColor="Red"></asp:Label>
</td>
</tr>
</table>

</asp:Content>
