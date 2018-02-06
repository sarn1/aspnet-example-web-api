using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stats.DataAccess.Entities
{
    public class Player : EntityBase
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // tells entity that a player belongs to only 1 Team.
        public virtual Team Team { get; set; }
    }
}