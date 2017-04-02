
using System;

namespace Model
{
    /// <summary>
    /// Account 用户模型
    /// </summary>
    public class Account
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public string Mail { get; set; }

        public string Username { get; set; }

        public DateTime RegistTime { get; set; }
    }

}