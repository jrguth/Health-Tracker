using System;
using System.Collections.Generic;

#nullable disable

namespace Hoop.Data.Models
{
    public partial class CheckIn
    {
        public int Id { get; set; }
        public int? RelationshipId { get; set; }
        public int? MoodId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Mood Mood { get; set; }
        public virtual Relationship Relationship { get; set; }
    }
}
