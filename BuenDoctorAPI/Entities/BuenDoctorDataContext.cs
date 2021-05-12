using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BuenDoctorAPI.Entities
{
    public partial class BuenDoctorDataContext : DbContext
    {
        public BuenDoctorDataContext()
        {
        }

        public BuenDoctorDataContext(DbContextOptions<BuenDoctorDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
        public virtual DbSet<DataUser> DataUsers { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DataConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("APPOINTMENT");

                entity.Property(e => e.AppointmentId)
                    .HasMaxLength(10)
                    .HasColumnName("APPOINTMENT_ID");

                entity.Property(e => e.AppointmentStatusId).HasColumnName("APPOINTMENT_STATUS_ID");

                entity.Property(e => e.DataUserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("DATA_USER_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.PatientId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("PATIENT_ID");

                entity.HasOne(d => d.AppointmentStatus)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.AppointmentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("APPOINTMENT_FK--APPOINTMENT_STATUS");

                entity.HasOne(d => d.DataUser)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DataUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("APPOINTMENT_FK--USER");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("APPOINTMENT_FK--PATIENT");
            });

            modelBuilder.Entity<AppointmentStatus>(entity =>
            {
                entity.ToTable("APPOINTMENT_STATUS");

                entity.HasIndex(e => e.Description, "APPOINTMENT_STATUS_DESCRIPTION_UK")
                    .IsUnique();

                entity.Property(e => e.AppointmentStatusId).HasColumnName("APPOINTMENT_STATUS_ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<DataUser>(entity =>
            {
                entity.ToTable("DATA_USER");

                entity.HasIndex(e => e.Email, "DATA_USER_EMAIL_UK")
                    .IsUnique();

                entity.HasIndex(e => e.Mobile, "DATA_USER_MOBILE_UK")
                    .IsUnique();

                entity.Property(e => e.DataUserId)
                    .HasMaxLength(10)
                    .HasColumnName("DATA_USER_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.FirstSurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_SURNAME");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("MOBILE");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(128)
                    .HasColumnName("PASSWORD_HASH");

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(128)
                    .HasColumnName("PASSWORD_SALT");

                entity.Property(e => e.ProfilePicture)
                    .HasColumnType("image")
                    .HasColumnName("PROFILE_PICTURE");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("SECOND_NAME");

                entity.Property(e => e.SecondSurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SECOND_SURNAME");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UserTypeId).HasColumnName("USER_TYPE_ID");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.DataUsers)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DATA_USER_FK--USER_TYPE");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("PATIENT");

                entity.HasIndex(e => e.Email, "PATIENT_EMAIL_UK")
                    .IsUnique();

                entity.Property(e => e.PatientId)
                    .HasMaxLength(10)
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDAY");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("CITY");

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("DIRECTION");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.FirstSurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_SURNAME");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(14)
                    .HasColumnName("MOBILE");

                entity.Property(e => e.Neighborhood)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("NEIGHBORHOOD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(14)
                    .HasColumnName("PHONE");

                entity.Property(e => e.ProfilePicture)
                    .HasColumnType("image")
                    .HasColumnName("PROFILE_PICTURE");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("SECOND_NAME");

                entity.Property(e => e.SecondSurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SECOND_SURNAME");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("USER_TYPE");

                entity.HasIndex(e => e.Description, "USER_TYPE_DESCRIPTION_UK")
                    .IsUnique();

                entity.Property(e => e.UserTypeId).HasColumnName("USER_TYPE_ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
