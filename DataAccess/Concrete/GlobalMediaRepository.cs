using DataAccess.Concrete;
using Football.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Football.Crosscutting.ViewModels;
using DataAccess.Models;

namespace Football.DataAccess.Concrete
{
    public class GlobalMediaRepository : EFRepositoryBase, IGlobalMediaRepository
    {
        public GlobalMediaRepository(c__database_futbol_mdfContext context) : base(context)
        {
        }

        public async Task<List<GlobalMediaData>> GetReferencedBlobIds()
        {
            var referencedGlobalMedias = await _context.Equipo.Select(x => x.TeamPicture)
                .Union(_context.Integrante.Select(x => x.Picture))
                .Union(_context.Competicion.Select(x => x.CompetitionLogo))
                .Where(x=> x != null).ToListAsync();
            try
            {
                return referencedGlobalMedias.Select(x => new GlobalMediaData()
                {
                    FileName = x.FileName,
                    GlobalMediaId = x.GlobalMediaId,
                    BlobStorageContainer = x.BlobStorageContainer,
                    BlobStorageReference = x.BlobStorageReference
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteUnreferencedBlobs(List<int> referencedBlobIds)
        {
            var blobsToDelete = await _context.GlobalMedia
                .Where(x => !referencedBlobIds.Any(y => y == x.GlobalMediaId)).Distinct().ToListAsync();

            _context.GlobalMedia.RemoveRange(blobsToDelete);

            return await _context.SaveChangesAsync();
        }

    }
}
