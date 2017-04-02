using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Model;

namespace Web
{
    public partial class WebBookDetial : System.Web.UI.Page
    {
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string BookImage { get; set; }
        public string BookAuthor { get; set; }
        public double BookPrice { get; set; }
        public string BookType { get; set; }
        public int BookId { get; set; }
        

        protected void Page_Load(object sender, EventArgs e)
        {        
            // 传参异常捕获
            try
            {
                // 获取get的传参
                BookId = Convert.ToInt32(Request.QueryString["id"]);
            }
            catch (Exception)
            {
                Response.Redirect("./Main.aspx");
            }
            // id值不可为负数
            if (BookId <= 0)
            {
                Response.Redirect("./Main.aspx");
            }

            BookDao bookDao = new BookDao();
            // 获取图书详情
            BookInfo bookInfo = bookDao.GetBookDetailById(BookId);
            // 展示到页面
            BookAuthor = bookInfo.Author;
            BookDescription = bookInfo.Description;
            BookImage = bookInfo.Image;
            BookPrice = bookInfo.Price;
            BookTitle = bookInfo.Name;
            BookType = bookInfo.TypeName;
        }

        // 添加到购物车
        protected void BtnAddToCart_Click(object sender, EventArgs e)
        {
            // 判断是否已经有用户登录
            if (Session["account"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            int num = 0;
            try
            {
                num = Convert.ToInt32(BuyNumber.Text);
            }
            catch (Exception)
            {
                BuyNumber.Text = "0";
                return;
            }
            // 根据Session获取用户ID，进行商品的添加
            Account account = (Account) Session["account"];
            OrderDao orderDao = new OrderDao();
            // 添加到数据库
            if (orderDao.AddNewOrder(account.Id, BookId, num))
            {
                ErrorInfo.CssClass = "text-primary";
                ErrorInfo.Text = "商品已经添加～";
            }
            else
            {
                ErrorInfo.Text = "加入购物车失败 = =";
            }
        }
    }

}