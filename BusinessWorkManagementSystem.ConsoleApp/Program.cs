using BusinessWorkManagementSystem.ConsoleApp.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessWorkManagementSystem.ConsoleApp
{
    /// <summary>
    /// In this console application we have done ADO.net database connection to retrieve the data from DB.
    /// 
    /// </summary>
    internal class Program
    {
        static ConnectionStrings connectionString;
        static void Main(string[] args)
        {

            if (!ReadAppConfig())
            {
                Console.WriteLine("\nApp config read successfully.\n");

                Console.WriteLine("\n\n**********************************************************\n\n");
                List<CountryModel> countryList =  GetCountryList();
                Console.WriteLine("\n Display list of countries from database");
                foreach (CountryModel countryModel in countryList)
                {
                    Console.WriteLine("\n Country Id: {0} CountryName: {1}",
                        countryModel.CountryId,countryModel.CountryName);
                }

                Console.WriteLine("\n\n**********************************************************\n\n");

                Console.WriteLine("If you want to insert new user into database then please press \"Y\" else press \"N\" ");
                string toInsert = Console.ReadLine();

                if (toInsert == "Y" || toInsert == "y")
                {

                    Console.WriteLine("\n ***************************************************");
                    Console.WriteLine("\n Below records shows available users from the database.");
                    DisplayAvailableUsers();
                    Console.WriteLine("\n ***************************************************");

                    UserModel userModel = new UserModel();  

                    Console.WriteLine("\n Enter user first name: ");
                    string userFirstName = Console.ReadLine();
                    Console.WriteLine("\n Enter user last name: ");
                    string userLastName = Console.ReadLine();
                    Console.WriteLine("\n Enter mobile number: ");
                    long mobileNumber = long.Parse(Console.ReadLine());
                    Console.WriteLine("\n Enter user email: ");
                    string userEmail = Console.ReadLine();

                    Console.WriteLine("\n Enter password: ");
                    string password = Console.ReadLine();

                    string encryptPass = PasswordEncryptionDecryption.EncryptString("GorakhShankarShinde1991PuneIndia", password);

                    CreateUser(userFirstName, userLastName, mobileNumber, userEmail, encryptPass);

                    Console.WriteLine("\n ***************************************************");
                    Console.WriteLine("\n Below records shows available users from the database.");
                    DisplayAvailableUsers();
                    Console.WriteLine("\n ***************************************************");

                }
               
                
            }
            else 
            {
                Console.WriteLine("Error while reading App config.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void DisplayAvailableUsers()
        {
            List<UserModel> userList = new List<UserModel>();

            SqlConnection sqlConnection = new SqlConnection(connectionString.DevelopmentConnection);
            SqlCommand sqlCommand = new SqlCommand("select * from Tbl_UserMaster", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserModel user = new UserModel();
                user.UserId = int.Parse(dt.Rows[i]["UserId"].ToString());
                user.UserFirstName = dt.Rows[i]["UserFirstName"].ToString();
                user.UserLastName = dt.Rows[i]["UserLastName"].ToString();
                user.UserEmailAddress = dt.Rows[i]["UserEmailAddress"].ToString();
                user.UserMobileNumber = long.Parse(dt.Rows[i]["UserMobileNumber"].ToString());
                user.CountryId = int.Parse(dt.Rows[i]["CountryId"].ToString());

                userList.Add(user);
            }

            Console.WriteLine("\n User Id | First Name | Last Name | Mobile Number | Email address ");
                       
            foreach (UserModel user in userList)
            {
                Console.WriteLine("\n     {0} |   {1} |   {2} |   {3} |   {4} ", user.UserId, user.UserFirstName, user.UserLastName, user.UserMobileNumber, user.UserEmailAddress);
            }
        }

        /// <summary>
        /// In this method we have used connection data architecture.
        /// 
        /// </summary>
        /// <param name="userFirstName"></param>
        /// <param name="userLastName"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="userEmail"></param>
        private static void CreateUser(string? userFirstName, string? userLastName, long mobileNumber, string? userEmail, string userPass)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString.DevelopmentConnection);
                string insertQuery = "insert into Tbl_UserMaster (UserFirstName, UserLastName, UserEmailAddress, UserMobileNumber, CountryId, UserTypeId, UserPassword, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, Active) values('" +
                    userFirstName +
                    "', '" + userLastName +
                    "', '" + userEmail +
                    "'," + mobileNumber +
                    ", 97, 1,'"+ userPass + "',1 , '"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', 1, '"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', 1)";

               SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection);
               sqlConnection.Open();
               sqlCommand.ExecuteNonQuery();
               sqlConnection.Close();
               Console.WriteLine("\n New user added successfully... ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error occurred while adding the new user.");
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static List<CountryModel> GetCountryList()
        {
            List<CountryModel> countryList = new List<CountryModel>();

            SqlConnection sqlConnection = new SqlConnection(connectionString.DevelopmentConnection);
            SqlCommand sqlCommand = new SqlCommand("select top 5 * from Tbl_Country", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            for(int i=0; i<dt.Rows.Count; i++)
            {
                CountryModel country = new CountryModel();
                country.CountryId = int.Parse(dt.Rows[i]["CountryId"].ToString());
                country.CountryName = dt.Rows[i]["CountryName"].ToString();
                countryList.Add(country);
            }

            return countryList;
        }

        private static bool ReadAppConfig()
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
                 connectionString = configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

                //Below line is used to read the application settings
                // those are available under "appsettings" section.
                var appSettings = configuration.GetSection("appsettings").Get<AppSettings>();

                if (connectionString != null)
                {
                    Console.WriteLine("\n****************************************************************\n");
                    Console.WriteLine("\nDevelopment Connection string:" + connectionString.DevelopmentConnection);
                    Console.WriteLine("\nProduction Connection string:" + connectionString.ProductionConnection);
                }

                if (appSettings != null)
                {
                    Console.WriteLine("\n****************************************************************\n");
                    Console.WriteLine("\nCode is executing on environment name :" + appSettings.EnvironmentName);
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