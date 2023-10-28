﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Ookly.Infrastructure.EntityFramework;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231027204052_CountryCategoryFilter")]
    partial class CountryCategoryFilter
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategoryCountry", b =>
                {
                    b.Property<string>("CategoriesId")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("CountriesId")
                        .HasColumnType("character varying(20)");

                    b.HasKey("CategoriesId", "CountriesId");

                    b.HasIndex("CountriesId");

                    b.ToTable("CategoryCountry");
                });

            modelBuilder.Entity("CategoryFilter", b =>
                {
                    b.Property<string>("CategoriesId")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("FiltersId")
                        .HasColumnType("character varying(20)");

                    b.HasKey("CategoriesId", "FiltersId");

                    b.HasIndex("FiltersId");

                    b.ToTable("CategoryFilter");
                });

            modelBuilder.Entity("CountryFilter", b =>
                {
                    b.Property<string>("CountriesId")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("FiltersId")
                        .HasColumnType("character varying(20)");

                    b.HasKey("CountriesId", "FiltersId");

                    b.HasIndex("FiltersId");

                    b.ToTable("CountryFilter");
                });

            modelBuilder.Entity("Ookly.Core.AdAggregate.Ad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("Bathrooms")
                        .HasColumnType("integer");

                    b.Property<int?>("Bedrooms")
                        .HasColumnType("integer");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("Furnished")
                        .HasColumnType("boolean");

                    b.Property<bool?>("Pets")
                        .HasColumnType("boolean");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SourceUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("State")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("Surface")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("VehicleBrandId")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("VehicleColor")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("VehicleFuelType")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<int?>("VehicleMileage")
                        .HasColumnType("integer");

                    b.Property<string>("VehicleModelId")
                        .HasColumnType("character varying(20)");

                    b.Property<int?>("VehicleYear")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.HasIndex("VehicleBrandId");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.CountryCategoryFilter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.Property<string>("FilterId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.HasIndex("FilterId");

                    b.ToTable("CountryCategoryFilter");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Filter", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Filter");
                });

            modelBuilder.Entity("Ookly.Core.VehicleBrandAggregate.VehicleBrand", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("VehicleBrands");
                });

            modelBuilder.Entity("Ookly.Core.VehicleBrandAggregate.VehicleModel", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("VehicleBrandId")
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("VehicleBrandId");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("CategoryCountry", b =>
                {
                    b.HasOne("Ookly.Core.CountryAggregate.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.CountryAggregate.Country", null)
                        .WithMany()
                        .HasForeignKey("CountriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryFilter", b =>
                {
                    b.HasOne("Ookly.Core.CountryAggregate.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.CountryAggregate.Filter", null)
                        .WithMany()
                        .HasForeignKey("FiltersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CountryFilter", b =>
                {
                    b.HasOne("Ookly.Core.CountryAggregate.Country", null)
                        .WithMany()
                        .HasForeignKey("CountriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.CountryAggregate.Filter", null)
                        .WithMany()
                        .HasForeignKey("FiltersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ookly.Core.AdAggregate.Ad", b =>
                {
                    b.HasOne("Ookly.Core.CountryAggregate.Category", "Category")
                        .WithMany("Ads")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.CountryAggregate.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.VehicleBrandAggregate.VehicleBrand", "VehicleBrand")
                        .WithMany()
                        .HasForeignKey("VehicleBrandId");

                    b.HasOne("Ookly.Core.VehicleBrandAggregate.VehicleModel", "VehicleModel")
                        .WithMany()
                        .HasForeignKey("VehicleModelId");

                    b.Navigation("Category");

                    b.Navigation("Country");

                    b.Navigation("VehicleBrand");

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.CountryCategoryFilter", b =>
                {
                    b.HasOne("Ookly.Core.CountryAggregate.Category", "Category")
                        .WithMany("CountryCategoryFilter")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.CountryAggregate.Country", "Country")
                        .WithMany("CountryCategoryFilter")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.CountryAggregate.Filter", "Filter")
                        .WithMany("CountryCategoryFilter")
                        .HasForeignKey("FilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Country");

                    b.Navigation("Filter");
                });

            modelBuilder.Entity("Ookly.Core.VehicleBrandAggregate.VehicleModel", b =>
                {
                    b.HasOne("Ookly.Core.VehicleBrandAggregate.VehicleBrand", null)
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleBrandId");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Category", b =>
                {
                    b.Navigation("Ads");

                    b.Navigation("CountryCategoryFilter");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Country", b =>
                {
                    b.Navigation("CountryCategoryFilter");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Filter", b =>
                {
                    b.Navigation("CountryCategoryFilter");
                });

            modelBuilder.Entity("Ookly.Core.VehicleBrandAggregate.VehicleBrand", b =>
                {
                    b.Navigation("VehicleModels");
                });
#pragma warning restore 612, 618
        }
    }
}
