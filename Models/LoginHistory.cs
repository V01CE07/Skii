using System;
using System.Collections.Generic;

namespace skiing.Models;

public partial class LoginHistory
{
    public int IdLoginHistory { get; set; }

    public int? IdUser { get; set; }

    public DateTime? LoginDate { get; set; }

    public bool? Validation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
