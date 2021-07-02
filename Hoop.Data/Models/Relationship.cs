using System;
using System.Collections.Generic;

#nullable disable

namespace Hoop.Data.Models
{
    public partial class Relationship
    {
        public Relationship()
        {
            CheckIns = new HashSet<CheckIn>();
            Habits = new HashSet<Habit>();
        }

        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? ProfessionalId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Professional Professional { get; set; }
        public virtual ICollection<CheckIn> CheckIns { get; set; }
        public virtual ICollection<Habit> Habits { get; set; }
    }
}
