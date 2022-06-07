// -----------------------------------------------------------------------
// <copyright file="QuestionCosmosService.cs" company="DIIAGE">
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
    public class QuestionCosmosService : IQuestionCosmosService
    {
        private readonly CosmosClient cosmosClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionCosmosService"/> class.
        /// </summary>
        public QuestionCosmosService()
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
        public Task<IEnumerable<CosmosQuestion>> GetCosmosQuestions()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> GetQuestion(string id)
        {
            throw new NotImplementedException();
        }
    }
}
