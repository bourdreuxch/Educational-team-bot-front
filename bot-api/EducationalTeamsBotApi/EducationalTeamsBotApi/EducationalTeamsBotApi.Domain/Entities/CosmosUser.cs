// -----------------------------------------------------------------------
// <copyright file="CosmosUser.cs" company="DiiageBot Team">
// Copyright (c) DIIAGE Groupe 1 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Domain.Entities
{
    /// <summary>
    /// Users contained in a cosmosDb format
    /// </summary>
    public class CosmosUser
    {
        /// <summary>
        /// Gets or sets a user's identifier.
        /// </summary>
        public string? Id { get; set; }
    }
}
