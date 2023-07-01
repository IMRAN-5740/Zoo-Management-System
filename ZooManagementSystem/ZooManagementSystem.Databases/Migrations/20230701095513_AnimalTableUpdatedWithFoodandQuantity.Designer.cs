﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZMS.Databases.Data;

#nullable disable

namespace ZMS.Databases.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230701095513_AnimalTableUpdatedWithFoodandQuantity")]
    partial class AnimalTableUpdatedWithFoodandQuantity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ZMS.Models.EntityModels.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("ZMS.Models.EntityModels.AnimalFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("FoodId");

                    b.ToTable("AnimalFoods");
                });

            modelBuilder.Entity("ZMS.Models.EntityModels.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("ZMS.Models.EntityModels.AnimalFood", b =>
                {
                    b.HasOne("ZMS.Models.EntityModels.Animal", "Animal")
                        .WithMany("AnimalFoods")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZMS.Models.EntityModels.Food", "Food")
                        .WithMany("AnimalFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("ZMS.Models.EntityModels.Animal", b =>
                {
                    b.Navigation("AnimalFoods");
                });

            modelBuilder.Entity("ZMS.Models.EntityModels.Food", b =>
                {
                    b.Navigation("AnimalFoods");
                });
#pragma warning restore 612, 618
        }
    }
}