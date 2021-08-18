using System;
using System.Collections.Generic;

#nullable disable

namespace Health.Web.Data.Models
{
    public partial class Emotion
    {
        public Emotion()
        {
            MoodEmotions = new HashSet<MoodEmotion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Emoji { get; set; }

        public virtual ICollection<MoodEmotion> MoodEmotions { get; set; }
    }
}
