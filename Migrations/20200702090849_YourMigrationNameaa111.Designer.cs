﻿// <auto-generated />
using System;
using DropShip.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DropShip.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200702090849_YourMigrationNameaa111")]
    partial class YourMigrationNameaa111
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DropShip.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("CartId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("DropShip.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Filled");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("OrderNumber")
                        .IsRequired();

                    b.Property<string>("ProductBoughtList")
                        .IsRequired();

                    b.Property<int?>("ProductId");

                    b.Property<string>("ShippingMethod")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DropShip.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("NumberOfImgs");

                    b.Property<string>("ProductDescription");

                    b.Property<string>("ProductKeywords");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<int>("ProductPrice");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DropShip.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Admin");

                    b.Property<string>("City");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MobilePhone");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Postal");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DropShip.Models.Cart", b =>
                {
                    b.HasOne("DropShip.Models.Product", "P")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DropShip.Models.User", "U")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DropShip.Models.Order", b =>
                {
                    b.HasOne("DropShip.Models.Product", "P")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId");

                    b.HasOne("DropShip.Models.User", "U")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
