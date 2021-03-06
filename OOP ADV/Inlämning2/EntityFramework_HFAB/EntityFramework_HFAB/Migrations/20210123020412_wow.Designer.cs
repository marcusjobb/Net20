﻿// <auto-generated />
using EntityFramework_HFAB.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFramework_HFAB.Migrations
{
    [DbContext(typeof(MyDatabase))]
    [Migration("20210123020412_wow")]
    partial class wow
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("EntityFramework_HFAB.Models.Door", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DoorName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Doors");
                });

            modelBuilder.Entity("EntityFramework_HFAB.Models.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventName")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EntityFramework_HFAB.Models.LogEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Door")
                        .HasColumnType("TEXT");

                    b.Property<string>("Event")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tag")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("LogEntries");
                });

            modelBuilder.Entity("EntityFramework_HFAB.Models.Tenant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tag")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Tenants");
                });
#pragma warning restore 612, 618
        }
    }
}
