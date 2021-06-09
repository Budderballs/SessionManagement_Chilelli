using System;

namespace SessionManagement
{
    public partial class MembersMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Request.QueryString["u"];
            string pass = Request.QueryString["p"];
            if (Session["user"].ToString() != user)
            {
                IHTTP.table.Clear();
                Response.Redirect("Default.aspx");
            }
            lblUser.Text = "Hello, " + user + "! Your password is " + pass;
        }
    }
}