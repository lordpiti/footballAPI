using Football.Crosscutting;
using Football.Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DataAccess.Interface
{
    public interface ITeamRepository
    {
        Team GetTeamByIdAndYear(int id, int year);

        List<Team> GetAllTeams();

        bool UpdateTeam(Team team);

        void AddTeamPicture(int teamId, BlobData mediaItem);
    }
}
