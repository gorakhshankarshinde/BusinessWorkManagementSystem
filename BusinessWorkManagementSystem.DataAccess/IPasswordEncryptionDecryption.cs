using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessWorkManagementSystem.DataAccess
{
    public interface IPasswordEncryptionDecryption
    {
        public string EncryptPassword(string key, string password);

        public string DecryptPassword(string key, string password);
    }
}
