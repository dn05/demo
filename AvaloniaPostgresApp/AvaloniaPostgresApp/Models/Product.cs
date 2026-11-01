using System;
using System.Collections.Generic;

namespace AvaloniaPostgresApp.Models;

public partial class Product
{
    public string Article { get; set; } = null!;

    public int? ProductNameId { get; set; }

    public string? Unit { get; set; }

    public int? Price { get; set; }

    public int? ManufacturerId { get; set; }

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ProductName? ProductName { get; set; }

    public virtual Supplier? Supplier { get; set; }
}