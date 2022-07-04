using Crosscutting.ViewModels;
using Football.DataAccessEFCore3.Interface;
using Football.GraphQLUtils.Models;
using GraphQL;
using GraphQL.Types;

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
                resolve: context => {
                    return playerRepository.GetMatchesPlayed(context.Source.PlayerId);
                }, description: "Player's matches played");
            FieldAsync<ListGraphType<CompetitionType>>("playerCompetitionsPlayed",
                resolve: async context => await playerRepository.GetCompetitionsByPlayer(context.Source.PlayerId), description: "Player's competitions played");
            FieldAsync<ListGraphType<MatchPlayedType>>("playerMatchesPlayedByCompetition",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "competitionId" }),
                resolve: async context =>
                {
                    var competitionId = context.GetArgument<int>("competitionId");
                    return await playerRepository.GetMatchesByCompetitionAndPlayer(competitionId, context.Source.PlayerId);
                }, description: "Player's matches played by competition");
        }
    }
}
