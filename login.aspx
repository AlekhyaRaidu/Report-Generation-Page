<%@ Page Title="Log in" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BavnReports.Login" Async="true" %>
<%@ Import Namespace="System.Web.Security" %>
<link href="cityfone.css" rel="stylesheet" type="text/css" />
<link href="header.css" rel="stylesheet" type="text/css" />
<link href="fonts.css" rel="stylesheet" type="text/css" />
<html>


    <body>
  <form id="loginForm" runat="server">
    <h3>
      Logon Page</h3>
    <table>
      <tr>
        <td>
          Employee ID</td>
        <td>
          <asp:TextBox ID="EmplID" runat="server" /></td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
            ControlToValidate="EmplID"
            Display="Dynamic" 
            ErrorMessage="Cannot be empty." 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td>
          Password:</td>
        <td>
          <asp:TextBox ID="UserPass" TextMode="Password" 
             runat="server" />
        </td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
            ControlToValidate="UserPass"
            ErrorMessage="Cannot be empty." 
            runat="server" />
        </td>
      </tr>     
    </table>
    <asp:Button ID="btnSubmit" Text="Log On" OnClick="LoginButton_Click"
       runat="server" />
    <p>
        <asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="Your username or password is invalid. Please try again."
            Visible="False"></asp:Label> 
    </p>
  </form>
</body>
</html>