using System;
using System.Collections.Generic;

#nullable disable

namespace Health.Web.Data.Models
{
    public partial class User
    {
        public User()
        {
            Patients = new HashSet<Patient>();
            Professionals = new HashSet<Professional>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Pronouns { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Professional> Professionals { get; set; }
    }
}
