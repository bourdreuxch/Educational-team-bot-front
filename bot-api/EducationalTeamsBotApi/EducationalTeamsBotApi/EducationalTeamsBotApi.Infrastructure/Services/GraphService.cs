// -----------------------------------------------------------------------
// <copyright file="GraphService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Azure.Identity;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using Microsoft.Graph;
    using Microsoft.Identity.Client;

    /// <summary>
    /// Class that will interact with Graph API.
    /// </summary>
    public class GraphService : IGraphService
    {
        /// <summary>
        /// Graph service client.
        /// </summary>
        private readonly GraphServiceClient graphServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphService"/> class.
        /// </summary>
        public GraphService()
        {
            var scopes = new[] { "User.Read" };
            var tenantId = "fefe9af7-f330-429d-8087-f5e656f7a7ce";
            var clientId = "bc4ba3e1-6c39-4b50-ba44-6b6b37b7fd4d";
            var clientSecret = "8it8Q~WypG5CvqUGGmyL0MfSq2nYyg7NQ9zzkatl";

            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
            };

            var cca = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithTenantId(tenantId)
                .WithClientSecret(clientSecret)
                .Build();

            var authProvider = new DelegateAuthenticationProvider(async (request) =>
            {
                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJub25jZSI6ImJNYmJHMGlRVFBpMDBlMVA5RmJNVDJqTHQ2ZVBTSzNQNmdqcFNJN0hUbFEiLCJhbGciOiJSUzI1NiIsIng1dCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyIsImtpZCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDAiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9mZWZlOWFmNy1mMzMwLTQyOWQtODA4Ny1mNWU2NTZmN2E3Y2UvIiwiaWF0IjoxNjUxNjAzNDMwLCJuYmYiOjE2NTE2MDM0MzAsImV4cCI6MTY1MTYwODY2MiwiYWNjdCI6MCwiYWNyIjoiMSIsImFpbyI6IkUyWmdZR2pWWHlXM1pjcXFGZDQyYTJ1UG1yb29HekRJWDh6LzJTSzM2QW5MMVZzOTk4UUIiLCJhbXIiOlsicHdkIl0sImFwcF9kaXNwbGF5bmFtZSI6ImVkdWNhdGlvbmFsLXRlYW1zLWJvdCIsImFwcGlkIjoiYmM0YmEzZTEtNmMzOS00YjUwLWJhNDQtNmI2YjM3YjdmZDRkIiwiYXBwaWRhY3IiOiIwIiwiZmFtaWx5X25hbWUiOiJTb3JyaWF1eCIsImdpdmVuX25hbWUiOiJCZW5qYW1pbiIsImlkdHlwIjoidXNlciIsImlwYWRkciI6IjkxLjE2NS4yMDMuNDgiLCJuYW1lIjoiQmVuamFtaW4gU29ycmlhdXgiLCJvaWQiOiJjMTkzYzEyMC04ZGUxLTQ4Y2QtOGMwNC1kZDY5MTQ0OGMxYjYiLCJwbGF0ZiI6IjMiLCJwdWlkIjoiMTAwMzIwMDFDMjFDNEE1QyIsInJoIjoiMC5BWUVBOTVyLV9qRHpuVUtBaF9YbVZ2ZW56Z01BQUFBQUFBQUF3QUFBQUFBQUFBQ0JBQzAuIiwic2NwIjoiQ2FsZW5kYXJzLlJlYWQgQ2hhbm5lbE1lc3NhZ2UuUmVhZC5BbGwgQ2hhbm5lbE1lc3NhZ2UuU2VuZCBlbWFpbCBFeHRlcm5hbEl0ZW0uUmVhZC5BbGwgRmlsZXMuUmVhZC5BbGwgR3JvdXAuUmVhZFdyaXRlLkFsbCBNYWlsLlJlYWQgb3BlbmlkIHByb2ZpbGUgU2l0ZXMuUmVhZC5BbGwgVXNlci5SZWFkIFVzZXIuUmVhZC5BbGwiLCJzdWIiOiJ5TlkxTVNyZTJGYzlTazR2SkI0ZEZ1Z1NEMEpXRDN5U1drc1JsWjREdXpZIiwidGVuYW50X3JlZ2lvbl9zY29wZSI6IkVVIiwidGlkIjoiZmVmZTlhZjctZjMzMC00MjlkLTgwODctZjVlNjU2ZjdhN2NlIiwidW5pcXVlX25hbWUiOiJiZW5qYW1pbi5zb3JyaWF1eEBncmV2b3JkLm9ubWljcm9zb2Z0LmNvbSIsInVwbiI6ImJlbmphbWluLnNvcnJpYXV4QGdyZXZvcmQub25taWNyb3NvZnQuY29tIiwidXRpIjoiMmlZODF3dWhUVXFiNk1RcEVQUWZBQSIsInZlciI6IjEuMCIsIndpZHMiOlsiNzI5ODI3ZTMtOWMxNC00OWY3LWJiMWItOTYwOGYxNTZiYmI4IiwiZjAyM2ZkODEtYTYzNy00YjU2LTk1ZmQtNzkxYWMwMjI2MDMzIiwiMjkyMzJjZGYtOTMyMy00MmZkLWFkZTItMWQwOTdhZjNlNGRlIiwiZjJlZjk5MmMtM2FmYi00NmI5LWI3Y2YtYTEyNmVlNzRjNDUxIiwiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIiwiZjI4YTFmNTAtZjZlNy00NTcxLTgxOGItNmExMmYyYWY2YjZjIiwiZmU5MzBiZTctNWU2Mi00N2RiLTkxYWYtOThjM2E0OWEzOGIxIiwiNjkwOTEyNDYtMjBlOC00YTU2LWFhNGQtMDY2MDc1YjJhN2E4IiwiYjc5ZmJmNGQtM2VmOS00Njg5LTgxNDMtNzZiMTk0ZTg1NTA5Il0sInhtc19zdCI6eyJzdWIiOiJJNUJWaWg5VHZpMU1NR0N4OE9IRWNiM1YzWTFCSThDUGhXYXhCY3pOZ2kwIn0sInhtc190Y2R0IjoxNjEzNjU3MzYyfQ.IUPsk_pKtjMsXYHRvR5mE6B_prDCt3FUkci3DMpHkG0MDpQoOl-iUMj_P_sfbziDB3k9He1t28-rHKUnvAvJ5ohMZDZS7JId6AVdUxtwLGMbXF1_UANscAu9RRc1WcBaoIq-7jwswmESfAe_6ocZkGttXPYkMUQAnHTe3KR0tjTmYmuG3i1sqGvYYmPLDwa5vwRDUZywjFPK3nOVE7aKQH7Nx_Ki9Rojo3ZQPmngxhEf_aCpWaJAxt2KUSkO-qHcABdEaOf8Hd9ARs2vT5kOuLzOcApfGrc97Oud2jBsul3DD6iPESXUMn7jEPnEfr4t7Pry1W0HiUi8amoBnJN3uA");
            });

            this.graphServiceClient = new GraphServiceClient(authProvider);
        }

        /// <inheritdoc/>
        public bool AddUserToTeam(string teamId, string userId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public List<object> GetMessageAnswers(string teamId, string channelId, string messageId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SearchEntity>> GetMessages()
        {
            var messages = new List<SearchEntity>();
            //var requestContent = new List<SearchRequestObject>()
            //{
            //    new SearchRequestObject
            //    {
            //        EntityTypes = new List<EntityType>()
            //        {
            //            EntityType.Message,
            //        },
            //        Query = new SearchQuery
            //        {
            //            QueryString = "test",
            //        },
            //    },
            //};

            //var requestResult = await this.graphServiceClient.Search
            //    .Query(requestContent)
            //    .Request()
            //    .PostAsync();

            //messages.AddRange(requestResult);

            return messages;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Group>> GetTeams()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public List<Message> GetUnansweredMessages(string teamId, string channelId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = new List<User>();

            var requestResult = await this.graphServiceClient.Users
                .Request()
                .GetAsync();

            users.AddRange(requestResult);

            return users;
        }

        /// <inheritdoc/>
        public bool RemoveUserFromTeam(string teamId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
