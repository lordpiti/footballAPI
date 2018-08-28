using Football.Crosscutting.ViewModels.Competition;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.GraphQLUtils.Models
{
    public class CompetitionType : ObjectGraphType<Competition>
    {
        public CompetitionType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Season);
            Field(x => x.Type);
        }
    }
}
