using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class StatisticsService
    {
        private readonly PatientRepository _patientRepository;
        private readonly PersonRepository _personRepository;
        private readonly DoctorRepository _doctorRepository;
        
        public StatisticsService(PatientRepository patientRepository, PersonRepository personRepository,  DoctorRepository doctorRepository)
        {
            _patientRepository = patientRepository;
            _personRepository = personRepository;
            _doctorRepository = doctorRepository;
        }
        
        public StatisticsDto GetStatistics()
        {
            StatisticsDto stats = new StatisticsDto();
            SetAgeGroupStats(stats);
            SetAllergyStats(stats);
            SetBloodtypeStats(stats);
            SetDoctorStats(stats);
            return stats;
        }

        private void SetAgeGroupStats(StatisticsDto stats)
        {
            List<DateTime> ageGroupDates = getAgeGroupDates();
            for(int i=0; i<ageGroupDates.Count()-1;i++)
            {
                stats.NumberOfMalesPerAgeGroup.Add(_personRepository.GetByAgeAndGender(ageGroupDates[i], ageGroupDates[i+1], Gender.male));
                stats.NumberOfFemalesPerAgeGroup.Add(_personRepository.GetByAgeAndGender(ageGroupDates[i], ageGroupDates[i+1], Gender.female));
            }
        }
        
        private List<DateTime> getAgeGroupDates()
        {
            List<DateTime> dates = new List<DateTime>();
            List<int> numberOfYearsToSubtract = new List<int> {0, 18, 30, 45, 60, 80, 150 };
            foreach(int i in numberOfYearsToSubtract)
                dates.Add(DateTime.Now.AddYears(-i));
            return dates;
        }

        private void SetAllergyStats(StatisticsDto stats)
        {
            IEnumerable<PatientAllergies> allergiesThatPatientsHave = _patientRepository.GetAllPatientAllergies();
            Dictionary<string, int> allergyPopularity = new Dictionary<string, int>();
            foreach (PatientAllergies pa in allergiesThatPatientsHave)
                allergyPopularity.TryAdd(pa.Allergy.Name, allergiesThatPatientsHave.Where(x => x.Allergy.Id == pa.Allergy.Id).Count());
            stats.AllergyPopularity = allergyPopularity;
        }

        private void SetBloodtypeStats(StatisticsDto stats)
        {
            IEnumerable<Patient> patients = _patientRepository.GetAll();
            Dictionary<string, int> bloodtypePopularity = new Dictionary<string, int>();
            foreach (Patient p in patients)
                bloodtypePopularity.TryAdd(p.BloodType.ToString().Replace("Plus","+").Replace("Minus","-"), patients.Where(x => x.BloodType == p.BloodType).Count());
            stats.BloodtypePopularity = bloodtypePopularity;
        }

        private void SetDoctorStats(StatisticsDto stats)
        {
            IEnumerable<int> doctorIds = _patientRepository.GetAllDoctorsWhoHavePatients();
            Dictionary<string, List<int>> doctorAgeGroups = new Dictionary<string, List<int>>();
            List<DateTime> ageGroupDates = getAgeGroupDates();
            foreach(int id in doctorIds)
            {
                var doctor = _doctorRepository.GetById(id);
                doctorAgeGroups.Add(doctor.Person.Name + " " + doctor.Person.Surname, getDoctorsAgeGroups(ageGroupDates,id));
            }
            stats.DoctorsAgeGroupDistribution = doctorAgeGroups;
        }

        private List<int> getDoctorsAgeGroups(List<DateTime> ageGroupDates, int id)
        {
            List<int> values = new List<int>();
            for (int i = 0; i < ageGroupDates.Count() - 1; i++)
            {
                values.Add(_patientRepository.GetByAgeAndDoctor(ageGroupDates[i], ageGroupDates[i + 1], id));
            }
            return values;
        }
        
    }
}
