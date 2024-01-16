using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Comp2001CW2.Models;

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