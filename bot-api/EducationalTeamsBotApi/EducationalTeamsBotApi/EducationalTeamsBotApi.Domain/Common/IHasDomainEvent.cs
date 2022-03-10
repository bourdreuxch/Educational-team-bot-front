// -----------------------------------------------------------------------
// <copyright file="IHasDomainEvent.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace EducationalTeamsBotApi.Domain.Common
{
    /// <summary>
    /// Interface providing a list of domain event.
    /// </summary>
    public interface IHasDomainEvent
    {
        /// <summary>
        /// Gets or sets the list of <see cref="DomainEvent"/>.
        /// </summary>
        public List<DomainEvent> DomainEvents { get; set; }
    }
}
