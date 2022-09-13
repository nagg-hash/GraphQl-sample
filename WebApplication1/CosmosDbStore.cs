using Microsoft.Azure.Cosmos;

namespace WebApplication1
{
    public class CosmosDbStore
    {
        public class CosmosDBStore : ICosmosDBStore
        {
            private readonly CosmosClient _client;

            public CosmosDBStore()
            {
                _client = GetCosmosDbClient();
            }

            public Container GetContainer(string containerName)
            {
                return _client.GetContainer("TEST", containerName);
            }

            private CosmosClient GetCosmosDbClient()
            {
                CosmosClientOptions options = new CosmosClientOptions()
                {
                    SerializerOptions = new CosmosSerializationOptions()
                    {
                        PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase,
                        IgnoreNullValues = true
                    }
                };
                string primaryKey = "REPLACE_THIS";
                return new CosmosClient("https://localhost:8081", primaryKey, options);
            }
        }

        public interface ICosmosDBStore
        {
            Container GetContainer(string containerName);
        }
    }
}
