using BusinessWorkManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessWorkManagementSystem.DataAccess
{
    public interface IUserData
    {
        public UserModel GetSingleUserById(int UserId);

        public List<UserModel> GetUserList();

        public void CreateUser(string? userFirstName, string? userLastName, long mobileNumber, string? userEmail, string userPass, int createdBy = 1, int updatedBy = 1);

    }
}
