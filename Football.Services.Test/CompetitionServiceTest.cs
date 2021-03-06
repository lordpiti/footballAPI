using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Football.Services.Concrete;
using Moq;
using Football.DataAccessEFCore3.Interface;
using Football.Crosscutting.ViewModels;
using System.Collections.Generic;
using Football.Crosscutting.ViewModels.Competition;
using Football.Crosscutting;
using Football.BlobStorage.Interfaces;
using Football.Crosscutting.ViewModels.Teams;
using Crosscutting.ViewModels;
using System.Threading.Tasks;
using Football.Services.Interface;

namespace Football.Services.Test
{
    [TestClass]
    public class CompetitionServiceTest
    {
        private ICompetitionRepository _competitionMockRepository;
        private Mock<IBlobStorageService> _mockBlobStorageService;
        private ICompetitionService _competitionService;

        [TestInitialize]
        public void TestInitialize()
        {
            _competitionMockRepository = _getCompetitionRepositoryMock();
            _mockBlobStorageService = new Mock<IBlobStorageService>();
            _mockBlobStorageService.Setup(m => m.PopulateUrlForBlob(It.IsAny<BlobData>()));
            _competitionService = new CompetitionService(_competitionMockRepository, _mockBlobStorageService.Object);
        }

        [TestCleanup()]
        public void Cleanup()
        {

        }

        #region private methods for mocks

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

            // Definimos el comportamiento del m�todo GetCount y su resultado
            mockRepository.Setup(m => m.GetCompetitionRoundData(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(_getMockCompetitionData());
            mockRepository.Setup(m => m.GetTopScorers(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(_getMockScorers());

            return mockRepository.Object;
        }

        #endregion

        [TestMethod]
        public async Task GetCompetitionRoundData_DoesStuff()
        {
            var obtained = await _competitionService.GetCompetitionRoundData(1, "3");

            //foreach(var item in obtained.MatchList)
            //{
            _mockBlobStorageService.Verify(mock => mock.PopulateUrlForBlob(It.IsAny<BlobData>()), Times.Exactly(6));
            //}
            // Creamos una instancia del objeto mockeado y la testeamos
            Assert.AreEqual(_getMockCompetitionData().MatchList.Count, obtained.MatchList.Count);
        }
    }
}
