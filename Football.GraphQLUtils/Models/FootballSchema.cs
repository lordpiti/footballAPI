using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.GraphQL.Models
{
    public class FootballSchema : Schema
    {
        public FootballSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<FootballQuery>();
            Mutation = resolver.Resolve<FootballMutation>();
        }
    }
}
