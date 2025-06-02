using Microsoft.EntityFrameworkCore;
using SneakerShop.Domain.Entities;

namespace SneakerShop.Infrastructure.Persistance;

public partial class SneakerDbContext : DbContext
{
    public SneakerDbContext()
    {
    }

    public SneakerDbContext(DbContextOptions<SneakerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sneaker> Sneakers { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=../../main.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sneaker>(entity =>
        {
            entity.ToTable("sneakers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Price)
                .HasColumnType("INT")
                .HasColumnName("price");
            entity.Property(e => e.Title)
                .HasColumnType("text(255)")
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Username).HasColumnName("username");
            entity.Property(e => e.Password).HasColumnName("password_hash");
            entity.Property(e => e.Role).HasColumnName("role");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}