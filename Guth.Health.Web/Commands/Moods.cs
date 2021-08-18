using System;
using System.Collections.Generic;

using Health.Web.Data.Models;

namespace Health.Web.Api.Commands
{
    public record AddMoodCommand(
        int PatientId,
        string Weather,
        IEnumerable<int> EmotionIds
    );
}