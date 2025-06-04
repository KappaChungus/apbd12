using System;
using System.Collections.Generic;

namespace abdp12.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public int Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? FulfilledAt { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual ICollection<ProductWarehouse> ProductWarehouses { get; set; } = new List<ProductWarehouse>();
}
