using Football.Crosscutting.ViewModels;
using Football.DataAccess.Interface;
using Football.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Services.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Team GetTeamByIdAndYear(int id, int year)
        {
            return _teamRepository.GetTeamByIdAndYear(id, year);
        }

        public List<Team> GetAllTeams()
        {
            return _teamRepository.GetAllTeams();
        }
    }
}
