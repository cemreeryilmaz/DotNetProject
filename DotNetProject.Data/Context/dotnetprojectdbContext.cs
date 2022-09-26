using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DotNetProject.Data
{
    public partial class dotnetprojectdbContext : DbContext
    {
        public dotnetprojectdbContext()
        {
        }

        public dotnetprojectdbContext(DbContextOptions<dotnetprojectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exchangerate> Exchangerates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=1234;database=dotnetprojectdb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exchangerate>(entity =>
            {
                entity.ToTable("exchangerate");

                entity.Property(e => e.BanknoteBuying).HasMaxLength(100);

                entity.Property(e => e.BanknoteSelling).HasMaxLength(100);

                entity.Property(e => e.CrossOrder).HasMaxLength(100);

                entity.Property(e => e.CrossRateOther).HasMaxLength(100);

                entity.Property(e => e.CrossRateUsd)
                    .HasMaxLength(100)
                    .HasColumnName("CrossRateUSD");

                entity.Property(e => e.CurrencyCode).HasMaxLength(100);

                entity.Property(e => e.CurrencyName).HasMaxLength(100);

                entity.Property(e => e.ForexBuying).HasMaxLength(100);

                entity.Property(e => e.ForexSelling).HasMaxLength(100);

                entity.Property(e => e.Isim).HasMaxLength(100);

                entity.Property(e => e.Kod).HasMaxLength(100);

                entity.Property(e => e.Unit).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
