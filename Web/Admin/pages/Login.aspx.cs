using System;
using Dao;
using Model;
namespace Web.Admin.pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            //实例化一个对象
            Model.Admin  admin = new Model.Admin();
            admin.Password = TextPassword.Text;
            admin.Username = TextUsername.Text;
            //实例化一个数据库操作类对象
            AdminDao adminDao = new AdminDao();
            //调用其登录方法
            admin = adminDao.AdminLogin(admin);
            //如果返回空值则说明登录失败
            if (admin == null)
            {
                ErrorInfo.Text = "请重试！";
            }
            //反之，登陆成功
            else
            {
                //设置一个值为admin的session，表示当前用户登录成功
                Session["admin"] = admin;
                // 显示登录成功信息，颜色位成功的绿色，而不是有错误的红色
                ErrorInfo.CssClass = "text-success";
                ErrorInfo.Text = "登录成功，3秒后自动跳转...";
                //过三秒钟后跳转到管理页面
                Response.Write("<meta   http-equiv='refresh'   content='3;URL=./UserList.aspx'>");
            }
        }
    }

}