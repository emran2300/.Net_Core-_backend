﻿// <auto-generated />
using System;
using DemoApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoApplication.Migrations
{
    [DbContext(typeof(DemoDbContext))]
    [Migration("20220920204450_update")]
    partial class update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoApplication.Models.Category", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatId"), 1L, 1);

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DemoApplication.Models.Product", b =>
                {
                    b.Property<int>("ProId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProId"), 1L, 1);

                    b.Property<int?>("CatId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryCatId")
                        .HasColumnType("int");

                    b.Property<string>("ProName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProPrice")
                        .HasColumnType("float");

                    b.Property<int>("ProStock")
                        .HasColumnType("int");

                    b.HasKey("ProId");

                    b.HasIndex("CategoryCatId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DemoApplication.Models.Product", b =>
                {
                    b.HasOne("DemoApplication.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryCatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DemoApplication.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
