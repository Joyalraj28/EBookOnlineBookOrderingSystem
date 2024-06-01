using AdminDashboard.SqlAttribute;

namespace AdminDashboard.Models.Table
{
    public class MOrder
    {
        [PrimaryKey]
        public int id { get; set; }
        public double price { get; set; }
        public string paymenttype { get; set; }
        public int bookid { get; set; }
        public int morderid { get; set; }

    }
}