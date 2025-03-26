using System;
using System.Collections.Generic;

namespace skiing.Models;

public partial class Position
{
    public int IdPosition { get; set; }

    public string? NamePosition { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
