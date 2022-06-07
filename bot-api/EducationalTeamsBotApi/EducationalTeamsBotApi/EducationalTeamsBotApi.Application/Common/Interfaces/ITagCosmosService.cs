// -----------------------------------------------------------------------
// <copyright file="ITagCosmosService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    using EducationalTeamsBotApi.Domain.Entities;

    /// <summary>
    /// Interface containing methods that call cosmosDB.
    /// </summary>
    public interface ITagCosmosService
    {
        /// <summary>
        /// Gets the list of tags of the cosmosDb.
        /// </summary>
        /// <returns>A list of user objects.</returns>
        Task<IEnumerable<CosmosTag>> GetTags();

        /// <summary>
        /// Get a specific tag.
        /// </summary>
        /// <param name="id">identifier of the tag.</param>
        /// <returns>Tag object.</returns>
        Task<CosmosTag> GetTag(string id);

        /// <summary>
        /// Get a tag by searching a corresponding variation.
        /// </summary>
        /// <param name="tag">variation to look for.</param>
        /// <returns>Tag object.</returns>
        Task<CosmosTag> SearchTag(string tag);

        /// <summary>
        /// Insert a brand new tag in the CosmosDB.
        /// </summary>
        /// <param name="tag">New tag.</param>
        /// <returns>The inserted value.</returns>
        Task<CosmosTag> AddTag(CosmosTag tag);

        /// <summary>
        /// Insert a new variation to an already existing tag.
        /// </summary>
        /// <param name="tag">the existing tag</param>
        /// <param name="tagVariation">the new variation.</param>
        /// <returns>The edited object</returns>
        Task<CosmosTag> AddTagVariation(CosmosTag tag, string tagVariation);
    }
}
