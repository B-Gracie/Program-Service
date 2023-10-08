using DataAccessLayer.CosmosClient;
using DataAccessLayer.Model;
using Microsoft.Azure.Cosmos;
using DataAccessLayer.Repository.@interface;

namespace DataAccessLayer.Repository.Implementation
{
    public class ProgramPreviewRepository : IProgramPreviewRepo
    {
        private readonly Microsoft.Azure.Cosmos.CosmosClient _cosmosClient;
        private readonly string _containerName = "ProgramPreviewContainer"; // Replace with your actual container name

        public ProgramPreviewRepository(CosmosClientProvider cosmosClientProvider)
        {
            _cosmosClient = cosmosClientProvider.GetCosmosClient();
        }

        public async Task<ProgramPreviewModel> GetProgramPreviewAsync(string programId)
        {
            try
            {
                var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
                var query = new QueryDefinition($"SELECT * FROM c WHERE c.Id = @programId")
                    .WithParameter("@programId", programId);

                var iterator = container.GetItemQueryIterator<ProgramPreviewModel>(query);

                if (iterator.HasMoreResults)
                {
                    var response = await iterator.ReadNextAsync();
                    return response.FirstOrDefault();
                }

                return null; // Program with the given ID not found
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                throw ex;
            }
        }
    }
}