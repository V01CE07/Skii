using System;
using System.Collections.Generic;

namespace skiing.Models;

public partial class Service
{
    public int IdService { get; set; }

    public string? NameService { get; set; }

    public string? CodeService { get; set; }

    public float? PriceService { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
