using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace skiing.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? UserName { get; set; }

    public string? UserLogin { get; set; }

    public string? UserPassword { get; set; }

    public int? IdPosition { get; set; }

    public string? UserImage { get; set; }

    public Bitmap Image => new Bitmap(UserImage != null ? $"Assets/{UserImage}" : "Assets/placeholder.png");

    public int? IdClients { get; set; }

    public virtual Client? IdClientsNavigation { get; set; }

    public virtual Position? IdPositionNavigation { get; set; }

    public virtual ICollection<LoginHistory> LoginHistories { get; set; } = new List<LoginHistory>();


}
