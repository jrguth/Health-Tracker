using System;
using Hoop.Api;

namespace Hoop.Api.Commands
{
    public record AddProfessionalCommand(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Pronouns
    );
}