using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Room>().HasData(
                new Room() { RoomId = 1, Number = "101A", Floor = 1 },
                new Room() { RoomId = 2, Number = "204", Floor = 2 },
                new Room() { RoomId = 3, Number = "305B", Floor = 3 }
            );

            modelBuilder.Entity<Appointment>().HasData(
               new Appointment() { AppointmentId =1,
        Patient =null,
        Doctor = null,
        Date =  new DateTime(),
        Time = new DateTime()
               }
            );
            base.OnModelCreating(modelBuilder);

        }
    }
}
