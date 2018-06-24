using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ef_test.Models
{


    public partial class lolscoreContext : DbContext
    {
        public lolscoreContext()
        {
        }

        public lolscoreContext(DbContextOptions<lolscoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Champion> Champion { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        // Unable to generate entity type for table 'dbo.cash'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
           optionsBuilder.UseSqlServer("Server=.;Database=lolscore;User id=user;Password=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Champion>(entity =>
            {
                entity.HasKey(e => e.Champion01);

                entity.ToTable("champion");

                entity.HasIndex(e => e.Champion02)
                    .HasName("IX_champion");

                entity.Property(e => e.Champion01).HasColumnName("champion01");

                entity.Property(e => e.Champion02)
                    .IsRequired()
                    .HasColumnName("champion02")
                    .HasMaxLength(20);

                entity.Property(e => e.Champion03)
                    .HasColumnName("champion03")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.Region01);

                entity.ToTable("region");

                entity.Property(e => e.Region01).HasColumnName("region01");

                entity.Property(e => e.Region02)
                    .IsRequired()
                    .HasColumnName("region02")
                    .HasMaxLength(10);

                entity.Property(e => e.Region03)
                    .HasColumnName("region03")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasKey(e => e.Score01);

                entity.ToTable("score");

                entity.Property(e => e.Score01).HasColumnName("score01");

                entity.Property(e => e.Score02).HasColumnName("score02");

                entity.Property(e => e.Score03).HasColumnName("score03");

                entity.Property(e => e.Score04).HasColumnName("score04");

                entity.Property(e => e.Score05).HasColumnName("score05");

                entity.Property(e => e.Score06).HasColumnName("score06");

                entity.Property(e => e.Score07)
                    .HasColumnName("score07")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Team01);

                entity.ToTable("team");

                entity.Property(e => e.Team01).HasColumnName("team01");

                entity.Property(e => e.Team02)
                    .IsRequired()
                    .HasColumnName("team02")
                    .HasMaxLength(10);

                entity.Property(e => e.Team03)
                    .IsRequired()
                    .HasColumnName("team03")
                    .HasMaxLength(10);

                entity.Property(e => e.Team04)
                    .HasColumnName("team04")
                    .HasColumnType("date");
            });
        }
    }
}
