using System;
using System.Threading;
using System.Threading.Tasks;

using HotChocolate;
using HotChocolate.Data;

using Hoop.Data;
using Hoop.Data.Models;
using Hoop.Api.Commands;

namespace Hoop.Api
{
    public class Mutations
    {
        [UseDbContext(typeof(HoopDBContext))]
        public async Task<AddPatientResponsePayload> AddPatientAsync(AddPatientCommand input, [ScopedService] HoopDBContext context)
        {
            var patient = new Patient
            {
                User = new User
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Email = input.Email,
                    PhoneNumber = input.PhoneNumber,
                    Pronouns = input.Pronouns
                }
            };
            context.Patients.Add(patient);
            await context.SaveChangesAsync();
            return new AddPatientResponsePayload(patient);
        }

        [UseDbContext(typeof(HoopDBContext))]
        public async Task<AddProfessionalResponsePayload> AddProfessionalAsync(AddProfessionalCommand input, [ScopedService] HoopDBContext context)
        {
            var professional = new Professional
            {
                User = new User
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Email = input.Email,
                    PhoneNumber = input.PhoneNumber,
                    Pronouns = input.Pronouns
                }
            };
            context.Professionals.Add(professional);
            await context.SaveChangesAsync();
            return new AddProfessionalResponsePayload(professional);
        }

        [UseDbContext(typeof(HoopDBContext))]
        public async Task<AddRelationshipResponsePayload> AddRelationship(int patientId, int professionalId, [ScopedService] HoopDBContext context)
        {
            var relationship = new Relationship
            {
                PatientId = patientId,
                ProfessionalId = professionalId
            };
            context.Relationships.Add(relationship);
            await context.SaveChangesAsync();
            return new AddRelationshipResponsePayload(relationship);
        }

        [UseDbContext(typeof(HoopDBContext))]
        public async Task<HealthLog> AddHealthLog([ScopedService] HoopDBContext context, int patientId, string log)
        {
            var patient = await context.FindAsync<Patient>(patientId);
            var healthLog = new HealthLog { Log = log };
            patient.HealthLogs.Add(healthLog);
            await context.SaveChangesAsync();
            return healthLog;
        }
    }
}