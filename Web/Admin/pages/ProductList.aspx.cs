using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;

namespace Web.Admin.pages
{
    public partial class ProductList : System.Web.UI.Page
    {
        //用来生成用户列表的html标签
        public string ProductsList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //在Session中取admin对象
            Model.Admin admin = (Model.Admin)Session["admin"];
            //判断是否已经登录
            if (admin == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //将登入管理系统的管理员名显示在右上角处
                AdminName.Text = admin.Username;
                //刷新列表
                UpdateList();
            }
        }

        private void UpdateList()
        {
            //实例化一个bookDao
            //Dao数据库访问操作
            BookDao bookDao = new BookDao();
            //通过bookDao对象取出所有的书的信息
            List<BookInfo> list = bookDao.GetAllBooks();
            if (list != null)
            {
                StringBuilder sb = new StringBuilder();
                //遍历列表
                foreach (BookInfo book in list)
                {
                    //生成html
                    sb.AppendFormat("<tr class='odd gradeX'><td>{0}</td><td style='width:20%;'><img width='99%' src='{4}'/></td><td>{1}</td><td>{2}</td><td>{3}</td><td>{5}</td><td>{6}</td><td><div bookId = '{0}' class='btn-group-sm text-center'><button type = 'button' class='btn btn-success btn_update'>编辑</button><p> </p><button type = 'button' class='btn btn-danger btn_delete' data-toggle='modal' data-target='#confirm-delete'>删除</button></div></td>",  book.Id, book.Name, book.Author, book.Description, book.Image, book.Price, book.TypeName);
                }
                //返回给页面
                ProductsList = sb.ToString();
            }
        }

        // 添加图书
        protected void BtnAddBook_Click(object sender, EventArgs e)
        {
            BookInfo book = new BookInfo();
            book.Author = TextBookAuthor.Text;
            book.Description = TextBookDescription.Text;
            book.Image = TextBookImage.Text;
            book.Name = TextBookName.Text;
            book.TypeId = Convert.ToInt32(DropDownList1.SelectedValue);
            book.Price = Convert.ToDouble(TextBookPrice.Text);
            //实例化一个bookDao
            //Dao数据库访问操作
            BookDao bookDao = new BookDao();
            if (bookDao.AddNewBook(book))
            {
                Response.AddHeader("Refresh", "0");
            }
        }

        // 删除图书
        protected void BtnDeleteBook_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(BookId.Text);
            //实例化一个bookDao
            BookDao bookDao = new BookDao();
            //调用删除方法删除图书
            if (bookDao.DeleteBookById(id))
            {
                //刷新当前页 0为立即刷新
                Response.AddHeader("Refresh", "0");
            }
        }
    }
}