using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.CosmosClient
{
    public class CosmosClientProvider
    {
        private readonly IConfiguration _configuration;

        public CosmosClientProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Microsoft.Azure.Cosmos.CosmosClient GetCosmosClient()
        {
            var connectionString = _configuration.GetConnectionString("CosmosDb");

            var cosmosClientOptions = new CosmosClientOptions
            {
                SerializerOptions = new CosmosSerializationOptions
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                }
            };

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Cosmos DB connection string is missing or empty.");
            }

            // Create and return the CosmosClient using the connectionString
            return new Microsoft.Azure.Cosmos.CosmosClient(connectionString, cosmosClientOptions);
        }
    }
}