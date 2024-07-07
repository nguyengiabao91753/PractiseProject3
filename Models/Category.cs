using System;
using System.Collections.Generic;

namespace WebApplicationBYD.Models;

public partial class Category
{
    public int CateId { get; set; }

    public string CateName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
