using System;

namespace Hoop.Api.Commands
{
    public record AddEmotionCommand(
        string Name,
        string Emoji
    );
}