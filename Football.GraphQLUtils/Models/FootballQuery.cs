using Football.DataAccessEFCore3.Interface;
using GraphQL;
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
            FieldAsync<PlayerType>(
                "player",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context => { 
                    return await playerRepository.GetPlayer(context.GetArgument<int>("id")); 
                });

            FieldAsync<ListGraphType<PlayerType>>(
                "players",
                resolve: async context => await playerRepository.GetAllPlayers());
        }
    }
}
