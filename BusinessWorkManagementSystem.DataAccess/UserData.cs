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
    }
}
