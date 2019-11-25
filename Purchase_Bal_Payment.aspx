<%@ Page Title="Purchase Balance Payment" Language="C#" MasterPageFile="~/Purchase_Sales_Menu.Master" AutoEventWireup="true" CodeBehind="Purchase_Bal_Payment.aspx.cs" Inherits="SMS.Purchase_Bal_Payment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
<script type="text/javascript">
    function isNumberKey(evt, obj) {

        var charCode = (evt.which) ? evt.which : event.keyCode
        var value = obj.value;
        var dotcontains = value.indexOf(".") != -1;
        if (dotcontains)
            if (charCode == 46) return false;
        if (charCode == 46) return true;
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
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
<h3>&nbsp;Purchase Balance Payment</h3>
<hr>
<table width="80%" border="0">
<tr style="height:40px">
<td>
Account No
</td>
<td>
    <asp:TextBox ID="txt_Account_No" runat="server"></asp:TextBox>
</td>
<td align="left">
                <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup"  style="display:none" />
                <asp:Button ID="btn_Search" Font-Bold runat="server" Text="Search" OnClick="btn_Search_Click" />
            </td>
<tr style="height:40px">
<td>
Receipt No
</td>
<td>
    <asp:TextBox ID="txt_Receipt_No" runat="server" Enabled="false"></asp:TextBox>
</td>
<td>
Invoice Date
</td>
<td>
    <asp:TextBox ID="txt_Invoice_Date" runat="server" Enabled="false"></asp:TextBox>
</td>
</tr>
</tr>
<tr style="height:40px">
<td>
Supplier Id
</td>
<td>
    <asp:TextBox ID="txt_Supplier_Id" runat="server" Enabled="false"></asp:TextBox>
</td>
<td>
Supplier Name
</td>
<td>
    <asp:TextBox ID="txt_Supplier_Name" runat="server" Enabled="false"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
Tran. Id
</td>
<td>
    <asp:TextBox ID="txt_Transaction_Id" runat="server" Enabled="false"></asp:TextBox>
</td>
<td>
Tran. Date
</td>
<td>
    <asp:TextBox ID="txt_Transaction_Date" runat="server" Enabled="false"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
<td>
Closing Balance
</td>
<td>
    <asp:TextBox ID="txt_Closing_Balance" runat="server" Enabled="false"></asp:TextBox>
</td>
<td>
Tran. Amount
</td>
<td>
    <asp:TextBox ID="txt_Transaction_Amount" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
</td>
</tr>
<tr style="height:40px">
           <td>
                Remarks
            </td>
            <td colspan="5">
                <asp:TextBox ID="txt_Narration" runat="server" Style="text-align: left;"  Width="93%"></asp:TextBox>
            </td>
        </tr>
<tr style="height:40px">
<td>
</td>
<td align="right">
    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click"/>
</td>
              <td colspan="2">
    <asp:Label ID="lbl_Status" runat="server" ForeColor="Red"></asp:Label>
</td>
</tr>
</table>
<table width="100%">
<tr>
                <td colspan="2">
                <asp:GridView ID="GridView2" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AllowPaging="true" PageSize="100" AutoGenerateColumns="False" OnPageIndexChanging="GridView2_OnPageIndexChanging" Width="100%">  
                <Columns>  
                <asp:TemplateField HeaderText="Tran. Id">
                <ItemTemplate>  
                <asp:Label ID="lbl_Tran_Id" runat="server" Font-Bold Text='<%#Bind("Transaction_Id") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tran Date">
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
                 <asp:TemplateField HeaderText="Balance">
                <ItemTemplate>  
                <asp:Label ID="lbl_Balance" runat="server" Font-Bold ForeColor="Black" Text='<%#Bind("Balance") %>'></asp:Label>  
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
    <div style="height: 450px;width:800px;background-color:#5F9EA0">
    
            <ContentTemplate>
             <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="Supplier_Id" Width="100%" OnPageIndexChanging="OnPageIndexChanging" OnSelectedIndexChanged="OnSelectedIndexChanged" AutoPostBack="true">  
                <Columns>
                <asp:TemplateField HeaderText="Account No">
                <ItemTemplate>  
                <asp:Label ID="lbl_Invoice_No" runat="server" Font-Bold Text='<%#Bind("Invoice_No") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Invoice Date">
                <ItemTemplate>  
                <asp:Label ID="lbl_Invoice_Date" runat="server" Font-Bold Text='<%#Bind("Invoice_Dates") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Receipt No">
                <ItemTemplate>  
                <asp:Label ID="lbl_Receipt_No" runat="server" Font-Bold Text='<%#Bind("Receipt_No") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier Id">
                <ItemTemplate>  
                <asp:Label ID="lbl_Supplier_Id" runat="server" Font-Bold Text='<%#Bind("Supplier_Id") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier Name">
                <ItemTemplate>  
                <asp:Label ID="lbl_Supplier_Name" runat="server" Font-Bold Text='<%#Bind("Supplier_Name") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Closing Balance">
                <ItemTemplate>  
                <asp:Label ID="lbl_Closing_Balance" runat="server" Font-Bold Text='<%#Bind("Closing_Balance") %>'></asp:Label>
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
        <br>
        <asp:Button ID="btnClose" runat="server" Text="Close" />
    </div>
</asp:Panel>
</asp:Content>
