﻿// <auto-generated />
using System;
using Chapter1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chapter1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Chapter1.Models.CustomCustomer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BillingAddress");

                    b.Property<string>("Name");

                    b.HasKey("CustomerId");

                    b.ToTable("CustomCustomer");
                });

            modelBuilder.Entity("Chapter1.Models.CustomOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateAt");

                    b.Property<int>("CustomerId");

                    b.Property<int?>("CustomerId1");

                    b.Property<string>("Tag");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerId1");

                    b.ToTable("CustomOrder");
                });

            modelBuilder.Entity("Chapter1.Models.CustomOrderSellableItemRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode");

                    b.Property<int>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("Barcode");

                    b.HasIndex("OrderId");

                    b.ToTable("CustomOrderSellableItemRelations");
                });

            modelBuilder.Entity("Chapter1.Models.SellableItem", b =>
                {
                    b.Property<string>("Barcode")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("Title");

                    b.HasKey("Barcode");

                    b.ToTable("SellableItems");

                    b.HasData(
                        new { Barcode = "123", SellingPrice = 50m, Title = "Headphone" },
                        new { Barcode = "456", SellingPrice = 40m, Title = "Keyboard" },
                        new { Barcode = "789", SellingPrice = 100m, Title = "Monitor" }
                    );
                });

            modelBuilder.Entity("Chapter1.Models.CustomOrder", b =>
                {
                    b.HasOne("Chapter1.Models.CustomCustomer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Chapter1.Models.CustomCustomer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId1");
                });

            modelBuilder.Entity("Chapter1.Models.CustomOrderSellableItemRelation", b =>
                {
                    b.HasOne("Chapter1.Models.SellableItem", "SellableItems")
                        .WithMany("CustomOrderSellableItemRelations")
                        .HasForeignKey("Barcode");

                    b.HasOne("Chapter1.Models.CustomOrder", "CustomOrder")
                        .WithMany("CustomOrderSellableItemRelations")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
