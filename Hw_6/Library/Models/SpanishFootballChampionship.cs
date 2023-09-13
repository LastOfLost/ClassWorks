using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_6.Library.Models
{
    internal class SpanishFootballChampionship
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int NumberOfWon { get; set; }
        public int NumberOfLesions { get; set; }
        public int NumberOfDraws { get; set; }
        public int Rank { get; set; }

        public SpanishFootballChampionship(int id = 0, int teamId = 0, int numberOfWon = 0,
            int numberOfLesions = 0, int numberOfDraws = 0, int rank = 0)
        {
            Id = id;
            TeamId = teamId;
            NumberOfWon = numberOfWon;
            NumberOfLesions = numberOfLesions;
            NumberOfDraws = numberOfDraws;
            Rank = rank;
        }
    }
}

/*
 * Install-Package System.Configuration.ConfigurationManager Microsoft.EntityFrameworkCore.Tools Microsoft.EntityFrameworkCore.SqlServer Microsoft.EntityFrameworkCore
 * 
 */
