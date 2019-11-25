<%@ Page Title="View Transactions" Language="C#" MasterPageFile="~/Purchase_Sales_Menu.Master" AutoEventWireup="true" CodeBehind="View_Transactions.aspx.cs" Inherits="SMS.View_Transactions" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
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
<h3>&nbsp;View Transactions</h3>
<hr>
<table width="65%" border="0">
<tr style="height:40px">
<td>
From Date
</td>
<td>
    <asp:TextBox ID="txt_From_Date" runat="server"></asp:TextBox>
      <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="txt_From_Date" runat="server"
                    TargetControlID="txt_From_Date" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
</td>
<td>
To Date
</td>
<td>
    <asp:TextBox ID="txt_To_Date" runat="server"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="txt_To_Date" runat="server"
                    TargetControlID="txt_To_Date" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
</td>
<td>
    <asp:Button ID="btn_Go" runat="server" Text="Go" OnClick="btn_Go_Click" />
    <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup"  style="display:none" />
</td>
</tr>
</table>
<table width="100%">
<tr>
                <td colspan="2">
                <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AllowPaging="true" PageSize="20" AutoGenerateColumns="False" DataKeyNames="Transaction_Id" Width="100%" OnPageIndexChanging="OnPageIndexChanging" OnSelectedIndexChanged="OnSelectedIndexChanged">  
                <Columns>
                <asp:TemplateField HeaderText="Tran. Id">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Id" runat="server" Font-Bold Text='<%#Bind("Transaction_Id") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tran. Date">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Date" runat="server" Font-Bold Text='<%#Bind("Transaction_Dates") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Particulars">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Particulars" runat="server" Font-Bold Text='<%#Bind("Transaction_Particulars") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tran. Amount">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Amount" runat="server" Font-Bold Text='<%#Bind("Transaction_Amount") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                <ItemTemplate>
                <asp:LinkButton Text="View" ID="lnkSelect" runat="server" CommandName="Select" />
                </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                </asp:GridView>  
                </td>
                </tr>
</table>
<!-- ModalPopupExtender -->
<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
    <div style="height:600px;width:800px;background-color:#5F9EA0">
            <ContentTemplate>
            <br>
            <font color="white"><h3>General Ledger - Postings</h3></font>
             <asp:GridView ID="GridView2" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="Transaction_Id" Width="100%"  AutoPostBack="true">  
                <Columns>
                <asp:TemplateField HeaderText="Tran Id">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Id" runat="server" Font-Bold Text='<%#Bind("Transaction_Id") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tran Date">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Date" runat="server" Font-Bold Text='<%#Bind("Transaction_Dates") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account No">
                <ItemTemplate>  
                <asp:Label ID="lbl_Account_No" runat="server" Font-Bold Text='<%#Bind("Account_No") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account Name">
                <ItemTemplate>  
                <asp:Label ID="lbl_Account_Name" runat="server" Font-Bold Text='<%#Bind("Account_Name") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tran Amount">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Amount" runat="server" Font-Bold Text='<%#Bind("Transaction_Amount") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tran Type">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Type" runat="server" Font-Bold Text='<%#Bind("Transaction_Type") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                </Columns>
                </asp:GridView> 
                <br><br /> 
                <font color="white"><h3>Account Ledger - Postings</h3></font>
                <asp:GridView ID="GridView3" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="Transaction_Id" Width="100%"  AutoPostBack="true">  
                <Columns>
                <asp:TemplateField HeaderText="Tran Id">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Id" runat="server" Font-Bold Text='<%#Bind("Transaction_Id") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tran Date">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Date" runat="server" Font-Bold Text='<%#Bind("Transaction_Dates") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account No">
                <ItemTemplate>  
                <asp:Label ID="lbl_Account_No" runat="server" Font-Bold Text='<%#Bind("Account_No") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account Name">
                <ItemTemplate>  
                <asp:Label ID="lbl_Account_Name" runat="server" Font-Bold Text='<%#Bind("Account_Name") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tran Amount">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Amount" runat="server" Font-Bold Text='<%#Bind("Transaction_Amount") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tran Type">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Type" runat="server" Font-Bold Text='<%#Bind("Transaction_Type") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                </Columns>
                </asp:GridView> 
            </ContentTemplate>
        <br>
        <table>
        <tr>
        <td>
        <asp:Button ID="btnClose" runat="server" Text="Close" />
        </td>
        <td>
            <asp:HiddenField ID="hd_Tran_Id" runat="server" />
            <asp:HiddenField ID="hd_Tran_Date" runat="server" />
            <asp:HiddenField ID="hd_Account_No" runat="server" />
        <asp:Button ID="btn_Delete" runat="server" Text="Delete" OnClick="btn_Delete_Click" OnClientClick="Confirm()" />
        </td>
        </tr>
        </table>
    </div>
</asp:Panel>
</asp:Content>
