using System;
using System.Collections.Generic;

using Health.Web.Data.Enums;

#nullable disable

namespace Health.Web.Data.Models
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
