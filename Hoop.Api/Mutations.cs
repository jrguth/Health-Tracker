using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using HotChocolate;
using HotChocolate.Data;

using Health.Web.Data;
using Health.Web.Data.Models;
using Health.Web.Data.Enums;
using Health.Web.Api.Commands;

namespace Health.Web.Api
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

        [UseDbContext(typeof(HoopDBContext))]
        public async Task<Medication> AddMedication([ScopedService] HoopDBContext context, int patientId, string medicationName, string dosage, string description)
        {
            var patient = await context.FindAsync<Patient>(patientId);
            var medication = new Medication
            {
                MedicationName = medicationName,
                Dosage = dosage,
                Description = description
            };
            patient.Medications.Add(medication);
            await context.SaveChangesAsync();
            return medication;
        }

        [UseDbContext(typeof(HoopDBContext))]
        public async Task DeleteMedication([ScopedService] HoopDBContext context, int medicationId)
        {
            var medication = await context.FindAsync<Medication>(medicationId);
            if (medication != null)
            {
                context.Remove(medication);
                await context.SaveChangesAsync();
            }
        }

        [UseDbContext(typeof(HoopDBContext))]
        public async Task<Habit> AddHabit([ScopedService] HoopDBContext context, int relationshipId, string habitName)
        {
            var habit = new Habit
            {
                RelationshipId = relationshipId,
                HabitName = habitName
            };

            await context.Habits.AddAsync(habit);
            await context.SaveChangesAsync();
            return habit;
        }

        [UseDbContext(typeof(HoopDBContext))]
        public async Task<HabitEvent> AddHabitEvent([ScopedService] HoopDBContext context, int habitId, HabitEventType habitEventType, string details)
        {
            var habit = await context.FindAsync<Habit>(habitId);
            if (habit != null)
            {
                var habitEvent = new HabitEvent
                {
                    Event = habitEventType,
                    Details = details
                };
                habit.HabitEvents.Add(habitEvent);
                await context.SaveChangesAsync();
                return habitEvent;
            }
            return null;
        }

        [UseDbContext(typeof(HoopDBContext))]
        public async Task<Mood> AddMood([ScopedService] HoopDBContext context, AddMoodCommand command)
        {
            var patient = await context.Patients.FindAsync(command.PatientId);
            var mood = new Mood
            {
                PatientId = command.PatientId,
                Weather = command.Weather,
                MoodEmotions = command.EmotionIds.Select(id => new MoodEmotion
                {
                    EmotionId = id
                }).ToList(),
            };
            patient.Moods.Add(mood);
            await context.SaveChangesAsync();
            return mood;
        }

        [UseDbContext(typeof(HoopDBContext))]
        public async Task<IEnumerable<Emotion>> AddEmotions([ScopedService] HoopDBContext context, IEnumerable<AddEmotionCommand> emotions)
        {
            var toAdd = emotions
                .Select(e => new Emotion
                {
                    Name = e.Name,
                    Emoji = e.Emoji
                })
                .ToArray();
            await context.Emotions.AddRangeAsync(toAdd);
            await context.SaveChangesAsync();
            return toAdd;
        }
    }
}