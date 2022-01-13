using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace АРМ
{
    public partial class laba8_bdContext : DbContext
    {
        public laba8_bdContext()
        {
        }

        public laba8_bdContext(DbContextOptions<laba8_bdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Delay> Delays { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host = localhost; Port = 5432; Database = laba8_bd; Username = postgres; Password = postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251@icu");

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("bank");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.LvlLicenses).HasColumnName("lvl_licenses");

                entity.Property(e => e.NameBank).HasColumnName("name_bank");
            });

            modelBuilder.Entity<Delay>(entity =>
            {
                entity.HasKey(e => new { e.IdProvider, e.IdProduct })
                    .HasName("delays_pk");

                entity.ToTable("delays");

                entity.Property(e => e.IdProvider).HasColumnName("id_provider");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Delays)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("delays_product_id_fk");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.Delays)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("delays_provider_id_fk");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CostPr).HasColumnName("cost_pr");

                entity.Property(e => e.IdGroop).HasColumnName("id_groop");

                entity.Property(e => e.Instruct).HasColumnName("instruct");

                entity.Property(e => e.NamePr).HasColumnName("name_pr");

                entity.Property(e => e.Term).HasColumnName("term");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("provider");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodePayment).HasColumnName("code_payment");

                entity.Property(e => e.CountDelays).HasColumnName("count_delays");

                entity.Property(e => e.DataCoop)
                    .HasColumnType("date")
                    .HasColumnName("data_coop");

                entity.Property(e => e.IdBank).HasColumnName("id_bank");

                entity.Property(e => e.NamePr).HasColumnName("name_pr");

                entity.HasOne(d => d.IdBankNavigation)
                    .WithMany(p => p.Providers)
                    .HasForeignKey(d => d.IdBank)
                    .HasConstraintName("provider_bank_id_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login");

                entity.Property(e => e.Lvl).HasColumnName("lvl");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
