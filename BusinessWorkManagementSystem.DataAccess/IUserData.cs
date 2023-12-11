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

    }
}
