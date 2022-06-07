using EducationalTeamsBotApi.Application.Users.Queries.GetUsersQuery;
using EducationalTeamsBotApi.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EducationalTeamsBotApi.UnitTests
{
    public abstract class TestUsers
    {
        [Fact]
        public async Task HandlerReturnsCorrectUserViewModel()
        {
            //var graphService = new GraphService();

            //var handler = new GetUsersQueryHandler(graphService);
            //var result = await handler.Handle(new UserQuery { Id = 100 });

            //Assert.NotNull(result);
            //Assert.Equal("Steve", result.Forename);
        }
    }
}
