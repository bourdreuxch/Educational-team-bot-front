// -----------------------------------------------------------------------
// <copyright file="QuestionCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Xml;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
    using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Linq;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Schema;
    using Microsoft.Bot.Connector;

    /// <summary>
    /// Class that will interact with the CosmosDB.
    /// </summary>
    public class QuestionCosmosService : IQuestionCosmosService
    {
        private readonly CosmosClient cosmosClient;
        private readonly QnAMakerClient qnaClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionCosmosService"/> class.
        /// </summary>
        public QuestionCosmosService()
        {
            var authoringKey = "113614810bcf4284bc388fc6f0f7ca7b";
            var authoringURL = "https://qnadiibot.cognitiveservices.azure.com/";
            var cosmosConString = Environment.GetEnvironmentVariable("COSMOS_CON_STRING");
            this.cosmosClient = new CosmosClient(cosmosConString);
            this.qnaClient = new QnAMakerClient(new ApiKeyServiceClientCredentials(authoringKey))
            { Endpoint = authoringURL };
            
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
        public async Task<IEnumerable<CosmosQuestion>> GetCosmosQuestions()
        {
            var db = this.cosmosClient.GetDatabase("DiiageBotDatabase");
            var container = db.GetContainer("Questions");
            var speakers = container.GetItemLinqQueryable<CosmosQuestion>();
            var iterator = speakers.ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return Tools.ToIEnumerable(results.GetEnumerator());
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> GetQuestion(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CosmosQuestion> GetQuestionFromAnswer(string answerId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<string> QuestionAsked(Activity question)
        {
            var mention = new Mention
            {
                Mentioned = question.From,
                Text = $"<at>{XmlConvert.EncodeName(question.From.Name)}</at>",
            };

            var replyActivity = MessageFactory.Text($"Hello {mention.Text}.");
            replyActivity.Entities = new List<Entity> { mention };
            var turnContext = question.GetConversationReference();
            turnContext.GetContinuationActivity().CreateReply();
            question.CreateReply($"Hello {mention.Text}.");

            var conv = question.GetConversationReference();

            var queryingURL = "https://qnadiibot.azurewebsites.net";
            var endpointKey = await this.qnaClient.EndpointKeys.GetKeysAsync();
            var qnaRuntimeCli = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials(endpointKey.PrimaryEndpointKey)) { RuntimeEndpoint = queryingURL };

            var response = await qnaRuntimeCli.Runtime.GenerateAnswerAsync("770b2be2-e25f-4963-b502-93961da9f88f", new QueryDTO { Question = question.Text });
            var res = response.Answers[0].Answer;
            if (response.Answers[0].Answer == "No good match found in KB.")
            {
                res = "Pas de solution mais je reste à l'écoute";
            }

            Console.WriteLine("Endpoint Response: {0}.", response.Answers[0].Answer);
            var responseBot = new Activity();
            responseBot.Conversation = question.Conversation;
            responseBot.From = question.Recipient;
            responseBot.Locale = question.Locale;
            responseBot.Recipient = question.From;
            responseBot.ReplyToId = question.Id;
            responseBot.Type = "message";
            responseBot.Text = res;

            var httpclient = new HttpClient();
            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Post;
            httpRequest.RequestUri = new Uri($"https://smba.trafficmanager.net/apis//v3/conversations/{responseBot.Conversation.Id}/activities/{responseBot.Id}");
            httpRequest.Headers("Authorization")
            var responseHttp = httpclient.Send(httpRequest);

            return res;
        }
    }
}
