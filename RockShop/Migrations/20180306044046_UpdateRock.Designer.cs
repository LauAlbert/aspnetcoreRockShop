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
    [Migration("20180306044046_UpdateRock")]
    partial class UpdateRock
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RockShop.Models.Rock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LongDescription");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<string>("ShortDescription");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Rocks");
                });
#pragma warning restore 612, 618
        }
    }
}
