using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<PatientAllergies> PatientAllergies { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Blood> Bloods { get; set; }
        public DbSet<HistoryTreatment> HistoryTreatments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Therapy> Therapys { get; set; }
        public DbSet<DoctorBloodConsumption> BloodConsumptions { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, Number = "101A", RoomType = RoomType.rehabilitationRoom, Floor = 1, Deleted = false },
                new Room() { Id = 2, Number = "204", RoomType = RoomType.rehabilitationRoom, Floor = 2, Deleted = false },
                new Room() { Id = 3, Number = "305B", RoomType = RoomType.rehabilitationRoom, Floor = 3, Deleted = false },
                new Room() { Id = 4, Number = "STORAGE", RoomType = RoomType.storage, Floor = 3, Deleted = false }

            );

            //modelBuilder.ApplyConfiguration(new EmailConfigMap());

            modelBuilder.Entity<Person>().OwnsOne(e => e.Email);


            base.OnModelCreating(modelBuilder);
        }
    }
}
