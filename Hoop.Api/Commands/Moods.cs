using System;
using System.Collections.Generic;

using Hoop.Data.Models;

namespace Hoop.Api.Commands
{
    public record AddMoodCommand(
        int PatientId,
        string Weather,
        IEnumerable<int> EmotionIds
    );
}