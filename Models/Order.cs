using System;
using System.Collections.Generic;

namespace skiing.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public string? OrderCode { get; set; }

    public DateOnly? OrderTime { get; set; }

    public DateOnly? OrderDateClose { get; set; }

    public TimeOnly? OrderRentTime { get; set; }

    public int? IdOrderStatus { get; set; }

    public int? IdClient { get; set; }

    public int? IdService { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual OrderStatus? IdOrderStatusNavigation { get; set; }

    public virtual Service? IdServiceNavigation { get; set; }
}
