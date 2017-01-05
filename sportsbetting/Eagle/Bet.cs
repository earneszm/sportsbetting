using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eagle
{
    public class Bet
    {
        public int BetID { get; set; }
        public string Comment { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int FinalScore { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
