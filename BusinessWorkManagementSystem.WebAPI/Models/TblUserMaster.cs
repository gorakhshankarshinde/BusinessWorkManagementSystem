using System;
using System.Collections.Generic;

namespace BusinessWorkManagementSystem;

public partial class TblUserMaster
{
    public int UserId { get; set; }

    public string? UserFirstName { get; set; }

    public string? UserLastName { get; set; }

    public string? UserEmailAddress { get; set; }

    public string? UserMobileNumber { get; set; }

    public int? CountryId { get; set; }

    public int? UserTypeId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? Active { get; set; }
}
