using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<WorkingDay> WorkingDays { get; set; }
        public DbSet<Allergy> Allergies { get; set; }

        public DbSet<PatientAllergies> PatientAllergies { get; set; }


        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, Number = "101A", Floor = 1 },
                new Room() { Id = 2, Number = "204", Floor = 2 },
                new Room() { Id = 3, Number = "305B", Floor = 3 }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address() { Id = 1, Street = "neka ulica1", Number = "1", City = "Novi Sad", Township = "Novi Sad", PostCode = "21000", Deleted = false },
                new Address() { Id = 2, Street = "neka ulica2", Number = "2", City = "Novi Sad", Township = "Novi Sad", PostCode = "21000", Deleted = false },
                new Address() { Id = 3, Street = "neka ulica3", Number = "3", City = "Ledinci", Township = "Novi Sad", PostCode = "21207", Deleted = false },
                new Address() { Id = 4, Street = "neka ulica4", Number = "4", City = "Sremska Kamenica", Township = "Novi Sad", PostCode = "21200", Deleted = false }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person() { Id = 1, Name = "Pera", Surname = "Petrovic", Role = Role.manager, Email = "pera@gmail.com", Deleted = false, Gender = Gender.male, BirthDate = DateTime.Today},
                new Person() { Id = 2, Name = "Nikola", Surname = "Nikolic", Role = Role.doctor, Email = "nikola@gmail.com", Deleted = false, Gender = Gender.male, BirthDate = DateTime.Today},
                new Person() { Id = 3, Name = "Marko", Surname = "Markovic", Role = Role.doctor, Email = "marko@gmail.com", Deleted = false, Gender = Gender.male, BirthDate = DateTime.Today},
                new Person() { Id = 4, Name = "Stefan", Surname = "Stefanovic", Role = Role.doctor, Email = "stefan@gmail.com", Deleted = false, Gender = Gender.male, BirthDate = DateTime.Today},
                new Person() { Id = 5, Name = "Pacijent1", Surname = "Nikolic", Role = Role.patient, Email = "pacijent1@gmail.com", Deleted = false, Gender = Gender.male, BirthDate = DateTime.Today},
                new Person() { Id = 6, Name = "Pacijent2", Surname = "Markovic", Role = Role.patient, Email = "pacijent2@gmail.com", Deleted = false, Gender = Gender.female, BirthDate = DateTime.Today},
                new Person() { Id = 7, Name = "Pacijent3", Surname = "Stefanovic", Role = Role.patient, Email = "pacijent3@gmail.com", Deleted = false, Gender = Gender.other, BirthDate = DateTime.Today}
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 5, BloodType = BloodType.APlus },
                new Patient() { Id = 6, BloodType = BloodType.BPlus },
                new Patient() { Id = 7, BloodType = BloodType.ABPlus }
            );

            modelBuilder.Entity<Allergy>().HasData(
                new Allergy() { Id = 1, Name = "Polen", Deleted = false },
                new Allergy() { Id = 2, Name = "Prasina", Deleted = false },
                new Allergy() { Id = 3, Name = "Pas", Deleted = false },
                new Allergy() { Id = 4, Name = "Macka", Deleted = false },
                new Allergy() { Id = 5, Name = "Pcela", Deleted = false },
                new Allergy() { Id = 6, Name = "Ambrozija", Deleted = false },
                new Allergy() { Id = 7, Name = "Kikiriki", Deleted = false },
                new Allergy() { Id = 8, Name = "Gluten", Deleted = false },
                new Allergy() { Id = 9, Name = "Laktoza", Deleted = false },
                new Allergy() { Id = 10, Name = "Alergija10", Deleted = false },
                new Allergy() { Id = 11, Name = "Alergija11", Deleted = false },
                new Allergy() { Id = 12, Name = "Alergija12", Deleted = false },
                new Allergy() { Id = 13, Name = "Alergija13", Deleted = false }
            );

            /*modelBuilder.Entity<PatientAllergies>().HasData(
                new PatientAllergies() { Id=1, Allergy = new Allergy() { Id = 1, Name = "Polen", Deleted = false }, Patient = new Patient() { Id = 5, BloodType = BloodType.APlus }}
            );*/


            base.OnModelCreating(modelBuilder);

        }
    }
}
