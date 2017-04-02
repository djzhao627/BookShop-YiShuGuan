using System;

namespace Model
{
    /// <summary>
    /// OrderForm模型
    /// </summary>
    public class OrderForm
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public double BookPrice { get; set; }
        public int Count { get; set; }
        public DateTime OrderTime { get; set; }
    }
}