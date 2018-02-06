using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stats.DataAccess.Entities
{
    public class Team : EntityBase
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // virtual allows lazy loading
        // collection allows 1-to-many
        public virtual ICollection<Player> Players { get; set; }
        
    }
}