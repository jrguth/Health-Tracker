using System;
using System.Linq;


using HotChocolate;
using HotChocolate.Data;

using Hoop.Data;
using Hoop.Data.Models;

namespace Hoop.Api
{
    public class Queries
    {
        [UseDbContext(typeof(HoopDBContext))]
        [UseProjection]
        [UseFiltering]
        public IQueryable<Patient> GetPatients([ScopedService] HoopDBContext dbContext)
            => dbContext.Patients;

        [UseDbContext(typeof(HoopDBContext))]
        public Patient GetPatient([ScopedService] HoopDBContext dbContext, int patientId)
            => dbContext.Find<Patient>(patientId);

        [UseDbContext(typeof(HoopDBContext))]
        public Patient GetProfessional([ScopedService] HoopDBContext dbContext, int professionalId)
            => dbContext.Find<Patient>(professionalId);

        [UseDbContext(typeof(HoopDBContext))]
        [UseProjection]
        [UseFiltering]
        public IQueryable<Professional> GetProfessionals([ScopedService] HoopDBContext dbContext)
            => dbContext.Professionals;

        [UseDbContext(typeof(HoopDBContext))]
        public IQueryable<HealthLog> GetHealthLogsByPatientId([ScopedService] HoopDBContext dbContext, int patientId)
            => dbContext.HealthLogs.Where(hl => hl.PatientId == patientId);
    }
}