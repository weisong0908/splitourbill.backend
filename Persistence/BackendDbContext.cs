using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using splitourbill_backend.Models.DomainModels;
using splitourbill_backend.Utils;

namespace splitourbill_backend.Persistence
{
    public class BackendDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<BillPurpose> BillPurposes { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillSharing> BillSharings { get; set; }

        public BackendDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(Constants.Database.UserTable, Constants.Database.Schema);
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(u => u.Username).HasColumnName("username");
            modelBuilder.Entity<User>().Property(u => u.EmailAddress).HasColumnName("email_address");

            modelBuilder.Entity<Friendship>().ToTable(Constants.Database.FriendshipTable, Constants.Database.Schema);
            modelBuilder.Entity<Friendship>().Property(r => r.Id).HasColumnName("id");
            modelBuilder.Entity<Friendship>().Property(r => r.RequestorId).HasColumnName("requestor_id");
            modelBuilder.Entity<Friendship>().Property(r => r.RequesteeId).HasColumnName("requestee_id");
            modelBuilder.Entity<Friendship>().Property(r => r.Status).HasColumnName("status");

            modelBuilder.Entity<BillPurpose>().ToTable(Constants.Database.BillPurposeTable, Constants.Database.Schema);
            modelBuilder.Entity<BillPurpose>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<BillPurpose>().Property(b => b.Name).HasColumnName("name");
            modelBuilder.Entity<BillPurpose>().Property(b => b.Category).HasColumnName("category");

            modelBuilder.Entity<Bill>().ToTable(Constants.Database.BillTable, Constants.Database.Schema);
            modelBuilder.Entity<Bill>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<Bill>().Property(b => b.DateTime).HasColumnName("date_time");
            modelBuilder.Entity<Bill>().Property(b => b.InitiatorId).HasColumnName("initiator_id");
            modelBuilder.Entity<Bill>().Property(b => b.TotalAmount).HasColumnName("total_amount");
            modelBuilder.Entity<Bill>().Property(b => b.BillPurposeId).HasColumnName("bill_purpose_id");
            modelBuilder.Entity<Bill>().Property(b => b.Remarks).HasColumnName("remarks");

            modelBuilder.Entity<BillSharing>().ToTable(Constants.Database.BillSharingTable, Constants.Database.Schema);
            modelBuilder.Entity<BillSharing>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<BillSharing>().Property(b => b.Amount).HasColumnName("amount");
            modelBuilder.Entity<BillSharing>().Property(b => b.SharerId).HasColumnName("sharer_id");
            modelBuilder.Entity<BillSharing>().Property(b => b.BillId).HasColumnName("bill_id");

            SeedDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var users = new List<User>()
            {
                new User(){ Id = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"), Username = "User 1"},
                new User(){ Id = new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"), Username = "User 2"}
            };
            modelBuilder.Entity<User>().HasData(users);

            var friendships = new List<Friendship>()
            {
                new Friendship()
                {
                    Id = new Guid("709fb6ba-705a-449b-8060-d09626deca01"),
                    RequestorId = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"),
                    RequesteeId = new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"),
                    Status = Constants.RelationshipStatuses.Accepted
                }
            };
            modelBuilder.Entity<Friendship>().HasData(friendships);

            var billPurposes = new List<BillPurpose>()
            {
                new BillPurpose("Breakfast", "Meal"){ Id = 1 },
                new BillPurpose("Lunch", "Meal"){ Id = 2 },
                new BillPurpose("Dinner", "Meal"){ Id = 3 },
                new BillPurpose("Supper", "Meal"){ Id = 4 },
                new BillPurpose("Snack", "Meal"){ Id = 5 },
                new BillPurpose("Drink", "Meal"){ Id = 6 },
                new BillPurpose("Brunch", "Meal"){ Id = 7 },
                new BillPurpose("Movie", "Activity"){ Id = 8 },
                new BillPurpose("Sing K", "Activity"){ Id = 9},
                new BillPurpose("Workout", "Activity"){ Id = 10 },
                new BillPurpose("Wedding", "Event"){ Id = 11 },
                new BillPurpose("Songka", "Event"){ Id = 12 },
                new BillPurpose("Other", "Other"){ Id = 13 }
            };
            modelBuilder.Entity<BillPurpose>().HasData(billPurposes);

            var bills = new List<Bill>()
            {
                new Bill()
                {
                    Id = new Guid("9024c3c8-a3f8-4b09-9ae5-d44850d9f354"),
                    InitiatorId = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"),
                    TotalAmount = 10,
                    BillPurposeId = 1,
                    Remarks = "no remarks",
                    DateTime = new DateTime(2020, 1, 20, 10, 20, 33)
                }
            };
            modelBuilder.Entity<Bill>().HasData(bills);

            var billSharings = new List<BillSharing>()
            {
                new BillSharing()
                {
                    Id = new Guid("e05ffb93-82ca-44fb-ab65-a4bdf415b237"),
                    SharerId = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"),
                    Amount = 3,
                    BillId = new Guid("9024c3c8-a3f8-4b09-9ae5-d44850d9f354")
                },
                new BillSharing()
                {
                    Id = new Guid("abdf45b0-3038-4659-a791-9b212528cc70"),
                    SharerId = new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"),
                    Amount = 7,
                    BillId = new Guid("9024c3c8-a3f8-4b09-9ae5-d44850d9f354")
                }
            };
            modelBuilder.Entity<BillSharing>().HasData(billSharings);
        }
    }
}