using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjektAPI.Models
{
    public partial class projektContext : DbContext
    {
        public projektContext()
        {
        }

        public projektContext(DbContextOptions<projektContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CzescNaMagazynie> CzescNaMagazynies { get; set; } = null!;
        public virtual DbSet<CzescUzytaDoZlecenium> CzescUzytaDoZlecenia { get; set; } = null!;
        public virtual DbSet<ModelCzesci> ModelCzescis { get; set; } = null!;
        public virtual DbSet<Pracownicy> Pracownicies { get; set; } = null!;
        public virtual DbSet<Producent> Producents { get; set; } = null!;
        public virtual DbSet<SpecjalizacjePracownika> SpecjalizacjePracownikas { get; set; } = null!;
        public virtual DbSet<TypCzesci> TypCzescis { get; set; } = null!;
        public virtual DbSet<Zlecenie> Zlecenies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=projekt;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CzescNaMagazynie>(entity =>
            {
                entity.ToTable("CzescNaMagazynie");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Idmodelu).HasColumnName("IDModelu");

                entity.Property(e => e.Idproducenta).HasColumnName("IDProducenta");

                entity.Property(e => e.Idtypu).HasColumnName("IDTypu");

                entity.Property(e => e.KodSegmentu)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdmodeluNavigation)
                    .WithMany(p => p.CzescNaMagazynies)
                    .HasForeignKey(d => d.Idmodelu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CzescNaMagazynie_ModelCzesci");

                entity.HasOne(d => d.IdproducentaNavigation)
                    .WithMany(p => p.CzescNaMagazynies)
                    .HasForeignKey(d => d.Idproducenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CzescNaMagazynie_Producent");

                entity.HasOne(d => d.IdtypuNavigation)
                    .WithMany(p => p.CzescNaMagazynies)
                    .HasForeignKey(d => d.Idtypu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CzescNaMagazynie_TypCzesci");
            });

            modelBuilder.Entity<CzescUzytaDoZlecenium>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DataWpisu).HasColumnType("datetime");

                entity.Property(e => e.Idczesci).HasColumnName("IDCzesci");

                entity.Property(e => e.Idzlecenia).HasColumnName("IDZlecenia");

                entity.HasOne(d => d.IdczesciNavigation)
                    .WithMany(p => p.CzescUzytaDoZlecenia)
                    .HasForeignKey(d => d.Idczesci)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CzescUzytaDoZlecenia_CzescNaMagazynie");

                entity.HasOne(d => d.IdzleceniaNavigation)
                    .WithMany(p => p.CzescUzytaDoZlecenia)
                    .HasForeignKey(d => d.Idzlecenia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CzescUzytaDoZlecenia_Zlecenie");
            });

            modelBuilder.Entity<ModelCzesci>(entity =>
            {
                entity.ToTable("ModelCzesci");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Model)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pracownicy>(entity =>
            {
                entity.ToTable("Pracownicy");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Imie)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NumerTelefonu)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producent>(entity =>
            {
                entity.ToTable("Producent");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SpecjalizacjePracownika>(entity =>
            {
                entity.ToTable("SpecjalizacjePracownika");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Idpracownika).HasColumnName("IDPracownika");

                entity.HasOne(d => d.IdpracownikaNavigation)
                    .WithMany(p => p.SpecjalizacjePracownikas)
                    .HasForeignKey(d => d.Idpracownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecjalizacjePracownika_Pracownicy");
            });

            modelBuilder.Entity<TypCzesci>(entity =>
            {
                entity.ToTable("TypCzesci");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Typ)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("typ");
            });

            modelBuilder.Entity<Zlecenie>(entity =>
            {
                entity.ToTable("Zlecenie");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DataPrzyjecia).HasColumnType("date");

                entity.Property(e => e.DataWydania).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Idpracownika).HasColumnName("IDPracownika");

                entity.Property(e => e.Imie)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Koszt).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NumerTelefonu)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.OpisZlecenia)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdpracownikaNavigation)
                    .WithMany(p => p.Zlecenies)
                    .HasForeignKey(d => d.Idpracownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zlecenie_Pracownicy");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
