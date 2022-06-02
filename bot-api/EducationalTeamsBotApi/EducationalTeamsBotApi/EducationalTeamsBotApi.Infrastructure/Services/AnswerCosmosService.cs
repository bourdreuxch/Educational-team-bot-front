// -----------------------------------------------------------------------
// <copyright file="AnswerCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Infrastructure.Services
{
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using Microsoft.Azure.Cosmos;

    /// <summary>
    /// Class that will interact with the CosmosDB.
    /// </summary>
    public class AnswerCosmosService : IAnswerCosmosService
    {
        private readonly CosmosClient cosmosClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerCosmosService"/> class.
        /// </summary>
        public AnswerCosmosService()
        {
            var cosmosConString = Environment.GetEnvironmentVariable("COSMOS_CON_STRING");
            this.cosmosClient = new CosmosClient(cosmosConString);
        }

        /// <inheritdoc/>
        public Task<CosmosAnswer> CreateAnswer(CosmosAnswer answer)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosAnswer> EditAnswer(CosmosAnswer answer)
        {
            throw new NotImplementedException();
        }
    }
}
