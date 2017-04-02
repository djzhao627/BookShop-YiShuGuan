using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using common;
using Model;

namespace Dao
{
    /// <summary>
    /// 图书类别数据库操作类
    /// </summary>
    public class BookTypeDao
    {
        private string _sql = "";

        /// <summary>
        /// 获取所有类别
        /// </summary>
        /// <returns></returns>
        public List<BookType> GetAllBookTypes()
        {
            _sql = "select id, typeName from bookType";

            DataTable data = SqlHelper.GetDataTable(_sql, CommandType.Text);
            if (data.Rows.Count > 0)
            {
                List<BookType> list = new List<BookType>();
                foreach (DataRow row in data.Rows)
                {
                    BookType type = new BookType();
                    LoadEntity(type, row);
                    list.Add(type);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 实体装载
        /// </summary>
        /// <param name="type">目标</param>
        /// <param name="row">源</param>
        private void LoadEntity(BookType type, DataRow row)
        {
            type.Id = Convert.ToInt32(row["id"]);
            type.TypeName = row["typeName"].ToString();
        }

        /// <summary>
        /// 添加一个分类
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public bool AddNewType(string typeName)
        {
            _sql =
                "if not exists(select id from bookType where typeName = @typeName) begin insert into bookType (typeName) values (@typeName) end";

            SqlParameter[] parameters =
            {
                new SqlParameter("@typeName", typeName), 
            };

            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 根据ID删除一个分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteTypeById(int id)
        {
            _sql = "delete from bookType where id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id), 
            };
            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }
    }
}