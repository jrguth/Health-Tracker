using System;

namespace Health.Web.Api.Commands
{
    public record AddEmotionCommand(
        string Name,
        string Emoji
    );
}