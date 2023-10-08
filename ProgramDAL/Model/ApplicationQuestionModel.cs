namespace DataAccessLayer.Model;
public class ApplicationQuestionModel
{
    public string Id { get; set; } // Unique identifier for the question
    public QuestionType Type { get; set; } // Type of the question (e.g., Paragraph, Dropdown, YesNo, etc.)
    public string Text { get; set; } // Question text
    public bool IsMandatory { get; set; } // Indicates if the question is mandatory
    public bool Show { get; set; } // Indicates if the question should be shown
    public List<string> Choices { get; set; } // Choices for multiple-choice questions
    public int MaxLength { get; set; } // Maximum length for text-based questions (e.g., Paragraph, ShortAnswer)
    public string Placeholder { get; set; } // Placeholder text for input fields
    public bool AllowFileUpload { get; set; } // Indicates if file upload is allowed
    public bool Hide { get; set; } // Indicates if the question should be hidden
}

public enum QuestionType
{
    Paragraph,
    ShortAnswer,
    YesNo,
    Dropdown,
    MultipleChoice,
    Date,
    Number,
    FileUpload
    
}