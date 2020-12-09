using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Competition;
using Football.DataAccessEFCore3.Interface;
using Football.GraphQLUtils.Models;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.GraphQL.Models
{
    public class FootballMutation : ObjectGraphType
    {
        public FootballMutation(IPlayerRepository playerRepository, ICompetitionRepository competitionRepository)
        {
            Name = "CreatePlayerMutation";

            //Field<IntGraphType>(
            //    "updatePlayer",
            //    arguments: new QueryArguments(
            //        new QueryArgument<NonNullGraphType<PlayerInputType>> { Name = "player" }
            //    ),
            //    resolve: context =>
            //    {
            //        var player = context.GetArgument<Player>("player");
            //        return playerRepository.UpdatePlayer(player);
            //    });

            Field<IntGraphType>(
                "updateCompetition",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CompetitionInputType>> { Name = "competition" }
                    ),
                resolve: context =>
                {
                    var competition = context.GetArgument<Competition>("competition");
                    return competitionRepository.SaveCompetitionDetails(competition);
                });
        }
    }
}
