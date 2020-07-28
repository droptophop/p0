using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Storing
{
    public partial class PizzaStoreDbContext : DbContext
    {
        public PizzaStoreDbContext()
        {
        }

        public PizzaStoreDbContext(DbContextOptions<PizzaStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaTopping> PizzaTopping { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Topping> Topping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=PizzaStoreDb;user id=sa;password=hop88SeZ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Crust");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Size");
            });

            modelBuilder.Entity<PizzaTopping>(entity =>
            {
                entity.ToTable("PizzaTopping", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaTopping)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.PizzaTopping)
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Topping");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.ToTable("Topping", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
