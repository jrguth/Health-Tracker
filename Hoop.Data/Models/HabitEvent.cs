using System;
using System.Collections.Generic;

using Hoop.Data.Enums;

#nullable disable

namespace Hoop.Data.Models
{
    public partial class HabitEvent
    {
        public int Id { get; set; }
        public int? HabitId { get; set; }
        public HabitEventType Event { get; set; }
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Habit Habit { get; set; }
    }
}
