namespace EducationalTeamsBotApi.Application.Common.Interfaces
{
    using EducationalTeamsBotApi.Domain.Entities;

    /// <summary>
    /// Interface containing methods that call cosmosDB.
    /// </summary>
    public interface ICosmosDbService
    {

        /// <summary>
        /// Gets the list of users of the cosmosDb.
        /// </summary>
        /// <returns>A list of user objects.</returns>
        Task<IEnumerable<CosmosUser>> GetUsers();

        /// <summary>
        /// Get a specific user (useless).
        /// </summary>
        /// <param name="id">identifier of the user.</param>
        /// <returns>User object</returns>
        Task<CosmosUser> GetUser(string id);

        /// <summary>
        /// Add a new user in the cosmos.
        /// </summary>
        /// <param name="user">User to add.</param>
        /// <returns>the created entity</returns>
        Task<CosmosUser> AddUser(CosmosUser user);

        /// <summary>
        /// Gets the list of tags of the cosmosDb.
        /// </summary>
        /// <returns>A list of user objects.</returns>
        Task<IEnumerable<CosmosTag>> GetTags();

        /// <summary>
        /// Get a specific tag.
        /// </summary>
        /// <param name="id">identifier of the tag.</param>
        /// <returns>Tag object.</returns>
        Task<CosmosTag> GetTag(string id);

        /// <summary>
        /// Get a tag by searching a corresponding variation.
        /// </summary>
        /// <param name="tag">variation to look for.</param>
        /// <returns>Tag object.</returns>
        Task<CosmosTag> SearchTag(string tag);

        /// <summary>
        /// Insert a brand new tag in the CosmosDB.
        /// </summary>
        /// <param name="tag">New tag.</param>
        /// <returns>The inserted value.</returns>
        Task<CosmosTag> AddTag(CosmosTag tag);

        /// <summary>
        /// Insert a new variation to an already existing tag.
        /// </summary>
        /// <param name="tag">the existing tag</param>
        /// <param name="tagVariation">the new variation.</param>
        /// <returns>The edited object</returns>
        Task<CosmosTag> AddTagVariation(CosmosTag tag, string tagVariation);

        /// <summary>
        /// Get all reactions.
        /// </summary>
        /// <returns>List of reactions.</returns>
        Task<IEnumerable<CosmosReaction>> GetCosmosReactions();

        /// <summary>
        /// Get a scpecific reaction.
        /// </summary>
        /// <param name="id">Identifier of the reaction.</param>
        /// <returns>The reaction object.</returns>
        Task<CosmosReaction> GetReaction(string id);

        /// <summary>
        /// Edit the reactions informations.
        /// </summary>
        /// <param name="reaction">the modified reaction.</param>
        /// <returns>the new object.</returns>
        Task<CosmosReaction> EditReaction(CosmosReaction reaction);

        /// <summary>
        /// Create a new reaction element.
        /// </summary>
        /// <param name="reaction">The new reaction.</param>
        /// <returns>The new object.</returns>
        Task<CosmosReaction> CreateReaction(CosmosReaction reaction);

        /// <summary>
        /// Delete a reaction.
        /// </summary>
        /// <param name="id">Id of the reaction to delete.</param>
        /// <returns>void.</returns>
        Task DeleteReaction(string id);

        /// <summary>
        /// Get a list of all the speakers.
        /// </summary>
        /// <returns>Enumerable of speaker objects.</returns>
        Task<IEnumerable<CosmosSpeaker>> GetCosmosSpeakers();

        /// <summary>
        /// Get a specific speaker.
        /// </summary>
        /// <param name="id">identifier of the speaker</param>
        /// <returns>A speaker object.</returns>
        Task<CosmosSpeaker> GetSpeaker(string id);

        /// <summary>
        /// Update the speacker informations.
        /// </summary>
        /// <param name="speaker">the changed speaker.</param>
        /// <returns>Updated speaker object.</returns>
        Task<CosmosSpeaker> EditSpeaker(CosmosSpeaker speaker);

        /// <summary>
        /// Disable the speaker.
        /// </summary>
        /// <param name="id">identifier of the speaker to disable.</param>
        /// <returns>The result object of the update.</returns>
        Task<CosmosSpeaker> DeleteSpeaker(string id);

        /// <summary>
        /// Enable a disabled speaker.
        /// </summary>
        /// <param name="id">identifier of the speaker to enable.</param>
        /// <returns>The result of the update.</returns>
        Task<CosmosSpeaker> EnableSpeaker(string id);

        /// <summary>
        /// Create a new speaker.
        /// </summary>
        /// <param name="speaker">Speaker to insert.</param>
        /// <returns>The newly created speaker object.</returns>
        Task<CosmosSpeaker> AddSpeaker(CosmosSpeaker speaker);

        /// <summary>
        /// Get all questions.
        /// </summary>
        /// <returns>List of all questions objects</returns>
        Task<IEnumerable<CosmosQuestion>> GetCosmosQuestions();

        /// <summary>
        /// Get a specific question.
        /// </summary>
        /// <param name="id">the identifier of a question.</param>
        /// <returns>The question Object.</returns>
        Task<CosmosQuestion> GetQuestion(string id);

        /// <summary>
        /// Add an answer to the question.
        /// </summary>
        /// <param name="answerId">The id of the answer.</param>
        /// <returns>The updated question.</returns>
        Task<CosmosQuestion> AddAnswerToQuestion(string answerId);

        /// <summary>
        /// Add multiple answers to a question.
        /// </summary>
        /// <param name="answerIds">List of answers ids</param>
        /// <returns>The newly updated question.</returns>
        Task<CosmosQuestion> AddAnswersToQuestion(List<string> answerIds);

        /// <summary>
        /// Add a new tag to a question.
        /// </summary>
        /// <param name="tagId">The id of the tag.</param>
        /// <returns>The updated question.</returns>
        Task<CosmosQuestion> AddTagToQuestion(string tagId);

        /// <summary>
        /// Add multiple new tags to a question.
        /// </summary>
        /// <param name="tagIds">A list of Ids for the tags.</param>
        /// <returns>The updated question.</returns>
        Task<CosmosQuestion> AddTagsToQuestion(List<string> tagIds);

        /// <summary>
        /// Create à new answer.
        /// </summary>
        /// <param name="answer">New answer object.</param>
        /// <returns>The inserted answer object.</returns>
        Task<CosmosAnswer> CreateAnswer(CosmosAnswer answer);

        /// <summary>
        /// Update the answer informations.
        /// </summary>
        /// <param name="answer">the answer to update.</param>
        /// <returns>the updated answer.</returns>
        Task<CosmosAnswer> EditAnswer(CosmosAnswer answer);
    }
}
