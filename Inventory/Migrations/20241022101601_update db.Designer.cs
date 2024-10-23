﻿// <auto-generated />
using Inventory.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventory.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20241022101601_update db")]
    partial class updatedb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inventory.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InStock = true,
                            Name = "Hp EliteBook 745 G6",
                            Quantity = 16
                        },
                        new
                        {
                            Id = 2,
                            InStock = true,
                            Name = "Elders Schnapps",
                            Quantity = 4
                        },
                        new
                        {
                            Id = 3,
                            InStock = false,
                            Name = "Mac Book Pro 2024",
                            Quantity = 11
                        },
                        new
                        {
                            Id = 4,
                            InStock = true,
                            Name = "Iphone 16pro max",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 5,
                            InStock = true,
                            Name = "Bottled Groudnut",
                            Quantity = 18
                        },
                        new
                        {
                            Id = 6,
                            InStock = true,
                            Name = "CWAY",
                            Quantity = 12
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
