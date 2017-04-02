using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;

namespace Web.Admin.pages
{
    public partial class UserList : System.Web.UI.Page
    {
        //用来生成用户列表的html标签
        public string UsersList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //在session中取admin对象
            Model.Admin admin = (Model.Admin) Session["admin"];
            // 判断是否已经登录
            if (admin == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //将登入管理系统的管理员名显示在右上角处
                AdminName.Text = admin.Username;
                //加载用户列表
                UpdateList();
            }
        }

        private void UpdateList()
        {
            //实例化一个accountDao
            //Dao数据库访问操作
            AccountDao accountDao = new AccountDao();
            //通过accountDao对象取出所有的用户
            List<Account> list = accountDao.GetAllAccounts();
            if (list != null)
            {
                StringBuilder sb = new StringBuilder();
                //遍历列表
                foreach (Account account in list)
                {
                    //生成html
                    sb.AppendFormat("<tr class='odd gradeX'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td><div class='text-center'><button type = 'button' userId='{0}' class='btn btn-danger btn_delete' data-toggle='modal' data-target='#confirm-delete'>删除</button></td></tr>", account.Id, account.Username, account.Question, account.Answer, account.Mail, account.RegistTime);
                }
                UsersList = sb.ToString();
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDeleteBook_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(BookId.Text);
            //实例化一个accountDao
            AccountDao accountDao = new AccountDao();
            //调用删除方法删除用户
            if (accountDao.DeleteAccountById(id))
            {
                // 刷新当前页 0为立即刷新
                Response.AddHeader("Refresh", "0");
            }
        }
    }
}