using System;
using System.Configuration;

namespace LaurenceGlenn_CRUDV2
{
    public partial class BernadoDataContext
    {
        // Parameterless constructor aron makagamit dayon og: new BernadoDataContext()
        public BernadoDataContext() : 
            base(GetConnectionString(), mappingSource)
        {
            OnCreated();
        }

        // Mokuha sa connection string gikan sa App.config o default fallback sa .\SQLEXPRESS
        private static string GetConnectionString()
        {
            try
            {
                var setting = ConfigurationManager.ConnectionStrings["BernadoConnection"];
                if (setting != null && !string.IsNullOrEmpty(setting.ConnectionString))
                {
                    return setting.ConnectionString;
                }
            }
            catch
            {
            }
            return @"Data Source=.\SQLEXPRESS;Initial Catalog=Bernado;Integrated Security=True;TrustServerCertificate=True;";
        }
    }
}
