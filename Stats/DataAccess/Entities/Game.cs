using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stats.DataAccess.Entities
{
    public class Game : EntityBase
    {
        // virtual so it's only loaded if needed
        public virtual Team HomeTeam {get;set;}
        public virtual Team AwayTeam { get; set; }
        public DateTime StartTime { get; set; }
    }
}