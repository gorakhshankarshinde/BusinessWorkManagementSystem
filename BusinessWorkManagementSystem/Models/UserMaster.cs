using BusinessWorkManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace BusinessWorkManagementSystem.Models
{
    public class UserMaster
    {
        public List<UserModel> users { get; set; }
    }
}