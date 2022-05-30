using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Класс-контекст, создается автоматически через фреймворк, который Милешко описывал на лк. Здесть прсотраиваются зависимости контейнеров базы с самой базой данных

namespace CursWorkAvalonia
{
    public partial class NewDataContext : DbContext
    {
        public NewDataContext()
        {
        }

        public NewDataContext(DbContextOptions<NewDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coach> Coaches { get; set; } = null!;
        public virtual DbSet<Hippodrome> Hippodromes { get; set; } = null!;
        public virtual DbSet<Horse> Horses { get; set; } = null!;
        public virtual DbSet<HorseHasCoach> HorseHasCoaches { get; set; } = null!;
        public virtual DbSet<HorseHasJockey> HorseHasJockeys { get; set; } = null!;
        public virtual DbSet<Jockey> Jockeys { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Race> Races { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { 
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\Егор\\Desktop\\RGR5\\NewData.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>(entity =>
            {
                entity.ToTable("Coach");

                entity.Property(e => e.CoachId)
                    .ValueGeneratedNever()
                    .HasColumnName("CoachID");
            });

            modelBuilder.Entity<Hippodrome>(entity =>
            {
                entity.HasKey(e => e.Hippodrome1);

                entity.ToTable("Hippodrome");

                entity.Property(e => e.Hippodrome1)
                    .ValueGeneratedNever()
                    .HasColumnName("Hippodrome");

                entity.Property(e => e.PathLengthFur).HasColumnName("PathLength (fur)");
            });

            modelBuilder.Entity<Horse>(entity =>
            {
                entity.ToTable("Horse");

                entity.HasIndex(e => e.HorseId, "IX_Horse_HorseID")
                    .IsUnique();

                entity.Property(e => e.HorseId)
                    .ValueGeneratedNever()
                    .HasColumnName("HorseID");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.RaceId).HasColumnName("RaceID");

                entity.Property(e => e.Rating).HasColumnType("DOUBLE");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Horses)
                    .HasForeignKey(d => d.OwnerId);

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Horses)
                    .HasForeignKey(d => d.RaceId);
            });

            modelBuilder.Entity<HorseHasCoach>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Horse_has_Coach");

                entity.Property(e => e.CoachId).HasColumnName("CoachID");

                entity.Property(e => e.HorseId).HasColumnName("HorseID");

                entity.HasOne(d => d.Coach)
                    .WithMany()
                    .HasForeignKey(d => d.CoachId);

                entity.HasOne(d => d.Horse)
                    .WithMany()
                    .HasForeignKey(d => d.HorseId);
            });

            modelBuilder.Entity<HorseHasJockey>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Horse_has_Jockey");

                entity.Property(e => e.HorseId).HasColumnName("HorseID");

                entity.Property(e => e.JockeyId).HasColumnName("JockeyID");

                entity.HasOne(d => d.Horse)
                    .WithMany()
                    .HasForeignKey(d => d.HorseId);
            });

            modelBuilder.Entity<Jockey>(entity =>
            {
                entity.ToTable("Jockey");

                entity.Property(e => e.JockeyId)
                    .ValueGeneratedNever()
                    .HasColumnName("JockeyID");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("Owner");

                entity.Property(e => e.OwnerId)
                    .ValueGeneratedNever()
                    .HasColumnName("OwnerID");
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.ToTable("Race");

                entity.Property(e => e.RaceId)
                    .ValueGeneratedNever()
                    .HasColumnName("RaceID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
