using System;
using System.Collections.Generic;

namespace WebApplicationBYD.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int? ProductId { get; set; }

    public int? WarehouseId { get; set; }

    public int? QuantityAvailable { get; set; }

    public int? SaleQuantity { get; set; }

    public int? TotalQuantity { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
