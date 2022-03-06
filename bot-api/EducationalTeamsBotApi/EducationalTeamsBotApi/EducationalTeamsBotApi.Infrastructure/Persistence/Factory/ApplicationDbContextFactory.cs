// -----------------------------------------------------------------------
// <copyright file="ApplicationDbContextFactory.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using EducationalTeamsBotApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EducationalTeamsBotApi.Infrastructure.Factory
{
    /// <summary>
    /// Class Factory for the <see cref="ApplicationDbContext"/>.
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        /// <summary>
        /// Creates a <see cref="ApplicationDbContext"/>.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>Returns a <see cref="ApplicationDbContext"/>.</returns>
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\\mssqllocaldb;Database=PocArchiCleanDb;Trusted_Connection=True;MultipleActiveResultSets=true;",
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

            return new ApplicationDbContext(optionsBuilder.Options, null, null);
        }
    }
}
