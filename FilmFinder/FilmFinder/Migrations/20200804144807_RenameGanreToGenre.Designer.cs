﻿// <auto-generated />
using System;
using FilmFinder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FilmFinder.Migrations
{
    [DbContext(typeof(DbContent))]
    [Migration("20200804144807_RenameGanreToGenre")]
    partial class RenameGanreToGenre
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FilmFinder.Data.Models.Actor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("FilmFinder.Data.Models.Film", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("genreid")
                        .HasColumnType("int");

                    b.Property<string>("imgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("genreid");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("FilmFinder.Data.Models.FilmActor", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("FilmActor");
                });

            modelBuilder.Entity("FilmFinder.Data.Models.Genre", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("FilmFinder.Data.Models.Film", b =>
                {
                    b.HasOne("FilmFinder.Data.Models.Genre", "genre")
                        .WithMany()
                        .HasForeignKey("genreid");
                });

            modelBuilder.Entity("FilmFinder.Data.Models.FilmActor", b =>
                {
                    b.HasOne("FilmFinder.Data.Models.Actor", "Actor")
                        .WithMany("FilmActor")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmFinder.Data.Models.Film", "Film")
                        .WithMany("FilmActor")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
