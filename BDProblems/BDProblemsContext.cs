using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BDProblems
{
    public partial class BDProblemsContext : DbContext
    {
        public BDProblemsContext()
        {
        }

        public BDProblemsContext(DbContextOptions<BDProblemsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Problem> Problem { get; set; }
        public virtual DbSet<ProblemGrade> ProblemGrade { get; set; }
        public virtual DbSet<ProblemTheme> ProblemTheme { get; set; }
        public virtual DbSet<Source> Source { get; set; }
        public virtual DbSet<Theme> Theme { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-10OKRJ9\\SQLEXPRESS; Database=BDProblems; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.GradeName)
                    .IsRequired()
                    .HasColumnName("GradeName")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Problem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Solution).HasColumnType("text");

                entity.Property(e => e.Statement).HasColumnType("text");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Problem)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_Problem_Level");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.Problem)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("FK_Problem_Source");
            });
            modelBuilder.Entity<ProblemGrade>().HasKey(t => new { t.ProblemId, t.GradeId });

            modelBuilder.Entity<ProblemGrade>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.ProblemGrade)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProblemGrade_Grade");

                entity.HasOne(d => d.Problem)
                    .WithMany(p => p.ProblemGrade)
                    .HasForeignKey(d => d.ProblemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProblemGrade_Problem");
            });
            modelBuilder.Entity<ProblemTheme>().HasKey(t => new { t.ProblemId, t.ThemeId });
            modelBuilder.Entity<ProblemTheme>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Problem)
                    .WithMany(p => p.ProblemTheme)
                    .HasForeignKey(d => d.ProblemId)
                    .HasConstraintName("FK_ProblemTheme_Problem");

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.ProblemTheme)
                    .HasForeignKey(d => d.ThemeId)
                    .HasConstraintName("FK_ProblemTheme_Theme");
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Info).HasColumnType("text");

                entity.Property(e => e.SourceName)
                    .HasColumnName("SourceName")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ThemeName).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
