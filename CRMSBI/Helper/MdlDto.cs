

using System.Data;
using NPoco;
using CRMSBI.Helper;

namespace CRMSBI
{
    public class MdlDto
    {
        IDatabase db;
        public MdlDto(IDatabase db)
        {
            this.db = db;
        }

        public T GetDataQuery<T>(String sql, params object[] value)
        {
            return db.SingleOrDefault<T>(sql, value);
        }

        public T GetData<T>(object primary)
        {
            return db.SingleOrDefaultById<T>(primary);
        }

        public Dictionary<string, object> GetDataDictionaryQuery(String sql, params object[] value)
        {
            return db.SingleOrDefault<Dictionary<string, object>>(sql, value);
        }

        public List<Dictionary<string, object>> RetrieveListDictionaryQuery(String sql, params object[] value)
        {
            return db.Fetch<Dictionary<string, object>>(sql, value);
        }

        public DataTable RetrieveDataTableQuery(String sql, params object[] value)
        {
            var list = db.Fetch<Dictionary<string, object>>(sql, value);
            return oFunction.DictionaryToDatatable(list);
        }


        public List<T> RetrieveListQuery<T>(string sql, params string[] value)
        {
            return db.Fetch<T>(sql, value);
        }

        public List<T> RetrieveList<T>()
        {
            return db.Fetch<T>();
        }

        public List<T> RetrieveList<T>(string filterExpr, params string[] value)
        {
            object o = Activator.CreateInstance(typeof(T))!;
            TableNameAttribute tableName = (TableNameAttribute)Attribute.GetCustomAttribute(o.GetType(), typeof(TableNameAttribute))!;
            return db.Fetch<T>("SELECT * FROM " + tableName.Value + " WHERE " + filterExpr, value);
        }

        public int Insert(object model)
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

        public int Update(object model)
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

        public int Delete<T>(object primaryKey)
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

        public T ExecuteScalar<T>(String sql, params object[] value)
        {
            return db.ExecuteScalar<T>(sql, value);
        }

        public int Execute(String sql, params object[] value)
        {
            return db.Execute(sql, value);
        }


    }
}
