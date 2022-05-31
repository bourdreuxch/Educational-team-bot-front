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
    using Microsoft.Extensions.Configuration;
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

        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphService"/> class.
        /// </summary>
        /// <param name="configuration">Configuration to use.</param>
        public GraphService(IConfiguration configuration)
        {
            this.configuration = configuration;
            var scopes = new[] { "User.Read" };
            var tenantId = this.configuration["AzureAd:TenantId"];
            var clientId = this.configuration["AzureAd:ClientId"];
            var clientSecret = this.configuration["AzureAd:ClientSecret"];

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
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJub25jZSI6IlVjM2NPRmpLNWlaUnh4N1dlT0dCV0FfY0JNYlgwTUdiNzV4WS12ZnpQbkEiLCJhbGciOiJSUzI1NiIsIng1dCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyIsImtpZCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDAiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9mZWZlOWFmNy1mMzMwLTQyOWQtODA4Ny1mNWU2NTZmN2E3Y2UvIiwiaWF0IjoxNjUzNTA0NzIxLCJuYmYiOjE2NTM1MDQ3MjEsImV4cCI6MTY1MzUwOTg0MiwiYWNjdCI6MSwiYWNyIjoiMSIsImFpbyI6IkFVUUF1LzhUQUFBQUJ3UnVqOWdEYU5uZC9YZisxUi9vNDZQK1ZVb2NDajJpUlhDMnBQQURiREtMSWkzQkZsaDcyU1pncW81VHFSL3lMbjdHbmFLSEozQTV3Q0ZmMkF5VjBBPT0iLCJhbHRzZWNpZCI6IjU6OjEwMDMyMDAwNTFDQUZCNjIiLCJhbXIiOlsicHdkIl0sImFwcF9kaXNwbGF5bmFtZSI6ImVkdWNhdGlvbmFsLXRlYW1zLWJvdCIsImFwcGlkIjoiYmM0YmEzZTEtNmMzOS00YjUwLWJhNDQtNmI2YjM3YjdmZDRkIiwiYXBwaWRhY3IiOiIwIiwiZW1haWwiOiJiZW5qYW1pbi5zb3JyaWF1eEBkaWlhZ2Uub3JnIiwiaWRwIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvMTRiYzUyMTktNDBjYS00ZDYyLWE4ZTQtN2M5N2MxMjM2MzQ5LyIsImlkdHlwIjoidXNlciIsImlwYWRkciI6IjkxLjE2NS4yMDMuNDgiLCJuYW1lIjoic29ycmlhdXguYmVuamFtaW4iLCJvaWQiOiIwMzU4M2I5NC02NzU2LTQ3MTgtYTk2Mi1iMDA4MjEwMWEwZjgiLCJwbGF0ZiI6IjMiLCJwdWlkIjoiMTAwMzIwMDFDMkRCRDc3RiIsInJoIjoiMC5BWUVBOTVyLV9qRHpuVUtBaF9YbVZ2ZW56Z01BQUFBQUFBQUF3QUFBQUFBQUFBQ0JBRDAuIiwic2NwIjoiQ2FsZW5kYXJzLlJlYWQgQ2hhbm5lbE1lc3NhZ2UuUmVhZC5BbGwgQ2hhbm5lbE1lc3NhZ2UuU2VuZCBlbWFpbCBFeHRlcm5hbEl0ZW0uUmVhZC5BbGwgRmlsZXMuUmVhZC5BbGwgR3JvdXAuUmVhZFdyaXRlLkFsbCBNYWlsLlJlYWQgb3BlbmlkIHByb2ZpbGUgU2l0ZXMuUmVhZC5BbGwgVXNlci5SZWFkIFVzZXIuUmVhZC5BbGwiLCJzaWduaW5fc3RhdGUiOlsia21zaSJdLCJzdWIiOiJKZHpnR2R2X0p2aVJTQWdYbkFZckdMRTZieWYyWFE4TXdhZml4UnU5RW9ZIiwidGVuYW50X3JlZ2lvbl9zY29wZSI6IkVVIiwidGlkIjoiZmVmZTlhZjctZjMzMC00MjlkLTgwODctZjVlNjU2ZjdhN2NlIiwidW5pcXVlX25hbWUiOiJiZW5qYW1pbi5zb3JyaWF1eEBkaWlhZ2Uub3JnIiwidXRpIjoiUS1aSHpuUWlhVVdyTDJKbHpDMDlBUSIsInZlciI6IjEuMCIsIndpZHMiOlsiMTNiZDFjNzItNmY0YS00ZGNmLTk4NWYtMThkM2I4MGYyMDhhIl0sInhtc19zdCI6eyJzdWIiOiJ3SkpxOEtmMVRPUkdxZS02NkRRWkF1bnR4ZTdBZWtscXFzZU12UXBMRXlNIn0sInhtc190Y2R0IjoxNjEzNjU3MzYyfQ.FF9T2-PBoz89jflfwDm8b3JZ2A6l5bUT9YW0JBMYQSAU5rr2SfevlpHVRGMOheoyEBXy4bTLX424nsV7x2Ap6BiUMKsZMgUGEleaGhdDcDByUb6pOqwXCUxQ11t-ZNCjck-_8n0mlhVgwozk9dfBmh_tmZ1Ccnjcogeru5Cdrv09QSrBcC39ypME61KA9ChZ95Jb0dT4_3lI-G_-sMxGN9W4wLYyQDMnfbTFeAfnDIxDyNrC84bCveXAR1B84JCBsN9pCHKqNknWqF_cgPHT1cjMWFwt086AMafvNRK1AfwR95UZdmfl7wprd1tWI465XzPlfGgoNARSdAN2R57-Lg");
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
