using System;
using System.Collections.Generic;

#nullable disable

namespace Health.Web.Data.Models
{
    public partial class HealthLog
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Log { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
