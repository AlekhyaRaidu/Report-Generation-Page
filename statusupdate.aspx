<%@ Page Title="Status Update" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="statusupdate.aspx.cs" Inherits="BavnReports.statusupdate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <style>
fieldset {
    
    align-content : center ;
    width: 800px;
    border: 45px solid lightgrey;
    padding: 15px;
    margin: 75px;
} </style>  
    <br /><br /><br /><br />
    <form method="post" action="~/statusupdate.aspx" style="background: white;">
        <br />
        <br />
        <br />
        <br />

        <fieldset>
            <div>
            <div id="dept">
                <label for="bsmSelectbsmContainer1"><span class="action-highlight">Select</span> Date</label>
                <div class="bsmContainer" id="bsmContainer1">
                    <select class="bsmSelect" name="Date2" id="Date2">
                        <option value="novalue">please select</option>
                        <option value="03-01-2017">03/01/2017</option>
                        <option value="03-15-2017">03/15/2017</option>
                        <option value="04-01-2017">04/01/2017</option>
                        <option value="04-15-2017">04/15/2017</option>



                    </select>
                </div>
            </div>


            <div id="coord">
                <label for="bsmSelectbsmContainer0"><span class="action-highlight">Select</span> department <span style="font-size: 0.7em; letter-spacing: 0; margin-left: 10px;"></span></label>
                <div class="bsmContainer" id="bsmContainer0">
                    <select class="bsmSelect" name="dd2" id="dd2" onchange="configureDropDownLists(this,document.getElementById('ddl2'))">
                        <option value="novalue">please select</option>
                        <option value="dept-A">dept-A</option>
                        <option value="dept-B">dept-B</option>
                        <option value="dept-C">dept-C</option>
                    </select>
                </div>
            </div>
                </div>
             <center><input type="submit" value="submit" name="submit" /> </center> 
        </fieldset>

     

    </form>

</asp:Content>