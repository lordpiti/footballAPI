using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Football.Services.Concrete;
using Moq;
using Football.DataAccess.Interface;
using Football.Crosscutting.ViewModels;
using System.Collections.Generic;
using Football.Crosscutting.ViewModels.Competition;
using Football.Crosscutting;
using Football.BlobStorage.Interfaces;
using Football.Crosscutting.ViewModels.Teams;
using Crosscutting.ViewModels;
using System.Threading.Tasks;

namespace Football.Services.Test
{
    [TestClass]
    public class UnitTest1
    {
        private CompetitionRoundData _getMockCompetitionData()
        {
            var competitionRoundData = new CompetitionRoundData()
            {
                TeamStatsRoundList = new List<TeamStatsRound>()
                {
                    new TeamStatsRound()
                    {
                         TeamLogo = new BlobData()
                    },
                    new TeamStatsRound()
                    {
                         TeamLogo = new BlobData()
                    }
                },
                MatchList = new List<MatchGeneralInfo>() {
                    new MatchGeneralInfo()
                    {
                        LocalTeam = new Team()
                        {
                            PictureLogo = new BlobData()
                        },
                        VisitorTeam = new Team()
                        {
                            PictureLogo = new BlobData()
                        }
                    },
                    new MatchGeneralInfo()
                    {
                        LocalTeam = new Team()
                        {
                            PictureLogo = new BlobData()
                        },
                        VisitorTeam = new Team()
                        {
                            PictureLogo = new BlobData()
                        }
                    }
                }
            };

            return competitionRoundData;
        }

        private List<Scorer> _getMockScorers()
        {
            return new List<Scorer>()
            {
                new Scorer()
                {
                    Goals = 3,
                    Player = new Player()
                    {
                        Name = "Pedro",
                        Surname = "Suarez"
                    }
                },
                new Scorer()
                {
                    Goals = 7,
                    Player = new Player()
                    {
                        Name = "Pepito",
                        Surname = "Grillo"
                    }
                }
            };
        }

        private ICompetitionRepository _getCompetitionRepositoryMock()
        {
            // Creamos el mock sobre nuestra interfaz
            var mockRepository = new Mock<ICompetitionRepository>();

            // Definimos el comportamiento del método GetCount y su resultado
            mockRepository.Setup(m => m.GetCompetitionRoundData(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(_getMockCompetitionData());
            mockRepository.Setup(m => m.GetTopScorers(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(_getMockScorers());

            return mockRepository.Object;
        }

        [TestMethod]
        public async Task GetCompetitionRoundData_DoesStuff()
        {
            var mockRepository = _getCompetitionRepositoryMock();
            var mockBlobStorageService = new Mock<IBlobStorageService>();
            mockBlobStorageService.Setup(m => m.PopulateUrlForBlob(It.IsAny<BlobData>()));

            var competitionService = new CompetitionService(mockRepository, mockBlobStorageService.Object);

            var obtained = await competitionService.GetCompetitionRoundData(1, "3");

            //foreach(var item in obtained.MatchList)
            //{
                mockBlobStorageService.Verify(mock => mock.PopulateUrlForBlob(It.IsAny<BlobData>()), Times.Exactly(6));
            //}
                            // Creamos una instancia del objeto mockeado y la testeamos
            Assert.AreEqual(_getMockCompetitionData().MatchList.Count, obtained.MatchList.Count);
        }
    }
}
