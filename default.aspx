<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication4._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
   <script type="text/javascript">
     function configureDropDownLists(ddl1,ddl2) {
         var colours = ['a-police', 'a-services', 'a-HR'];
         var shapes = ['b-police', 'b-services', 'b-HR'];
         var names = ['c-police', 'c-services', 'c-HR'];

    switch (ddl1.value) {
        case 'dept-A':
            ddl2.options.length = 0;
            for (i = 0; i < colours.length; i++) {
                createOption(ddl2, colours[i], colours[i]);
            }
            break;
        case 'dept-B':
            ddl2.options.length = 0; 
        for (i = 0; i < shapes.length; i++) {
            createOption(ddl2, shapes[i], shapes[i]);
            }
            break;
        case 'dept-C':
            ddl2.options.length = 0;
            for (i = 0; i < names.length; i++) {
                createOption(ddl2, names[i], names[i]);
            }
            break;
            default:
                ddl2.options.length = 0;
            break;
    }

}

    function createOption(ddl, text, value) {
        var opt = document.createElement('option');
        opt.value = value;
        opt.text = text;
        ddl.options.add(opt);
    }
</script>
 <form method="post"  action="~/Default.aspx"> 
   Date: <select id="Date1" name="Date1" >
    <option value="novalue">please select</option>
  <option value="03-01-2017" >03/01/2017</option>
  <option value="03-15-2017">03/15/2017</option>
  <option value="04-01-2017">04/01/2017</option>
  <option value="04-15-2017">04/15/2017</option>
</select >
     <br />
Department Name:<select name="dd1" id="ddl" onchange="configureDropDownLists(this,document.getElementById('ddl2'))">
    <option value="novalue">please select</option>
<option value="dept-A">dept-A</option>
<option value="dept-B">dept-B</option>
<option value="dept-C">dept-C</option>
</select>

Application Name:<select name="dd2" id="ddl2">
  


     <input type="submit" value="submit" name="submit"/>
     
</form>
</asp:Content>