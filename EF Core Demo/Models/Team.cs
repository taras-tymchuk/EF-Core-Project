using System.Collections.Generic;

namespace EF_Core_Demo.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }

        public List<Player> Players { get; set; }
    }
}
