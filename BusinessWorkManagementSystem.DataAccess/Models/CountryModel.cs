using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessWorkManagementSystem.DataAccess.Models
{
    public class CountryModel
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string IsoCode { get; set; }
    }
}
