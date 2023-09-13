using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_6.Library.Models
{
    internal class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Team(int id = 0, string name = "")
        {
            Id = id;
            Name = name;
        }
    }
}
