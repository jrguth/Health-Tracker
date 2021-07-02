using System;
using System.Collections.Generic;

#nullable disable

namespace Hoop.Data.Models
{
    public partial class HabitEvent
    {
        public int Id { get; set; }
        public int? HabitId { get; set; }
        public string Event { get; set; }
        public string Details { get; set; }

        public virtual Habit Habit { get; set; }
    }
}
