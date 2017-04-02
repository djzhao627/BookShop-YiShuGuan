using System;
using System.Data;
using System.Data.SqlClient;
using common;
using Model;

namespace Dao
{
    public class AdminDao
    {
        private string _sql;
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>一个完整的Admin实体</returns>
        public Admin AdminLogin(Admin admin)
        {
            _sql = "select id, username, password, mail, registertime from admin where username = @username and password = @password";
            SqlParameter[] parameters =
            {
                new SqlParameter("@username", SqlDbType.VarChar),
                new SqlParameter("@password", SqlDbType.VarChar)
            };
            parameters[0].Value = admin.Username;
            parameters[1].Value = admin.Password;
            // 数据存储表
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameters);

            // 如果查找到记录
            if (dataTable.Rows.Count > 0)
            {
                // 填充记录
                LoadEntity(admin, dataTable.Rows[0]);
            }
            // 否则返回空
            else
            {
                admin = null;
            }
            return admin;
        }

        /// <summary>
        /// 装载数据到Admin
        /// </summary>
        /// <param name="admin">要装载的Admin</param>
        /// <param name="dataRow">数据来源</param>
        private void LoadEntity(Admin admin, DataRow dataRow)
        {
            admin.Id = Convert.ToInt32(dataRow["id"]);
            admin.Username = dataRow["username"].ToString();
            admin.Password = dataRow["password"].ToString();
            admin.Mail = dataRow["mail"].ToString();
            admin.RegistTime = Convert.ToDateTime(dataRow["registertime"]);
        }
    }
}