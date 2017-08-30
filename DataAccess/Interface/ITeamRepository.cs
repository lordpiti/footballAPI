using Football.Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DataAccess.Interface
{
    public interface ITeamRepository
    {
        Team GetTeamByIdAndYear(int id, int year);
    }
}
