using Crosscutting.ViewModels;
using DataAccess.Interface;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.GraphQL.Models
{
    public class PlayerType : ObjectGraphType<Player>
    {
        public PlayerType(IPlayerRepository playerRepository)
        {
            Field(x => x.PlayerId);
            Field(x => x.Name, true);
            Field(x => x.BirthPlace);
            Field(x => x.Surname);
            Field(x => x.TeamName);
            //Field<StringGraphType>("birthDate", resolve: context => context.Source.BirthDate.ToShortDateString());
            Field<ListGraphType<MatchPlayedType>>("playerMatchesPlayed",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => playerRepository.GetMatchesPlayed(context.Source.PlayerId), description: "Player's matches played");
        }
    }
}
