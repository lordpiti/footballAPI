using DataAccess.Interface;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.GraphQL.Models
{
    public class FootballQuery : ObjectGraphType
    {
        public FootballQuery(IPlayerRepository playerRepository)
        {
            Field<PlayerType>(
                "player",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => playerRepository.GetPlayer(context.GetArgument<int>("id")));
            

            //Field<PlayerType>(
            //    "randomPlayer",
            //    resolve: context => playerRepository.GetRandom());

            Field<ListGraphType<PlayerType>>(
                "players",
                resolve: context => playerRepository.GetAllPlayers());
        }
    }
}
