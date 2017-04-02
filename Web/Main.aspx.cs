using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;

namespace Web
{
    public partial class Main : System.Web.UI.Page
    {
        /// <summary>
        /// 热搜图书占位符
        /// </summary>
        public string HotSearch { get; set; }

        /// <summary>
        /// 新书上架占位符
        /// </summary>
        public string NewComing { get; set; }

        /// <summary>
        /// 推荐书籍占位符
        /// </summary>
        public string RecommendBooks { get; set; }

        /// <summary>
        /// 图书类别占位符
        /// </summary>
        public string BookType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            int typeId;
            try
            {
                typeId = Convert.ToInt32(Request.QueryString["typeId"]);
            }
            catch (Exception)
            {
                typeId = -1;
            }

            if (typeId <= 0)
            {
                typeId = -1;
            }

            BookDao bookDao = new BookDao();
            // 图书集合
            List<BookInfo> list;

            // 热搜图书
            list = bookDao.GetHotSearchTop10(typeId);
            if (list != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (BookInfo book in list)
                {
                    stringBuilder.AppendFormat("<div class='book'><a href = './BookDetial.aspx?id={0}' ><img src = '{1}' /><h4 class='title' alt='{2}'>{2}</h4><small class='text-info' alt='{3}'>{3} </small><p class='text-danger'>￥{4}</p></a></div>", book.Id, book.Image, book.Name, book.Author, book.Price);
                }
                HotSearch = stringBuilder.ToString();
            }
            else
            {
                HotSearch = "<h3 class='text-warning'>热搜图书暂无数据...</h3>";
            }

            // 新上架图书
            list = bookDao.GetNewComingTop10(typeId);
            if (list != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (BookInfo book in list)
                {
                    stringBuilder.AppendFormat("<div class='book'><a href = './BookDetial.aspx?id={0}' ><img src = '{1}' /><h4 class='title' alt='{2}'>{2}</h4><small class='text-info' alt='{3}'>{3} </small><p class='text-danger'>￥{4}</p></a></div>", book.Id, book.Image, book.Name, book.Author, book.Price);
                }
                NewComing = stringBuilder.ToString();
            }
            else
            {
                NewComing = "<h3 class='text-warning'>新上架图书暂无数据...</h3>";
            }

            // 推荐图书
            list = bookDao.GetRecommendBooksTop10(typeId);
            if (list != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (BookInfo book in list)
                {
                    stringBuilder.AppendFormat("<div class='book'><a href = './BookDetial.aspx?id={0}' ><img src = '{1}' /><h4 class='title' alt='{2}'>{2}</h4><small class='text-info' alt='{3}'>{3} </small><p class='text-danger'>￥{4}</p></a></div>", book.Id, book.Image, book.Name, book.Author, book.Price);
                }
                RecommendBooks = stringBuilder.ToString();
            }
            else
            {
                RecommendBooks = "<h3 class='text-warning'>推荐图书暂无数据...</h3>";
            }

            // 左侧类别栏
            BookTypeDao bookTypeDao = new BookTypeDao();
            List<BookType> types = bookTypeDao.GetAllBookTypes();
            if (types != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach ( BookType type in types)
                {
                    sb.AppendFormat(
                        "<a href='Main.aspx?typeId={0}' class='list-group-item'><i class='fa fa-comment fa-fw'></i>{1}</a>",
                        type.Id, type.TypeName);
                }
                BookType = sb.ToString();
            }
        }
    }
}