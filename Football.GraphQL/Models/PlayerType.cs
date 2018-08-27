using Crosscutting.ViewModels;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.GraphQL.Models
{
    public class PlayerType : ObjectGraphType<Player>
    {
        public PlayerType(/*ISkaterStatisticRepository footballRepository*/)
        {
            Field(x => x.PlayerId);
            Field(x => x.Name, true);
            Field(x => x.BirthPlace);
            Field(x => x.Surname);
            Field(x => x.TeamName);
            //Field<StringGraphType>("birthDate", resolve: context => context.Source.BirthDate.ToShortDateString());
            //Field<ListGraphType<SkaterStatisticType>>("skaterSeasonStats",
            //    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            //    resolve: context => skaterStatisticRepository.Get(context.Source.Id), description: "Player's skater stats");
        }
    }
}
