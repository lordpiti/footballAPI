using Football.Crosscutting.ViewModels;
using Football.DataAccessEFCore3.Concrete;
using Football.DataAccessEFCore3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccessEFCore3.Interface
{
    public interface IGlobalMediaRepository : IRepositoryBase<GlobalMedia>
    {
        Task<List<GlobalMediaData>> GetReferencedBlobIds();

        Task<int> DeleteUnreferencedBlobs(List<int> referencedBlobIds);
    }
}
