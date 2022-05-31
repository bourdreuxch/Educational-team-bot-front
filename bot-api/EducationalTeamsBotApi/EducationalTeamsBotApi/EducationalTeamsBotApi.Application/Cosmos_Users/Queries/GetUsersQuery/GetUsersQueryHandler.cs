// -----------------------------------------------------------------------
// <copyright file="CosmosUser.cs" company="DiiageBot Team">
// Copyright (c) DIIAGE Groupe 1 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Cosmos_Users.Queries.GetUsersQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    ///  Handler for the query that will get users.
    /// </summary>
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<CosmosUser>>
    {
        /// <summary>
        /// cosmos service.
        /// </summary>
        private readonly ICosmosDbService cosmosDbService;

        /// <summary>
        ///  Initializes a new instance of the <see cref="GetUsersQueryHandler"/> class.
        /// </summary>
        /// <param name="cosmosDbService"> cosmos service.</param>
        public GetUsersQueryHandler(ICosmosDbService cosmosDbService)
        {
            this.cosmosDbService = cosmosDbService;
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CosmosUser>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
