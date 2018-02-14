<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateRecord.aspx.cs" Inherits="WebApplication4.WebForm2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <form method="post" action="~/InputRecord.aspx">  
        <br /><br />
        Department Name: <%=Session["deptname"] %><br />
        Application Name: <%=Session["appname"] %><br />
        Report: <textarea> <%=Session["comment"] %> </textarea>
        
     <br />
      <input type="submit" value="Update" name="submit"/>        
    </form>
     </div>
</asp:Content>