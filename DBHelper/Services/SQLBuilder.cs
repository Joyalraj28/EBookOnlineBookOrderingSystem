using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace DBHelper.Services
{
    public static class Sqlbulider
    {
        public static SqlConnection connection = Getconnectio();

        
        static SqlConnection Getconnectio()
        {

            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build().GetValue<string>("Logging:ConnectionStrings:DefaultConnection");
            return new SqlConnection(configuration);
        }

        public static int? Execute<T>(string query, T model)
        {

            try
            {
               
                    var result = connection.Execute(query, model, commandTimeout: 120);
                    return result;
                
            }
            catch (Exception ex)
            {
                //ShowException(ex, query, model);
            }
            return null;
         }

            //public static  int? Execute<T>(string query, T model)
            //{
            //    return null;
            //}

            //    try
            //    {
            //        using (var db = connection)
            //        {

            //            var result = db.Execute(query, model, commandTimeout: 120);
            //            return result;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //ShowException(ex, query, model);
            //    }


            //    return null;
            //}

            public static int Add<Model>(Model model)
        {
            List<string> data = new List<string>();
            model?.GetType().GetProperties().ToList().ForEach(val =>
            {
                if (val.GetValue(model) is DateTime datatime)
                {

                    data.Add("convert(datetime,'" + datatime.ToString() + "', 105)");
                }
                else
                {
                    data.Add(val.GetValue(model) != null ? "'" + val.GetValue(model)?.ToString() + "'" : "NULL");
                }
            });


            var str = $"Insert into {typeof(Model).Name} Values ({string.Join(',', data)})";

            return connection.Execute($"Insert into {typeof(Model).Name} Values ({string.Join(',', data)})");
        }

        public static int Update<Model>(Model model)
        {
            string Name = "", ID = "";

            List<string> data = new List<string>();
            model?.GetType().GetProperties().ToList().ForEach(val =>
            {
                if (Attribute.GetCustomAttribute(val, typeof(PrimaryKeyAttribute)) is PrimaryKeyAttribute primarykey)
                {
                    Name = val.Name;
                    ID = val.GetValue(model)?.ToString() ?? string.Empty;

                }

                if (val.GetValue(model) is DateTime datatime)
                {

                    data.Add(val.Name + "= convert(datetime,'" + datatime.ToString() + "', 105)");
                }
                else
                {
                    data.Add(val.Name + "=" + (val.GetValue(model) != null ? "'" + val.GetValue(model)?.ToString() + "'" : "NULL"));

                }
            });

            var str = $"Update {typeof(Model).Name} SET {string.Join(',', data)} WHERE {Name} = '{ID}'";

            return connection.Execute($"Update {typeof(Model).Name} SET {string.Join(',', data)} WHERE {Name} = '{ID}'");
        }
        public static int Update1(tblUser user)
        {
            int Status_value = (user.Status == true) ? 1 : 0;
            return connection.Execute($"update tblUser set User_Name = '{user.User_Name}', User_Type = '{user.User_Type}', Password = '{user.Password}',Status = {Status_value},Create_date = '{user.Create_date.ToString("yyyy-MM-dd HH:mm:ss")}',Update_date = '{user.Update_date.ToString("yyyy-MM-dd HH:mm:ss")}' where U_ID = {user.U_ID}");
           
        }

        public static int GetMaxId()
        {
          var id = $"select MAX(U_ID) from tblUser";
          return connection.QueryFirstOrDefault<int>(id);
        }

        public static int Add1(AddUserModel user)
        {
            int MaxId = GetMaxId();
            MaxId = MaxId + 1;
            int Status_Value = (user.Status == true) ? 1 : 0;
            return connection.Execute($"Insert INTO tblUser(U_ID,User_Type,User_Name,Password,Status,Create_date,Update_date) Values ({MaxId},'{user.User_Type}','{user.User_Name}','{user.Password}',{Status_Value},'{user.Create_date.ToString("yyyy-MM-dd HH:mm:ss")}','{user.Update_date.ToString("yyyy-MM-dd HH:mm:ss")}');");


        }
        
        public static int Delete<Model>(Model model)
        {
            string Name = "", ID = "";

            List<string> data = new List<string>();
            model?.GetType().GetProperties().ToList().ForEach(val =>
            {
                if (Attribute.GetCustomAttribute(val, typeof(PrimaryKeyAttribute)) is PrimaryKeyAttribute primarykey)
                {
                    Name = val.Name;
                    ID = val.GetValue(model)?.ToString() ?? string.Empty;

                }

            });

            return connection.Execute($"DELETE {typeof(Model).Name} WHERE {Name} = '{ID}'");
        }


        public static int Delete<Model>(int ID)
        {
            string Name = "";
            var objects = Activator.CreateInstance<Model>();

            objects?.GetType().GetProperties().ToList().ForEach(val =>
            {
                if (Attribute.GetCustomAttribute(val, typeof(PrimaryKeyAttribute)) is PrimaryKeyAttribute primarykey)
                {
                    Name = val.Name;

                }

            });

            return connection.Execute($"DELETE {typeof(Model).Name} WHERE {Name} = '{ID}'");
        }


        public static IEnumerable<Model> Get<Model>()
        {
            return connection.Query<Model>("SELECT * FROM " + typeof(Model).Name);
        }

        public static int Count<Model>()
        {
            return connection.Query<int>("SELECT Count(*) FROM " + typeof(Model).Name).FirstOrDefault();
        }

        public static IEnumerable<T> GetValue<T>(string Type, string value)
        {
            try {
                return connection.Query<T>($"select * from {typeof(T).Name} where {Type} = '{value}'");
            }catch (Exception ex)
            {
                return new List<T>();
            }           
        }

        public static bool IsValidLogin(string userType,string user_name,string password)
        {
            return connection.QueryFirst<int>($"Select Count(*) from tblUser Where User_Name = '{user_name}' AND Password = '{password}' AND User_Type = '{userType}'") > 0;
        }
        
        public static IEnumerable<Model> Get<Model>(int ID)
        {

            string Name = "";
            var objects = Activator.CreateInstance<Model>();

            objects?.GetType().GetProperties().ToList().ForEach(val =>
            {
                if (Attribute.GetCustomAttribute(val, typeof(PrimaryKeyAttribute)) is PrimaryKeyAttribute primarykey)
                {
                    Name = val.Name;

                }

            });
            return connection.Query<Model>("SELECT * FROM " + typeof(Model).Name + " WHERE " + Name + " = '" + ID + "'");
        }

        public static IEnumerable<Model> Procedure<Model>(object param = null)
        {
            return connection.Query<Model>(typeof(Model).Name,param:param,commandType:System.Data.CommandType.StoredProcedure);
        }
    }
}
