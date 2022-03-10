// -----------------------------------------------------------------------
// <copyright file="IApplicationDbContext.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    /// <summary>
    /// Interface context for the application.
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Persists the data.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Returns a <see cref="Task{int}"/>.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
