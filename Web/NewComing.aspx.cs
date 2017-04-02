using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;

namespace Web
{
    public partial class NewComing : System.Web.UI.Page
    {
        public string BestSaleBook { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BookDao bookDao = new BookDao();
            List<BookInfo> list = bookDao.GetNewComingBook();
            if (list != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (BookInfo book in list)
                {
                    stringBuilder.AppendFormat("<div class='book'><a href = './BookDetial.aspx?id={0}' ><img src = '{1}' /><h4 class='title' alt='{2}'>{2}</h4><small class='text-info' alt='{3}'>{3} </small><p class='text-danger'>￥{4}</p></a></div>", book.Id, book.Image, book.Name, book.Author, book.Price);
                }
                BestSaleBook = stringBuilder.ToString();
            }
        }
    }
}