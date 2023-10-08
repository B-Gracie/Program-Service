namespace DataAccessLayer.Model;

public class ProgramModel
{
    public string Id { get; set; } // Unique identifier for the program
    public string ProgramTitle { get; set; } // Program Title
    public string ProgramSummary { get; set; } // Summary of the Program (less than 250 characters)
    public string ProgramDescription { get; set; } // Program Description
    public List<string> KeySkillsRequired { get; set; } // Key Skills Required for this Program
    public string ProgramBenefits { get; set; } // Program Benefits (bullet points)
    public string ApplicationCriteria { get; set; } // Application Criteria and Interview Process
    public string AdditionalProgramInformation { get; set; } // Additional Program Information
    public ProgramType ProgramType { get; set; } // Program type (e.g., Full Time)
    public DateTime ProgramStartDate { get; set; } // Program start date
    public DateTime ApplicationOpenDate { get; set; } // Application open date
    public DateTime ApplicationCloseDate { get; set; } // Application close date
    public string ProgramDuration { get; set; } // Duration of the program
    public string ProgramLocation { get; set; } // Program location
    public string MinQualifications { get; set; } // Minimum qualifications
    public int MaxNumberOfApplications { get; set; } // Maximum number of applications
    public List<string> ApplicationTemplateIds { get; set; }
}

public enum ProgramType
{
    FullTime = 1,
    PartTime = 2,
    Internship = 3
}

