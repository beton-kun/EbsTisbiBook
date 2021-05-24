﻿// <auto-generated />
using System;
using EbsTisbiBook.WebAppMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EbsTisbiBook.WebAppMVC.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20210522114847_AuthorBookMTM_BiblioRec")]
    partial class AuthorBookMTM_BiblioRec
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Middlename")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Surname")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BibliographicRecord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FgosId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isbn")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Liability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PubhouseId")
                        .HasColumnType("int");

                    b.Property<int?>("PubtypeId")
                        .HasColumnType("int");

                    b.Property<int>("Pubyear")
                        .HasColumnType("int");

                    b.Property<int?>("SpecialPurposeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TitleAdditional")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Title_additional");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FgosId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PubhouseId");

                    b.HasIndex("PubtypeId");

                    b.HasIndex("SpecialPurposeId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Fgos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("UgnpId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UgnpId");

                    b.ToTable("Fgos");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Pubhouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Pubhouse");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Pubtype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Pubtype");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.SpecialPurpose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("SpecialPurpose");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Ugnp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Ugnp");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("EbsTisbiBook.WebAppMVC.Models.Library.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbsTisbiBook.WebAppMVC.Models.Library.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Book", b =>
                {
                    b.HasOne("EbsTisbiBook.WebAppMVC.Models.Library.Fgos", "Fgos")
                        .WithMany("Books")
                        .HasForeignKey("FgosId")
                        .HasConstraintName("FK_Book_Fgos");

                    b.HasOne("EbsTisbiBook.WebAppMVC.Models.Library.Language", "Language")
                        .WithMany("Books")
                        .HasForeignKey("LanguageId")
                        .HasConstraintName("FK_Book_Language");

                    b.HasOne("EbsTisbiBook.WebAppMVC.Models.Library.Pubhouse", "Pubhouse")
                        .WithMany("Books")
                        .HasForeignKey("PubhouseId")
                        .HasConstraintName("FK_Book_Pubhouse");

                    b.HasOne("EbsTisbiBook.WebAppMVC.Models.Library.Pubtype", "Pubtype")
                        .WithMany("Books")
                        .HasForeignKey("PubtypeId")
                        .HasConstraintName("FK_Book_Pubtype");

                    b.HasOne("EbsTisbiBook.WebAppMVC.Models.Library.SpecialPurpose", "SpecialPurpose")
                        .WithMany("Books")
                        .HasForeignKey("SpecialPurposeId")
                        .HasConstraintName("FK_Book_SpecialPurpose");

                    b.Navigation("Fgos");

                    b.Navigation("Language");

                    b.Navigation("Pubhouse");

                    b.Navigation("Pubtype");

                    b.Navigation("SpecialPurpose");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Fgos", b =>
                {
                    b.HasOne("EbsTisbiBook.WebAppMVC.Models.Library.Ugnp", "Ugnp")
                        .WithMany("Fgos")
                        .HasForeignKey("UgnpId")
                        .HasConstraintName("FK_Fgos_Ugnp");

                    b.Navigation("Ugnp");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Fgos", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Language", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Pubhouse", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Pubtype", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.SpecialPurpose", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("EbsTisbiBook.WebAppMVC.Models.Library.Ugnp", b =>
                {
                    b.Navigation("Fgos");
                });
#pragma warning restore 612, 618
        }
    }
}
