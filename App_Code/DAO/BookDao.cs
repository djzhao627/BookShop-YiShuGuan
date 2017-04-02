using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using common;
using Model;

namespace Dao
{
    /// <summary>
    /// BookDao数据库操作类
    /// </summary>
    public class BookDao
    {
        private string _sql;

        /// <summary>
        /// 获取热搜图书列表
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public List<BookInfo> GetHotSearchTop10(int typeId)
        {
            // 查询语句
            _sql = "select top 10 a.id as id, name, author, price, image, description, typeName, type from bookInfo a, bookType b where a.type = b.id and type = @type";
            SqlParameter[] parameter =
            {
                new SqlParameter("type", typeId),
            };
            if (typeId == -1)
            {
                _sql = "select top 10 a.id as id, name, author, price, image, description, typeName, type from bookInfo a, bookType b where a.type = b.id";
                parameter = null;
            }
            // 获取数据
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameter);

            List<BookInfo> list = null;
            // 如果存在数据
            if (dataTable.Rows.Count > 0)
            {
                list = new List<BookInfo>();
                foreach (DataRow row in dataTable.Rows)
                {
                    BookInfo bookInfo = new BookInfo();
                    // 数据填充
                    LoadEntity(bookInfo, row);
                    // 加入集合
                    list.Add(bookInfo);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取新书上架列表
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public List<BookInfo> GetNewComingTop10(int typeId)
        {
            // 查询语句（只取偶数行）
            _sql = "select top 10 a.id as id, name, author, price, image, description, typeName, type from bookInfo a, bookType b where a.type = b.id and a.id % 2 = 0 and type = @type";
            SqlParameter[] parameter =
            {
                new SqlParameter("type", typeId),
            };
            if (typeId == -1)
            {
                _sql = "select top 10 a.id as id, name, author, price, image, description, typeName, type from bookInfo a, bookType b where a.type = b.id and a.id % 2 = 0";
                parameter = null;
            }
            // 获取数据
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameter);

            List<BookInfo> list = null;
            // 如果存在数据
            if (dataTable.Rows.Count > 0)
            {
                list = new List<BookInfo>();
                foreach (DataRow row in dataTable.Rows)
                {
                    BookInfo bookInfo = new BookInfo();
                    // 数据填充
                    LoadEntity(bookInfo, row);
                    // 加入集合
                    list.Add(bookInfo);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取推荐图书列表
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public List<BookInfo> GetRecommendBooksTop10(int typeId)
        {
            // 查询语句（只取奇数行）
            _sql = "select top 10 a.id as id, name, author, price, image, description, typeName, type from bookInfo a, bookType b where a.type = b.id and a.id % 2 = 1 and type = @type";
            SqlParameter[] parameter =
            {
                new SqlParameter("type", typeId),
            };
            if (typeId == -1)
            {
                _sql = "select top 10 a.id as id, name, author, price, image, description, typeName, type from bookInfo a, bookType b where a.type = b.id and a.id % 2 = 1";
                parameter = null;
            }
            // 获取数据
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameter);

            List<BookInfo> list = null;
            // 如果存在数据
            if (dataTable.Rows.Count > 0)
            {
                list = new List<BookInfo>();
                foreach (DataRow row in dataTable.Rows)
                {
                    BookInfo bookInfo = new BookInfo();
                    // 数据填充
                    LoadEntity(bookInfo, row);
                    // 加入集合
                    list.Add(bookInfo);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过id获取书籍详细信息
        /// </summary>
        /// <param name="id">书籍id</param>
        /// <returns></returns>
        public BookInfo GetBookDetailById(int id)
        {
            _sql = "select a.id as id, name, author, price, image, description, typeName, type from bookInfo a, bookType b where a.id = @id and a.type = b.id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id),
            };
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameters);

            if (dataTable.Rows.Count > 0)
            {
                BookInfo bookInfo = new BookInfo();
                LoadEntity(bookInfo, dataTable.Rows[0]);
                return bookInfo;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据关键字搜索图书
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<BookInfo> SearchBookWithKeyword(string keyword)
        {
            _sql =
                "select a.id as id, name, author, price, image, description, typeName, type from bookInfo a, bookType b where (name like '%' + @keyword + '%' or author like '%' + @keyword + '%' or description like '%' + @keyword + '%' or typeName like '%' + @keyword + '%') and a.type = b.id";
            //  
            SqlParameter[] parameters =
            {
                new SqlParameter("@keyword", keyword),
            };
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameters);

            if (dataTable.Rows.Count > 0)
            {
                List<BookInfo> list = new List<BookInfo>();
                foreach (DataRow row in dataTable.Rows)
                {
                    BookInfo book = new BookInfo();
                    LoadEntity(book, row);
                    list.Add(book);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 插入新的图书
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool AddNewBook(BookInfo book)
        {
            _sql =
                "insert into bookInfo (name, author, price, image, description, type) values (@name, @author, @price, @image, @description, @type)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", book.Name),
                new SqlParameter("@author", book.Author),
                new SqlParameter("@price", book.Price),
                new SqlParameter("@image", book.Image),
                new SqlParameter("@description", book.Description),
                new SqlParameter("@type", book.TypeId),
            };
            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 获取所有图书
        /// </summary>
        /// <returns></returns>
        public List<BookInfo> GetAllBooks()
        {
            _sql = "select a.id as id, name, author, price, image, description, typeName, type from bookInfo a, bookType b where a.type = b.id";
            DataTable data = SqlHelper.GetDataTable(_sql, CommandType.Text);

            if (data.Rows.Count > 0)
            {
                List<BookInfo> list = new List<BookInfo>();
                foreach (DataRow row in data.Rows)
                {
                    BookInfo book = new BookInfo();
                    LoadEntity(book, row);
                    list.Add(book);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据id删除图书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteBookById(int id)
        {
            _sql = "delete from bookInfo where id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id),
            };
            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 更新图书信息
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool UpdateBookInfo(BookInfo book)
        {
            _sql =
                "update bookInfo set name = @name, author = @author, price = @price, image = @image, description = @description, type = @type where id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", book.Name),
                new SqlParameter("@author", book.Author),
                new SqlParameter("@price", book.Price),
                new SqlParameter("@image", book.Image),
                new SqlParameter("@description", book.Description),
                new SqlParameter("@type", book.TypeId),
                new SqlParameter("@id", book.Id),
            };
            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }
        /// <summary>
        /// 实体装载
        /// </summary>
        /// <param name="book">需要转载的对象</param>
        /// <param name="row">数据源</param>
        public void LoadEntity(BookInfo book, DataRow row)
        {
            book.Id = Convert.ToInt32(row["id"]);
            book.Name = row["name"].ToString();
            book.Author = row["author"].ToString();
            book.Image = row["image"].ToString();
            book.Price = Convert.ToDouble(row["price"]);
            book.Description = row["description"].ToString();
            book.TypeName = row["typeName"].ToString();
            book.TypeId = Convert.ToInt32(row["type"]);
        }

        /// <summary>
        /// 将图书移动到默认分类（分类：其他）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveBookToDefaultType(int id)
        {
            _sql = "update bookInfo set type = 1 where type = @type";
            SqlParameter[] parameters =
            {
                new SqlParameter("@type", id), 
            };
            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 获取畅销图书
        /// </summary>
        /// <returns></returns>
        public List<BookInfo> GetBestSale()
        {
            // 查询语句
            _sql = "select top 50 a.id as id, name, author, price, image, description, typeName, type from bookInfo a, bookType b where a.type = b.id";
            
            // 获取数据
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text);

            List<BookInfo> list = null;
            // 如果存在数据
            if (dataTable.Rows.Count > 0)
            {
                list = new List<BookInfo>();
                foreach (DataRow row in dataTable.Rows)
                {
                    BookInfo bookInfo = new BookInfo();
                    // 数据填充
                    LoadEntity(bookInfo, row);
                    // 加入集合
                    list.Add(bookInfo);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取新品图书
        /// </summary>
        /// <returns></returns>
        public List<BookInfo> GetNewComingBook()
        {
            // 查询语句
            _sql = "select top 50 a.id as id, name, author, price, image, description, typeName, type from bookInfo a, bookType b where a.type = b.id order by a.id desc";

            // 获取数据
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text);

            List<BookInfo> list = null;
            // 如果存在数据
            if (dataTable.Rows.Count > 0)
            {
                list = new List<BookInfo>();
                foreach (DataRow row in dataTable.Rows)
                {
                    BookInfo bookInfo = new BookInfo();
                    // 数据填充
                    LoadEntity(bookInfo, row);
                    // 加入集合
                    list.Add(bookInfo);
                }
            }
            return list;
        }
    }
}