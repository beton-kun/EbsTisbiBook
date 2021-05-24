using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EbsTisbiBook.WebAppMVC.Models.Library;

#nullable disable

namespace EbsTisbiBook.WebAppMVC.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Fgos> Fgos { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Pubhouse> Pubhouses { get; set; }
        public virtual DbSet<Pubtype> Pubtypes { get; set; }
        public virtual DbSet<SpecialPurpose> SpecialPurposes { get; set; }
        public virtual DbSet<Ugnp> Ugnp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Library");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Middlename).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Surname).HasMaxLength(150);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Isbn).HasMaxLength(30);

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.Property(e => e.TitleAdditional)
                    .HasMaxLength(150)
                    .HasColumnName("Title_additional");

                entity.HasOne(d => d.Fgos)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.FgosId)
                    .HasConstraintName("FK_Book_Fgos");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Book_Language");

                entity.HasOne(d => d.Pubhouse)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PubhouseId)
                    .HasConstraintName("FK_Book_Pubhouse");

                entity.HasOne(d => d.Pubtype)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PubtypeId)
                    .HasConstraintName("FK_Book_Pubtype");

                entity.HasOne(d => d.SpecialPurpose)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.SpecialPurposeId)
                    .HasConstraintName("FK_Book_SpecialPurpose");
            });

            modelBuilder.Entity<Fgos>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.Ugnp)
                    .WithMany(p => p.Fgos)
                    .HasForeignKey(d => d.UgnpId)
                    .HasConstraintName("FK_Fgos_Ugnp");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Pubhouse>(entity =>
            {
                entity.ToTable("Pubhouse");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Pubtype>(entity =>
            {
                entity.ToTable("Pubtype");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<SpecialPurpose>(entity =>
            {
                entity.ToTable("SpecialPurpose");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Ugnp>(entity =>
            {
                entity.ToTable("Ugnp");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
