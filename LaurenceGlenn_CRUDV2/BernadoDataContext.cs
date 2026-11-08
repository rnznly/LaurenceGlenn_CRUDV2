using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace LaurenceGlenn_CRUDV2
{
    public partial class BernadoDataContext
    {
        public BernadoDataContext() : 
            base(GetConnectionString(), mappingSource)
        {
            OnCreated();
        }

        private static string GetConnectionString()
        {
            try
            {
                var setting = ConfigurationManager.ConnectionStrings["BernadoConnection"];
                if (setting != null && !string.IsNullOrEmpty(setting.ConnectionString))
                {
                    string rawConn = setting.ConnectionString;
                    if (CanConnect(rawConn))
                    {
                        return rawConn;
                    }

                    string mdfInBase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bernado.mdf");
                    if (File.Exists(mdfInBase))
                    {
                        string localDbConn = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{mdfInBase}"";Integrated Security=True;Connect Timeout=15;";
                        if (CanConnect(localDbConn)) return localDbConn;

                        string sqlExpConn = $@"Data Source=.\SQLEXPRESS;AttachDbFilename=""{mdfInBase}"";Integrated Security=True;Connect Timeout=15;";
                        if (CanConnect(sqlExpConn)) return sqlExpConn;
                    }
                }
            }
            catch { }

            string sqlexpressFallback = @"Data Source=.\SQLEXPRESS;Initial Catalog=Bernado;Integrated Security=True;TrustServerCertificate=True;";
            if (CanConnect(sqlexpressFallback)) return sqlexpressFallback;

            string localDbFallback = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Bernado;Integrated Security=True;";
            if (CanConnect(localDbFallback)) return localDbFallback;

            return sqlexpressFallback;
        }

        private static bool CanConnect(string connectionString)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
