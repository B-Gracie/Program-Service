
using DataAccessLayer.CosmosClient;
using DataAccessLayer.Model;
using DataAccessLayer.Repository.@interface;
using Microsoft.Azure.Cosmos;

namespace DataAccessLayer.Repository.Implementation
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly Microsoft.Azure.Cosmos.CosmosClient _cosmosClient;
        private readonly string _containerName = "ProgramContainer"; // Replace with your actual container name

        public ProgramRepository(CosmosClientProvider cosmosClientProvider)
        {
            _cosmosClient = cosmosClientProvider.GetCosmosClient();
        }

        public async Task<IEnumerable<ProgramModel>> GetProgramsAsync()
        {
            var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
            var query = new QueryDefinition("SELECT * FROM c");
            var iterator = container.GetItemQueryIterator<ProgramModel>(query);

            var programs = new List<ProgramModel>();
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                programs.AddRange(response.ToList());
            }

            return programs;
        }

        public async Task<ProgramModel> GetProgramAsync(string id)
        {
            try
            {
                var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
                var response = await container.ReadItemAsync<ProgramModel>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Handle not found
                return null;
            }
        }

        public async Task<ProgramModel> CreateProgramAsync(ProgramModel programModel)
        {
            try
            {
                var container = _cosmosClient.GetContainer("ProgramDB", _containerName);
                var response = await container.CreateItemAsync(programModel);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return programModel;
                }
                else
                {
                    throw new Exception($"Failed to create program. Status code: {response.StatusCode}");
                }
            }
            catch (CosmosException ex)
            {
                // Handle any Cosmos DB-related exceptions here, e.g., logging, error response
                throw ex;
            }
        }



        public async Task<ProgramModel> UpdateProgramAsync(string id, ProgramModel program)
        {
            try
            {
                var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
                var response = await container.ReplaceItemAsync(program, id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Handle not found
                return null;
            }
        }

      

        public async Task<bool> DeleteProgramAsync(string id)
        {
            try
            {
                var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
                await container.DeleteItemAsync<ProgramModel>(id, new PartitionKey(id));
                return true;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false; // Return false if the item was not found
            }
        }
    }
}
