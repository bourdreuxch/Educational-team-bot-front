namespace EducationalTeamsBotApi.Infrastructure.Services
{
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos;

    /// <summary>
    /// Class that will interact with the CosmosDB.
    /// </summary>
    public class UserCosmosService : IUserCosmosService
    {
        private readonly CosmosClient cosmosClient;


        /// <summary>
        /// Initializes a new instance of the <see cref="UserCosmosService"/> class.
        /// </summary>
        public UserCosmosService()
        {
            var cosmosConString = Environment.GetEnvironmentVariable("COSMOS_CON_STRING");
            this.cosmosClient = new CosmosClient(cosmosConString);
        }

        /// <inheritdoc/>
        public Task<CosmosUser> AddUser(CosmosUser user)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosUser> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CosmosUser>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
