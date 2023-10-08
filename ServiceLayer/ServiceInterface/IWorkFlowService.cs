using DataAccessLayer.Model;

namespace ServiceLayer.ServiceInterface;

public interface IWorkFlowService
{
        Task<WorkFlowModel> GetWorkFlowAsync(string workFlowId);
        Task<WorkflowStageModel?> GetStageAsync(string workFlowId, string stageId);
        Task<WorkflowStageModel> CreateOrUpdateStageAsync(string workFlowId, WorkflowStageModel stage);
        Task<bool> DeleteStageAsync(string workFlowId, string stageId);
    
}