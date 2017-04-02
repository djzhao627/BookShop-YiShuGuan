namespace Model
{
    /// <summary>
    /// 图书信息模型
    /// </summary>
    public class BookInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
    }
}