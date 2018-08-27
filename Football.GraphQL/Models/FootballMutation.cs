using Crosscutting.ViewModels;
using DataAccess.Interface;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.GraphQL.Models
{
    public class FootballMutation : ObjectGraphType
    {
        public FootballMutation(IPlayerRepository playerRepository)
        {
            Name = "CreatePlayerMutation";

            Field<PlayerType>(
                "createPlayer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PlayerInputType>> { Name = "player" }
                ),
                resolve: context =>
                {
                    var player = context.GetArgument<Player>("player");
                    return playerRepository.UpdatePlayer(player);
                });
        }
    }
}
