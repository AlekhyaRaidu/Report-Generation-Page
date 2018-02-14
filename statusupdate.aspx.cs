using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace BavnReports
{
    public partial class statusupdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string date2 = Request.Form["Date2"];
            Session["date2"] = date2;
            string deptname = Request.Form["dd2"];
            Session["deptname"] = deptname;

            var userName = User.Identity.Name;

            //if (!string.IsNullOrEmpty(report2))
            //if (!string.IsNullOrEmpty(date2) && !string.IsNullOrEmpty(deptname))
            if (Page.IsPostBack)
            {
                
                string strcon = "Server=localhost;Database=bavn;Uid=root;Pwd=mysqlroot;";
                string str;
                MySql.Data.MySqlClient.MySqlCommand com;
                object obj;

                MySqlConnection con = new MySqlConnection(strcon);
                con.Open();



                str = "select applicationName, report from employeerecords where deptName=@deptname and enddate=@date2 ";
                com = new MySqlCommand(str, con);
                com.Parameters.AddWithValue("@deptname", deptname);     
                com.Parameters.AddWithValue("@date2",date2);


                obj = com.ExecuteScalar();

                // Your DB Connection codes.
                MySqlDataReader Reader = com.ExecuteReader();
                //ArrayList list = new ArrayList();
                ArrayList arrayList = new ArrayList();
             

                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Dictionary<string, string> emplRec = new Dictionary<string, string>();
                        
                        //list.Add(Reader[0]);
                        // list1.Add(Reader[1]);
                        emplRec.Add("applicationName", Reader["applicationName"].ToString());
                        emplRec.Add("report", Reader["report"].ToString());
                        arrayList.Add(emplRec);
                    }
                    Reader.Close();
                }
                Session["list"] = arrayList;
                //ession["list1"] = list1;

                try
                {


                    Response.Redirect("Displayapp.aspx", true);
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