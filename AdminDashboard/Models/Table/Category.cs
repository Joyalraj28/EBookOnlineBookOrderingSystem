using AdminDashboard.SqlAttribute;

namespace AdminDashboard.Models.Table
{
    public class Category
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
    }
}