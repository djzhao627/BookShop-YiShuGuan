<%@ WebHandler Language="C#" Class="Web.AutoLogin" %>

using System;
using System.Web;
using System.Web.SessionState;
using Dao;
using Model;

namespace Web
{
    public class AutoLogin : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Cookies["accountId"] != null)
            {
                try
                {
                    AccountDao accountDao = new AccountDao();
                    context.Session["account"] = accountDao.GetAccountById(Convert.ToInt32(context.Request.Cookies["accountId"]));
                    context.Response.Redirect("Main.aspx");
                }
                catch (Exception)
                {
                    context.Response.Redirect("Login.aspx");
                }
            }
            else
            {
                context.Response.Redirect("Login.aspx");
            }
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