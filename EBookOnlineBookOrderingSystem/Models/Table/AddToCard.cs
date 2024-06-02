using EBookOnlineBookOrderingSystem.SqlAttribute;

namespace EBookOnlineBookOrderingSystem.Models.Table
{
    public class AddToCard
    {
        [PrimaryKey]
        public int id { get; set; }
        public double price { get; set; }
        public int bookid { get; set; }
        public int userid { get; set; }
        public int quantity { get; set; }
    }
}