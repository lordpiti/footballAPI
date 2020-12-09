using Crosscutting.ViewModels;
using Football.DataAccessEFCore3.Interface;
using Football.GraphQLUtils.Models;
using GraphQL;
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
            Field<ListGraphType<CompetitionType>>("playerCompetitionsPlayed",
                resolve: context => playerRepository.GetCompetitionsByPlayer(context.Source.PlayerId), description: "Player's competitions played");
            Field<ListGraphType<MatchPlayedType>>("playerMatchesPlayedByCompetition",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "competitionId" }),
                resolve: context =>
                {
                    var competitionId = context.GetArgument<int>("competitionId");
                    return playerRepository.GetMatchesByCompetitionAndPlayer(competitionId, context.Source.PlayerId);
                }, description: "Player's matches played by competition");
        }
    }
}
