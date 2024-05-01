﻿// <auto-generated />
using System;
using GameWeb.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameWeb.Migrations
{
    [DbContext(typeof(FarmDbContext))]
    [Migration("20240430124526_creacionRemota")]
    partial class creacionRemota
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameWeb.Models.Crops", b =>
                {
                    b.Property<int>("CropId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CropId"));

                    b.Property<string>("CropName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FarmId")
                        .HasColumnType("int");

                    b.HasKey("CropId");

                    b.ToTable("Crops");
                });

            modelBuilder.Entity("GameWeb.Models.Devices", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceId"));

                    b.Property<string>("Consumer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FarmId")
                        .HasColumnType("int");

                    b.HasKey("DeviceId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("GameWeb.Models.DevicesTypeEnergy", b =>
                {
                    b.Property<int>("DevicesEnergyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DevicesEnergyId"));

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("TypeEnergyId")
                        .HasColumnType("int");

                    b.HasKey("DevicesEnergyId");

                    b.ToTable("DevicesTypeEnergy");
                });

            modelBuilder.Entity("GameWeb.Models.Farms", b =>
                {
                    b.Property<int>("FarmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmId"));

                    b.Property<string>("FarmName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FarmId");

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("GameWeb.Models.Tasks", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FarmId")
                        .HasColumnType("int");

                    b.Property<bool?>("Finished")
                        .HasColumnType("bit");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("GameWeb.Models.TypeEnergy", b =>
                {
                    b.Property<int>("TypeEnergyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeEnergyId"));

                    b.Property<string>("TypeEnergyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeEnergyId");

                    b.ToTable("TypeEnergy");
                });
#pragma warning restore 612, 618
        }
    }
}
