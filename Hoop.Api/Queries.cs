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
        // [UseDbContext(typeof(HoopDBContext))]
        // public IQueryable<User> GetUsers([ScopedService] HoopDBContext dbContext)
        //     => dbContext.Users;

        [UseDbContext(typeof(HoopDBContext))]
        public User GetUser([ScopedService] HoopDBContext context, int id)
            => context.Find<User>(id);

         [UseDbContext(typeof(HoopDBContext))]
         [UseProjection]
        public IQueryable<Professional> GetProfessionalsForPatient([ScopedService] HoopDBContext context, int patientId)
            => context.Relationships
                .Where(r => r.PatientId == patientId)
                .Select(r => r.Professional);
    }
}