using Football.Crosscutting;
using Football.Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Interface
{
    public interface ITeamService
    {
        Task<Team> GetTeamByIdAndYear(int id, int year);

        Task<List<Team>> GetAllTeams();

        Task<int> UpdateTeam(Team team);

        Task AddTeamPicture(int teamId, BlobData mediaItem);
    }
}
