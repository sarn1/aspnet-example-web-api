using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stats.Models
{
    public class PlayerModel
    {
        public string Url { get; set; }
        public int PlayerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; } 
    }
}