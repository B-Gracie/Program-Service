namespace DataAccessLayer.Model;

public class ProgramPreviewModel
{
   
        public string ProgramName { get; set; }
        public string ProgramLocation { get; set; }
        public DateTime ApplicationOpenDate { get; set; }
        public DateTime ApplicationCloseDate { get; set; }
        public string ProgramDescription { get; set; }
        public string ProgramType { get; set; }
        public string ProgramDuration { get; set; }
        public List<string> ProgramBenefits { get; set; }
        public List<string> ApplicationCriteria { get; set; }

}