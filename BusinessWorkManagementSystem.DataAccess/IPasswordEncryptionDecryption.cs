using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessWorkManagementSystem.DataAccess
{
    public interface IPasswordEncryptionDecryption
    {
        public string EncryptString(string key, string password);

        public string DecryptString(string key, string password);
    }
}
