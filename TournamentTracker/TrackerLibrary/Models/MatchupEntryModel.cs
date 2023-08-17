using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// represents one team in the matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// represent score this perticular team
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// represent the matchup from where this team came as a winner
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }

    }
}
