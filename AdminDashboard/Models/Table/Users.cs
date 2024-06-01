using AdminDashboard.SqlAttribute;

namespace AdminDashboard.Models.Table
{
    public class Users
    {
        [PrimaryKey]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int phoneNo { get; set; }
        public int email { get; set; }
        public string usertype { get; set; }
    }
}