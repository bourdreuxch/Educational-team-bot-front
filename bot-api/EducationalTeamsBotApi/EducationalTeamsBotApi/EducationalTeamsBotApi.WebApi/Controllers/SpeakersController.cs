// -----------------------------------------------------------------------
// <copyright file="SpeakersController.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EducationalTeamsBotApi.WebApi.Controllers
{
    using EducationalTeamsBotApi.Application.Speakers.Queries.GetSpeakersQuery;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    /// <summary>
    /// Controller allowing to interact with speakers.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ApiBaseController
    {
        /// <summary>
        /// Gets the list of all speakers.
        /// </summary>
        /// <returns>A list of speakers.</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpeakers()
        {
            try
            {
                var speakers = await this.Mediator.Send(new GetSpeakerQuery());
                return this.Ok(speakers);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
