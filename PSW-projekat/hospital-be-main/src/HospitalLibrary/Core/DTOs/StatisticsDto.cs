using System.Collections.Generic;

namespace HospitalLibrary.Core.DTOs
{
    public class StatisticsDto
    {
        public List<int> NumberOfMalesPerAgeGroup { get; set; } = new List<int>();
        public List<int> NumberOfFemalesPerAgeGroup { get; set; } = new List<int>();
        public Dictionary<string, int> BloodtypePopularity { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> AllergyPopularity { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, List<int>> DoctorsAgeGroupDistribution { get; set; } = new Dictionary<string, List<int>>();
    }
}
