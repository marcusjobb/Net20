﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ooa_2_husrum_ef.Database;

namespace ooa_2_husrum_ef.Migrations
{
    [DbContext(typeof(LogsContext))]
    partial class LogsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Access", b =>
                {
                    b.Property<string>("TagId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DoorId")
                        .HasColumnType("TEXT");

                    b.HasKey("TagId", "DoorId");

                    b.HasIndex("DoorId");

                    b.ToTable("Accesses");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Door", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Doors");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Event", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Location", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.LogEntry", b =>
                {
                    b.Property<string>("TagId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("When")
                        .HasColumnType("TEXT");

                    b.Property<string>("DoorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventId")
                        .HasColumnType("TEXT");

                    b.HasKey("TagId", "When");

                    b.HasIndex("DoorId");

                    b.HasIndex("EventId");

                    b.ToTable("LogEntries");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Tag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Activate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Expire")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Tenant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ApartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Access", b =>
                {
                    b.HasOne("ooa_2_husrum_ef.Models.Door", "Door")
                        .WithMany()
                        .HasForeignKey("DoorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ooa_2_husrum_ef.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Door");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Door", b =>
                {
                    b.HasOne("ooa_2_husrum_ef.Models.Location", "Location")
                        .WithMany("Doors")
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.LogEntry", b =>
                {
                    b.HasOne("ooa_2_husrum_ef.Models.Door", "Door")
                        .WithMany("LogEntries")
                        .HasForeignKey("DoorId");

                    b.HasOne("ooa_2_husrum_ef.Models.Event", "Event")
                        .WithMany("LogEntries")
                        .HasForeignKey("EventId");

                    b.HasOne("ooa_2_husrum_ef.Models.Tag", "Tag")
                        .WithMany("LogEntries")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Door");

                    b.Navigation("Event");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Tag", b =>
                {
                    b.HasOne("ooa_2_husrum_ef.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Tenant", b =>
                {
                    b.HasOne("ooa_2_husrum_ef.Models.Location", "Apartment")
                        .WithMany("Tenants")
                        .HasForeignKey("ApartmentId");

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Door", b =>
                {
                    b.Navigation("LogEntries");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Event", b =>
                {
                    b.Navigation("LogEntries");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Location", b =>
                {
                    b.Navigation("Doors");

                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("ooa_2_husrum_ef.Models.Tag", b =>
                {
                    b.Navigation("LogEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
