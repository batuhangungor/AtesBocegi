﻿// <auto-generated />
using AtesBocegi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AtesBocegi.Data.Migrations
{
    [DbContext(typeof(DAO))]
    partial class DAOModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AtesBocegi.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlbumPhoto");

                    b.Property<int?>("ColorId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("AtesBocegi.Models.AlbumItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlbumId");

                    b.Property<string>("İmage")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("albumItem");
                });

            modelBuilder.Entity("AtesBocegi.Models.ColorScale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MainColor");

                    b.Property<string>("Name");

                    b.Property<string>("SecondColor");

                    b.Property<string>("TextColor");

                    b.HasKey("Id");

                    b.ToTable("ColorScale");
                });

            modelBuilder.Entity("AtesBocegi.Models.FAQ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer")
                        .IsRequired();

                    b.Property<bool>("IsVisible");

                    b.Property<string>("Question")
                        .IsRequired();

                    b.Property<int>("ScreenOrder");

                    b.HasKey("Id");

                    b.ToTable("FAQ");
                });

            modelBuilder.Entity("AtesBocegi.Models.Album", b =>
                {
                    b.HasOne("AtesBocegi.Models.ColorScale", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");
                });

            modelBuilder.Entity("AtesBocegi.Models.AlbumItem", b =>
                {
                    b.HasOne("AtesBocegi.Models.Album", "Album")
                        .WithMany("AlbumItems")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
