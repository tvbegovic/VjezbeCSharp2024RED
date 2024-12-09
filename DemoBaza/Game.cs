using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBaza
{
    internal class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? IdGenre { get; set; }
        public int? IdPublisher { get; set; }
        public int? IdDeveloper { get; set; }
        public double? Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
    }
}
