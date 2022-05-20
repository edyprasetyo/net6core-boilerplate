

using System.Data;
using NPoco;
using CRMSBI.Helper;

namespace CRMSBI
{
    public class MdlDtl
    {

        public static T GetDataQuery<T>(String sql, params object[] value)
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                return db.SingleOrDefault<T>(sql, value);
            }
        }

        public static T GetData<T>(object primary)
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                return db.SingleOrDefaultById<T>(primary);
            }
        }

        public static Dictionary<string, object> GetDataDictionaryQuery(String sql, params object[] value)
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                return db.SingleOrDefault<Dictionary<string, object>>(sql, value);
            }
        }

        public static List<Dictionary<string, object>> RetrieveListDictionaryQuery(String sql, params object[] value)
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                return db.Fetch<Dictionary<string, object>>(sql, value);
            }
        }

        public static DataTable RetrieveDataTableQuery(String sql, params object[] value)
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                var list = db.Fetch<Dictionary<string, object>>(sql, value);
                return oFunction.DictionaryToDatatable(list);
            }
        }


        public static List<T> RetrieveListQuery<T>(string sql, params string[] value)
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                return db.Fetch<T>(sql, value);
            }
        }

        public static List<T> RetrieveList<T>()
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                return db.Fetch<T>();
            }
        }

        public static List<T> RetrieveList<T>(string filterExpr, params string[] value)
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                object o = Activator.CreateInstance(typeof(T))!;
                TableNameAttribute tableName = (TableNameAttribute)Attribute.GetCustomAttribute(o.GetType(), typeof(TableNameAttribute))!;
                return db.Fetch<T>("SELECT * FROM " + tableName.Value + " WHERE " + filterExpr, value);
            }
        }

        public static int Insert(object model)
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                try
                {
                    oFunction.SetDefaultValueToObjectProperty(model);
                    db.Insert(model);
                    return 1;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public static int Update(object model)
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                try
                {
                    oFunction.SetDefaultValueToObjectProperty(model);
                    return db.Update(model);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public static int Delete<T>(object primaryKey)
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                try
                {
                    return db.Delete<T>(primaryKey);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public static T ExecuteScalar<T>(String sql, params object[] value)
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                return db.ExecuteScalar<T>(sql, value);
            }
        }

        public static int Execute(String sql, params object[] value)
        {
            using (IDatabase db = oFunction.GetConnection())
            {
                return db.Execute(sql, value);
            }
        }


    }
}
