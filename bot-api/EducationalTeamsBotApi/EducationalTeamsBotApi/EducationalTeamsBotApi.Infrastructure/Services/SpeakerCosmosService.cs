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
        public Task<IEnumerable<CosmosSpeaker>> GetCosmosSpeakers()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker> GetSpeaker(string id)
        {
            throw new NotImplementedException();
        }
    }
}
