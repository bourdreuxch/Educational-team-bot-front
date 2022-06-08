// -----------------------------------------------------------------------
// <copyright file="TagCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Constants;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;
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
            var options = new CosmosClientOptions() { ConnectionMode = ConnectionMode.Gateway };

            this.cosmosClient = new CosmosClient(cosmosConString, options);

        }

        /// <inheritdoc/>
        public Task<CosmosTag?> AddTag(List<string> variants)
        {
            var db = this.cosmosClient.GetDatabase("DiiageBotDatabase");
            var container = db.GetContainer("Tags");
            if (variants.Any())
            {
                throw new Exception("No variants");
            }

            var id = Guid.NewGuid().ToString();
            container.CreateItemAsync<CosmosTag>(new CosmosTag { Id = id, Variants = variants }, new PartitionKey(id));

            return this.SearchTag(variants.First());
        }

        /// <inheritdoc/>
        public Task<CosmosTag?> EditTagVariant(string id, string tagVariant)
        {
            var db = this.cosmosClient.GetDatabase("DiiageBotDatabase");
            var container = db.GetContainer("Tags");

            var existingTag = this.GetTag(id).Result;

            if (existingTag != null)
            {
                var tags = existingTag.Variants.ToList();

                if (tags.Contains(tagVariant))
                {
                    tags.Remove(tagVariant);
                }
                else
                {
                    tags.Add(tagVariant);
                }

                existingTag.Variants = tags;
                container.ReplaceItemAsync(existingTag, existingTag.Id);
            }

            return this.GetTag(id);
        }

        /// <inheritdoc/>
        public async Task<CosmosTag?> GetTag(string id)
        {
            var db = this.cosmosClient.GetDatabase("DiiageBotDatabase");
            var container = db.GetContainer("Tags");

            var q = container.GetItemLinqQueryable<CosmosTag>();
            var iterator = q.Where(t => t.Id == id).ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return results.FirstOrDefault<CosmosTag>();
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
        public async Task<CosmosTag?> SearchTag(string tag)
        {
            var db = this.cosmosClient.GetDatabase("DiiageBotDatabase");
            var container = db.GetContainer("Tags");

            var q = container.GetItemLinqQueryable<CosmosTag>();
            var iterator = q.Where(t => t.Variants.Contains(tag)).ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return results.FirstOrDefault<CosmosTag>();
        }

        /// <inheritdoc/>
        public async Task<Unit> DeleteTag(string id)
        {
            var db = this.cosmosClient.GetDatabase("DiiageBotDatabase");
            var container = db.GetContainer("Tags");

            await container.DeleteItemAsync<CosmosTag>(id, new PartitionKey(id));
            return default(Unit);
        }
    }
}