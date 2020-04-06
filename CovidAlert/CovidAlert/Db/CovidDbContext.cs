using System;
using System.IO;
using CovidAlert.Db.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace CovidAlert.Db
{
    public class CovidDbContext : DbContext
    {
        private const string databaseName = "coronavirus.db";

        public DbSet<CountryName> CountryNames
        {
            get;
            set;
        }

        public DbSet<Country> Countries
        {
            get;
            set;
        }

        public DbSet<Statistics> Statistics
        {
            get;
            set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databasePath = String.Empty;

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                {
                    var basePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    databasePath = Path.Combine(basePath, databaseName);
                    break;
                }

                case Device.UWP:
                {
                    var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    databasePath = Path.Combine(basePath, databaseName);
                    break;
                }

                case Device.iOS:
                {
                    SQLitePCL.Batteries_V2.Init();
                    var basePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    databasePath = Path.Combine(basePath, "..", "Library", databaseName);
                    break;
                }
            }

            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasIndex(nameof(Country.Code), nameof(Country.Province))
                .IsUnique(true);
        }
    }
}