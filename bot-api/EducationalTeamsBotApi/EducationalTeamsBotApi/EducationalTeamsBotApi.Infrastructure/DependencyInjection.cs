// -----------------------------------------------------------------------
// <copyright file="DependencyInjection.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace EducationalTeamsBotApi.Infrastructure
{
    using EducationalTeamsBotApi.Application.Common.Interfaces;
    using EducationalTeamsBotApi.Infrastructure.Persistence;
    using EducationalTeamsBotApi.Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Graph;

    /// <summary>
    /// Static class providing an extension method to handle dependency injection for the infrastructure layer.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configures and returns a service collection for the infrastructure layer.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="configuration">Configuration of the application.</param>
        /// <returns>Returns a <see cref="ServiceCollection"/>.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<GraphServiceClient, GraphServiceClient>();
            services.AddScoped<IGraphService, GraphService>();
            services.AddScoped<ITagService, TagService>();

            return services;
        }
    }
}