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

        private readonly Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionCosmosService"/> class.
        /// </summary>
        public QuestionCosmosService()
        {
            var cosmosConString = Environment.GetEnvironmentVariable("COSMOS_CON_STRING");

            var options = new CosmosClientOptions() { ConnectionMode = ConnectionMode.Gateway };

            this.cosmosClient = new CosmosClient(cosmosConString, options);

            this.database = this.cosmosClient.GetDatabase("DiiageBotDatabase");
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CosmosQuestion>> InsertCosmosQuestions(List<CosmosQuestion> questions)
        {
            var container = this.database.GetContainer("Questions");

            var insertedQuestions = new List<CosmosQuestion>();

            questions.ForEach(async question =>
            {
                // If question already exists, ignore it
                var existingQuestion = this.GetQuestion(question.Id);
                if (existingQuestion == null)
                {
                    insertedQuestions.Add(await container.CreateItemAsync(question));
                }
            });

            return insertedQuestions;
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
        public async Task<CosmosQuestion> GetQuestion(string id)
        {
            var container = this.database.GetContainer("Questions");
            var query = new QueryDefinition("SELECT * FROM q WHERE q.id = " + '"' + id + '"');
            var question = container.GetItemQueryIterator<CosmosQuestion>(query);
            var result = await question.ReadNextAsync();
            return Tools.ToIEnumerable(result.GetEnumerator()).First();
        }
    }
}
