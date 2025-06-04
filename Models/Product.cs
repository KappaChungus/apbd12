using System;
using System.Collections.Generic;

namespace abdp12.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductWarehouse> ProductWarehouses { get; set; } = new List<ProductWarehouse>();
}
