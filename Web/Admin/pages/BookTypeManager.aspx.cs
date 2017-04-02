using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;

namespace Web.Admin.pages
{
    public partial class BookTypeManager : System.Web.UI.Page
    {
        public string TypeList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Model.Admin admin = (Model.Admin) Session["admin"];
            if (admin == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                AdminName.Text = admin.Username;
                UpdateList();
            }
        }

        /// <summary>
        /// 更新列表
        /// </summary>
        private void UpdateList()
        {
            BookTypeDao bookTypeDao = new BookTypeDao();
            List<BookType> list = bookTypeDao.GetAllBookTypes();
            if (list != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (BookType type in list)
                {
                    sb.AppendFormat(
                        "<tr class='odd gradeX'><td>{0}</td><td>{1}</td><td><div bookId = '{0}' class='btn-group-sm text-center'><button type = 'button' class='btn btn-danger btn_delete' data-toggle='modal' data-target='#confirm-delete'>删除</button></div></td>",
                        type.Id, type.TypeName);
                }
                TypeList = sb.ToString();
            }
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAddBook_Click(object sender, EventArgs e)
        {
            string typeName = TextTypeName.Text.Trim();
            if (string.Empty != typeName)
            {
                BookTypeDao bookTypeDao = new BookTypeDao();
                if (bookTypeDao.AddNewType(typeName))
                {
                    Response.AddHeader("Refresh", "0");
                }
            }
        }

        /// <summary>
        /// 类别删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDeleteBook_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(BookId.Text);
            if (id == 1)
            {
                Response.Write("<script>alert('其他分类为默认分类，无法删除！');</script>");
                return;
            }
            BookTypeDao bookTypeDao = new BookTypeDao();
            // 删除成功
            if (bookTypeDao.DeleteTypeById(id))
            {
                BookDao bookDao = new BookDao();

                // 移动分类
                if (bookDao.RemoveBookToDefaultType(id))
                {
                    Response.AddHeader("Refresh", "0");
                }                
            }
        }
    }

}