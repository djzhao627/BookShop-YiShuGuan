using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;

namespace Web.Admin.pages
{
    public partial class UpdateBookInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.Admin admin = (Model.Admin)Session["admin"];
            if (admin == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                AdminName.Text = admin.Username;
                //是否是第一次请求，防止缓存
                if (!IsPostBack)
                {
                    UpdatePage();
                }                
            }
        }

        private void UpdatePage()
        {
            int id = 0;
            try
            {
               id  = Convert.ToInt32(Request.QueryString["bookId"]);
            }
            //捕获异常，如果有错就返回上一页
            catch (Exception)
            {
                Response.Write("<script>window.history.go(-1);</script>");
            }
            //实例化一个数据库操作
            BookDao bookDao = new BookDao();

            //通过ID获取书本的详细信息
            BookInfo book = bookDao.GetBookDetailById(id);
            if (book == null)
            {
                //无数据时，返回上一页
                Response.Write("<script>window.history.go(-1);</script>");
            }
            else
            {
                //将这本书的信息写在界面上
                TextAuthor.Text = book.Author;
                TextDescription.Text = book.Description;
                TextImage.Text = book.Image;
                TextName.Text = book.Name;
                TextPrice.Text = book.Price + "";

                for (int i = 0; i < DropDownList.Items.Count; i++)
                {
                    if (Convert.ToInt32(DropDownList.Items[i].Value) == book.TypeId)
                    {
                        DropDownList.SelectedIndex = i;
                    }
                }

            }
        }

        // 更新按钮点击事件
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            //获取现在所编辑的书的ID
            int id = Convert.ToInt32(Request.QueryString["bookId"]);
            //实例化一个数据库操作
            BookDao bookDao = new BookDao();
            //实例化一个模型
            BookInfo book = new BookInfo();
            book.Description = this.TextDescription.Text;
            book.Author = this.TextAuthor.Text;
            book.Image = this.TextImage.Text;
            book.Name = this.TextName.Text;
            book.Price = Convert.ToDouble(this.TextPrice.Text);
            book.TypeId = Convert.ToInt32(DropDownList.SelectedValue);
            book.Id = id;

            if (bookDao.UpdateBookInfo(book))
            {
                //设置样式
                ResultInfo.CssClass = "text-success";
                ResultInfo.Text = "更新成功！";
            }
            else
            {
                ResultInfo.CssClass = "text-danger";
                ResultInfo.Text = "更新失败！";
            }
        }
    }
}