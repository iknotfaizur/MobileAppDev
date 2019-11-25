<%@ Page Title="Account Statement" Language="C#" MasterPageFile="~/Purchase_Sales_Menu.Master" AutoEventWireup="true" CodeBehind="Account_Statement.aspx.cs" Inherits="SMS.Account_Statement" %>
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
<h3>&nbsp;Account Statement</h3>
<hr>
<table width="100%" border="0">
<tr style="height:40px">
<td>
Account Type
</td>
<td>
    <asp:DropDownList ID="ddl_Account_Type" runat="server" Width="96%">
    <asp:ListItem>Purchase</asp:ListItem>
    <asp:ListItem>Sales</asp:ListItem>
    </asp:DropDownList>
</td>
<td>
Account No
</td>
<td>
    <asp:TextBox ID="txt_GL_Code" runat="server"></asp:TextBox>
</td>
<td>
Account Name
</td>
<td>
    <asp:TextBox ID="txt_GL_Name" runat="server" Enabled="false"></asp:TextBox>
</td>
<td>
    <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup"  style="display:none" />
    <asp:Button ID="btn_Search" runat="server" Text="Search"  OnClick="btn_Search_Click" />
</td>
</tr>
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
</td>
<td>
    <asp:Button ID="btn_Excel" runat="server" Text="Export to Excel" OnClick="btn_Excel_Click" />
</td>
</tr>
</table>
<table width="100%">
<tr>
                <td colspan="2">
                <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AllowPaging="true" PageSize="20" AutoGenerateColumns="False" DataKeyNames="Transaction_Id" Width="100%" OnPageIndexChanging="GridView1_OnPageIndexChanging">  
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
                <asp:TemplateField HeaderText="Debit">
                <ItemTemplate>  
                <asp:Label ID="lbl_Debit" runat="server" Font-Bold ForeColor="Red" Text='<%#Bind("Debit") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Credit">
                <ItemTemplate>  
                <asp:Label ID="lbl_Credit" runat="server" Font-Bold ForeColor="Green" Text='<%#Bind("Credit") %>'></asp:Label>
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
    <div style="height:450px;width:800px;background-color:#5F9EA0">
            <ContentTemplate>
            <br>
             <asp:GridView ID="GridView2" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="GL_Code" Width="100%"  AutoPostBack="true" OnPageIndexChanging="GridView2_OnPageIndexChanging" OnSelectedIndexChanged="GridView2_OnSelectedIndexChanged">  
                <Columns>
                <asp:TemplateField HeaderText="GL Code">
                <ItemTemplate>  
                <asp:Label ID="lbl_GL_Code" runat="server" Font-Bold Text='<%#Bind("GL_Code") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="GL Name">
                <ItemTemplate>  
                <asp:Label ID="lbl_GL_Name" runat="server" Font-Bold Text='<%#Bind("GL_Name") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                <ItemTemplate>
                <asp:LinkButton Text="Select" ID="lnkSelect" runat="server" CommandName="Select" />
                </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                </asp:GridView>
            </ContentTemplate>
        <br />
        <asp:Button ID="btnClose" runat="server" Text="Close" />
    </div>
</asp:Panel>
</asp:Content>
