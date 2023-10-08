using DataAccessLayer.Model;

namespace DataAccessLayer.Repository.@interface;

public interface IWorkFlowRepository
{
   
    Task<WorkflowStageModel?> GetStageAsync(string workFlowId, string stageId);
    Task<WorkflowStageModel> CreateOrUpdateStageAsync(string workFlowId, WorkflowStageModel stage);
    Task<bool> DeleteStageAsync(string workFlowId, string stageId);
    Task<WorkFlowModel> GetWorkFlowAsync(string workFlowId);
    Task CreateOrUpdateWorkFlowAsync(WorkFlowModel workflow);



}