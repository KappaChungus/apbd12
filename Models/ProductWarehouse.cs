using System;
using System.Collections.Generic;

namespace abdp12.Models;

public partial class ProductWarehouse
{
    public int IdProductWarehouse { get; set; }

    public int IdWarehouse { get; set; }

    public int IdProduct { get; set; }

    public int IdOrder { get; set; }

    public int Amount { get; set; }

    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Warehouse IdWarehouseNavigation { get; set; } = null!;
}
