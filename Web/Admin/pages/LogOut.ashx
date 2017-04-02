<%@ WebHandler Language="C#" Class="Web.Admin.pages.LogOut" %>

using System;
using System.Web;
using System.Web.SessionState;

namespace Web.Admin.pages
{
    public class LogOut : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["admin"] != null)
            {
                context.Session.Remove("admin");
            }
            context.Response.Redirect("Login.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }

}