<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InputRecord.aspx.cs" Inherits="BavnReports._InputRecord" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
    <style>
        div{
            color:dimgrey ;
        }
        textarea{
             align-content : center ;
    width: 800px;
    border: 3px solid lightgrey;
    padding: 15px;
    margin: 0.5px;
        }
    </style>  <br />
    <br />

     <div>
<br /><br /><br /><br />
        <br />
    <form method="post" action="~/InputRecord.aspx">  
     <div>  Department Name: <%=Session["deptname"] %><br />
        Application Name: <%=Session["appname"] %><br />
        Report:<br /> </div> 
        <textarea name="report" id="report" cols="18" rows="20"><%=Session["comment"] %> </textarea>
        
     <br />
      <input type="submit" value="Update" name="submit"/>        
    </form>
     </div>
</asp:Content>