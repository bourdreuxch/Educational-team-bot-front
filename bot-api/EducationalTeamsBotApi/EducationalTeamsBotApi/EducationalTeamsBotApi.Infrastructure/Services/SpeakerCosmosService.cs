// -----------------------------------------------------------------------
// <copyright file="SpeakerCosmosService.cs" company="DIIAGE">
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
    public class SpeakerCosmosService : ISpeakerCosmosService
    {
        private readonly CosmosClient cosmosClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpeakerCosmosService"/> class.
        /// </summary>
        public SpeakerCosmosService()
        {
            var cosmosConString = Environment.GetEnvironmentVariable("COSMOS_CON_STRING");
            this.cosmosClient = new CosmosClient(cosmosConString);
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker> AddSpeaker(CosmosSpeaker speaker)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker> DeleteSpeaker(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker> EditSpeaker(CosmosSpeaker speaker)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker> EnableSpeaker(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CosmosSpeaker>> GetCosmosSpeakers()
        {
            var db = this.cosmosClient.GetDatabase("DiiageBotDatabase");
            var container = db.GetContainer("Speakers");
            var speakers = container.GetItemLinqQueryable<CosmosSpeaker>();
            var iterator = speakers.ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return Tools.ToIEnumerable(results.GetEnumerator());
        }

        /// <inheritdoc/>
        public async Task<CosmosSpeaker> GetSpeaker(string id)
        {
            var db = this.cosmosClient.GetDatabase("DiiageBotDatabase");
            var container = db.GetContainer("Speakers");

            var speaker = container.GetItemQueryIterator<CosmosSpeaker>("SELECT * FROM c WHERE c.id = " + id);
            var result = await speaker.ReadNextAsync();
            return (CosmosSpeaker)result.GetEnumerator();
        }
    }
}
