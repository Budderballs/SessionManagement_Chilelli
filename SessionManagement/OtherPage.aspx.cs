using System;

namespace SessionManagement
{
    public partial class OtherPage : System.Web.UI.Page
    {
        string user;
        string pass;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["u"];
            pass = Request.QueryString["p"];
            lblUser.Text = "Hello, " + user + "! Your password is " + pass;
        }
        protected void btnLogIn_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("MembersMain.aspx?u=" + user + "&p=" + pass);
        }
    }
}