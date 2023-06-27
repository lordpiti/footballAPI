using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using FluentAssertions;
using Football.BlobStorage.Interfaces;
using Football.Crosscutting;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Competition;
using Football.DataAccessEFCore3.Interface;
using Football.Services.Concrete;
using Moq;

namespace Football.Services.Tests
{
    public class CompetitionServiceNewTest
    {
        private readonly IFixture fixture;
        private readonly Mock<ICompetitionRepository> _competitionRepository;
        private readonly Mock<IBlobStorageService> _blobStorageService;

        public CompetitionServiceNewTest()
        {
            this.fixture = new Fixture().Customize(new AutoMoqCustomization());
            this._competitionRepository = this.fixture.Freeze<Mock<ICompetitionRepository>>();
            this._blobStorageService = this.fixture.Freeze<Mock<IBlobStorageService>>();      
        }

        [Fact]
        public async Task GetCompetitionRoundData_DoesStuff()
        {
            // Arrange
            var scorers = fixture.Create<List<Scorer>>();
            var competitionRoundData = fixture.Create<CompetitionRoundData>();
            this._competitionRepository.Setup(m => m.GetCompetitionRoundData(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(competitionRoundData);
            this._competitionRepository.Setup(m => m.GetTopScorers(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(scorers);
            var competitionService = fixture.Create<CompetitionService>();

            var expectedPopulatedImagesInMatches = 2 * competitionRoundData.MatchList.Count;
            var expectedPopulatedImagesInTeamStatsRounds = competitionRoundData.TeamStatsRoundList.Count;

            // Act
            var obtained = await competitionService.GetCompetitionRoundData(1, "3");

            //Assert
            this._blobStorageService.Verify(mock => mock.PopulateUrlForBlob(It.IsAny<BlobData>()), Times.Exactly(expectedPopulatedImagesInMatches + expectedPopulatedImagesInTeamStatsRounds));
            competitionRoundData.MatchList.Count.Should().Be(obtained.MatchList.Count);
        }

        [Theory]
        [AutoData]
        public async Task GetCompetitionRoundData_UsingAutoData(List<Scorer> scorers, CompetitionRoundData competitionRoundData)
        {
            // https://autofixture.github.io/docs/quick-start/
            // Arrange
            this._competitionRepository.Setup(m => m.GetCompetitionRoundData(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(competitionRoundData);
            this._competitionRepository.Setup(m => m.GetTopScorers(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(scorers);
            var competitionService = fixture.Create<CompetitionService>();

            var expectedPopulatedImagesInMatches = 2 * competitionRoundData.MatchList.Count;
            var expectedPopulatedImagesInTeamStatsRounds = competitionRoundData.TeamStatsRoundList.Count;

            // Act
            var obtained = await competitionService.GetCompetitionRoundData(1, "3");

            //Assert
            this._blobStorageService.Verify(mock => mock.PopulateUrlForBlob(It.IsAny<BlobData>()), Times.Exactly(expectedPopulatedImagesInMatches + expectedPopulatedImagesInTeamStatsRounds));
            competitionRoundData.MatchList.Count.Should().Be(obtained.MatchList.Count);
        }
    }
}