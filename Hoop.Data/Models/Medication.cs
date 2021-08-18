using System;
using System.Collections.Generic;

#nullable disable

namespace Health.Web.Data.Models
{
    public partial class Medication
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Description { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
