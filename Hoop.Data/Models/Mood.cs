using System;
using System.Collections.Generic;

#nullable disable

namespace Hoop.Data.Models
{
    public partial class Mood
    {
        public Mood()
        {
            CheckIns = new HashSet<CheckIn>();
            MoodEmotions = new HashSet<MoodEmotion>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Weather { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ICollection<CheckIn> CheckIns { get; set; }
        public virtual ICollection<MoodEmotion> MoodEmotions { get; set; }
    }
}
