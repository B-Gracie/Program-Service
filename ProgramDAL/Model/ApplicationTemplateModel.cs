namespace DataAccessLayer.Model;

public class ApplicationTemplateModel
{
        public string Id { get; set; } // Unique identifier for the template
        public string ProgramId { get; set; } // Associated program ID
        public List<ApplicationQuestionModel> Questions { get; set; } // List of application questions
        
}

    

