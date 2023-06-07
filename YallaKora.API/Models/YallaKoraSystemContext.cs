using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace YallaKora.API.Models
{
    public partial class YallaKoraSystemContext : DbContext
    {
        public YallaKoraSystemContext()
        {
        }

        public YallaKoraSystemContext(DbContextOptions<YallaKoraSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<TournamentGalary> TournamentGalaries { get; set; }
        public virtual DbSet<TournamentsTeam> TournamentsTeams { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=YallaKoraSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.PlayerName).HasMaxLength(100);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__Player__TeamId__1A14E395");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(100);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FoundationDate).HasMaxLength(100);

                entity.Property(e => e.Logo).HasMaxLength(200);

                entity.Property(e => e.TeamName).HasMaxLength(100);

                entity.Property(e => e.WebsiteUrl)
                    .HasMaxLength(100)
                    .HasColumnName("WebsiteURL");
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Logo).HasMaxLength(200);

                entity.Property(e => e.TournamentName).HasMaxLength(100);

                entity.Property(e => e.TournamentVideo).HasMaxLength(200);
            });

            modelBuilder.Entity<TournamentGalary>(entity =>
            {
                entity.ToTable("TournamentGalary");

                entity.Property(e => e.Image1).HasMaxLength(100);

                entity.Property(e => e.Image2).HasMaxLength(100);

                entity.Property(e => e.Image3).HasMaxLength(100);

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentGalaries)
                    .HasForeignKey(d => d.TournamentId)
                    .HasConstraintName("FK__Tournamen__Tourn__239E4DCF");
            });

            modelBuilder.Entity<TournamentsTeam>(entity =>
            {
                entity.HasKey(e => e.TournamentsTeamsId)
                    .HasName("PK__Tourname__E2D86BD948AAC4D3");

                entity.ToTable("Tournaments_Teams");

                entity.Property(e => e.TournamentsTeamsId).HasColumnName("Tournaments_TeamsId");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TournamentsTeams)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__Tournamen__TeamI__173876EA");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentsTeams)
                    .HasForeignKey(d => d.TournamentId)
                    .HasConstraintName("FK__Tournamen__Tourn__164452B1");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserMast__1788CC4C0DD77682");

                entity.ToTable("UserMaster");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserMasters)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserMaste__RoleI__1CF15040");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
