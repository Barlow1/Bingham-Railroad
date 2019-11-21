﻿// <auto-generated />
using System;
using BinghamRailroad.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BinghamRailroad.Migrations
{
    [DbContext(typeof(BingRailContext))]
    [Migration("20191121180758_AddRoute")]
    partial class AddRoute
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("BinghamRailroad.Models.Amenity", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("Amenity");
                });

            modelBuilder.Entity("BinghamRailroad.Models.Rider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rider");
                });

            modelBuilder.Entity("BinghamRailroad.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("DestinationStation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OriginStation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrainId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("BinghamRailroad.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Station");
                });

            modelBuilder.Entity("BinghamRailroad.Models.StationAmenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmenityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("StationAmenity");
                });

            modelBuilder.Entity("BinghamRailroad.Models.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumSeats")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Train");
                });

            modelBuilder.Entity("BinghamRailroad.Models.TrainAmenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmenityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrainId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TrainAmenity");
                });
#pragma warning restore 612, 618
        }
    }
}
