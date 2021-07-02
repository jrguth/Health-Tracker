using System;
using System.Collections.Generic;

#nullable disable

namespace Hoop.Data.Models
{
    public partial class MoodEmotion
    {
        public int Id { get; set; }
        public int MoodId { get; set; }
        public int EmotionId { get; set; }

        public virtual Emotion Emotion { get; set; }
        public virtual Mood Mood { get; set; }
    }
}
