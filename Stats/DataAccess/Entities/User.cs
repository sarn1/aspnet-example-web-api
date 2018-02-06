using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stats.Entities
{
    public class User
    {
        public int ID { get; set; } //entity will see ID and know its the primary key
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateCreated { get; set; }

        // a user is associate to an account, make account a sub-entity of user (navigational property?? )
        // but not load account unless its trying to be used
        public virtual Account Account { get; set; }
    }
}