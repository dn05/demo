using System;
using System.Collections.Generic;

namespace AvaloniaPostgresApp.Models;

public partial class PickupPoint
{
    public int PickupPointId { get; set; }

    public int? PickupCode { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? HouseNumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
