using Ecommerce_Product_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Ecommerce_Product_API.Contexts;

public partial class HarvestContext : DbContext
{
    public HarvestContext()
    {
    }

    public HarvestContext(DbContextOptions<HarvestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attribute_> Attributes { get; set; }

    public virtual DbSet<AttributeValue> AttributeValues { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    public virtual DbSet<VariantAttributeValue> VariantAttributeValues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) { }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attribute_>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attributes_pkey");

            entity.ToTable("attributes");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<AttributeValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attribute_values_pkey");

            entity.ToTable("attribute_values");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.AttributeValue1).HasColumnName("attribute_value");

            entity.HasOne(d => d.Attribute).WithMany(p => p.AttributeValues)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("attribute_id_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("product_pkey");

            entity.ToTable("products");

            entity.Property(e => e.ProductId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("product_id");
            entity.Property(e => e.BrandProduct).HasColumnName("brand_product");
            entity.Property(e => e.CategoryProduct).HasColumnName("category_product");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LongDescriptionProduct).HasColumnName("long_descriptionProduct");
            entity.Property(e => e.ShortDescription).HasColumnName("short_description");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdateDate).HasColumnName("update_date");
        });

        modelBuilder.Entity<ProductVariant>(entity =>
        {
            entity.HasKey(e => e.VariantId).HasName("variant_pkey");

            entity.ToTable("product_variants");

            entity.Property(e => e.VariantId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("variant_id");
            entity.Property(e => e.BasePrice).HasColumnName("base_price");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SalePrice).HasColumnName("sale_price");
            entity.Property(e => e.Sku).HasColumnName("sku");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.UpdateDate).HasColumnName("update_date");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_fkey");
        });

        modelBuilder.Entity<VariantAttributeValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("variant_attribute_values_pkey");

            entity.ToTable("variant_attribute_values");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AttributeValueId).HasColumnName("attribute_value_id");
            entity.Property(e => e.VariantId).HasColumnName("variant_id");

            entity.HasOne(d => d.Variant).WithMany(p => p.VariantAttributeValues)
                .HasForeignKey(d => d.VariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("variant_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
