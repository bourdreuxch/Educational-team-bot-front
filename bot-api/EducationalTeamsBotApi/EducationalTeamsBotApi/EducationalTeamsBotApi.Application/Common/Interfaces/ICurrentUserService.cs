// -----------------------------------------------------------------------
// <copyright file="ICurrentUserService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    /// <summary>
    /// Interface Current user service.
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        string UserId { get; }
    }
}
