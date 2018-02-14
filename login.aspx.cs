using System;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Net.Http;

using System.Net.Http.Headers;
using AuthenticationService.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using AuthenticationService.Interfaces;
using System.Web.Security;

namespace BavnReports
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {      
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(Load));
        }

        private async Task Load()
        {
            try
            {
                if (EmplID.Text != null && UserPass.Text !=null)
                {

                    AuthResponseDTO response = await AuthenticateLogin(EmplID.Text, UserPass.Text);

                    if (response.LoginSuccessful)
                    {
                        FormsAuthentication.SetAuthCookie(EmplID.Text, true);

                        FormsAuthenticationTicket ticket1 =
                           new FormsAuthenticationTicket(
                                1,                                   // version
                                EmplID.Text,   // get username  from the form
                                DateTime.Now,                        // issue time is now
                                DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),         // expires in 20 minutes
                                true,      // cookie is not persistent
                                "User"                              // role assignment is stored
                                                                  // in userData
                                );
                        HttpCookie cookie1 = new HttpCookie(
                          FormsAuthentication.FormsCookieName,
                          FormsAuthentication.Encrypt(ticket1));
                        Response.Cookies.Add(cookie1);

                        Response.Redirect("~/statusupdate.aspx");
                    }
                    else
                    {
                        //ModelState.AddModelError("", response.ErrorMessage);
                        InvalidCredentialsMessage.Text = response.ErrorMessage;
                        InvalidCredentialsMessage.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                InvalidCredentialsMessage.Text = ex.Message;
                InvalidCredentialsMessage.Visible = true;
            }
        } 

        private async Task<AuthResponseDTO> AuthenticateLogin(string serialNumber, string password)
        {
            try
            {

                AuthResponseDTO result = new AuthResponseDTO();                            

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(LdapAuthenticationServiceUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Specify what LDAP attributes need to be returned when a user's authentication is passed
                    AuthRequestDTO authRequest = new AuthRequestDTO { UserId = serialNumber, Password = password, LoginRequested = true, AuthenticatedMode = AuthenticatedModes.CityOfLA };
                    authRequest.LdapAttributes = new Dictionary<string, string>();
                    authRequest.LdapAttributes.Add(LdapAttributeName.FULLNAME, "");
                    authRequest.LdapAttributes.Add(LdapAttributeName.SURNAME, "");

                    var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(authRequest);

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/auth", authRequest);

                    if (response.IsSuccessStatusCode)
                    {
                        AuthResponseDTO authResponse = await response.Content.ReadAsAsync<AuthResponseDTO>();

                        result = authResponse;
                    }
                    else
                    {
                        throw new Exception("Authentication: " + response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
            }
        }


        private static string _ldapAuthenticationServiceUrl;
        public static string LdapAuthenticationServiceUrl
        {
            get
            {
                string result = _ldapAuthenticationServiceUrl;
                if (result == null)
                {
                    string ldapAuthenticationServiceUrlEntry = ConfigurationManager.AppSettings["LdapAuthenticationServiceUrl"];
                    if (ldapAuthenticationServiceUrlEntry == null)
                    {
                        throw new ArgumentNullException("LdapAuthenticationServiceUrl entry missing from AppSettings");
                    }
                    result = ldapAuthenticationServiceUrlEntry;

                    _ldapAuthenticationServiceUrl = result;
                }
                return result;
            }
        }

    }
}