using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;

using MySql.Data.MySqlClient;

using System.Data;

namespace BavnReports
{
    public partial class _InputRecord : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string report = Request.Form["report"];           
            Session["report"] = report;
           string date1 = (string)Session["date1"];
            string deptName = (string)Session["deptname"];
            string applicationName = (string)Session["appname"];
    




            //if (!string.IsNullOrEmpty(report2))
            if (Page.IsPostBack)
            {

                string strcon = "Server=localhost;Database=bavn;Uid=root;Pwd=mysqlroot;";
                string str;
                MySql.Data.MySqlClient.MySqlCommand com;
                object obj;

                MySqlConnection con = new MySqlConnection(strcon);
                con.Open();
                if ((string)Session["comment"] != "comment") 
                {
                    str = "Update EmployeeRecords set eid=@eid,report=@report where deptName=@deptName and applicationName=@applicationName and enddate=@enddate";
                    com = new MySqlCommand(str, con);
                    com.CommandType = CommandType.Text;
                    com.Parameters.AddWithValue("@eid", 45);
                    com.Parameters.AddWithValue("@ename", "ITAiid013");
                    com.Parameters.AddWithValue("@report", report);
                    com.Parameters.AddWithValue("@enddate", date1);
                    com.Parameters.AddWithValue("@deptName", deptName);
                    com.Parameters.AddWithValue("@applicationName", applicationName);
                }
                else
                {
                    str = "Insert into EmployeeRecords values(@eid,@ename,@enddate,@deptName,@applicationName,@report)";
                    com = new MySqlCommand(str, con);
                    com.CommandType = CommandType.Text;
                    //com.Parameters.AddWithValue("@reference", reference);
                    com.Parameters.AddWithValue("@eid", 45);
                    com.Parameters.AddWithValue("@ename", "ITAiid013");
                    com.Parameters.AddWithValue("@enddate", date1);
                    com.Parameters.AddWithValue("@deptName", deptName);
                    com.Parameters.AddWithValue("@applicationName", applicationName);
                    com.Parameters.AddWithValue("@report", report);
                }


                obj = com.ExecuteScalar();




                try
                {

                    //Server.Transfer("WebForm1.aspx", true);
                    Response.Redirect("statusupdate.aspx", true);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    string errorMessage = string.Empty;
                    while (ex2 != null)
                    {
                        errorMessage += ex2.ToString();
                        ex2 = ex2.InnerException;
                    }
                    HttpContext.Current.Response.Write(errorMessage);
                }
                finally
                {
                    con.Close();//close db connection
                }


            }

        

    }
    }
}