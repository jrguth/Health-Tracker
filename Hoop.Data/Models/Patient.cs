using System;
using System.Collections.Generic;

#nullable disable

namespace Hoop.Data.Models
{
    public partial class Patient
    {
        public Patient()
        {
            HealthLogs = new HashSet<HealthLog>();
            Medications = new HashSet<Medication>();
            Moods = new HashSet<Mood>();
            Relationships = new HashSet<Relationship>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<HealthLog> HealthLogs { get; set; }
        public virtual ICollection<Medication> Medications { get; set; }
        public virtual ICollection<Mood> Moods { get; set; }
        public virtual ICollection<Relationship> Relationships { get; set; }
    }
}
