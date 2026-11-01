using System;
using System.Collections.Generic;

namespace AvaloniaPostgresApp.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string? SupplierName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
