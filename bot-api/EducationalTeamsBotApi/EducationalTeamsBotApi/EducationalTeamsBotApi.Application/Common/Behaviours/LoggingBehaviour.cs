// -----------------------------------------------------------------------
// <copyright file="LoggingBehaviour.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using EducationalTeamsBotApi.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace EducationalTeamsBotApi.Application.Common.Behaviours
{
    /// <summary>
    /// Class Behaviour for logging.
    /// </summary>
    /// <typeparam name="TRequest">Type of the request.</typeparam>
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger logger;
        private readonly ICurrentUserService currentUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingBehaviour{TRequest}"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="currentUserService">Current user service.</param>
        /// <param name="identityService">Identity service.</param>
        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            this.logger = logger;
            this.currentUserService = currentUserService;
        }

        /// <summary>
        /// Process the behaviour.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Return a <see cref="Task"/>.</returns>
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = this.currentUserService.UserId ?? string.Empty;

            this.logger.LogInformation(
                "Request: {Name} {@UserId} {@Request}",
                requestName,
                userId,
                request);
        }
    }
}
