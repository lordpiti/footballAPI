using Football.Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccess.Interface
{
    public interface IGlobalMediaRepository
    {
        Task<List<GlobalMediaData>> GetReferencedBlobIds();

        Task<int> DeleteUnreferencedBlobs(List<int> referencedBlobIds);
    }
}
