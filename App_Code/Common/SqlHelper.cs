
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace common
{
    /// <summary>
    /// SqlHelper Sql工具类
    /// </summary>
    public class SqlHelper
    {
        // 连接字符串
        private static readonly string ConStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        // 数据库连接
        private static SqlConnection _conn;

        /// <summary>
        /// 析构函数，释放资源
        /// </summary>
        ~SqlHelper()
        {
            if (_conn != null)
            {
                _conn.Close();
            }
        }

        /// <summary>
        /// 打开一个连接
        /// </summary>
        private static void Open()
        {
            if (_conn == null)
            {
                _conn = new SqlConnection(ConStr);
                _conn.Open();
            }
            else
            {
                if (_conn.State.Equals(ConnectionState.Closed))
                {
                    _conn.Open();
                }
            }
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConn()
        {
            if (_conn == null)
            {
                _conn = new SqlConnection(ConStr);
            }
            return _conn;
        }

        /// <summary>
        /// 查询方法的封装
        /// </summary>
        /// <param name="sql">sql语句，或者存储过程指令</param>
        /// <param name="type">指定sql的类型</param>
        /// <param name="pars">参数集</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable(string sql, CommandType type, params SqlParameter[] pars)
        {
            // 创建一个连接

            using (_conn = new SqlConnection(ConStr))
            {
                // 创建适配器
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, _conn))
                {
                    // 如果有参数
                    if (pars != null)
                    {
                        // 设置参数
                        adapter.SelectCommand.Parameters.AddRange(pars);
                    }
                    // 设置sql类型，可能传过来的是一个存储过程
                    adapter.SelectCommand.CommandType = type;

                    DataTable dataTable = new DataTable();

                    // 适配器填充
                    adapter.Fill(dataTable);

                    // 返回
                    return dataTable;
                }
            }
        }

        /// <summary>
        /// 返回受影响行数
        /// </summary>
        /// <param name="sql">sql语句，或者存储过程指令</param>
        /// <param name="type">指定sql的类型</param>
        /// <param name="pars">参数集</param>
        /// <returns>int</returns>
        public static int ExecuteNonquery(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (_conn = new SqlConnection(ConStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    // 如果存在参数
                    if (pars != null)
                    {
                        // 设置参数
                        cmd.Parameters.AddRange(pars);
                    }
                    // 设置类型
                    cmd.CommandType = type;

                    // 打开数据库连接
                    _conn.Open();

                    // 返回结果
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 返回数据记录中的第一行，第一列单元内的值。
        /// </summary>
        /// <param name="sql">sql语句，或者存储过程指令</param>
        /// <param name="type">指定sql的类型</param>
        /// <param name="pars">参数集</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (_conn = new SqlConnection(ConStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    cmd.CommandType = type;

                    _conn.Open();

                    return cmd.ExecuteScalar();
                }
            }
        }
    }

}