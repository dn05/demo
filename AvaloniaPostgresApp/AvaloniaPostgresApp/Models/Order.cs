using System;
using System.Collections.Generic;

namespace AvaloniaPostgresApp.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? OrderDate { get; set; }

    public string? DeliveryDate { get; set; }

    public int? PickupPointId { get; set; }

    public int? UserId { get; set; }

    public int? PickupCode { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual PickupPoint? PickupPoint { get; set; }

    public virtual OrderStatus? Status { get; set; }

    public virtual User? User { get; set; }
}
