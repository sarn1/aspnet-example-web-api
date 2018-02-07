using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Stats.DataAccess.Entities
{
    public abstract class ReportingBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // if null and store in db, create a default date
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}