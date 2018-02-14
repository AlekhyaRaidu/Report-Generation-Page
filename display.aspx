<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Displayapp.aspx.cs" Inherits="BavnReports.Displayapp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
    <br />
    <br />
    <br />
    <br /><br />
    <br /><br />
    <br />
    <style> div{
            color:dimgrey ;
        }</style>
    
    <center> <img src="images/ita_banner.jpg"  height="130" width="1200" align="middle"/></center><br /><br />
 
      
    <form method="post" action="~/Displayapp.aspx">
       <center> <div>WEEK ENDING ON  <%=Session["date2"] %> <br /> Department Name: <%=Session["deptname"] %></div></center> 
        <br />    


        <% var list = (System.Collections.ArrayList)Session["list"];
            foreach (var item in list)
            {


                var appName = ((System.Collections.Generic.Dictionary<string, string>)item)["applicationName"];
                var report = ((System.Collections.Generic.Dictionary<string, string>)item)["report"];
        %>

      


            <h2 style="background: #e2e2e2; border-radius: 12px 12px 0px 0px;"><a href="#"><center><%=appName.ToString() %></center></a></h2>
            <ul style="margin-left: 10px !important; padding-top: 10px !important;">
                <li>


                    <p style="background-color: aliceblue">
                        <%=report.ToString() %>
                    </p>

                </li>

            </ul>
      
        <%              
                // Response.Write("application:" + appName.ToString() +"<br/>");
                // Response.Write("report:" + report.ToString() +"<br/>");
            }

        %>
        <input type="button" onclick="location.href = 'statusupdate.aspx';" value="OK" />




    </form>
</asp:Content>