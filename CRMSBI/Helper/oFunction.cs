

using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;
using NPoco;

namespace CRMSBI.Helper
{
    public class oFunction
    {

        public static IDatabase GetConnection()
        {
            IDatabase db = new Database(Program.connectionString!, DatabaseType.SqlServer2012, SqlClientFactory.Instance);
            return db;
        }

        public static DataTable DictionaryToDatatable(List<Dictionary<string, object>> oListDict)
        {
            DataTable dt = new DataTable();
            if (oListDict.Count > 0)
            {
                List<String> myKeys = oListDict[0].Keys.ToList();
                foreach (string item in myKeys)
                {
                    DataColumn col = new DataColumn(item);
                    if (oListDict[0][item].GetType() == typeof(string))
                    {
                        col.DataType = System.Type.GetType("System.String");
                    }
                    else if (oListDict[0][item].GetType() == typeof(DateTime))
                    {
                        col.DataType = System.Type.GetType("System.DateTime");
                    }
                    else if (oListDict[0][item].GetType() == typeof(Int32) || oListDict[0][item].GetType() == typeof(int))
                    {
                        col.DataType = System.Type.GetType("System.Int32");
                    }
                    else if (oListDict[0][item].GetType() == typeof(Boolean) || oListDict[0][item].GetType() == typeof(bool))
                    {
                        col.DataType = System.Type.GetType("System.Boolean");
                    }
                    else if (oListDict[0][item].GetType() == typeof(TimeSpan))
                    {
                        col.DataType = System.Type.GetType("System.TimeSpan");
                    }
                    else if (oListDict[0][item].GetType() == typeof(decimal) || oListDict[0][item].GetType() == typeof(double))
                    {
                        col.DataType = System.Type.GetType("System.Decimal");
                    }
                    else if (oListDict[0][item].GetType() == typeof(Byte[]))
                    {
                        col.DataType = System.Type.GetType("System.Byte[]");
                    }
                    else if (oListDict[0][item].GetType() == typeof(Int32))
                    {
                        col.DataType = System.Type.GetType("System.Int32");
                    }
                    else if (oListDict[0][item].GetType() == typeof(Int32))
                    {
                        col.DataType = System.Type.GetType("System.Int32");
                    }
                    else if (oListDict[0][item].GetType() == typeof(Int32))
                    {
                        col.DataType = System.Type.GetType("System.Int32");
                    }

                    dt.Columns.Add(col);
                    //dt.Columns.Add(item);
                }
                foreach (Dictionary<string, object> dict in oListDict)
                {
                    var row = dt.NewRow();
                    foreach (var key in dict.Keys)
                    {
                        row[key] = dict[key];
                    }
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        public static void SetDefaultValueToObjectProperty(object obj)
        {
            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    if (propertyInfo.GetValue(obj, null) == null)
                    {
                        propertyInfo.SetValue(obj, string.Empty, null);
                    }
                }
                if (propertyInfo.PropertyType == typeof(string[]))
                {
                    if (propertyInfo.GetValue(obj, null) == null)
                    {
                        propertyInfo.SetValue(obj, new string[] { }, null);
                    }
                }
                if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    if (propertyInfo.GetValue(obj, null) == null)
                    {
                        propertyInfo.SetValue(obj, new DateTime(1900, 1, 1), null);
                    }
                    else
                    {
                        try
                        {
                            if (DateTime.Compare(((DateTime)propertyInfo.GetValue(obj, null)!), new DateTime(1900, 1, 1)) < 0)
                            {
                                propertyInfo.SetValue(obj, new DateTime(1900, 1, 1), null);
                            }
                            if (DateTime.Compare(((DateTime)propertyInfo.GetValue(obj, null)!), new DateTime(2099, 1, 1)) > 0)
                            {
                                propertyInfo.SetValue(obj, new DateTime(1900, 1, 1), null);
                            }
                        }
                        catch (Exception) { }
                    }

                }
                if (propertyInfo.PropertyType == typeof(int))
                {
                    if (propertyInfo.GetValue(obj, null) == null)
                    {
                        propertyInfo.SetValue(obj, 0, null);
                    }
                }
                if (propertyInfo.PropertyType == typeof(double))
                {
                    if (propertyInfo.GetValue(obj, null) == null)
                    {
                        propertyInfo.SetValue(obj, 0, null);
                    }
                }
                if (propertyInfo.PropertyType == typeof(bool))
                {
                    if (propertyInfo.GetValue(obj, null) == null)
                    {
                        propertyInfo.SetValue(obj, false, null);
                    }
                }
            }

        }

        public static string EncryptSHA1(string text)
        {
            text = "7n" + text + "K!";
            string encryptedText = "";
            using (var sha = SHA1.Create())
            {
                var hashedBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
                encryptedText = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
            return encryptedText;
        }

        public static string Protect(string text)
        {
            var keyString = "Indorent10!Indorent10!Indorent10";
            var key = Encoding.UTF8.GetBytes(keyString);
            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                        var iv = aesAlg.IV;
                        var decryptedContent = msEncrypt.ToArray();
                        var result = new byte[iv.Length + decryptedContent.Length];
                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);
                        var encryptedText = Convert.ToBase64String(result);
                        encryptedText = encryptedText.Replace('+', '-').Replace('/', '_');
                        char[] padding = { '=' };
                        if (encryptedText.EndsWith("=="))
                        {
                            encryptedText = encryptedText.Replace("==", "");
                        }
                        if (encryptedText.EndsWith("="))
                        {
                            encryptedText = encryptedText.Replace("=", "");
                        }
                        return encryptedText;
                    }
                }
            }
        }

        public static string Unprotect(string text)
        {
            var keyString = "Indorent10!Indorent10!Indorent10";

            string o = text;
            text = text.Replace('_', '/').Replace('-', '+');
            switch (o.Length % 4)
            {
                case 2: text += "=="; break;
                case 3: text += "="; break;
            }
            var fullCipher = Convert.FromBase64String(text);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                    return result;
                }
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static DateTime StringToDateTime(string tanggal, string format = "")
        {
            try
            {
                if (string.IsNullOrEmpty(format))
                {
                    return Convert.ToDateTime(tanggal, CultureInfo.GetCultureInfo("id-ID").DateTimeFormat);
                }
                return DateTime.ParseExact(tanggal, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            }
            catch (Exception)
            {
                return new DateTime(1900, 1, 1);
            }
        }

        public static string DatetimeToString(DateTime dt, string format)
        {
            try
            {
                var oDate = dt.ToString(format, CultureInfo.GetCultureInfo("id-ID"));
                oDate = oDate.Replace("Nopember", "November");
                oDate = oDate.Replace("Pebruari", "Februari");
                return oDate;
            }
            catch (Exception)
            {
                return "";
            }
        }


    }
}