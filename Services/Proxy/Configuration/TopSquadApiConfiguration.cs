using Crosscutting.ViewModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Services.Proxy.Configuration
{
    public class TopSquadApiConfiguration
    {
        public TopSquadApiConfiguration(IOptions<AppSettings> apiSettings)
        {
            this.TopSquadApiBaseUri = new Uri(apiSettings?.Value.TopSquadApiUrl);
        }

        public Uri TopSquadApiBaseUri { get; }
    }
}
