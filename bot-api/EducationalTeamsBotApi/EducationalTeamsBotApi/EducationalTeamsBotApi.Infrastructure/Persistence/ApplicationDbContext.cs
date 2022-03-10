// -----------------------------------------------------------------------
// <copyright file="ApplicationDbContext.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using EducationalTeamsBotApi.Application.Common.Interfaces;
using EducationalTeamsBotApi.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace EducationalTeamsBotApi.Infrastructure.Persistence
{
    /// <summary>
    /// Class context of the application.
    /// </summary>
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IDomainEventService domainEventService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">Options of the context.</param>
        /// <param name="currentUserService">Current user service.</param>
        /// <param name="domainEventService">Domain event service.</param>
        public ApplicationDbContext(
            DbContextOptions options,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
            : base(options)
        {
            this.currentUserService = currentUserService;
            this.domainEventService = domainEventService;
        }

        /// <inheritdoc/>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in this.ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = this.currentUserService.UserId;
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = this.currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            await this.DispatchEvents();

            return result;
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Dispatch the events.
        /// </summary>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        private async Task DispatchEvents()
        {
            while (true)
            {
                var domainEventEntity = this.ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .FirstOrDefault(domainEvent => !domainEvent.IsPublished);

                if (domainEventEntity == null)
                {
                    break;
                }

                domainEventEntity.IsPublished = true;
                await this.domainEventService.Publish(domainEventEntity);
            }
        }
    }
}
