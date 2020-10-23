using Football.API.IntegrationTests.Infrastructure;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Football.API.IntegrationTests.Tests
{
    public class TeamTests : TestServerBase
    {
        [Fact]
        public async Task Test1()
        {
            base.TopSquadApiClientMock.GetAllTopSquads_ReturnsTopSquadList();

            //Act 
            var response = await base.HttpClient.GetAsync("api/Team/TopSquad");

            //Assert
            Assert.True(response.IsSuccessStatusCode);

            Assert.True(true);
        }
    }
}
