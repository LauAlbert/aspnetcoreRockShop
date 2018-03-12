﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RockShop.Models;
using System;

namespace RockShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180311083226_updateOrder2")]
    partial class updateOrder2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RockShop.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<int>("RockId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("RockId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("RockShop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("OrderPlaced");

                    b.Property<decimal>("OrderTotal");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("State")
                        .HasMaxLength(10);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RockShop.Models.Rock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LongDescription");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<bool>("RockOfTheWeek");

                    b.Property<string>("ShortDescription");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Rocks");
                });

            modelBuilder.Entity("RockShop.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int?>("RockId");

                    b.Property<string>("ShoppingCartId");

                    b.HasKey("Id");

                    b.HasIndex("RockId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("RockShop.Models.Item", b =>
                {
                    b.HasOne("RockShop.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RockShop.Models.Rock", "Rock")
                        .WithMany()
                        .HasForeignKey("RockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RockShop.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("RockShop.Models.Rock", "Rock")
                        .WithMany()
                        .HasForeignKey("RockId");
                });
#pragma warning restore 612, 618
        }
    }
}
