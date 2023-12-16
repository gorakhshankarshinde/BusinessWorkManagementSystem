using BusinessWorkManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessWorkManagementSystem.DataAccess
{
    public class UserData : BusinessWorkDBContext, IUserData
    {
        /// <summary>
        /// Below method is returning single user information based on the user id.
        /// </summary>
        /// <param name="UserId">UserId</param>
        /// <returns>It will return single user details.</returns>
        public UserModel GetSingleUserById(int UserId)
        {
            try
            {
                UserModel singleUser = new UserModel(); 
                List<UserModel> userList = new List<UserModel>();

                bool hasError = ReadAppConfig();

                if(hasError == false) { 
                SqlConnection sqlConnection = new SqlConnection(connectionString.DevelopmentConnection);
                SqlCommand sqlCommand = new SqlCommand("select * from Tbl_UserMaster  where Active = 1", sqlConnection);
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

                singleUser = (from user in userList
                              where user.UserId == UserId
                              select user).FirstOrDefault() ;
                }

                return singleUser;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// GetUserList method will return all users from those are active.
        /// </summary>
        /// <returns></returns>
        public List<UserModel> GetUserList()
        {
            try
            {
                List<UserModel> userList = new List<UserModel>();

                bool hasError = ReadAppConfig();

                if (hasError == false)
                {
                    SqlConnection sqlConnection = new SqlConnection(connectionString.DevelopmentConnection);
                    SqlCommand sqlCommand = new SqlCommand("select * from Tbl_UserMaster where Active = 1", sqlConnection);
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
                        user.UserPassword = dt.Rows[i]["UserPassword"].ToString();
                        user.Active = Convert.ToBoolean( dt.Rows[i]["Active"]);

                        userList.Add(user);
                    }
                }

                return userList;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// This method is use to create new user in database.
        /// </summary>
        /// <param name="userFirstName"></param>
        /// <param name="userLastName"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="userEmail"></param>
        public void CreateUser(string? userFirstName, string? userLastName, long mobileNumber, string? userEmail, string userPass, int createdBy =1, int updatedBy = 1)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString.DevelopmentConnection);
                string insertQuery = "insert into Tbl_UserMaster (UserFirstName, UserLastName, UserEmailAddress, UserMobileNumber, CountryId, UserTypeId, UserPassword, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, Active) values('" +
                    userFirstName +
                    "', '" + userLastName +
                    "', '" + userEmail +
                    "'," + mobileNumber +
                    ", 97, 1,'" + userPass + "',"+ createdBy +" , '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', "+ updatedBy +", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', 1)";

                SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
