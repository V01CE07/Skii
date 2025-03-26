using System;
using System.Collections.Generic;

namespace skiing.Models;

public partial class OrderStatus
{
    public int IdOrderStatus { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
