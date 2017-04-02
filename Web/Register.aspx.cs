using System;
using Dao;
using Model;

namespace Web
{
    public partial class WebRegister : System.Web.UI.Page
    {
        // 数据库操作类
        private AccountDao accountDao;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 注册按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            accountDao = new AccountDao();
            // 如果用户已经存在
            if (accountDao.IsAccountExist(TextUsername.Text.Trim()))
            {
                ErrorInfo.Text = "该用户名已经被使用，请更换一个！";
                return;
            }
            // 模型赋值
            Account account = new Account();
            account.Username = TextUsername.Text.Trim();
            account.Password = TextPassword.Text.Trim();
            account.Mail = TextEmail.Text.Trim();
            account.Question = TextQuestion.Text.Trim();
            account.Answer = TextAnswer.Text.Trim();
            // 注册成功
            if (accountDao.InsertAccount(account))
            {
                Session["account"] = account;
                ErrorInfo.Style.Add("color", "green");
                ErrorInfo.Text = "注册成功，3秒后自动跳转...";
                Response.Write("<meta   http-equiv='refresh'   content='3;URL=./Main.aspx'>");
            }
            // 注册失败
            else
            {
                ErrorInfo.Text = "注册失败，请稍后重试...";
            }
        }
    }
}