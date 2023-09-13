using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_6.Library.Models
{
    internal class MyLibContext : DbContext
    {
        private static string StrConnection = ConfigurationManager.ConnectionStrings["Default"].ToString();
        public DbSet<Team> Teams { get; set; }
        public DbSet<SpanishFootballChampionship> SpanishFootballChampionships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(StrConnection);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(new List<Team>() {
            new Team()
            {
                Id = 1,
                Name = "Team_Name_1",
            },
            new Team()
            {
                Id = 2,
                Name = "Team_Name_2",
            },
            new Team()
            {
                Id = 3,
                Name = "Team_Name_3",
            }
            });

            modelBuilder.Entity<SpanishFootballChampionship>().HasData(new List<SpanishFootballChampionship>() {
            new SpanishFootballChampionship()
            {
                Id = 1,
                TeamId = 1,
                NumberOfDraws = 0,
                NumberOfLesions = 0,
                NumberOfWon = 3,
                Rank = 1,
            },
            new SpanishFootballChampionship()
            {
                Id = 2,
                TeamId = 2,
                NumberOfDraws = 1,
                NumberOfLesions = 2,
                NumberOfWon = 1,
                Rank = 2,
            },
            new SpanishFootballChampionship()
            {
                Id = 3,
                TeamId = 3,
                NumberOfDraws = 1,
                NumberOfLesions = 2,
                NumberOfWon = 0,
                Rank = 3,
            }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
