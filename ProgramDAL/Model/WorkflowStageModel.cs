namespace DataAccessLayer.Model;

public class WorkflowStageModel
{
        public string Id { get; set; } 
        public string StageName { get; set; } 
        public StageType StageType { get; set; } 
        public bool EvaluateWithVideoInterview { get; set; }
        public List<string> VideoInterviewQuestions { get; set; } 

        // Additional properties specific to VideoInterview stages
        public int MaxVideoDurationSeconds { get; set; } 
        public int DeadlineDays { get; set; } 
        public bool HideFromCandidate { get; set; } 

        // Additional properties specific to Placement stages
        public string AdditionalInformation { get; set; } 
    }

    public enum StageType
    {
        Shortlisting,
        VideoInterview,
        Placement
    }
