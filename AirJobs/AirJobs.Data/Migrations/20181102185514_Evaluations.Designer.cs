﻿// <auto-generated />
using System;
using AirJobs.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirJobs.Data.Migrations
{
    [DbContext(typeof(AirJobsContext))]
    [Migration("20181102185514_Evaluations")]
    partial class Evaluations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirJobs.Domain.Entities.Addresses.Address", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("CityId");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Addresses.City", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Addresses.Country", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Addresses.State", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Jobs.Evaluation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("JobId");

                    b.Property<Guid>("SchedulingId");

                    b.Property<int>("Stars");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("SchedulingId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Evaluation");
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Jobs.Favorite", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("JobId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Jobs.Job", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("AddressId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Users.Scheduling", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime>("JobDate");

                    b.Property<Guid>("JobId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("Scheduling");
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Addresses.Address", b =>
                {
                    b.HasOne("AirJobs.Domain.Entities.Addresses.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirJobs.Domain.Entities.Users.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("GeoCoordinatePortable.GeoCoordinate", "GeoLocation", b1 =>
                        {
                            b1.Property<Guid?>("AddressId");

                            b1.Property<double>("Latitude")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnName("Longitude");

                            b1.ToTable("Address");

                            b1.HasOne("AirJobs.Domain.Entities.Addresses.Address")
                                .WithOne("GeoLocation")
                                .HasForeignKey("GeoCoordinatePortable.GeoCoordinate", "AddressId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Addresses.City", b =>
                {
                    b.HasOne("AirJobs.Domain.Entities.Addresses.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Addresses.State", b =>
                {
                    b.HasOne("AirJobs.Domain.Entities.Addresses.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Jobs.Evaluation", b =>
                {
                    b.HasOne("AirJobs.Domain.Entities.Jobs.Job", "Job")
                        .WithMany("Evaluations")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirJobs.Domain.Entities.Users.Scheduling", "Scheduling")
                        .WithOne("Evaluation")
                        .HasForeignKey("AirJobs.Domain.Entities.Jobs.Evaluation", "SchedulingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirJobs.Domain.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Jobs.Favorite", b =>
                {
                    b.HasOne("AirJobs.Domain.Entities.Jobs.Job", "Job")
                        .WithMany("Favorites")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirJobs.Domain.Entities.Users.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Jobs.Job", b =>
                {
                    b.HasOne("AirJobs.Domain.Entities.Addresses.Address", "Address")
                        .WithMany("Jobs")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Users.Scheduling", b =>
                {
                    b.HasOne("AirJobs.Domain.Entities.Jobs.Job", "Job")
                        .WithMany("Scheduling")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AirJobs.Domain.Entities.Users.User", "User")
                        .WithMany("Schedulings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AirJobs.Domain.Entities.Users.User", b =>
                {
                    b.OwnsOne("AirJobs.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid?>("UserId");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnName("FirstName")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnName("LastName")
                                .HasColumnType("varchar(200)");

                            b1.ToTable("User");

                            b1.HasOne("AirJobs.Domain.Entities.Users.User")
                                .WithOne("Name")
                                .HasForeignKey("AirJobs.Domain.ValueObjects.Name", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}