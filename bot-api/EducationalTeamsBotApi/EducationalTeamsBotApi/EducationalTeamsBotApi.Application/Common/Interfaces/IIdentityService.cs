// -----------------------------------------------------------------------
// <copyright file="IIdentityService.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using EducationalTeamsBotApi.Application.Common.Models;
using System.Threading.Tasks;

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    /// <summary>
    /// Interface indentity service.
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Returns a <see cref="Task{string}"/>.</returns>
        Task<string> GetUserNameAsync(string userId);

        /// <summary>
        /// Verify if the user is in the role.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="role">Role.</param>
        /// <returns>Returns a <see cref="Task{bool}"/>.</returns>
        Task<bool> IsInRoleAsync(string userId, string role);

        /// <summary>
        /// Authorize the user with a policy.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="policyName">Policy name.</param>
        /// <returns>Returns a <see cref="Task{bool}"/>.</returns>
        Task<bool> AuthorizeAsync(string userId, string policyName);

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Returns a <see cref="Task{(Result Result, string UserId)}"/>.</returns>
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Returns a <see cref="Task{Result}"/>.</returns>
        Task<Result> DeleteUserAsync(string userId);
    }
}
