﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement
{
	public partial class Default : System.Web.UI.Page
	{
		protected void btnLogIn_Click(object sender, EventArgs e)
		{
			if (txtUser.Text=="Yuya" && txtPassword.Text=="Sum" || txtUser.Text == "Budder" && txtPassword.Text == "Ball")
			{
				string user = txtUser.Text;
				string pass = txtPassword.Text;
				Response.Redirect("OtherPage.aspx?u=" + txtUser.Text + "&p=" + txtPassword.Text);
			}
			else {lblMessage.Text = "Account not recognized";}
		}
	}
}