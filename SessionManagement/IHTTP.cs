using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;

namespace SessionManagement
{
    public class IHTTP : IHttpModule
    {
        public static Dictionary<string, string> table = new Dictionary<string, string>();
        public void Dispose() { }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(OnBeginRequest);
        }
        private void OnBeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            string URL = context.Request.Path;
            string user = context.Request.QueryString["u"];
            string pass = context.Request.QueryString["p"];
            string eUser = string.Empty;
            string ePass = string.Empty;
            //Hard coded check if user is not null
            if (!string.IsNullOrEmpty(user))
            {
                //Looks for values in dictionary table, if not adds it
                if (!table.ContainsKey(eUser))
                {
                    eUser = encryptStuff(user);
                    ePass = encryptStuff(pass);
                    table.Add(eUser, user);
                    table.Add(ePass, pass);
                }
                //Force 3rd page working
                if (URL.Contains("OtherPage.aspx") && table.Count > 4) { URL = "MembersMain.aspx"; }
                //Shove good string into URL
                context.RewritePath(URL, string.Empty, "u=" + eUser + "&p=" + ePass, true);
                //Checks dictionary for key value pair
                if (table.ContainsKey(pass) && table.ContainsValue(pass))
                {
                    //Checks again for user, if and only if there rewrites path
                    if (table.ContainsKey(user)) { context.RewritePath(URL, string.Empty, "u=" + table[user] + "&p=" + table[pass], true); }
                }
                //Changes URL to new one
                else if (table.ContainsValue(user)) { context.Response.Redirect(context.Request.Url.ToString()); }
            }
        }
        private string encryptStuff(string info)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            Thread.Sleep(1);
            string sodiumChloride = r.Next(100000, 999999).ToString();
            int a;
            byte[] b;
            byte[] h;
            b = ASCIIEncoding.ASCII.GetBytes(info);
            h = new MD5CryptoServiceProvider().ComputeHash(b);
            StringBuilder output = new StringBuilder(h.Length);
            for (a = 0; a < h.Length; a++) { output.Append(h[a].ToString("X2")); }
            return output.ToString().Substring(0, 6) + sodiumChloride + output.ToString().Substring(6);
        }
    }
}