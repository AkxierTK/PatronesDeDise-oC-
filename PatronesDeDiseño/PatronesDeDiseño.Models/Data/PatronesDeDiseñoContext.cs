using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PatronesDeDiseño.Models.Data;

public partial class PatronesDeDiseñoContext : DbContext
{
    public PatronesDeDiseñoContext()
    {
    }

    public PatronesDeDiseñoContext(DbContextOptions<PatronesDeDiseñoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\Patrones; Database=PatronesDeDiseño; Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>(entity =>
        {
            entity.ToTable("Beer");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Style).HasMaxLength(50);
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
