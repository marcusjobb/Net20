﻿// <auto-generated />
using System;
using HFABEF.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HFABEF.Migrations
{
    [DbContext(typeof(MyDatabase))]
    partial class MyDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HFABEF.Models.Door_Explanation", b =>
                {
                    b.Property<string>("Door_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Explanation")
                        .HasColumnType("TEXT");

                    b.HasKey("Door_Name");

                    b.ToTable("Door_Explanation");
                });

            modelBuilder.Entity("HFABEF.Models.Doors", b =>
                {
                    b.Property<string>("Door")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.HasKey("Door");

                    b.ToTable("Doors");
                });

            modelBuilder.Entity("HFABEF.Models.Event", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Explanation")
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("HFABEF.Models.Logs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Door1")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventCode")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Door1");

                    b.HasIndex("EventCode");

                    b.HasIndex("TenantId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("HFABEF.Models.Tenants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tag")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenant")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("HFABEF.Models.Tenants_Info", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Info")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("Tenants_Info");
                });

            modelBuilder.Entity("HFABEF.Models.Logs", b =>
                {
                    b.HasOne("HFABEF.Models.Doors", "Door")
                        .WithMany()
                        .HasForeignKey("Door1");

                    b.HasOne("HFABEF.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventCode");

                    b.HasOne("HFABEF.Models.Tenants", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Door");

                    b.Navigation("Event");

                    b.Navigation("Tenant");
                });
#pragma warning restore 612, 618
        }
    }
}
