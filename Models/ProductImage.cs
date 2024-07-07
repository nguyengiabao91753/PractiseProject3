using System;
using System.Collections.Generic;

namespace WebApplicationBYD.Models;

public partial class ProductImage
{
    public int ProductImageId { get; set; }

    public int? ProductId { get; set; }

    public string Image { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
