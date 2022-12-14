﻿// <auto-generated />
using System;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalLibrary.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    [Migration("20221122150548_BloodConsumption")]
    partial class BloodConsumption
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HospitalLibrary.Core.DTOs.PatientDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PatientDto");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Township")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Allergy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Allergies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deleted = false,
                            Name = "Polen"
                        },
                        new
                        {
                            Id = 2,
                            Deleted = false,
                            Name = "Prasina"
                        },
                        new
                        {
                            Id = 3,
                            Deleted = false,
                            Name = "Pas"
                        },
                        new
                        {
                            Id = 4,
                            Deleted = false,
                            Name = "Macka"
                        },
                        new
                        {
                            Id = 5,
                            Deleted = false,
                            Name = "Pcela"
                        },
                        new
                        {
                            Id = 6,
                            Deleted = false,
                            Name = "Ambrozija"
                        },
                        new
                        {
                            Id = 7,
                            Deleted = false,
                            Name = "Kikiriki"
                        },
                        new
                        {
                            Id = 8,
                            Deleted = false,
                            Name = "Gluten"
                        },
                        new
                        {
                            Id = 9,
                            Deleted = false,
                            Name = "Laktoza"
                        },
                        new
                        {
                            Id = 10,
                            Deleted = false,
                            Name = "Alergija10"
                        },
                        new
                        {
                            Id = 11,
                            Deleted = false,
                            Name = "Alergija11"
                        },
                        new
                        {
                            Id = 12,
                            Deleted = false,
                            Name = "Alergija12"
                        },
                        new
                        {
                            Id = 13,
                            Deleted = false,
                            Name = "Alergija13"
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Bed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BedState")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientDtoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientDtoId");

                    b.ToTable("Beds");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Blood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BloodType")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bloods");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("Specialization")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.DoctorBloodConsumption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BloodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BloodId");

                    b.HasIndex("DoctorId");

                    b.ToTable("BloodConsumptions");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BedId")
                        .HasColumnType("int");

                    b.Property<int?>("BloodId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("MedicineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BedId");

                    b.HasIndex("BloodId");

                    b.HasIndex("MedicineId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAnonimous")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.HistoryTreatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("HistoryTreatments");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BloodType")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PersonId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.PatientAllergies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AllergyId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AllergyId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientAllergies");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deleted = false,
                            Floor = 1,
                            Number = "101A",
                            RoomType = 0
                        },
                        new
                        {
                            Id = 2,
                            Deleted = false,
                            Floor = 2,
                            Number = "204",
                            RoomType = 0
                        },
                        new
                        {
                            Id = 3,
                            Deleted = false,
                            Floor = 3,
                            Number = "305B",
                            RoomType = 0
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Therapy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BloodId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("MedicineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BloodId");

                    b.HasIndex("MedicineId");

                    b.ToTable("Therapys");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdmission")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDischarge")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("ReasonForAdmission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonForDischarge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<int?>("TherapyId")
                        .HasColumnType("int");

                    b.Property<int>("TreatmentState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TherapyId");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.WorkingDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WorkingDays");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Appointment", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("HospitalLibrary.Core.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Bed", b =>
                {
                    b.HasOne("HospitalLibrary.Core.DTOs.PatientDto", "PatientDto")
                        .WithMany()
                        .HasForeignKey("PatientDtoId");

                    b.Navigation("PatientDto");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Doctor", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.DoctorBloodConsumption", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Blood", "Blood")
                        .WithMany()
                        .HasForeignKey("BloodId");

                    b.HasOne("HospitalLibrary.Core.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.Navigation("Blood");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Equipment", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Bed", "Bed")
                        .WithMany()
                        .HasForeignKey("BedId");

                    b.HasOne("HospitalLibrary.Core.Model.Blood", "Blood")
                        .WithMany()
                        .HasForeignKey("BloodId");

                    b.HasOne("HospitalLibrary.Core.Model.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId");

                    b.Navigation("Bed");

                    b.Navigation("Blood");

                    b.Navigation("Medicine");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Feedback", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Person", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Patient", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("HospitalLibrary.Core.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Doctor");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.PatientAllergies", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Allergy", "Allergy")
                        .WithMany()
                        .HasForeignKey("AllergyId");

                    b.HasOne("HospitalLibrary.Core.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("Allergy");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Person", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Room", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Therapy", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Blood", "Blood")
                        .WithMany()
                        .HasForeignKey("BloodId");

                    b.HasOne("HospitalLibrary.Core.Model.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId");

                    b.Navigation("Blood");

                    b.Navigation("Medicine");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Treatment", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("HospitalLibrary.Core.Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.HasOne("HospitalLibrary.Core.Model.Therapy", "Therapy")
                        .WithMany()
                        .HasForeignKey("TherapyId");

                    b.Navigation("Patient");

                    b.Navigation("Room");

                    b.Navigation("Therapy");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.WorkingDay", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Person", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
