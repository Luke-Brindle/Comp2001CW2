using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Comp2001CW2.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Comp2001CW2.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }


        public DbSet<User> Accounts { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<ActiveUsersView> ActiveUsersView { get; set; }
        public DbSet<ArchivedAccounts> ArchivedAccounts { get; set; }
        public DbSet<ActiveUsersFavouriteActivities> ActiveUsersFavouriteActivities { get; set; }
        public DbSet<RegionBreakdown> RegionBreakdown { get; set; }

        public void ArchiveAccount(int userID)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[ArchiveAccount]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@UserID", userID);
            command.ExecuteNonQuery();
        }

        public void UnarchiveAccount(int userID)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[UnarchiveAccount]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@UserID", userID);
            command.ExecuteNonQuery();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Accounts", "CW2");
            modelBuilder.Entity<ActiveUsersView>(e =>
            {
                e.HasNoKey();
                e.ToView("ActiveAccounts", "CW2"); 
            });

            modelBuilder.Entity<ArchivedAccounts>(e =>
            {
                e.HasNoKey();
                e.ToView("ArchivedAccounts", "CW2"); 
            });

            modelBuilder.Entity<ActiveUsersFavouriteActivities>(e =>
            {
                e.HasNoKey();
                e.ToView("ActiveUsersFavouriteActivities", "CW2");
            });

            modelBuilder.Entity<RegionBreakdown>(e =>
            {
                e.HasNoKey();
                e.ToView("RegionBreakdown", "CW2");
            });
        }

    }
}