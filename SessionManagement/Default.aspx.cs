using System;

namespace SessionManagement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "Yuya" && txtPassword.Text == "Sum" || txtUser.Text == "Budder" && txtPassword.Text == "Ball")
            {
                string oUser = txtUser.Text;
                string oPass = txtPassword.Text;
                Session.Add("user", oUser);
                Response.Redirect("OtherPage.aspx?u=" + txtUser.Text + "&p=" + txtPassword.Text);
            }
            else { lblMessage.Text = "Account not recognized"; }
        }
    }
}