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
            modelBuilder.Entity<Friendship>().Property(r => r.Requestor).HasColumnName("requestor");
            modelBuilder.Entity<Friendship>().Property(r => r.Requestee).HasColumnName("requestee");
            modelBuilder.Entity<Friendship>().Property(r => r.Status).HasColumnName("status");

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
                    Requestor = new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"),
                    Requestee = new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"),
                    Status = Constants.RelationshipStatuses.Accepted
                }
            };

            modelBuilder.Entity<Friendship>().HasData(friendships);
        }
    }
}