using Crosscutting.ViewModels;
using Football.DataAccessEFCore3.Concrete;
using Football.DataAccessEFCore3.Models;
using Football.Crosscutting;
using Football.Crosscutting.ViewModels.Reports;
using Football.DataAccessEFCore3.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccessEFCore3.Concrete
{
    public class ReportRepository : EFRepositoryBase<Jugador>, IReportRepository
    {
        public ReportRepository(FootballContext context) : base(context)
        {
        }
        private async Task<List<SubstitutionReportItem>> GetSubstitutionReportItems(int matchId)
        {
            var substitutions = await _context.Cambio
                .Include(x => x.CodJugadorEntraNavigation).ThenInclude(x => x.CodIntegranteNavigation)
                .Include(x => x.CodJugadorSaleNavigation).ThenInclude(x => x.CodIntegranteNavigation)
                .Where(x => x.CodPartido == matchId)
                .Select(x => new SubstitutionReportItem()
                {
                    MatchId = matchId,
                    Minute = x.Minuto,
                    PlayerIn = new Player() {
                        Name = x.CodJugadorEntraNavigation.CodIntegranteNavigation.Nombre,
                        Surname = x.CodJugadorEntraNavigation.CodIntegranteNavigation.Apellidos,
                        Picture = x.CodJugadorEntraNavigation.CodIntegranteNavigation.PictureGlobalMedia != null ? new BlobData()
                        {
                            FileName = x.CodJugadorEntraNavigation.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageReference,
                            Id = x.CodJugadorEntraNavigation.CodIntegranteNavigation.PictureGlobalMedia.GlobalMediaId,
                            ContainerReference = x.CodJugadorEntraNavigation.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageContainer
                        } : new BlobData()
                    },
                    PlayerOut = new Player()
                    {
                        Name = x.CodJugadorSaleNavigation.CodIntegranteNavigation.Nombre,
                        Surname = x.CodJugadorSaleNavigation.CodIntegranteNavigation.Apellidos,
                        Picture = x.CodJugadorSaleNavigation.CodIntegranteNavigation.PictureGlobalMedia != null ? new BlobData()
                        {
                            FileName = x.CodJugadorSaleNavigation.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageReference,
                            Id = x.CodJugadorSaleNavigation.CodIntegranteNavigation.PictureGlobalMedia.GlobalMediaId,
                            ContainerReference = x.CodJugadorSaleNavigation.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageContainer
                        } : new BlobData()
                    }
                }).ToListAsync();

            return substitutions;
        }

        private async Task<List<GoalReportItem>> GetGoalReportItems(int matchId)
        {
            var goals = await _context.Gol.Where(x => x.CodPartido == matchId)
                .Include(x => x.CodJugadorNavigation).ThenInclude(x => x.CodIntegranteNavigation)
                .Select(x => new GoalReportItem()
                {
                    MatchId = matchId, Scorer = new Player()
                    {
                        Name = x.CodJugadorNavigation.CodIntegranteNavigation.Nombre,
                        Surname = x.CodJugadorNavigation.CodIntegranteNavigation.Apellidos
                    },
                    Minute = x.Minuto,
                    VideoUrl = x.Video
                }).ToListAsync();

            return goals;
        }

        private async Task<List<YellowRedCardReportItem>> GetReportYellowRedCardItems(int matchId)
        {
            var cards = await _context.Tarjeta.Where(x => x.CodPartido == matchId)
                .Include(x => x.CodJugadorNavigation).ThenInclude(x => x.CodIntegranteNavigation)
                .Select(x => new YellowRedCardReportItem()
                {
                    ItemType = x.Tipo == "Amarilla" ? Crosscutting.Enums.MatchEventTypeEnum.YellowCard : Crosscutting.Enums.MatchEventTypeEnum.RedCard,
                    Minute = x.Minuto,
                    Reason = x.Motivo,
                    MatchId = matchId,
                    Player = new Player() {
                        Name = x.CodJugadorNavigation.CodIntegranteNavigation.Nombre,
                        Surname = x.CodJugadorNavigation.CodIntegranteNavigation.Apellidos,
                        Picture = x.CodJugadorNavigation.CodIntegranteNavigation.PictureGlobalMedia != null ? new BlobData()
                        {
                            FileName = x.CodJugadorNavigation.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageReference,
                            Id = x.CodJugadorNavigation.CodIntegranteNavigation.PictureGlobalMedia.GlobalMediaId,
                            ContainerReference = x.CodJugadorNavigation.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageContainer
                        } : new BlobData()
                    }
                }).ToListAsync();
            return cards;
        }

        public async Task<List<BaseItem>> GetMatchReportData(int matchId)
        {
            var goals = await GetGoalReportItems(matchId);
            var cards = await GetReportYellowRedCardItems(matchId);
            var substitutions = await GetSubstitutionReportItems(matchId);

            var list = new List<BaseItem>();

            list.AddRange(goals);
            list.AddRange(cards);
            list.AddRange(substitutions);

            return list.OrderBy(x=>x.Minute).ToList();
        }
    }
}
