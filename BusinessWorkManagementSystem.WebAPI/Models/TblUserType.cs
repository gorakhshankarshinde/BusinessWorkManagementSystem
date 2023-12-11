using System;
using System.Collections.Generic;

namespace BusinessWorkManagementSystem;

public partial class TblUserType
{
    public int UserTypeId { get; set; }

    public string? UserType { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? Active { get; set; }
}
