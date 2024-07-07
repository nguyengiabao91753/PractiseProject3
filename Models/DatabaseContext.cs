using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBYD.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ImportOrder> ImportOrders { get; set; }

    public virtual DbSet<ImportOrderItem> ImportOrderItems { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<LevelHasPermission> LevelHasPermissions { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Database=webbanhang;user id=sa;password=1234567890;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__349DA586B3BD5EC9");

            entity.Property(e => e.AccountId)
                .ValueGeneratedOnAdd()
                .HasColumnName("AccountID");
            entity.Property(e => e.LevelId).HasColumnName("LevelID");
            entity.Property(e => e.Password).HasMaxLength(255);

            entity.HasOne(d => d.AccountNavigation).WithOne(p => p.Account)
                .HasForeignKey<Account>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Accounts__Accoun__3D5E1FD2");

            entity.HasOne(d => d.Level).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Accounts__LevelI__3E52440B");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CateId).HasName("PK__Categori__27638D7470609146");

            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CateName).HasMaxLength(50);
        });

        modelBuilder.Entity<ImportOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Import_o__C3905BAF1750A686");

            entity.ToTable("Import_orders");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Supplier).WithMany(p => p.ImportOrders)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__Import_or__Suppl__5EBF139D");
        });

        modelBuilder.Entity<ImportOrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__Import_o__57ED06A1391D1A3C");

            entity.ToTable("Import_order_items");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.HasOne(d => d.Order).WithMany(p => p.ImportOrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Import_or__Order__619B8048");

            entity.HasOne(d => d.Product).WithMany(p => p.ImportOrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Import_or__Produ__628FA481");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.ImportOrderItems)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK__Import_or__Wareh__6383C8BA");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Inventor__F5FDE6B37C149DD4");

            entity.ToTable("Inventory");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Inventory__Produ__6754599E");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK__Inventory__Wareh__66603565");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PK__Levels__09F03C0618446B32");

            entity.Property(e => e.LevelId).HasColumnName("LevelID");
            entity.Property(e => e.LevelName).HasMaxLength(50);
        });

        modelBuilder.Entity<LevelHasPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__level_ha__3214EC070A7ADCCD");

            entity.ToTable("level_has_permissions");

            entity.Property(e => e.LevelId).HasColumnName("LevelID");

            entity.HasOne(d => d.Level).WithMany(p => p.LevelHasPermissions)
                .HasForeignKey(d => d.LevelId)
                .HasConstraintName("FK__level_has__Level__45F365D3");

            entity.HasOne(d => d.Per).WithMany(p => p.LevelHasPermissions)
                .HasForeignKey(d => d.PerId)
                .HasConstraintName("FK__level_has__PerId__46E78A0C");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__Modules__2B747787783A9527");

            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.ModuleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF70307C0B");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__UserID__534D60F1");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06A1ADBCCD68");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__5629CD9C");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Produ__571DF1D5");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PerId).HasName("PK__Permissi__496D3DD0E9B70294");

            entity.ToTable("Permission");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(24);

            entity.HasOne(d => d.Module).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__Permissio__Modul__4316F928");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED600B7B82");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Size).HasMaxLength(20);

            entity.HasOne(d => d.Cate).WithMany(p => p.Products)
                .HasForeignKey(d => d.CateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__CateID__4CA06362");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PK__Product___5721CE5158C987D5");

            entity.ToTable("Product_Images");

            entity.Property(e => e.ProductImageId).HasColumnName("Product_ImageID");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Product_I__Produ__4F7CD00D");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE66694EAA77C2F");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.ContactEmail).HasMaxLength(100);
            entity.Property(e => e.ContactName).HasMaxLength(100);
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC207147F1");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105341E4FB615").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__Warehous__2608AFD92FCFDC38");

            entity.ToTable("Warehouse");

            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");
            entity.Property(e => e.WarehouseName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
