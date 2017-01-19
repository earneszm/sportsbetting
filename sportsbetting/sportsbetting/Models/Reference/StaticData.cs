using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sportsbetting.Models
{
    public static class StaticData
    {
        public static Dictionary<int, Team> Teams { get { return _Teams; } }

        private static Dictionary<int, Team> _Teams = new Dictionary<int, Team>
        {
            {1, new Team() { Name = "Siena", Mascot = "Saints" } },
            {2, new Team() { Name = "Albany", Mascot = "Great Danes" } },
            {3, new Team() { Name = "James Madison", Mascot = "Dukes" } }
        };


    }

    public class Team
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Mascot { get; set; }
    }

}