using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<WorkingDay> WorkingDays { get; set; }


        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, Number = "101A", Floor = 1 },
                new Room() { Id = 2, Number = "204", Floor = 2 },
                new Room() { Id = 3, Number = "305B", Floor = 3 }
            );

            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Name = "Pera", Surname = "Petrovic", Role = Role.manager, Email = "pera@gmail.com", Deleted = false },
                new User() { Id = 2, Name = "Nikola", Surname = "Nikolic", Role = Role.doctor, Email = "nikola@gmail.com", Deleted = false },
                new User() { Id = 3, Name = "Marko", Surname = "Markovic", Role = Role.doctor, Email = "marko@gmail.com", Deleted = false },
                new User() { Id = 4, Name = "Stefan", Surname = "Stefanovic", Role = Role.doctor, Email = "stefan@gmail.com", Deleted = false }
            );

            base.OnModelCreating(modelBuilder);

        }
    }
}
