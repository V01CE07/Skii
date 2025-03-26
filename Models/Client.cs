using System;
using System.Collections.Generic;

namespace skiing.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string? ClientCode { get; set; }

    public string? ClientPassportSeries { get; set; }

    public string? ClientPassportCode { get; set; }

    public DateOnly? ClientBirth { get; set; }

    public string? ClientAdress { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
