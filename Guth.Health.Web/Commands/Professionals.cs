using System;
using Health.Web.Api;

namespace Health.Web.Api.Commands
{
    public record AddProfessionalCommand(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Pronouns
    );
}