// -----------------------------------------------------------------------
// <copyright file="TagCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Linq;

    /// <summary>
    /// Class that will interact with the CosmosDB.
    /// </summary>
    public class TagCosmosService : ITagCosmosService
    {
        private readonly CosmosClient cosmosClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagCosmosService"/> class.
        /// </summary>
        public TagCosmosService()
        {
            var cosmosConString = Environment.GetEnvironmentVariable("COSMOS_CON_STRING");
            this.cosmosClient = new CosmosClient(cosmosConString);
        }

        /// <inheritdoc/>
        public Task<CosmosTag> AddTag(CosmosTag tag)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosTag> AddTagVariation(CosmosTag tag, string tagVariation)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosTag> GetTag(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CosmosTag>> GetTags()
        {
            var db = this.cosmosClient.GetDatabase("DiiageBotDatabase");
            var container = db.GetContainer("Tags");
            var tags = container.GetItemLinqQueryable<CosmosTag>();
            var iterator = tags.ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return Tools.ToIEnumerable<CosmosTag>(results.GetEnumerator());
        }

        /// <inheritdoc/>
        public Task<CosmosTag> SearchTag(string tag)
        {
            throw new NotImplementedException();
        }
    }
}
