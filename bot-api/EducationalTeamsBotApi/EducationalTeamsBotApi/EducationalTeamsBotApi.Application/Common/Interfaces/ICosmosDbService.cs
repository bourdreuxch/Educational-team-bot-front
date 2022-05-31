

using EducationalTeamsBotApi.Domain.Entities;

namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    public interface ICosmosDbService
    {

        /// <summary>
        /// Gets the list of users of the cosmosDb.
        /// </summary>
        /// <returns>A list of user objects.</returns>
        Task<IEnumerable<CosmosUser>> GetUsers();
    }
}
