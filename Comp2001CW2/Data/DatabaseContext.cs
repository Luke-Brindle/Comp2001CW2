using Microsoft.EntityFrameworkCore;
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

        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<ActiveUsersView> ActiveUsersView { get; set; }
        public DbSet<ArchivedAccounts> ArchivedAccounts { get; set; }
        public DbSet<ActiveUsersFavouriteActivities> ActiveUsersFavouriteActivities { get; set; }
        public DbSet<RegionBreakdown> RegionBreakdown { get; set; }
        public DbSet<LimitedView> LimitedView { get; set; }

        public DbSet<LocationsView> LocationsView { get; set; }
        public DbSet<LanguagesView> LanguagesView { get; set; }
        public DbSet<ActivitiesView> ActivitiesView { get; set; }

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

        public void CreateAccount(string email, string password, string username, string dateofbirth, string languageid, bool unitpref, bool timepref)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[CreateAccount]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@UserName", username);
            command.Parameters.AddWithValue("@DateOfBirth", dateofbirth);
            command.Parameters.AddWithValue("@LanguageID", languageid);
            command.Parameters.AddWithValue("@UnitPref", unitpref);
            command.Parameters.AddWithValue("@TimePref", timepref);

            command.ExecuteNonQuery();
        }

        public void DeleteFavActivity(int userID, int activityID)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[DeleteFavActivity]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@UserID", userID);
            command.Parameters.AddWithValue("@ActivityID", activityID);

            command.ExecuteNonQuery();
        }

        public void NewFavActivity(int userID, int activityID)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[NewFavActivity]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@UserID", userID);
            command.Parameters.AddWithValue("@ActivityID", activityID);

            command.ExecuteNonQuery();
        }

        public void EditAdminRights(int userID, bool adminRights)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[EditAdminRights]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@UserID", userID);
            command.Parameters.AddWithValue("@AdminRights", adminRights);

            command.ExecuteNonQuery();
        }

        public void UpdateAccount(int userID, string email, string password, string username, string dateofbirth, string languageid, int locationid, string aboutme, double height, double weight)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[UpdateAccount]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@UserID", userID);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@UserName", username);
            command.Parameters.AddWithValue("@DateOfBirth", dateofbirth);
            command.Parameters.AddWithValue("@LanguageID", languageid);
            command.Parameters.AddWithValue("@LocationID", locationid);
            command.Parameters.AddWithValue("@AboutMe", aboutme);
            command.Parameters.AddWithValue("@Height", height);
            command.Parameters.AddWithValue("@Weight", weight);

            command.ExecuteNonQuery();
        }

        public void UpdatePreferences(int userID, bool unitPref, bool timePref)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[UpdatePreferences]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@UserID", userID);
            command.Parameters.AddWithValue("@UnitPref", unitPref);
            command.Parameters.AddWithValue("@TimePref", timePref);

            command.ExecuteNonQuery();
        }

        public void CreateActivity(string activityName)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[CreateActivity]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@ActivityName", activityName);

            command.ExecuteNonQuery();
        }

        public void UpdateActivity(int activityID, string activityName)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[UpdateActivity]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@ActivityID", activityID);
            command.Parameters.AddWithValue("@ActivityName", activityName);

            command.ExecuteNonQuery();
        }

        public void DeleteActivity(int activityID)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[DeleteActivity]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@ActivityID", activityID);

            command.ExecuteNonQuery();
        }

        public void CreateLanguage(string languageID, string languageName)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[CreateLanguage]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@LanguageID", languageID);
            command.Parameters.AddWithValue("@LanguageName", languageName);

            command.ExecuteNonQuery();
        }

        public void UpdateLanguage(string languageID, string languageName)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[UpdateLanguage]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@LanguageID", languageID);
            command.Parameters.AddWithValue("@LanguageName", languageName);

            command.ExecuteNonQuery();
        }

        public void DeleteLanguage(string languageID)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[DeleteLanguage]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@LanguageID", languageID);

            command.ExecuteNonQuery();
        }



        public void CreateLocation(string town, string county, string country)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[CreateLocation]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Town", town);
            command.Parameters.AddWithValue("@County", county);
            command.Parameters.AddWithValue("@Country", country);

            command.ExecuteNonQuery();
        }

        public void UpdateLocation(int locationID, string town, string county, string country)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[UpdateLocation]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@LocationID", locationID);
            command.Parameters.AddWithValue("@Town", town);
            command.Parameters.AddWithValue("@County", county);
            command.Parameters.AddWithValue("@Country", country);

            command.ExecuteNonQuery();
        }

        public void DeleteLocation(int locationID)
        {
            using var connection = new SqlConnection(Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("[CW2].[DeleteLocation]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@LocationID", locationID);

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

            modelBuilder.Entity<LimitedView>(e =>
            {
                e.HasNoKey();
                e.ToView("LimitedView", "CW2");
            });


            modelBuilder.Entity<LocationsView>(e =>
            {
                e.HasNoKey();
                e.ToView("LocationsView", "CW2");
            });

            modelBuilder.Entity<LanguagesView>(e =>
            {
                e.HasNoKey();
                e.ToView("LanguagesView", "CW2");
            });

            modelBuilder.Entity<ActivitiesView>(e =>
            {
                e.HasNoKey();
                e.ToView("ActivitiesView", "CW2");
            });



        }
    }
}