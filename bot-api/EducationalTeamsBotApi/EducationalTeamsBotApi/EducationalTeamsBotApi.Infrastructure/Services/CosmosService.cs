// -----------------------------------------------------------------------
// <copyright file="CosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using Microsoft.Azure.Cosmos;

    /// <summary>
    /// Class that will interact with the CosmosDB.
    /// </summary>
    internal class CosmosService : ICosmosDbService
    {
        private readonly CosmosClient cosmosClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CosmosService"/> class.
        /// </summary>
        public CosmosService()
        {
            var cosmosConString = Environment.GetEnvironmentVariable("COSMOS_CON_STRING");
            this.cosmosClient = new CosmosClient(cosmosConString);
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> AddAnswersToQuestion(List<string> answerIds)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> AddAnswerToQuestion(string answerId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker> AddSpeaker(CosmosSpeaker speaker)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosTag> AddTag(CosmosTag tag)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> AddTagsToQuestion(List<string> tagIds)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> AddTagToQuestion(string tagId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosTag> AddTagVariation(CosmosTag tag, string tagVariation)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosUser> AddUser(CosmosUser user)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosAnswer> CreateAnswer(CosmosAnswer answer)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosReaction> CreateReaction(CosmosReaction reaction)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task DeleteReaction(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker> DeleteSpeaker(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosAnswer> EditAnswer(CosmosAnswer answer)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosReaction> EditReaction(CosmosReaction reaction)
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
        public Task<IEnumerable<CosmosQuestion>> GetCosmosQuestions()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CosmosReaction>> GetCosmosReactions()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CosmosSpeaker>> GetCosmosSpeakers()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> GetQuestion(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosReaction> GetReaction(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosSpeaker> GetSpeaker(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosTag> GetTag(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CosmosTag>> GetTags()
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

        /// <inheritdoc/>
        public Task<CosmosTag> SearchTag(string tag)
        {
            throw new NotImplementedException();
        }
    }
}
