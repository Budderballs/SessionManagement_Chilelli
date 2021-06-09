using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement
{
	public partial class MembersMain : System.Web.UI.Page
	{
		List<string> x = new List<string>();
		protected void Page_Load(object sender, EventArgs e)
		{
			string user = Request.QueryString["u"];
			string pass = Request.QueryString["p"];
            x.Add("Yuya");
            x.Add("Budder");
			if (!x.Contains(user)) { Response.Redirect("Default.aspx"); }
			lblUser.Text = "Hello, " + user + "! Your password is " + pass;
			x.Clear();
		}
	}
}