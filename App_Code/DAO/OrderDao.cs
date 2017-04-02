using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using common;
using Model;

namespace Dao
{
    /// <summary>
    /// OrderDao数据库操作类
    /// </summary>
    public class OrderDao
    {
        private string _sql;

        /// <summary>
        /// 添加新的订单
        /// </summary>
        /// <param name="accountId">用户id</param>
        /// <param name="bookId">图书id</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public bool AddNewOrder(int accountId, int bookId, int count)
        {
            _sql =
                "insert into orderForm (accountId, bookId, count, orderTime) values (@accountId, @bookId, @count, getdate())";
            SqlParameter[] parameters =
            {
                new SqlParameter("@accountId", accountId),
                new SqlParameter("@bookId", bookId),
                new SqlParameter("@count", count),
            };

            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 通过用户ID获取购物车列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<OrderForm> GetOrderFormsByAccountId(int id)
        {
            _sql =
                "select orderForm.id as id, name, image, price, count, orderTime from bookInfo, orderForm where accountId = @accountId and bookId = bookInfo.id ";

            SqlParameter[] parameters =
            {
                new SqlParameter("@accountId", id),
            };

            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameters);
            List<OrderForm> list = null;
            if (dataTable.Rows.Count > 0)
            {
                list = new List<OrderForm>();
                foreach (DataRow row in dataTable.Rows)
                {
                    OrderForm order = new OrderForm();
                    LoadEntity(order, row);
                    list.Add(order);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据ID删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteOrderById(int id)
        {
            _sql = "delete from orderForm where id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id),
            };

            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 实体装载
        /// </summary>
        /// <param name="order">装载的对象</param>
        /// <param name="row">数据源</param>
        private void LoadEntity(OrderForm order, DataRow row)
        {
            order.Count = Convert.ToInt32(row["count"]);
            order.Id = Convert.ToInt32(row["id"]);
            order.BookImage = row["image"].ToString();
            order.BookName = row["name"].ToString();
            order.BookPrice = Convert.ToDouble(row["price"]);
            order.OrderTime = Convert.ToDateTime(row["orderTime"]);
        }
    }
}