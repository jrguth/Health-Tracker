using System;
using System.Collections.Generic;

#nullable disable

namespace Health.Web.Data.Models
{
    public partial class Habit
    {
        public Habit()
        {
            HabitEvents = new HashSet<HabitEvent>();
        }

        public int Id { get; set; }
        public int? RelationshipId { get; set; }
        public string HabitName { get; set; }

        public virtual Relationship Relationship { get; set; }
        public virtual ICollection<HabitEvent> HabitEvents { get; set; }
    }
}
