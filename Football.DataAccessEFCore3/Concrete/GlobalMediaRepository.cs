using Football.DataAccessEFCore3.Concrete;
using Football.DataAccessEFCore3.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Football.Crosscutting.ViewModels;
using Football.DataAccessEFCore3.Models;

namespace Football.DataAccessEFCore3.Concrete
{
    public class GlobalMediaRepository : EFRepositoryBase<GlobalMedia>, IGlobalMediaRepository
    {
        public GlobalMediaRepository(FootballContext context) : base(context)
        {
        }

        public async Task<List<GlobalMediaData>> GetReferencedBlobIds()
        {
            var referencedGlobalMedias = await _context.Equipo.Select(x => x.TeamPictureGlobalMedia)
                .Union(_context.Integrante.Select(x => x.PictureGlobalMedia))
                .Union(_context.Competicion.Select(x => x.CompetitionLogoGlobalMedia))
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
                .Where(x => !referencedBlobIds.Any(y => y == x.GlobalMediaId)).ToListAsync();

            _context.GlobalMedia.RemoveRange(blobsToDelete);

            return await _context.SaveChangesAsync();
        }

    }
}
