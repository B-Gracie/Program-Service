using DataAccessLayer.CosmosClient;
using DataAccessLayer.Model;
using Microsoft.Azure.Cosmos;
using DataAccessLayer.Repository.@interface;

namespace DataAccessLayer.Repository.Implementation
{
    public class WorkFlowRepository : IWorkFlowRepository
    {
        private readonly Microsoft.Azure.Cosmos.CosmosClient _cosmosClient;
        private readonly string _containerName = "WorkFlowContainer"; 

        public WorkFlowRepository(CosmosClientProvider cosmosClientProvider)
        {
            _cosmosClient = cosmosClientProvider.GetCosmosClient();
        }

        // Get a workflow stage by its ID within a workflow
        public async Task<WorkflowStageModel?> GetStageAsync(string workFlowId, string stageId)
        {
            var workflow = await GetWorkFlowAsync(workFlowId);

            var stage = workflow.Stages.FirstOrDefault(s => s.Id == stageId);
            return stage;
        }

        // Create or update a workflow stage within a workflow
        public async Task<WorkflowStageModel> CreateOrUpdateStageAsync(string workFlowId, WorkflowStageModel stage)
        {
            var workflow = await GetWorkFlowAsync(workFlowId);

            // Check if the stage already exists
            var existingStageIndex = workflow.Stages.FindIndex(s => s.Id == stage.Id);
            if (existingStageIndex >= 0)
            {
                workflow.Stages[existingStageIndex] = stage;
            }
            else
            {
                workflow.Stages.Add(stage);
            }

            await CreateOrUpdateWorkFlowAsync(workflow); // Update the workflow with the modified stage

            return stage;
        }

        // Delete a workflow stage within a workflow
        public async Task<bool> DeleteStageAsync(string workFlowId, string stageId)
        {
            var workflow = await GetWorkFlowAsync(workFlowId);

            var stageToRemove = workflow.Stages.FirstOrDefault(s => s.Id == stageId);
            if (stageToRemove != null)
            {
                workflow.Stages.Remove(stageToRemove);
                await CreateOrUpdateWorkFlowAsync(workflow); // Update the workflow without the removed stage
                return true;
            }

            return false; // Stage not found
        }

        public async Task<WorkFlowModel> GetWorkFlowAsync(string workFlowId)
        {
            try
            {
                var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
                var query = new QueryDefinition("SELECT * FROM c WHERE c.id = @workflowId")
                    .WithParameter("@workflowId", workFlowId);

                var iterator = container.GetItemQueryIterator<WorkFlowModel>(query);

                if (iterator.HasMoreResults)
                {
                    var response = await iterator.ReadNextAsync();
                    return response.FirstOrDefault();
                }

                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                throw ex;
            }
        }

        public async Task CreateOrUpdateWorkFlowAsync(WorkFlowModel workflow)
        {
            try
            {
                var existingWorkflow = await GetWorkFlowAsync(workflow.Id);

                if (existingWorkflow == null)
                {
                    var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
                    // Workflow does not exist, create it
                    var response = await container.CreateItemAsync(workflow, new PartitionKey(workflow.Id));
                }
                else
                {
                    var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
                    // Workflow exists, update it
                    var response = await container.ReplaceItemAsync(workflow, workflow.Id, new PartitionKey(workflow.Id));
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                throw;
            }
        }
    }
}
