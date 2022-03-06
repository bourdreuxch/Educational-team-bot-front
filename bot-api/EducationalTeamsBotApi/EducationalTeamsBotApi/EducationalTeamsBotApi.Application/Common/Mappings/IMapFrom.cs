// -----------------------------------------------------------------------
// <copyright file="IMapFrom.cs" company="DIIAGE">
// Copyright (c) DIIAGE 2022. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using AutoMapper;

namespace EducationalTeamsBotApi.Application.Common.Mappings
{
    /// <summary>
    /// Interface mapper.
    /// </summary>
    /// <typeparam name="T">Type to map.</typeparam>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// Creates a Map.
        /// </summary>
        /// <param name="profile">Profile of mapping.</param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), this.GetType());
    }
}
