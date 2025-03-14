﻿using EBookOnlineBookOrderingSystem.SqlAttribute;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using EBookOnlineBookOrderingSystem.Models.Table;

namespace EBookOnlineBookOrderingSystem.Services
{
    public static class Sqlbulider
    {
        public static SqlConnection connection = Getconnection();

        static SqlConnection Getconnection()
        {
            var connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            return new SqlConnection(connection);
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

        public static int Add<Model>(Model model)
        {
            List<string> data = new List<string>();
            model?.GetType().GetProperties().ToList().ForEach(val =>
            {
                if (val.GetValue(model) is DateTime datatime)
                {

                    data.Add("convert(datetime,'" + datatime.ToString() + "')");
                }
                else
                {
                    data.Add(val.GetValue(model) != null ? "'" + val.GetValue(model)?.ToString() + "'" : "NULL");
                }
            });


            var str = $"Insert into {typeof(Model).Name} Values ({string.Join(",", data)})";

            return connection.Execute($"Insert into {typeof(Model).Name} Values ({string.Join(",", data)})");
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

                    data.Add(val.Name + "= convert(datetime,'" + datatime.ToString() + "')");
                }
                else
                {
                    data.Add(val.Name + "=" + (val.GetValue(model) != null ? "'" + val.GetValue(model)?.ToString() + "'" : "NULL"));

                }
            });

            var str = $"Update {typeof(Model).Name} SET {string.Join(",", data)} WHERE {Name} = '{ID}'";

            return connection.Execute($"Update {typeof(Model).Name} SET {string.Join(",", data)} WHERE {Name} = '{ID}'");
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

        public static int IsValidUser(Users user)
        {
            return connection.Query<int>("SELECT Count(*) FROM Users where email = '" + user.email+"' and '"+user.password+"'").FirstOrDefault();
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

        public static IEnumerable<T> GetValue<T>(string Type1, string value1, string Type2, string value2)
        {
            try
            {
                return connection.Query<T>($"select * from {typeof(T).Name} where {Type1} = '{value1}' and {Type2} = '{value2}'");
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }

        public static IEnumerable<T> GetValue<T>(string Type1, string value1, string Type2, string value2, string Type3, string value3)
        {
            try
            {
                return connection.Query<T>($"select * from {typeof(T).Name} where {Type1} = '{value1}' and {Type2} = '{value2}' and {Type3} = '{value3}'");
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
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
