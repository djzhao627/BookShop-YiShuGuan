using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Model;

namespace Web
{
    public partial class Search : System.Web.UI.Page
    {
        public string ResultList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // 获取get传递过来的搜索关键字
            string keyword = Request.QueryString["key"];
            // 错误检验
            if (keyword == null || string.Empty == keyword.Trim())
            {
                EmptyInfo.Text = "没有结果～";
            }
            else
            {
                //实例一个bookDao数据访问对象，是一个面向对象的数据库接口
                BookDao bookDao = new BookDao();
                // 根据关键字获取结果
                List<BookInfo> list = bookDao.SearchBookWithKeyword(keyword.Trim());
                // 如果为null，说明该关键字无法查询到相关记录
                if (list == null)
                {
                    EmptyInfo.Text = "没有结果～";
                }
                else
                {
                    // 将查询结果封装成字符串
                    StringBuilder sb = new StringBuilder();
                    // 列表计数器
                    int counter = 1;
                    // 遍历集合
                    foreach (BookInfo book in list)
                    {
                        // 生成html代码
                        sb.AppendFormat(
                            "<tr><td>{0}</td ><td ><a href ='BookDetial.aspx?id={1}'><img alt = '' class='book_image' src='{2}'/></a></td><td class='text-primary'><a href = 'BookDetial.aspx?id={1}' >{3}</a></td><td class='text-danger'>{4}</td><td class='text-success'>{5}</td><td class='text-danger'>￥{6}</td></tr>", counter++, book.Id, book.Image, book.Name, book.Author, book.Description, book.Price);
                    }
                    // 返回给浏览器进行解析
                    ResultList = sb.ToString();
                }
            }
        }
    }

}