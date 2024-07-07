using System;
using System.Collections.Generic;

namespace WebApplicationBYD.Models;

public partial class ImportOrder
{
    public int OrderId { get; set; }

    public decimal? Total { get; set; }

    public int? SupplierId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ImportOrderItem> ImportOrderItems { get; set; } = new List<ImportOrderItem>();

    public virtual Supplier? Supplier { get; set; }
}
