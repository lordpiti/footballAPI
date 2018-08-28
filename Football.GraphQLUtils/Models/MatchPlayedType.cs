using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Match;
using Football.GraphQLUtils.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.GraphQL.Models
{
    public class MatchPlayedType : ObjectGraphType<MatchPlayedInfo>
    {
        public MatchPlayedType()
        {
            Field(x => x.Id);
            Field(x => x.LocalTeamName);
            Field(x => x.VisitorTeamName);
            Field(x => x.LocalGoals);
            Field(x => x.VisitorGoals);
            
            Field<DateTimeGraphType>("date",
                resolve: context => (DateTime)context.Source.Date);

            // USEFUL FOR COMPLEX FIELDS
            //Field(x => x.Id, type: typeof(IntGraphType))
            //  .Name("matchIdComplex")
            //  .Resolve(context => context.Source.Id);
            //Field<StringGraphType>("matchIdComplexAndString",
            //    resolve: context => context.Source.Id.ToString());

            Field<CompetitionType>("competition",
                resolve: context => context.Source.Competition, description: "Match competition");
        }
    }
}
