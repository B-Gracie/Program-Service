using DataAccessLayer.Model;
using Newtonsoft.Json;

namespace DataAccessLayer.DTOs;

    public class ProgramDto
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string ProgramTitle { get; set; }
        public string ProgramSummary { get; set; }
        public string ProgramDescription { get; set; }
        public List<string> KeySkillsRequired { get; set; }
        public ProgramType ProgramType { get; set; }
        public DateTime ProgramStartDate { get; set; }
        public DateTime ApplicationOpenDate { get; set; }
        public DateTime ApplicationCloseDate { get; set; }
        public string ProgramDuration { get; set; }
        public string ProgramLocation { get; set; }
        public int MaxNumberOfApplications { get; set; }
    }

