using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

using System.Data;

namespace WebApplication4
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Page.IsPostBack)
            {
                string date1 = Request.Form["Date1"];
                Session["date1"] = date1;
                string deptname = Request.Form["dd1"];
                Session["deptname"] = deptname;


                if (!string.IsNullOrEmpty(date1) && !string.IsNullOrEmpty(deptname) )
                {
                    string appname = Request.Form["dd2"];
                    Session["appname"] = appname;


                    string strcon = "Server=localhost;Database=bavn;Uid=root;Pwd=mysqlroot;";
                    string str;
                    MySql.Data.MySqlClient.MySqlCommand com;
                    object obj;

                    MySqlConnection con = new MySqlConnection(strcon);
                    con.Open();
                  
                  

                    str = "select report from employeerecords where deptName=@deptname and applicationName=@appname ";
                    com = new MySqlCommand(str, con);
                    com.Parameters.AddWithValue("@deptname", deptname);
                    com.Parameters.AddWithValue("@appname", appname);
                    com.Parameters.AddWithValue("@date1",date1);


                    obj = com.ExecuteScalar();

                    string comment = Convert.ToString(obj);
                    Session["comment"] = comment;
                   
                        try
                        {


                            Response.Redirect("InputRecord.aspx", true);
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

                   
                    }
                }
            }
        }
    }
