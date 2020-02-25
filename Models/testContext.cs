using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TutoAspNetCoreMvc.Models
{
    public partial class testContext : DbContext
    {
        public testContext()
        {

        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pays> Pays { get; set; }
        public virtual DbSet<Ville> Ville { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pays>(entity =>
            {
                entity.HasKey(e => e.IdPays);

                entity.Property(e => e.IdPays).HasColumnName("id_Pays");

                entity.Property(e => e.NomPays)
                    .IsRequired()
                    .HasColumnName("Nom_pays")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ville>(entity =>
            {
                entity.HasKey(e => e.IdVille);

                entity.HasIndex(e => e.IdPays)
                    .HasName("FK_Ville");

                entity.Property(e => e.IdVille).HasColumnName("id_ville");

                entity.Property(e => e.IdPays).HasColumnName("id_Pays");

                entity.Property(e => e.NomVille)
                    .HasColumnName("Nom_Ville")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPaysNavigation)
                    .WithMany(p => p.Ville)
                    .HasForeignKey(d => d.IdPays)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pays_ville");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
