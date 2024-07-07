using System;
using System.Collections.Generic;

namespace WebApplicationBYD.Models;

public partial class Warehouse
{
    public int WarehouseId { get; set; }

    public string? WarehouseName { get; set; }

    public virtual ICollection<ImportOrderItem> ImportOrderItems { get; set; } = new List<ImportOrderItem>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
