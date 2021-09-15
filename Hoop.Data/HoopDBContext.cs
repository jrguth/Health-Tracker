using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Health.Web.Data.Models;
using System.Threading.Tasks;

#nullable disable

namespace Health.Web.Data
{
    public partial class HoopDBContext : DbContext
    {
        
        public HoopDBContext(DbContextOptions<HoopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CheckIn> CheckIns { get; set; }
        public virtual DbSet<Emotion> Emotions { get; set; }
        public virtual DbSet<Habit> Habits { get; set; }
        public virtual DbSet<HabitEvent> HabitEvents { get; set; }
        public virtual DbSet<HealthLog> HealthLogs { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Mood> Moods { get; set; }
        public virtual DbSet<MoodEmotion> MoodEmotions { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Professional> Professionals { get; set; }
        public virtual DbSet<Relationship> Relationships { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CheckIn>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.MoodId).HasColumnName("moodId");

                entity.Property(e => e.RelationshipId).HasColumnName("relationshipId");

                entity.HasOne(d => d.Mood)
                    .WithMany(p => p.CheckIns)
                    .HasForeignKey(d => d.MoodId)
                    .HasConstraintName("FK__CheckIns__moodId__66603565");

                entity.HasOne(d => d.Relationship)
                    .WithMany(p => p.CheckIns)
                    .HasForeignKey(d => d.RelationshipId)
                    .HasConstraintName("FK__CheckIns__relati__656C112C");
            });

            modelBuilder.Entity<Emotion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Emoji)
                    .HasMaxLength(255)
                    .HasColumnName("emoji");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("emotion");
            });

            modelBuilder.Entity<Habit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HabitName)
                    .HasMaxLength(255)
                    .HasColumnName("habitName");

                entity.Property(e => e.RelationshipId).HasColumnName("relationshipId");

                entity.HasOne(d => d.Relationship)
                    .WithMany(p => p.Habits)
                    .HasForeignKey(d => d.RelationshipId)
                    .HasConstraintName("FK__Habits__relation__59FA5E80");
            });

            modelBuilder.Entity<HabitEvent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Details)
                    .HasMaxLength(255)
                    .HasColumnName("details");

                entity.Property(e => e.Event)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("event")
                    .HasConversion<string>();

                entity.Property(e => e.HabitId).HasColumnName("habitId");

                entity.HasOne(d => d.Habit)
                    .WithMany(p => p.HabitEvents)
                    .HasForeignKey(d => d.HabitId)
                    .HasConstraintName("FK__HabitEven__habit__6A30C649");
            });

            modelBuilder.Entity<HealthLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Log)
                    .HasMaxLength(255)
                    .HasColumnName("log");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.HealthLogs)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__HealthLog__patie__5CD6CB2B");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Dosage)
                    .HasMaxLength(255)
                    .HasColumnName("dosage");

                entity.Property(e => e.MedicationName)
                    .HasMaxLength(255)
                    .HasColumnName("medicationName");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Medications)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Medicatio__patie__49C3F6B7");
            });

            modelBuilder.Entity<Mood>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.Weather)
                    .HasMaxLength(255)
                    .HasColumnName("weather");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Moods)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Moods__patientId__5EBF139D");
            });

            modelBuilder.Entity<MoodEmotion>(entity =>
            {
                entity.ToTable("MoodEmotion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmotionId).HasColumnName("emotionId");

                entity.Property(e => e.MoodId).HasColumnName("moodId");

                entity.HasOne(d => d.Emotion)
                    .WithMany(p => p.MoodEmotions)
                    .HasForeignKey(d => d.EmotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MoodEmoti__emoti__60A75C0F");

                entity.HasOne(d => d.Mood)
                    .WithMany(p => p.MoodEmotions)
                    .HasForeignKey(d => d.MoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MoodEmoti__moodI__5FB337D6");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Patients__userId__5629CD9C");
            });

            modelBuilder.Entity<Professional>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Professionals)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Professio__userI__571DF1D5");
            });

            modelBuilder.Entity<Relationship>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.ProfessionalId).HasColumnName("professionalId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Relationships)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Relations__patie__5812160E");

                entity.HasOne(d => d.Professional)
                    .WithMany(p => p.Relationships)
                    .HasForeignKey(d => d.ProfessionalId)
                    .HasConstraintName("FK__Relations__profe__412EB0B6");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("lastName");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Pronouns)
                    .HasMaxLength(255)
                    .HasColumnName("pronouns");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
