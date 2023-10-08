using DataAccessLayer.Model;
using DataAccessLayer.Repository.@interface;
using ServiceLayer.ServiceInterface;

namespace ServiceLayer.ServiceImplementation;

public class WorkFlowService : IWorkFlowService
{
    private readonly IWorkFlowRepository _repository;

    public WorkFlowService(IWorkFlowRepository repository)
    {
        _repository = repository;
    }

    public async Task<WorkFlowModel> GetWorkFlowAsync(string workFlowId)
    {
        return await _repository.GetWorkFlowAsync(workFlowId);
    }

    public async Task<WorkflowStageModel> GetStageAsync(string workFlowId, string stageId)
    {
        return await _repository.GetStageAsync(workFlowId, stageId);
    }

    public async Task<WorkflowStageModel> CreateOrUpdateStageAsync(string workFlowId, WorkflowStageModel stage)
    {
        return await _repository.CreateOrUpdateStageAsync(workFlowId, stage);
    }

    public async Task<bool> DeleteStageAsync(string workFlowId, string stageId)
    {
        return await _repository.DeleteStageAsync(workFlowId, stageId);
    }
}

