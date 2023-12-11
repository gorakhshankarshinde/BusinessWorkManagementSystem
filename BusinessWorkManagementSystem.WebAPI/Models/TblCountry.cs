using System;
using System.Collections.Generic;

namespace BusinessWorkManagementSystem;

public partial class TblCountry
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public string IsoCode { get; set; } = null!;
}
