﻿using Football.Crosscutting;
using Football.Crosscutting.ViewModels;
using Football.DataAccess.Interface;
using Football.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<Team> GetTeamByIdAndYear(int id, int year)
        {
            return await _teamRepository.GetTeamByIdAndYear(id, year);
        }

        public async Task<List<Team>> GetAllTeams()
        {
            return await _teamRepository.GetAllTeams();
        }

        public async Task AddTeamPicture(int teamId, BlobData mediaItem)
        {
            await _teamRepository.AddTeamPicture(teamId, mediaItem);
        }

        public async Task<int> UpdateTeam(Team team)
        {
            return await _teamRepository.UpdateTeam(team);
        }
    }
}
