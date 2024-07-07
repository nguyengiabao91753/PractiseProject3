using System;
using System.Collections.Generic;

namespace WebApplicationBYD.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int SeriesId { get; set; }

    public int CateId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string Image { get; set; } = null!;

    public string? Color { get; set; }

    public string? Size { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category Cate { get; set; } = null!;

    public virtual ICollection<ImportOrderItem> ImportOrderItems { get; set; } = new List<ImportOrderItem>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
