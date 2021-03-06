﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using splitourbill_backend.Persistence;

namespace splitourbill_backend.Migrations
{
    [DbContext(typeof(BackendDbContext))]
    partial class BackendDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("splitourbill_backend.Models.DomainModels.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<int>("BillPurposeId")
                        .HasColumnName("bill_purpose_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnName("date_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("InitiatorId")
                        .HasColumnName("initiator_id")
                        .HasColumnType("uuid");

                    b.Property<string>("Remarks")
                        .HasColumnName("remarks")
                        .HasColumnType("text");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnName("total_amount")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("bills","backend");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9024c3c8-a3f8-4b09-9ae5-d44850d9f354"),
                            BillPurposeId = 1,
                            DateTime = new DateTime(2020, 1, 20, 10, 20, 33, 0, DateTimeKind.Unspecified),
                            InitiatorId = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"),
                            Remarks = "no remarks",
                            TotalAmount = 10m
                        });
                });

            modelBuilder.Entity("splitourbill_backend.Models.DomainModels.BillPurpose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Category")
                        .HasColumnName("category")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("bill_purposes","backend");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Meal",
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Meal",
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Meal",
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Meal",
                            Name = "Supper"
                        },
                        new
                        {
                            Id = 5,
                            Category = "Meal",
                            Name = "Snack"
                        },
                        new
                        {
                            Id = 6,
                            Category = "Meal",
                            Name = "Drink"
                        },
                        new
                        {
                            Id = 7,
                            Category = "Meal",
                            Name = "Brunch"
                        },
                        new
                        {
                            Id = 8,
                            Category = "Activity",
                            Name = "Movie"
                        },
                        new
                        {
                            Id = 9,
                            Category = "Activity",
                            Name = "Sing K"
                        },
                        new
                        {
                            Id = 10,
                            Category = "Activity",
                            Name = "Workout"
                        },
                        new
                        {
                            Id = 11,
                            Category = "Event",
                            Name = "Wedding"
                        },
                        new
                        {
                            Id = 12,
                            Category = "Event",
                            Name = "Songka"
                        },
                        new
                        {
                            Id = 13,
                            Category = "Other",
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("splitourbill_backend.Models.DomainModels.BillSharing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("numeric");

                    b.Property<Guid>("BillId")
                        .HasColumnName("bill_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SharerId")
                        .HasColumnName("sharer_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("bill_sharings","backend");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e05ffb93-82ca-44fb-ab65-a4bdf415b237"),
                            Amount = 3m,
                            BillId = new Guid("9024c3c8-a3f8-4b09-9ae5-d44850d9f354"),
                            SharerId = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd")
                        },
                        new
                        {
                            Id = new Guid("abdf45b0-3038-4659-a791-9b212528cc70"),
                            Amount = 7m,
                            BillId = new Guid("9024c3c8-a3f8-4b09-9ae5-d44850d9f354"),
                            SharerId = new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6")
                        });
                });

            modelBuilder.Entity("splitourbill_backend.Models.DomainModels.Friendship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RequesteeId")
                        .HasColumnName("requestee_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RequestorId")
                        .HasColumnName("requestor_id")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .HasColumnName("status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("friendships","backend");

                    b.HasData(
                        new
                        {
                            Id = new Guid("709fb6ba-705a-449b-8060-d09626deca01"),
                            RequesteeId = new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"),
                            RequestorId = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"),
                            Status = "accepted"
                        });
                });

            modelBuilder.Entity("splitourbill_backend.Models.DomainModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("EmailAddress")
                        .HasColumnName("email_address")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("users","backend");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"),
                            Username = "User 1"
                        },
                        new
                        {
                            Id = new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"),
                            Username = "User 2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
