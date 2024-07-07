using System;
using System.Collections.Generic;

namespace WebApplicationBYD.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<ImportOrder> ImportOrders { get; set; } = new List<ImportOrder>();
}
