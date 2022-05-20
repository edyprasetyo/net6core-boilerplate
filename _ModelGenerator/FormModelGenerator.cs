using NPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelGenerator
{
    public partial class FormModelGenerator : Form
    {
        string dbName = "CRMSBI";
        string projectName = "CRMSBI";
        string server = "CSMDEVS";
        string login = "app";
        string password = "D3veloper!";

        public string GetCSharpHeader()
        {
            string q = "";
            q += " using " + projectName + ".Helper;" + Environment.NewLine;
            q += " using NPoco;" + Environment.NewLine;
            q += " using System;" + Environment.NewLine;
            q += " " + Environment.NewLine;
            q += " namespace " + projectName + ".Data" + Environment.NewLine;
            q += " {" + Environment.NewLine;
            return q;
        }

        public string GetFlutterHeader()
        {
            string q = "";
            q += " import \"dart:convert\";" + Environment.NewLine;
            q += " import \"package:flutter/foundation.dart\";" + Environment.NewLine;
            q += " import \"../helper/tools.dart\";" + Environment.NewLine;
            return q;
        }

        public string GetModelControllerHeader()
        {
            string q = "";
            q += " using " + projectName + ".Data;" + Environment.NewLine;
            q += " using System;" + Environment.NewLine;
            q += " using System.Web.Mvc;" + Environment.NewLine;
            q += " " + Environment.NewLine;
            q += " namespace " + projectName + ".Controllers " + Environment.NewLine;
            q += " { " + Environment.NewLine;
            return q;
        }

        public FormModelGenerator()
        {
            InitializeComponent();
            InitcboLanguage();
            InitcboTableName();  
        }

        public void InitcboTableName()
        {
            var oList = new List<string>();
            foreach (var o in GetAllTableName())
            {
                oList.Add(o["TableName"].ToString());
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = oList;
            cboTable.DataSource = bs;
            cboTable.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void InitcboLanguage()
        {
            var oList = new List<string>();
            oList.Add("C#");
            oList.Add("Flutter");
            BindingSource bs = new BindingSource();
            bs.DataSource = oList;
            cboLanguage.DataSource = bs;
            cboLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public List<Dictionary<string, object>> RetrieveList(string query, params object[] args)
        {
            var conn = new Database("Persist Security Info=true;server=" + server + ";database=" + dbName + ";uid=" + login + ";pwd=" + password + ";Integrated Security=false; Connection Timeout=60", DatabaseType.SqlServer2012);
            using (IDatabase db = conn)
            {
                return db.Fetch<Dictionary<string, object>>(query, args);
            }
        }

        public List<Dictionary<string, object>> GetAllTableName(string tableName = "")
        {
            string q = "";
            q += " SELECT a.TABLE_NAME AS TableName" + Environment.NewLine;
            q += " FROM INFORMATION_SCHEMA.TABLES a" + Environment.NewLine;
            q += " WHERE a.TABLE_TYPE = 'BASE TABLE' AND a.TABLE_CATALOG='" + dbName + "'" + Environment.NewLine;
            if(!string.IsNullOrEmpty(tableName)){
                q += " AND a.TABLE_NAME = '"+ tableName +"'" + Environment.NewLine;
            }
            q += " ORDER BY a.TABLE_NAME" + Environment.NewLine;
            return RetrieveList(q);
        }

        public List<Dictionary<string, object>> GetCSharpTableManifest(string tableName)
        {
            string q = "";
            q += " select DISTINCT" + Environment.NewLine;
            q += " CAST(replace(col.name, ' ', '_') AS varchar(MAX)) ColumnName, " + Environment.NewLine;
            q += " column_id as ColumnId, " + Environment.NewLine;
            q += " CAST(case typ.name  " + Environment.NewLine;
            q += " when 'bigint' then 'long' " + Environment.NewLine;
            q += " when 'binary' then 'byte[]' " + Environment.NewLine;
            q += " when 'bit' then 'bool' " + Environment.NewLine;
            q += " when 'char' then 'String' " + Environment.NewLine;
            q += " when 'date' then 'DateTime' " + Environment.NewLine;
            q += " when 'datetime' then 'DateTime' " + Environment.NewLine;
            q += " when 'datetime2' then 'DateTime' " + Environment.NewLine;
            q += " when 'datetimeoffset' then 'DateTime' " + Environment.NewLine;
            q += " when 'decimal' then 'double' " + Environment.NewLine;
            q += " when 'float' then 'float' " + Environment.NewLine;
            q += " when 'image' then 'byte[]' " + Environment.NewLine;
            q += " when 'int' then 'int' " + Environment.NewLine;
            q += " when 'money' then 'double' " + Environment.NewLine;
            q += " when 'nchar' then 'string' " + Environment.NewLine;
            q += " when 'ntext' then 'string' " + Environment.NewLine;
            q += " when 'numeric' then 'double' " + Environment.NewLine;
            q += " when 'nvarchar' then 'String' " + Environment.NewLine;
            q += " when 'real' then 'double' " + Environment.NewLine;
            q += " when 'smalldatetime' then 'DateTime' " + Environment.NewLine;
            q += " when 'smallint' then 'int' " + Environment.NewLine;
            q += " when 'smallmoney' then 'double' " + Environment.NewLine;
            q += " when 'text' then 'String' " + Environment.NewLine;
            q += " when 'time' then 'DateTime' " + Environment.NewLine;
            q += " when 'timestamp' then 'DateTime' " + Environment.NewLine;
            q += " when 'tinyint' then 'int' " + Environment.NewLine;
            q += " when 'uniqueidentifier' then 'Guid' " + Environment.NewLine;
            q += " when 'varbinary' then 'byte[]' " + Environment.NewLine;
            q += " when 'varchar' then 'string' " + Environment.NewLine;
            q += " else 'UNKNOWN_' + typ.name " + Environment.NewLine;
            q += " end AS varchar(MAX)) ColumnType, " + Environment.NewLine;
            q += " case  " + Environment.NewLine;
            q += " when col.is_nullable = 1 and typ.name in ('bigint', 'bit', 'date', 'datetime', 'datetime2', 'datetimeoffset', 'decimal', 'float', 'int', 'money', 'numeric', 'real', 'smalldatetime', 'smallint', 'smallmoney', 'time', 'tinyint', 'uniqueidentifier')  " + Environment.NewLine;
            q += " --then '?'  " + Environment.NewLine;
            q += " then CAST('' AS varchar(MAX)) " + Environment.NewLine;
            q += " else CAST('' AS varchar(MAX)) " + Environment.NewLine;
            q += " end NullableSign " + Environment.NewLine;
            q += " from sys.columns col " + Environment.NewLine;
            q += " join sys.types typ on " + Environment.NewLine;
            q += " col.system_type_id = typ.system_type_id AND col.user_type_id = typ.user_type_id " + Environment.NewLine;
            q += " where object_id = object_id('"+ tableName +"') " + Environment.NewLine;
            return RetrieveList(q);
        }

        public List<Dictionary<string, object>> GetFlutterTableManifest(string tableName)
        {
            string q = "";
            q += " select DISTINCT" + Environment.NewLine;
            q += " CAST(replace(col.name, ' ', '_') AS varchar(MAX)) ColumnName, " + Environment.NewLine;
            q += " column_id as ColumnId, " + Environment.NewLine;
            q += " CAST(case typ.name  " + Environment.NewLine;
            q += " when 'bigint' then 'long' " + Environment.NewLine;
            q += " when 'binary' then 'byte[]' " + Environment.NewLine;
            q += " when 'bit' then 'bool' " + Environment.NewLine;
            q += " when 'char' then 'String' " + Environment.NewLine;
            q += " when 'date' then 'DateTime' " + Environment.NewLine;
            q += " when 'datetime' then 'DateTime' " + Environment.NewLine;
            q += " when 'datetime2' then 'DateTime' " + Environment.NewLine;
            q += " when 'datetimeoffset' then 'DateTime' " + Environment.NewLine;
            q += " when 'decimal' then 'double' " + Environment.NewLine;
            q += " when 'float' then 'float' " + Environment.NewLine;
            q += " when 'image' then 'List<int>' " + Environment.NewLine;
            q += " when 'int' then 'int' " + Environment.NewLine;
            q += " when 'money' then 'double' " + Environment.NewLine;
            q += " when 'nchar' then 'String' " + Environment.NewLine;
            q += " when 'ntext' then 'String' " + Environment.NewLine;
            q += " when 'numeric' then 'double' " + Environment.NewLine;
            q += " when 'nvarchar' then 'String' " + Environment.NewLine;
            q += " when 'real' then 'double' " + Environment.NewLine;
            q += " when 'smalldatetime' then 'DateTime' " + Environment.NewLine;
            q += " when 'smallint' then 'int' " + Environment.NewLine;
            q += " when 'smallmoney' then 'double' " + Environment.NewLine;
            q += " when 'text' then 'String' " + Environment.NewLine;
            q += " when 'time' then 'DateTime' " + Environment.NewLine;
            q += " when 'timestamp' then 'DateTime' " + Environment.NewLine;
            q += " when 'tinyint' then 'int' " + Environment.NewLine;
            q += " when 'uniqueidentifier' then 'Guid' " + Environment.NewLine;
            q += " when 'varbinary' then 'List<int>' " + Environment.NewLine;
            q += " when 'varchar' then 'String' " + Environment.NewLine;
            q += " else 'UNKNOWN_' + typ.name " + Environment.NewLine;
            q += " end AS varchar(MAX)) ColumnType, " + Environment.NewLine;
            q += " case  " + Environment.NewLine;
            q += " when col.is_nullable = 1 and typ.name in ('bigint', 'bit', 'date', 'datetime', 'datetime2', 'datetimeoffset', 'decimal', 'float', 'int', 'money', 'numeric', 'real', 'smalldatetime', 'smallint', 'smallmoney', 'time', 'tinyint', 'uniqueidentifier')  " + Environment.NewLine;
            q += " --then '?'  " + Environment.NewLine;
            q += " then CAST('' AS varchar(MAX)) " + Environment.NewLine;
            q += " else CAST('' AS varchar(MAX)) " + Environment.NewLine;
            q += " end NullableSign " + Environment.NewLine;
            q += " from sys.columns col " + Environment.NewLine;
            q += " join sys.types typ on " + Environment.NewLine;
            q += " col.system_type_id = typ.system_type_id AND col.user_type_id = typ.user_type_id " + Environment.NewLine;
            q += " where object_id = object_id('" + tableName + "') " + Environment.NewLine;
            return RetrieveList(q);
        }

        public List<Dictionary<string, object>> GetPrimaryKeyOfTable(string tableName)
        {
            string q = "";
            q += " SELECT DISTINCT a.COLUMN_NAME AS ColumnName, b.is_identity AS IsAutoIncrement, a.ORDINAL_POSITION" + Environment.NewLine;
            q += " FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE a" + Environment.NewLine;
            q += " INNER JOIN sys.columns b ON a.COLUMN_NAME = b.name" + Environment.NewLine;
            q += " WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1" + Environment.NewLine;
            q += " AND a.TABLE_NAME = '" + tableName + "' AND b.is_nullable = 0" + Environment.NewLine;
            q += " ORDER BY a.ORDINAL_POSITION" + Environment.NewLine;
            return RetrieveList(q);
        }

        public List<Dictionary<string, object>> GetMsLookupHdr()
        {
            string q = "";
            q += " SELECT a.Kode, a.Keterangan" + Environment.NewLine;
            q += " FROM MsLookupHdr a" + Environment.NewLine;         
            q += " ORDER BY a.Kode" + Environment.NewLine;
            return RetrieveList(q);
        }

        public List<Dictionary<string, object>> GetMsLookupDtl(string kode)
        {
            string q = "";
            q += " SELECT a.Kode, a.KodeLookup" + Environment.NewLine;
            q += " FROM MsLookupDtl a" + Environment.NewLine;
            q += " WHERE a.Kode = '"+ kode +"'" + Environment.NewLine;
            q += " ORDER BY a.NoUrut" + Environment.NewLine;
            return RetrieveList(q);
        }

        public string CSharpOutput(string tableName)
        {
            if (tableName.Equals(""))
            {
                MessageBox.Show("Nama table belum diisi");
                return "";
            }
            var oList = GetAllTableName(tableName);
            if (oList.Count == 0)
            {
                MessageBox.Show("Nama table tidak ada");
                return "";
            }

            var oListManifest = GetCSharpTableManifest(tableName);
            if (oListManifest.Count == 0)
            {
                MessageBox.Show("Manifest table tidak ada");
                return "";
            }

            string primaryKey = "";
            string primaryKeyAsParameter = "";
            string primaryKeyParamQuery = "";
            string primaryKeyParamQueryValue = "";
            string primaryKeyParamQueryValueTransaction = "new {";
            string isAutoIncrement = "false";
            var i = 0;
            var oListPrimaryKeyOfTable = GetPrimaryKeyOfTable(tableName);
            foreach (var o in oListPrimaryKeyOfTable)
            {
                var colName = o["ColumnName"].ToString();
                var columnType = oListManifest.Where(m => m["ColumnName"].ToString().Equals(colName)).ToList().FirstOrDefault()["ColumnType"].ToString();
                primaryKey += colName + ", ";

                primaryKeyAsParameter += columnType + " " + colName.Substring(0, 1).ToLower() + colName.Substring(1) + ", ";
                primaryKeyParamQuery += colName + " = @" + i.ToString() + " AND ";
                primaryKeyParamQueryValue += colName.Substring(0, 1).ToLower() + colName.Substring(1) + ", ";
                primaryKeyParamQueryValueTransaction += colName + " = " + colName.Substring(0, 1).ToLower() + colName.Substring(1) + ", ";
                if (isAutoIncrement.Equals("false") && (bool)o["IsAutoIncrement"])
                {
                    isAutoIncrement = "true";
                }
                i++;
            }
            primaryKey = primaryKey.Substring(0, primaryKey.Length - 2);
            primaryKeyAsParameter = primaryKeyAsParameter.Substring(0, primaryKeyAsParameter.Length - 2);
            primaryKeyParamQuery = primaryKeyParamQuery.Substring(0, primaryKeyParamQuery.Length - 5);
            primaryKeyParamQueryValue = primaryKeyParamQueryValue.Substring(0, primaryKeyParamQueryValue.Length - 2);
            primaryKeyParamQueryValueTransaction = primaryKeyParamQueryValueTransaction.Substring(0, primaryKeyParamQueryValueTransaction.Length - 2);
            primaryKeyParamQueryValueTransaction += "}";
            if (oListPrimaryKeyOfTable.Count == 1)
            {
                var colName = oListPrimaryKeyOfTable[0]["ColumnName"].ToString();
                primaryKeyParamQueryValueTransaction = colName.Substring(0, 1).ToLower() + colName.Substring(1);
            }
            string output = "";
            output += GetCSharpHeader() + Environment.NewLine;
            output += "     [TableName(\"" + tableName + "\")]" + Environment.NewLine;
            output += "     [PrimaryKey(\"" + primaryKey + "\", AutoIncrement = " + isAutoIncrement + ")]" + Environment.NewLine;
            output += "     public partial class " + tableName + "Mdl" + Environment.NewLine;
            output += "     {" + Environment.NewLine;
            output += "     " + Environment.NewLine;
            foreach (var o in oListManifest)
            {
                output += "         public " + o["ColumnType"].ToString() + " " + o["ColumnName"].ToString() + " { get; set; }" + Environment.NewLine;
                output += "     " + Environment.NewLine;
            }
            output += "         public static " + tableName + "Mdl GetData(" + primaryKeyAsParameter + ")" + Environment.NewLine;
            output += "         {" + Environment.NewLine;
            output += "             return MdlDtl.GetDataQuery<" + tableName + "Mdl>(\"SELECT * FROM " + tableName + " WITH (NOLOCK,NOWAIT) WHERE " + primaryKeyParamQuery + "\", " + primaryKeyParamQueryValue + ");" + Environment.NewLine;
            output += "         }" + Environment.NewLine;
            output += "         public static " + tableName + "Mdl GetDataTransaction(MdlDto oMdlDto, " + primaryKeyAsParameter + ")" + Environment.NewLine;
            output += "         {" + Environment.NewLine;
            output += "             return oMdlDto.GetData<" + tableName + "Mdl>("+ primaryKeyParamQueryValueTransaction + ");" + Environment.NewLine;
            output += "         }" + Environment.NewLine;
            output += "     }" + Environment.NewLine;
            output += " }" + Environment.NewLine;
            return output;
        }

        public string FlutterOutput(string tableName)
        {
            if (tableName.Equals(""))
            {
                MessageBox.Show("Nama table belum diisi");
                return "";
            }
            var oList = GetAllTableName(tableName);
            if (oList.Count == 0)
            {
                MessageBox.Show("Nama table tidak ada");
                return "";
            }

            var oListManifest = GetFlutterTableManifest(tableName);
            if (oListManifest.Count == 0)
            {
                MessageBox.Show("Manifest table tidak ada");
                return "";
            }

            string primaryKeyAsParameter = "";
            string primaryKeyParamRequest = "";
            var i = 0;
            foreach (var o in GetPrimaryKeyOfTable(tableName))
            {
                var colName = o["ColumnName"].ToString();
                var colNameLower = colName.Substring(0, 1).ToLower() + colName.Substring(1);
                var columnType = oListManifest.Where(m => m["ColumnName"].ToString().Equals(colName)).ToList().FirstOrDefault()["ColumnType"].ToString();

                primaryKeyAsParameter += columnType + " " + colNameLower + ", ";
                primaryKeyParamRequest += "\"" + colNameLower + "\": " + colNameLower + ", ";
                i++;
            }
            primaryKeyAsParameter = primaryKeyAsParameter.Substring(0, primaryKeyAsParameter.Length - 2);
            primaryKeyParamRequest = primaryKeyParamRequest.Substring(0, primaryKeyParamRequest.Length - 2);

            string output = "";
            output += GetFlutterHeader() + Environment.NewLine;
            output += "     " + Environment.NewLine;
            output += " class "+ tableName +"Mdl {" + Environment.NewLine;
            foreach (var o in oListManifest)
            {
                var colName = o["ColumnName"].ToString();
                var colNameLower = colName.Substring(0, 1).ToLower() + colName.Substring(1);
                output += "     " + o["ColumnType"].ToString() + " " + colNameLower + ";" + Environment.NewLine;
            }
            output += "     " + Environment.NewLine;
            output += "     " + tableName + "Mdl({" + Environment.NewLine;
            foreach (var o in oListManifest)
            {
                var colName = o["ColumnName"].ToString();
                var colNameLower = colName.Substring(0, 1).ToLower() + colName.Substring(1);
                output += "         @required this." + colNameLower + "," + Environment.NewLine;
            }
            output += "     });" + Environment.NewLine;
            output += "     " + Environment.NewLine;
            output += "     " + tableName + "Mdl.fromJson(Map<String, dynamic> json) : " + Environment.NewLine;

            var fromJson = "";
            foreach (var o in oListManifest)
            {
                var colName = o["ColumnName"].ToString();
                var colNameLower = colName.Substring(0, 1).ToLower() + colName.Substring(1);
                var columnType = oListManifest.Where(m => m["ColumnName"].ToString().Equals(colName)).ToList().FirstOrDefault()["ColumnType"].ToString();
                if (columnType.ToLower().Equals("double") || columnType.ToLower().Equals("decimal"))
                {
                    fromJson += Environment.NewLine + "         " + colNameLower + " = json[\"" + colName + "\"].toDouble(),";
                }
                else if (columnType.ToLower().Equals("int") || columnType.ToLower().Equals("short"))
                {
                    fromJson += Environment.NewLine + "         " + colNameLower + " = json[\"" + colName + "\"].toInt(),";
                }
                else if (columnType.ToLower().Equals("datetime"))
                {
                    fromJson += Environment.NewLine + "         " + colNameLower + " = deserializeDatetimeModel(json[\"" + colName + "\"]),";
                }
                else
                {
                    fromJson += Environment.NewLine + "         " + colNameLower + " = json[\"" + colName + "\"],";
                }

            }
            fromJson = fromJson.Substring(0, fromJson.Length - 1);
            fromJson += ";";
            output += fromJson;

            output += "     " + Environment.NewLine;
            output += "     " + tableName + "Mdl.initModel() : " + Environment.NewLine;
            var initModel = "";
            foreach (var o in oListManifest)
            {
                var colName = o["ColumnName"].ToString();
                var colNameLower = colName.Substring(0, 1).ToLower() + colName.Substring(1);
                initModel += Environment.NewLine + "         " + colNameLower + " = null,";
            }
            initModel = initModel.Substring(0, initModel.Length - 1);
            initModel += ";";
            output += initModel;

            output += "     " + Environment.NewLine;
            output += "     Map<String, dynamic> toJson() => { " + Environment.NewLine;
            var toJson = "";
            foreach (var o in oListManifest)
            {
                var colName = o["ColumnName"].ToString();
                var colNameLower = colName.Substring(0, 1).ToLower() + colName.Substring(1);
                var columnType = oListManifest.Where(m => m["ColumnName"].ToString().Equals(colName)).ToList().FirstOrDefault()["ColumnType"].ToString();
                if (columnType.ToLower().Equals("datetime"))
                {
                    toJson += Environment.NewLine + "         \"" + colName + "\": serializeDatetime(" + colNameLower + "),";
                }
                else
                {
                    toJson += Environment.NewLine + "         \"" + colName + "\": " + colNameLower + ",";
                }
            }
            toJson = toJson.Substring(0, toJson.Length - 1);
            output += "     " + Environment.NewLine;
            toJson += "     };";
            output += toJson;

            output += "     " + Environment.NewLine;
            output += "     static void deleteModel() {" + Environment.NewLine;
            output += "         return saveString(\""+ tableName + "Mdl\", \"\");" + Environment.NewLine;
            output += "     }" + Environment.NewLine;
            output += "     " + Environment.NewLine;
            output += "     static Future<" + tableName + "Mdl> getData("+ primaryKeyAsParameter +") async {" + Environment.NewLine;
            output += "         try {" + Environment.NewLine;
            output += "             var json = await postRequest(\"Model/Get" + tableName + "Mdl\", {" + Environment.NewLine;
            output += "             "+ primaryKeyParamRequest +"" + Environment.NewLine;
            output += "             });" + Environment.NewLine;
            output += "             return " + tableName + "Mdl.fromJson(json);" + Environment.NewLine;
            output += "          } catch (e) {" + Environment.NewLine;
            output += "             return null;" + Environment.NewLine;
            output += "          }" + Environment.NewLine;
            output += "      }" + Environment.NewLine;
            output += "      " + Environment.NewLine;
            output += "      static " + tableName + "Mdl getModel() {" + Environment.NewLine;
            output += "         try {" + Environment.NewLine;
            output += "             String json = getString(\""+ tableName +"Mdl\");" + Environment.NewLine;
            output += "             Map<String, dynamic> oMap = jsonDecode(json);" + Environment.NewLine;
            output += "             return " + tableName + "Mdl.fromJson(oMap);" + Environment.NewLine;
            output += "         } catch (e) {" + Environment.NewLine;
            output += "             return null;" + Environment.NewLine;
            output += "         }" + Environment.NewLine;
            output += "      }" + Environment.NewLine;
            output += "      " + Environment.NewLine;
            output += "      static void saveModel(" + tableName + "Mdl oModel) {" + Environment.NewLine;
            output += "         return saveString(\"" + tableName + "Mdl\", jsonEncode(oModel));" + Environment.NewLine;
            output += "      }" + Environment.NewLine;
            output += "      " + Environment.NewLine;
            output += "      static void saveModelJson(Map<String, dynamic> oMap) {" + Environment.NewLine;
            output += "         return saveString(\"" + tableName + "Mdl\", jsonEncode(" + tableName + "Mdl.fromJson(oMap)));" + Environment.NewLine;
            output += "      }" + Environment.NewLine;
            output += " }" + Environment.NewLine;          
            return output;
        }
                
        public string ModelControllerOutput()
        {
            var oList = GetAllTableName();

            string output = "";
            output += GetModelControllerHeader() + Environment.NewLine;
            output += "     " + Environment.NewLine;
            output += "     //[ApiPermission()]" + Environment.NewLine;
            output += "     public class ModelController : Controller" + Environment.NewLine;
            output += "     {" + Environment.NewLine;
            output += "     " + Environment.NewLine;
            foreach (var o in oList)
            {
                string tableName = o["TableName"].ToString();
                var oListManifest = GetCSharpTableManifest(tableName);
                string primaryKeyAsParameter = "";
                string primaryKeyGetData = "";
                foreach (var oPrimary in GetPrimaryKeyOfTable(tableName))
                {
                    var colName = oPrimary["ColumnName"].ToString();
                    var columnType = oListManifest.Where(m => m["ColumnName"].ToString().Equals(colName)).ToList().FirstOrDefault()["ColumnType"].ToString();
                    var colNameLower = colName.Substring(0, 1).ToLower() + colName.Substring(1);

                    primaryKeyAsParameter += columnType + " " + colNameLower + ", ";
                    primaryKeyGetData += colNameLower + ", ";
                    
                }
                primaryKeyAsParameter = primaryKeyAsParameter.Substring(0, primaryKeyAsParameter.Length - 2);
                primaryKeyGetData = primaryKeyGetData.Substring(0, primaryKeyGetData.Length - 2);

                string encryptFunction = "Get" + tableName + "Mdl";
                output += "         public ActionResult Get"+ tableName +"Mdl("+ primaryKeyAsParameter +")" + Environment.NewLine;
                output += "         {" + Environment.NewLine;
                output += "             return Json(" + tableName + "Mdl.GetData(" + primaryKeyGetData + "), JsonRequestBehavior.AllowGet);" + Environment.NewLine;
                output += "         }" + Environment.NewLine;
                output += "         " + Environment.NewLine;
            }
            output += "     }" + Environment.NewLine;
            output += " }" + Environment.NewLine;
            return output;
        }

        public string MsLookupHdrCSharpOutput()
        {
            var oListHdr = GetMsLookupHdr();
            string output = "";
            output += " namespace " + projectName + ".Data" + Environment.NewLine;
            output += " {" + Environment.NewLine;
            output += "     " + Environment.NewLine;
            output += "     public partial class MsLookupHdrMdl" + Environment.NewLine;
            output += "     {" + Environment.NewLine;
            foreach (var o in oListHdr)
            {
                output += "         public const string "+ o["Kode"].ToString() + " = \"" + o["Kode"].ToString() + "\";" + Environment.NewLine;
            }
            output += "     }" + Environment.NewLine;
            output += "" + Environment.NewLine;
            foreach (var o in oListHdr)
            {
                output += "     public partial class " + o["Keterangan"].ToString() + "" + Environment.NewLine;
                output += "     {" + Environment.NewLine;
                foreach (var i in GetMsLookupDtl(o["Kode"].ToString()))
                {
                    output += "         public const string " + i["KodeLookup"].ToString() + " = \"" + i["KodeLookup"].ToString() + "\";" + Environment.NewLine;
                }
                output += "     }" + Environment.NewLine;
                output += "" + Environment.NewLine;
            }

            output += " }" + Environment.NewLine;
            return output;
        }

        public string MsLookupHdrFLutterOutput()
        {
            var oListHdr = GetMsLookupHdr();
            string output = "// ignore_for_file: constant_identifier_names" + Environment.NewLine;
            output += "     class MsLookupHdr {" + Environment.NewLine;
            foreach (var o in oListHdr)
            {
                output += "         static const String " + o["Keterangan"].ToString() + " = \"" + o["Kode"].ToString() + "\";" + Environment.NewLine;
            }
            output += "     }" + Environment.NewLine;
            output += "" + Environment.NewLine;
            foreach (var o in oListHdr)
            {
                output += "     class " + o["Keterangan"].ToString() + " {" + Environment.NewLine;
                foreach (var i in GetMsLookupDtl(o["Kode"].ToString()))
                {
                    output += "         static const String " + i["KodeLookup"].ToString() + " = \"" + i["KodeLookup"].ToString() + "\";" + Environment.NewLine;
                }
                output += "     }" + Environment.NewLine;
                output += "" + Environment.NewLine;
            }

            return output;
        }

        private void btnGenerateModelController_Click(object sender, EventArgs e)
        {
            txtResult3.Text = "";
            txtResult3.Text = ModelControllerOutput();
        }

        public static string EncryptSHA1(string text)
        {
            text = "k9Z" + text + "!";
            string encryptedText = "";
            using (var sha1 = SHA1.Create())
            {
                var hashedBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
                encryptedText = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
            return encryptedText;
        }

        private void btnGenerateModel_Click(object sender, EventArgs e)
        {
            txtResult1.Text = "";
            string tableName = cboTable.SelectedItem.ToString();
            if (cboLanguage.SelectedItem.ToString().Equals("C#"))
            {
                txtResult1.Text = CSharpOutput(tableName);
            } else if (cboLanguage.SelectedItem.ToString().Equals("Flutter"))
            {
                txtResult1.Text = FlutterOutput(tableName);
            }
        }

        private void btnGenerateAllModel_Click(object sender, EventArgs e)
        {
            string folderPath = Environment.CurrentDirectory.Replace("_ModelGenerator\\bin\\Debug", projectName + "\\DataModel\\");
            if (cboLanguage.SelectedItem.ToString().Equals("Flutter"))
            {
                folderPath = Environment.CurrentDirectory.Replace("_ModelGenerator\\bin\\Debug", projectName + "\\DataModelFlutter\\");
            }
            bool exists = Directory.Exists(folderPath);
            if (!exists)
            {
                Directory.CreateDirectory(folderPath);
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(folderPath);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }

            txtResult2.Text = "";
            foreach (var oDict in GetAllTableName())
            {
                var tableName = oDict["TableName"].ToString();
                if (cboLanguage.SelectedItem.ToString().Equals("C#"))
                {
                    string path = folderPath + tableName + "Mdl.cs";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    txtResult2.Text = txtResult2.Text + folderPath + tableName + "Mdl.cs" + Environment.NewLine;
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(CSharpOutput(tableName));
                    }
                }
                else if (cboLanguage.SelectedItem.ToString().Equals("Flutter"))
                {
                    string path = folderPath + tableName.ToLower() + "mdl.dart";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    txtResult2.Text = txtResult2.Text + folderPath + tableName + "Mdl.dart" + Environment.NewLine;
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(FlutterOutput(tableName));
                    }
                }                
            }
        }

        private void btnGenerateMsLookupHdrMapping_Click(object sender, EventArgs e)
        {
            txtResult4.Text = "";
            if (cboLanguage.SelectedItem.ToString().Equals("C#"))
            {
                txtResult4.Text = MsLookupHdrCSharpOutput();
            }
            else if (cboLanguage.SelectedItem.ToString().Equals("Flutter"))
            {
                txtResult4.Text = MsLookupHdrFLutterOutput();
            }
        }
    }
}
