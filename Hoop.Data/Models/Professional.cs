using System;
using System.Collections.Generic;

#nullable disable

namespace Health.Web.Data.Models
{
    public partial class Professional
    {
        public Professional()
        {
            Relationships = new HashSet<Relationship>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Relationship> Relationships { get; set; }
    }
}
