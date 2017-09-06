using Football.Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Services.Interface
{
    public interface ITeamService
    {
        Team GetTeamByIdAndYear(int id, int year);

        List<Team> GetAllTeams();

        bool UpdateTeam(Team team);
    }
}
