using System;
using System.Collections.Generic;

namespace WebApplicationBYD.Models;

public partial class ImportOrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal? Price { get; set; }

    public int Quantity { get; set; }

    public int? WarehouseId { get; set; }

    public virtual ImportOrder Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Warehouse? Warehouse { get; set; }
}
