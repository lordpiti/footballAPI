﻿using Football.Crosscutting;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccess.Interface
{
    public interface ITeamRepository
    {
        Task<Team> GetTeamByIdAndYear(int id, int year);

        Task<List<Team>> GetAllTeams(int? competitionId = null);

        Task<int> UpdateTeam(Team team);

        Task AddTeamPicture(int teamId, BlobData mediaItem);

        Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId,
            string competitionName, string season);

        Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId,
            int competitionId);

    }
}
