using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using common;
using Model;

namespace Dao
{
    /// <summary>
    /// AccountDao 数据库操作类
    /// </summary>
    public class AccountDao
    {
        private string _sql;
        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="account">用户模型</param>
        /// <returns>成功与否</returns>
        public bool InsertAccount(Account account)
        {
            // 查询语句
            _sql = "insert into account (username, password, question, answer, mail, registertime) values (@username, @password, @question, @answer, @mail, getdate())";
            // 参数列表
            SqlParameter[] parameters =
            {
                new SqlParameter("@username", SqlDbType.VarChar),
                new SqlParameter("@password", SqlDbType.VarChar),
                new SqlParameter("@question", SqlDbType.VarChar),
                new SqlParameter("@answer", SqlDbType.VarChar),
                new SqlParameter("@mail", SqlDbType.VarChar)  
            };
            // 列表赋值
            parameters[0].Value = account.Username;
            parameters[1].Value = account.Password;
            parameters[2].Value = account.Question;
            parameters[3].Value = account.Answer;
            parameters[4].Value = account.Mail;
            // 操作
            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 根据ID获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account GetAccountById(int id)
        {
            _sql = "select * from account where id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id), 
            };

            DataTable data = SqlHelper.GetDataTable(_sql, CommandType.Text, parameters);

            if (data.Rows.Count > 0)
            {
                Account account = new Account();
                LoadEntity(account, data.Rows[0]);
                return account;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>bool</returns>
        public bool IsAccountExist(string username)
        {
            _sql = "select count(*) from account where username = @username";
            SqlParameter[] parameters =
            {
                new SqlParameter("@username", SqlDbType.VarChar)
            };
            parameters[0].Value = username;
            return (int)SqlHelper.ExecuteScalar(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="account"></param>
        /// <returns>一个完整的Account实体</returns>
        public Account AccountLogin(Account account)
        {
            _sql = "select id, username, password, question, answer, mail, registertime from account where username = @username and password = @password";
            SqlParameter[] parameters =
            {
                new SqlParameter("@username", SqlDbType.VarChar),
                new SqlParameter("@password", SqlDbType.VarChar)
            };
            parameters[0].Value = account.Username;
            parameters[1].Value = account.Password;
            // 数据存储表
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameters);

            // 如果查找到记录
            if (dataTable.Rows.Count > 0)
            {
                // 填充记录
                LoadEntity(account, dataTable.Rows[0]);
            }
            // 否则返回空
            else
            {
                account = null;
            }
            return account;
        }

        /// <summary>
        /// 根据用户Id更新用户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool UpdateAccountInfoById(Account account)
        {
            _sql =
                "update account set password = @password, question = @question, answer = @answer, mail = @mail where id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@password", account.Password),
                new SqlParameter("@question", account.Question),
                new SqlParameter("@answer", account.Answer),
                new SqlParameter("@mail", account.Mail), 
                new SqlParameter("@id", account.Id), 
            };

            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<Account> GetAllAccounts()
        {
            _sql = "select id, username, password, question, answer, mail, registertime from account";

            DataTable data = SqlHelper.GetDataTable(_sql, CommandType.Text, null);

            if (data.Rows.Count > 0)
            {
                List<Account> list = new List<Account>();
                foreach (DataRow row in data.Rows)
                {
                    Account account = new Account();
                    LoadEntity(account, row);
                    list.Add(account);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteAccountById(int id)
        {
            _sql = "delete from account where id = @id";
            SqlParameter[] pqParameters =
            {
                new SqlParameter("@id", id),
            };
            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, pqParameters) > 0;
        }

        /// <summary>
        /// 装载数据到Account
        /// </summary>
        /// <param name="account">要装载的account</param>
        /// <param name="dataRow">数据来源</param>
        private void LoadEntity(Account account, DataRow dataRow)
        {
            account.Id = Convert.ToInt32(dataRow["id"]);
            account.Username = dataRow["username"].ToString();
            account.Password = dataRow["password"].ToString();
            account.Question = dataRow["question"].ToString();
            account.Answer = dataRow["answer"].ToString();
            account.Mail = dataRow["mail"].ToString();
            account.RegistTime = Convert.ToDateTime(dataRow["registertime"]);
        }
    }
    
}