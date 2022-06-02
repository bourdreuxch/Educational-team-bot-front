// -----------------------------------------------------------------------
// <copyright file="CosmosUser.cs" company="DiiageBot Team">
// Copyright (c) DIIAGE Groupe 1 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Application.Cosmos_Users.Queries.GetUsersQuery
{
    using EducationalTeamsBotApi.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Query allowing to get Cosmos users.
    /// </summary>
    public class GetUsersQuery : IRequest<IEnumerable<CosmosUser>>
    {
    }
}
