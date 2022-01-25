﻿// <auto-generated />
using System;
using EquipmentRental.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EquipmentRental.Database.Migrations
{
    [DbContext(typeof(EquipmentRentalContext))]
    [Migration("20220125065638_AddNameStreetSurnameUserIdToRentModel")]
    partial class AddNameStreetSurnameUserIdToRentModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EquipmentRental.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("EquipmentRental.Models.Rent", b =>
                {
                    b.Property<Guid>("RentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsIssued")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsReturned")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("IssuedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SportEquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RentId");

                    b.HasIndex("SportEquipmentId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Rents", (string)null);
                });

            modelBuilder.Entity("EquipmentRental.Models.SportEquipment", b =>
                {
                    b.Property<Guid>("SportEquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceForDay")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SportEquipmentId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SportsEquipment", (string)null);
                });

            modelBuilder.Entity("EquipmentRental.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("EquipmentRental.Models.Rent", b =>
                {
                    b.HasOne("EquipmentRental.Models.SportEquipment", "SportEquipment")
                        .WithOne("Rent")
                        .HasForeignKey("EquipmentRental.Models.Rent", "SportEquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EquipmentRental.Models.User", "User")
                        .WithMany("Rents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SportEquipment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EquipmentRental.Models.SportEquipment", b =>
                {
                    b.HasOne("EquipmentRental.Models.Category", "Category")
                        .WithMany("SportsEquipment")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EquipmentRental.Models.Category", b =>
                {
                    b.Navigation("SportsEquipment");
                });

            modelBuilder.Entity("EquipmentRental.Models.SportEquipment", b =>
                {
                    b.Navigation("Rent")
                        .IsRequired();
                });

            modelBuilder.Entity("EquipmentRental.Models.User", b =>
                {
                    b.Navigation("Rents");
                });
#pragma warning restore 612, 618
        }
    }
}
