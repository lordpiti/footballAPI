using Football.DataAccessEFCore3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccessEFCore3.Concrete
{
    public interface IFootballUnitOfWork
    {
        ICompetitionRepository CompetitionRepository { get; }

        IGlobalMediaRepository GlobalMediaRepository { get; }

        ITeamRepository TeamRepository { get; }

        Task<int> CommitAsync();
    }
}
