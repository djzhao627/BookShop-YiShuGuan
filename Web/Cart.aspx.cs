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
    public partial class Cart : System.Web.UI.Page
    {
        public string OrderList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 验证当前是否有用户登录
            Account account = (Account)Session["account"];
            // 未登录则禁止访问本页，跳转到登录页面
            if (account == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                AccountName.Text = account.Username;
                OrderDao orderDao = new OrderDao();
                // 通过用户ID获取订单
                List<OrderForm> list = orderDao.GetOrderFormsByAccountId(account.Id);

                if (list != null)
                {
                    // 套接字符串
                    StringBuilder sbBuilder = new StringBuilder();
                    int counter = 1;
                    foreach (OrderForm order in list)
                    {
                        // 生成html
                        sbBuilder.AppendFormat(
                            "<tr><td>{0}</ td><td><img alt = '' class='book_image'src='{1}'/></td><td class='text-primary'><a href='BookDetial.aspx?id={6}'>{2}</a></td><td class='text-danger'>￥{3}</td><td class='text-success'>{4}</td><td class='text-danger'>{5}</td><td><input class='btn btn-danger delete_book' data-toggle='modal' data-target='#confirm-delete' bookId='{6}' bookName='{2}' value='删除' type='button' /></td></tr>", counter++, order.BookImage, order.BookName, order.BookPrice, order.Count, order.OrderTime, order.Id);
                    }
                    // 返回给浏览器
                    OrderList = sbBuilder.ToString();
                }
                else
                {
                    EmptyInfo.Text = "您的购物车里还没有东西哦～";
                }
            }
        }

        /// <summary>
        /// 删除一条订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDeleteBook_Click(object sender, EventArgs e)
        {
            OrderDao orderDao = new OrderDao();
            if (orderDao.DeleteOrderById(Convert.ToInt32(BookId.Text)))
            {
                // 刷新当前页
                Response.AddHeader("Refresh", "0");
            }

        }
    }

}