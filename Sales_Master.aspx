<%@ Page Title="Sales Master" Language="C#" MasterPageFile="~/Purchase_Sales.Master" AutoEventWireup="true" CodeBehind="Sales_Master.aspx.cs" Inherits="SMS.Sales_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
<script type="text/javascript" language="javascript">
      function validatenumerics(key) {
          //getting key code of pressed key
          var keycode = (key.which) ? key.which : key.keyCode;
          //comparing pressed keycodes

          if (keycode > 31 && (keycode < 48 || keycode > 57)) {
              alert(" You can enter only characters 0 to 9 ");
              return false;
          }
          else return true;
      }
</script>
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
<%--    <script type="text/javascript">
        window.onload = function () {
            document.getElementById('<%= txt_Receipt_No.ClientID%>').focus();
        };
    </script>--%>
    <link href="http://code.jquery.com/ui/1.11.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript">
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
            font-weight: bold;
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
            color: #000;
            font-weight: bold;
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
<asp:UpdatePanel ID="button" runat="server">
<ContentTemplate>
    <table width="100%" border="0">
    <tr>
    <td colspan="8">
        <b>Sales Master</b>
    </td>
    <td colspan="10">
         <b> Date : <asp:Label ID="lbl_Current_Date" runat="server" ForeColor="Red"></asp:Label></b>
    </td>
    <tr>
    <td colspan="10">
    <hr>
    </td>
    </tr>
    </tr>
        <tr style="height: 30px">
            <td>
                <b>Invoice No</b>
            </td>
            <td>
                <asp:TextBox ID="txt_Invoice_No" Font-Bold runat="server" Width="100px" Enabled="false"></asp:TextBox>
                <asp:HiddenField ID="hd_Scheme_Code" Value="98001" runat="server" />
            </td>
            <td>
                <b>Invoice Date</b>
            </td>
            <td>
                <asp:TextBox ID="txt_Invoice_Date" Font-Bold runat="server" Width="100px" Enabled="false"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="txt_Invoice_Date" runat="server"
                    TargetControlID="txt_Invoice_Date" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                </td>
            <td>
                <b>Customer Id</b>
            </td>
            <td>
                <asp:TextBox ID="txt_Customer_Id" Font-Bold runat="server" Enabled="false" Width="100px"></asp:TextBox>
            </td>
            <td>
                <b>Customer Name</b>
            </td>
            <td>
                <asp:TextBox ID="txt_Customer_Name" Font-Bold runat="server" Width="300px"></asp:TextBox> 
            </td>
            <td align="left">
                <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup"  style="display:none" />
                <asp:Button ID="btn_Search" Font-Bold runat="server" Text="Search" OnClick="btn_Search_Click" />
            </td>
        </tr>
    </table>
    <table style="background-color: Teal" width="100%">
        <tr style="height: 40px">
            <td>
                <font color="white"><b>P.Code</b></font>
            </td>
            <td>
                <asp:TextBox ID="txt_Product_Code" Font-Bold runat="server" Width="100px" OnTextChanged="txt_Product_Code_Change" AutoPostBack="true" onkeypress="return validatenumerics(event);"  OnClientClick = "return false;"></asp:TextBox>
            </td>
            <td>
                <font color="white"><b>Name</b></font>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txt_Product_Name" Font-Bold runat="server" Width="380px" Enabled="false"></asp:TextBox>
<%--<ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txt_Product_Name"
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetCountries" >
</ajax:AutoCompleteExtender>--%>
   </td>
            <td>
                <font color="white"><b>Unit</b></font>
            </td>
            <td>
                <asp:TextBox ID="txt_Unit_Name" Font-Bold runat="server" Width="50px" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <font color="white"><b>Quantity</b></font>
            </td>
            <td>
                <asp:TextBox ID="txt_Quantity" Font-Bold runat="server" Width="50px" onkeypress="return isNumberKey(event,this)" OnTextChanged="txt_Quantity_Change" AutoPostBack="true" OnClientClick = "return false;"></asp:TextBox>
            </td>
            <td>
                <font color="white"><b>Rate</b></font>
            </td>
            <td>
                <asp:TextBox ID="txt_Rate" runat="server" Font-Bold Width="100px" OnTextChanged="txt_Rate_Change" AutoPostBack="true"  OnClientClick = "return false;" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <font color="white"><b>Amount</b></font>
            </td>
            <td>
                <asp:TextBox ID="txt_Amount" Font-Bold runat="server" Width="100px" Enabled="false" Text="0.00"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="chk_Tax" runat="server" />
            </td>
            <td>
              <font color="white"><b>Tax</b></font>
            </td>
        </tr>
    </table>
    <table style="background-color: Gray;display:none" width="100%">
        <tr style="height: 40px">
            <td>
                <font color="white"><b>CGST%</b></font>
            </td>
            <td>
                <asp:TextBox ID="txt_CGST_PER" runat="server" Width="80px" Enabled="false" Text="0"></asp:TextBox>
            </td>
            <td>
                <font color="white"><b>CGST</b></font>
            </td>
            <td>
                <asp:TextBox ID="txt_CGST_AMT" runat="server" Width="80px" Enabled="false" Text="0.00"></asp:TextBox>
            </td>
            <td>
                <font color="white"><b>SGST%</b></font>
            </td>
            <td>
                <asp:TextBox ID="txt_SGST_PER" runat="server" Width="80px" Enabled="false" Text="0"></asp:TextBox>
            </td>
            <td>
                <font color="white"><b>SGST</b></font>
            </td>
            <td>
                <asp:TextBox ID="txt_SGST_AMT" runat="server" Width="80px" Enabled="false" Text="0.00"></asp:TextBox>
            </td>
            <td>
                <font color="white"><b>IGST%</b></font>
            </td>
            <td>
                <asp:TextBox ID="txt_IGST_PER" runat="server" Width="80px" Enabled="false" Text="0"></asp:TextBox>
            </td>
            <td>
                <font color="white"><b>IGST</b></font>
            </td>
            <td>
                <asp:TextBox ID="txt_IGST_AMT" runat="server" Width="80px" Enabled="false" Text="0.00"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="height:300px;background-color:#FFCC66; overflow:auto;">
    <table border="0" width="100%">
        <tr>
            <td rowspan="7" style="width: 1000px" valign="top">
                <div class="rounded_corners">
<asp:GridView ID="GridView2" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server"  AllowPaging="true" PageSize="500" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting" OnRowDataBound="GridView2_RowDataBound">  
        <Columns> 
        <asp:TemplateField HeaderText="S.No" ItemStyle-Width="30px">
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Code" HeaderText="Code"  ItemStyle-Width="50px" />
        <asp:BoundField DataField="Product_Name" HeaderText="Particulars" />
        <asp:BoundField DataField="Unit_Name" HeaderText="Unit" ItemStyle-Width="50px"  />
        <asp:BoundField DataField="Quantity" HeaderText="Qty" ItemStyle-Width="40px"  />
        <asp:BoundField DataField="Rate" HeaderText="Rate" ItemStyle-Width="50px" />
        <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-Width="60px" />
        <asp:BoundField DataField="CGST_PER" HeaderText="CGST%" ItemStyle-Width="50px" />
        <asp:BoundField DataField="CGST_AMT" HeaderText="CGST" ItemStyle-Width="50px" />
        <asp:BoundField DataField="SGST_PER" HeaderText="SGST%" ItemStyle-Width="50px" />
        <asp:BoundField DataField="SGST_AMT" HeaderText="SGST" ItemStyle-Width="50px" />
        <asp:BoundField DataField="IGST_PER" HeaderText="IGST%" ItemStyle-Width="50px" />
        <asp:BoundField DataField="IGST_AMT" HeaderText="IGST" ItemStyle-Width="50px" />
        <asp:CommandField ShowDeleteButton="true" />
        </Columns>
</asp:GridView>  
               </div>
            </td>
        </tr>
    </table>
    </div>
    <div style="background-color:#CCCCCC" align="left">
    <table border="0">
    <tr>
    <td align="right">
                <b>Purchase Value</b>
            </td>
            <td>
                <asp:TextBox ID="txt_Sales_Value" runat="server" Text="0.00" Style="text-align: right;
                    color: blue" Font-Bold Width="120px" Enabled="false"></asp:TextBox>
            </td>
            <td align="right">
                <b>Addition</b>
            </td>
            <td>
                <asp:TextBox ID="txt_Addition" runat="server" Text="0.00" Style="text-align: right;
                    color: black" Font-Bold Width="120px" OnTextChanged="txt_Addition_Change" AutoPostBack="true"></asp:TextBox>
            </td>
            <td align="right">
                <b>Grand Total</b>
            </td>
            <td>
                <asp:TextBox ID="txt_Grand_Total" runat="server" Text="0.00" Style="text-align: right;
                    color: red" Font-Bold Width="120px" Enabled="false" OnTextChanged="txt_Grand_Total_Change" AutoPostBack="true"></asp:TextBox>
            </td>
            <td rowspan="4">
            <font color="red" size="24px"><b>Bal.</b></font>
            </td>
            <td rowspan="4" colspan="2">
           <font color="red" size="24px"><b><asp:Label ID="lbl_Balance" runat="server"></asp:Label></b></font>
            </td>
    </tr>
    <tr>
     <td align="right">
                <b>Tax Amount</b>
            </td>
            <td>
                   <asp:TextBox ID="txt_Total_Tax" runat="server" Text="0.00" Style="text-align: right;
                    color: blue" Font-Bold Width="120px" Enabled="false"></asp:TextBox>
            </td>
             <td align="right">
                <b>Deduction</b>
            </td>
            <td>
                <asp:TextBox ID="txt_Deduction" runat="server" Text="0.00" Style="text-align: right;
                    color: black" Font-Bold Width="120px" OnTextChanged="txt_Deduction_Change" AutoPostBack="true"></asp:TextBox>
            </td>
             <td align="right">
                <b>Tran. Mode</b>
            </td>
             <td>
                 <asp:DropDownList ID="ddl_Payment_Mode" runat="server" Width="125px" Font-Bold>
                 <asp:ListItem>Cash</asp:ListItem>
                 <asp:ListItem>Credit</asp:ListItem>
                 </asp:DropDownList>
            </td>
    </tr>
        <tr>
           <td align="right">
                <b>Account No</b>
            </td>
            <td>
                <asp:TextBox ID="txt_Account_No" runat="server" Style="text-align: right;
                    color: blue" Font-Bold Width="120px" Enabled="false"></asp:TextBox>
            </td>
             <td align="right">
                <b>Tran. Id</b>
            </td>
            <td>
                   <asp:TextBox ID="txt_Transaction_Id" runat="server" Style="text-align: right; color: blue" Font-Bold Width="120px" Enabled="false"></asp:TextBox>
            </td>
             <td align="right">
                <b>Tran. Date</b>
            </td>
            <td>
                <asp:TextBox ID="txt_Transaction_Date" runat="server" Style="text-align: right;color: blue" Font-Bold Width="120px" Enabled="false"></asp:TextBox>
                 <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="txt_Transaction_Date" runat="server"
                    TargetControlID="txt_Transaction_Date" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
           <td align="right">
                <b>Remarks</b>
            </td>
            <td colspan="5">
                <asp:TextBox ID="txt_Narration" runat="server" Style="text-align: left;
                    color: blue" Font-Bold Width="99%"></asp:TextBox>
            </td>
        </tr>
    <tr style="display:none">
     <td align="right">
                <b>Balance</b>
            </td>
            <td>
                <asp:TextBox ID="txt_Closing_Balance" runat="server" Text="0.00" Style="text-align: right;
                    color: blue" Font-Bold Width="120px" Enabled="false"></asp:TextBox>
            </td>
    </tr>
    </table>
    </div>
    <hr>
    <div align="center">
    <table width="13%">
    <tr>
    <td>
    <asp:Button ID="btn_Save" Font-Bold runat="server" Text="Save" OnClick="btn_Save_Click" />
    </td>
    <td>
        <asp:Button ID="btn_Home" Font-Bold runat="server" Text="Home" OnClick="btn_Home_Click" />
    </td>
    <td colspan="2">
        <asp:Label ID="lbl_Status" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    </table>
    </div>
<!-- ModalPopupExtender -->
<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
    <div style="height: 450px;width:800px;background-color:#5F9EA0">
    
            <ContentTemplate>
             <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="Customer_Id" Width="100%" OnPageIndexChanging="OnPageIndexChanging" OnSelectedIndexChanged="OnSelectedIndexChanged" AutoPostBack="true">  
                <Columns>
                <asp:TemplateField HeaderText="Supplier Id">
                <ItemTemplate>  
                <asp:Label ID="lbl_Customer_Id" runat="server" Font-Bold Text='<%#Bind("Customer_Id") %>'></asp:Label>  
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier Name">
                <ItemTemplate>  
                <asp:Label ID="lbl_Customer_Name" runat="server" Font-Bold Text='<%#Bind("Customer_Name") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Town / City">
                <ItemTemplate>  
                <asp:Label ID="lbl_Town_City" runat="server" Font-Bold Text='<%#Bind("Town_City") %>'></asp:Label>
                </ItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact No">
                <ItemTemplate>  
                <asp:Label ID="lbl_Contact_No" runat="server" Font-Bold Text='<%#Bind("Contact_No_1") %>'></asp:Label>
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
<!-- ModalPopupExtender -->
<%--<Triggers>
    <asp:AsyncPostBackTrigger ControlID="txt_Product_Code" EventName="TextChanged" />
</Triggers>--%>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


