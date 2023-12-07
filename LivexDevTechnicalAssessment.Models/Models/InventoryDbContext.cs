using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LivexDevTechnicalAssessment.Entities.Models;

public partial class InventoryDbContext : DbContext
{
    public InventoryDbContext()
    {
    }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerInventory> CustomerInventories { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=Tumi-Lap1; Database=InventoryDB; Integrated Security=True; TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
            entity.Property(e => e.EmailAddress).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomerInventory>(entity =>
        {
            entity.ToTable("CustomerInventory");

            entity.HasIndex(e => e.CustomerId, "IX_CustomerInventory_CustomerId");

            entity.Property(e => e.CustomerInventoryId).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerInventories)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerInventory_Customer");

            entity.HasOne(d => d.Inventory).WithMany(p => p.CustomerInventories)
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerInventory_Inventory");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId).ValueGeneratedNever();
            entity.Property(e => e.InventoryName).HasMaxLength(50);
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("SKU");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
