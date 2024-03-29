﻿using GraphQL.Types;
using GraphQL.Utilities;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Football.GraphQL.Models
{
    public class FootballSchema : Schema
    {
        public FootballSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<FootballQuery>();
            Mutation = serviceProvider.GetRequiredService<FootballMutation>();
        }
    }
}
