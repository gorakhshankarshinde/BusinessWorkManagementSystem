using BusinessWorkManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BusinessWorkManagementSystem.Data
{
    public class BusinessWorkDBContext : DbContext
    {
        public BusinessWorkDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserMaster> UserMasterModels { get; set; }
    }


}
