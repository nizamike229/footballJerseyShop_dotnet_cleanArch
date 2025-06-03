using Microsoft.EntityFrameworkCore;
using SneakerShop.Domain.Entities;

namespace SneakerShop.Infrastructure.Persistance;

public partial class JerseyDbContext : DbContext
{
    public JerseyDbContext()
    {
    }

    public JerseyDbContext(DbContextOptions<JerseyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Jersey> Jerseys { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=/Users/nizami/Desktop/api/main.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Club>(entity =>
        {
            entity.ToTable("clubs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Jersey>(entity =>
        {
            entity.ToTable("jerseys");

            entity.HasIndex(e => e.Name, "IX_jerseys_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClubId)
                .HasColumnType("string")
                .HasColumnName("club_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("text(255)")
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("INT")
                .HasColumnName("price");

            entity.HasOne(d => d.Club).WithMany(p => p.Jerseys).HasForeignKey(d => d.ClubId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PasswordHash)
                .HasColumnType("text(30)")
                .HasColumnName("password_hash");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Username)
                .HasColumnType("text(40)")
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
