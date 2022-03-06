// -----------------------------------------------------------------------
// <copyright file="IDomainEventService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using EducationalTeamsBotApi.Domain.Common;
using System.Threading.Tasks;

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    /// <summary>
    /// Interface domain event service.
    /// </summary>
    public interface IDomainEventService
    {
        /// <summary>
        /// Publish the event.
        /// </summary>
        /// <param name="domainEvent">Domain event.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task Publish(DomainEvent domainEvent);
    }
}
