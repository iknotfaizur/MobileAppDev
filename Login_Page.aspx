<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Page.aspx.cs" Inherits="SMS.Login_Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="UTF-8">
  <title>Login Form</title>
      <link rel="stylesheet" href="CSS/login_style.css">
</head>
<body>
<form id="form_1" runat="server">
  <body>
	<div class="login">
		<div class="login-screen">
			<div class="app-title">
				<h1>Login</h1>
			</div>
			<div class="login-form">
				<div class="control-group">
                <h5>Username</h5>
                <asp:TextBox ID="txt_Username" class="login-field" runat="server"></asp:TextBox>
				</div>
				<div class="control-group">
                <h5>Password</h5>
                </td>
                <td>
               <asp:TextBox ID="txt_Password" class="login-field" runat="server" TextMode="Password"></asp:TextBox>
				</div>
                <asp:Button ID="btn_Login" class="btn btn-primary btn-large btn-block" runat="server" Text="Login" OnClick="Login_Click" />
                <br>
                <asp:Label ID="lbl_Status" runat="server"></asp:Label>
				<%--<a class="btn btn-primary btn-large btn-block" href="#">login</a>--%>
			</div>
		</div>
	</div>
</body>
</form>
</body>
</html>
