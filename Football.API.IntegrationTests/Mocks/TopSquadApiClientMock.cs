using Football.API.IntegrationTests.Builders;
using Football.Services.Proxy;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.API.IntegrationTests.Mocks
{
    public class TopSquadApiClientMock : Mock<ITopSquadApiClient>
    {
        public TopSquadApiClientMock(MockBehavior behavior = MockBehavior.Default): base(behavior)
        {
        }

        public TopSquadApiClientMock GetAllTopSquads_ReturnsTopSquadList()
        {
            var topSquadClientBuilder = new TopSquadClientBuilder().WithTopSquads().Build();

            this.Setup(client =>
                       client.GetAllTopSquads())
                .Returns(Task.FromResult(topSquadClientBuilder.TopSquads));

            return this;
        }
    }
}
