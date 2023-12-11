using Microsoft.Extensions.Configuration;

namespace BusinessWorkManagementSystem.DataAccess
{
    public class BusinessWorkDBContext : IBusinessWorkDBContext
    {
        public ConnectionStrings connectionString;

        public bool ReadAppConfig()
        {
            bool hasError = false;
            try
            {
                var binder = new ConfigurationBuilder().
                    SetBasePath(
                    Directory.GetCurrentDirectory()).
                    AddJsonFile("appsettings.json");

                IConfiguration configuration = binder.Build();
                //Below line is used to read the database connection strings
                // those are available under "ConnectionStrings" section.
                if(configuration != null) 
                { 
                    connectionString = configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
                }
                //Below line is used to read the application settings
                // those are available under "appsettings" section.
                var appSettings = configuration.GetSection("appsettings").Get<AppSettings>();

                if (connectionString != null)
                {
                    // Return an error as connection string is not available.
                }

                if (appSettings != null)
                {
                    // Return an error app setting is not available.
                }
            }
            catch (Exception)
            {
                hasError = true;
                return hasError;
            }

            return hasError;
        }
    }

    /// <summary>
    /// Below class is added to read "ConnectionStrings" section.
    /// </summary>
    public class ConnectionStrings
    {
        /// <summary>
        /// Below property is use to read DevelopmentConnnection string from appsetting.json file.
        /// </summary>
        public string DevelopmentConnection { get; set; }

        /// <summary>
        /// Below property is use to read ProductionConnnection string from appsetting.json file.
        /// </summary>
        public string ProductionConnection { get; set; }
    }

    /// <summary>
    /// Below class is added to read "AppSettings" section.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Below property is use to read "EnvironmentName" from the appsettings section.
        /// </summary>
        public string EnvironmentName { get; set; }
    }
}