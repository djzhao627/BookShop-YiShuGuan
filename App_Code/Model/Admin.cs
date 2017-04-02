using System;

namespace Model
{
    /// <summary>
    /// Admin模型
    /// </summary>
    public class Admin
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public string Username { get; set; }

        public DateTime RegistTime { get; set; }
    }
}