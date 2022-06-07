// -----------------------------------------------------------------------
// <copyright file="ApiBaseController.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using EducationalTeamsBotApi.Application.Common.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace EducationalTeamsBotApi.WebApi.Controllers
{
    /// <summary>
    /// Abstract class controller to define <see cref="ISender"/>.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        private ISender mediator;

        /// <summary>
        /// Gets the <see cref="ISender"/>.
        /// </summary>
        protected ISender Mediator => this.mediator ??= this.HttpContext.RequestServices.GetService<ISender>();
    }
}
