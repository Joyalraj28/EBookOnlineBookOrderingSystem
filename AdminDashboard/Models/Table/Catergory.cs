using AdminDashboard.SqlAttribute;

namespace AdminDashboard.Models.Table
{
    public class Catergory
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
    }
}