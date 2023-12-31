﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RobertMaxim.DataModel;

namespace RobertMaxim.DataModel.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231006072734_DrugTypeWeightUpdate")]
    partial class DrugTypeWeightUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RobertMaxim.DataModel.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("RobertMaxim.DataModel.Depot", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvenienceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvenienceId");

                    b.ToTable("Depots");
                });

            modelBuilder.Entity("RobertMaxim.DataModel.DrugType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("DrugTypes");
                });

            modelBuilder.Entity("RobertMaxim.DataModel.DrugUnit", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepotId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PickNumber")
                        .HasColumnType("int");

                    b.Property<string>("SiteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepotId");

                    b.HasIndex("SiteId");

                    b.HasIndex("TypeId");

                    b.ToTable("DrugUnits");
                });

            modelBuilder.Entity("RobertMaxim.DataModel.Site", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CountryCode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("RobertMaxim.DataModel.Country", b =>
                {
                    b.HasOne("RobertMaxim.DataModel.Depot", "Supplier")
                        .WithMany("CountriesSupplied")
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("RobertMaxim.DataModel.Depot", b =>
                {
                    b.HasOne("RobertMaxim.DataModel.Country", "Provenience")
                        .WithMany()
                        .HasForeignKey("ProvenienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RobertMaxim.DataModel.DrugUnit", b =>
                {
                    b.HasOne("RobertMaxim.DataModel.Depot", "Depot")
                        .WithMany("DrugUnits")
                        .HasForeignKey("DepotId");

                    b.HasOne("RobertMaxim.DataModel.Site", null)
                        .WithMany("DrugUnits")
                        .HasForeignKey("SiteId");

                    b.HasOne("RobertMaxim.DataModel.DrugType", "Type")
                        .WithMany("DrugUnits")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
