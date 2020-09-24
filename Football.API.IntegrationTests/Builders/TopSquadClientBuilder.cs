using Football.Crosscutting.ViewModels.TopSquad;
using Microsoft.Extensions.Azure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.API.IntegrationTests.Builders
{
    public class TopSquadClientBuilder
    {
        private TopSquadClientBuilder _builder;

        public IEnumerable<TopSquad> TopSquads { get; set; }

        public TopSquadClientBuilder WithTopSquads()
        {
            _builder = new TopSquadClientBuilder();

            var hhehe = new List<TopSquad>();

            hhehe.Add(new TopSquad() { squad = new List<PlayerSelected>(), userId = "test1" });
            hhehe.Add(new TopSquad() { squad = new List<PlayerSelected>(), userId = "test2" });

            _builder.TopSquads = hhehe;

            return this;
        }

        public TopSquadClientBuilder Build()
        {
            return _builder;
        }
    }
}
