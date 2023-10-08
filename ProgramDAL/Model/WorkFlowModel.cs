namespace DataAccessLayer.Model;

public class WorkFlowModel
{
        public string Id { get; set; } // Unique identifier for the workflow
        public string ProgramId { get; set; } // Associated program ID

        // List of workflow stages
        public List<WorkflowStageModel> Stages { get; set; }
    }



