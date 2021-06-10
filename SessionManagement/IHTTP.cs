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
            string oUser = context.Request.QueryString["u"];
            string oPass = context.Request.QueryString["p"];
            string SHAUser256 = string.Empty;
            string SHAPass256 = string.Empty;
            //Hard coded check if user is not null
            if (!string.IsNullOrEmpty(oUser))
            {
                //Looks for values in dictionary table, if not adds it
                if (!table.ContainsKey(SHAUser256))
                {
                    SHAUser256 = encryptStuff(oUser);
                    SHAPass256 = encryptStuff(oPass);
                    table.Add(SHAUser256, oUser);
                    table.Add(SHAPass256, oPass);
                }
                //Force 3rd page working
                if (URL.Contains("OtherPage.aspx") && table.Count > 4) { URL = "MembersMain.aspx"; }
                //Shove good string into URL
                context.RewritePath(URL, string.Empty, "u=" + SHAUser256 + "&p=" + SHAPass256, true);
                //Checks dictionary for key value pair
                if (table.ContainsKey(oPass) && table.ContainsValue(oPass))
                {
                    //Checks again for user, if and only if there rewrites path
                    if (table.ContainsKey(oUser)) { context.RewritePath(URL, string.Empty, "u=" + table[oUser] + "&p=" + table[oPass], true); }
                }
                //Changes URL to new one
                else if (table.ContainsValue(oUser)) { context.Response.Redirect(context.Request.Url.ToString()); }
            }
        }
        private string encryptStuff(string plainInfo)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            Thread.Sleep(1);
            string sodiumChloride = r.Next(100000, 999999).ToString();
            int a;
            byte[] b;
            byte[] h;
            b = UTF8Encoding.UTF8.GetBytes(plainInfo);
            h = new SHA256CryptoServiceProvider().ComputeHash(b);
            StringBuilder hashedInfo = new StringBuilder(h.Length);
            for (a = 0; a < h.Length; a++) { hashedInfo.Append(h[a].ToString("X2")); }
            return hashedInfo.ToString().Substring(0, 6) + sodiumChloride + hashedInfo.ToString().Substring(7);
        }
    }
}