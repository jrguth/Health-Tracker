using System;

using Hoop.Data.Models;

namespace Hoop.Api
{
    public class AddPatientResponsePayload
    {
        public Patient Patient { get; }
        public AddPatientResponsePayload(Patient patient)
        {
            Patient = patient;
        }
    }

    public class AddProfessionalResponsePayload
    {
        public Professional Professional { get; }
        public AddProfessionalResponsePayload(Professional professional)
        {
            Professional = professional;
        }
    }

    public class AddRelationshipResponsePayload
    {
        public Relationship Relationship { get; }
        public AddRelationshipResponsePayload(Relationship relationship)
        {
            Relationship = relationship;
        }
    }
}