using System.Linq;
using Moq;
using NUnit.Framework;

namespace Common.Tests
{
    [TestFixture]
    public class ScoreCardTests
    {
        #region Private fields

        private const string CategoryOnesId = "ones";
        private const string CategoryTwoesId = "twoes";

        private readonly int[] _someTestDices = new[] {1, 2, 3, 4, 5, 6};

        private ScoreCard _scoreCard;
        private Mock<ICategoryProvider> _mockCategoryProvider;

        #endregion

        [SetUp]
        public void TestInitialize()
        {
            _mockCategoryProvider = new Mock<ICategoryProvider>();
            _scoreCard = new ScoreCard(_mockCategoryProvider.Object);
        }

        public void Ctor_sets_CategoryProvider()
        {
            Assert.AreSame(_mockCategoryProvider.Object, _scoreCard.CategoryProvider);
        }

        #region GetTotalScore tests

        [Test]
        public void GetTotalScore_returns_0_for_0_turn_rolls()
        {
            var score = _scoreCard.GetTotalScore();

            Assert.AreEqual(0, score);
        }

        [Test]
        public void GetTotalScore_returns_1_category_score_for_1_turn_roll()
        {
            const int expectedScore = 9;
            SetupRollCalculationFor(expectedScore, CategoryOnesId);

            var score = _scoreCard.GetTotalScore();

            Assert.AreEqual(expectedScore, score);
        }

        [Test]
        public void GetTotalScore_returns_sum_of_category_scores_for_2_turn_rolls()
        {
            const int expectedScoreOnes = 9;
            SetupRollCalculationFor(expectedScoreOnes, CategoryOnesId);
            const int expectedScoreTwoes = 2;
            SetupRollCalculationFor(expectedScoreTwoes, CategoryTwoesId);

            var score = _scoreCard.GetTotalScore();

            Assert.AreEqual(expectedScoreOnes + expectedScoreTwoes, score);
        }

        #endregion

        #region GetScores

        [Test]
        public void GetScores_returns_empty_list_for_0_rolls()
        {
            var scores = _scoreCard.GetScores();

            CollectionAssert.IsEmpty(scores);
        }

        [Test]
        public void GetScores_returns_1_score_for_1_added_turn_rolle()
        {
            const int expectedScore = 12;
            SetupRollCalculationFor(expectedScore, CategoryOnesId);

            var scores = _scoreCard.GetScores();

            Assert.AreEqual(1, scores.Count());
        }

        [Test]
        public void GetScores_returns_2_scores_for_2_added_turn_rolls()
        {
            const int expectedScoreOnes = 12;
            SetupRollCalculationFor(expectedScoreOnes, CategoryOnesId);
            const int expectedScoreTwoes = 3;
            SetupRollCalculationFor(expectedScoreTwoes, CategoryTwoesId);

            var scores = _scoreCard.GetScores();

            Assert.AreEqual(2, scores.Count());
        }
        
        [Test]
        public void GetScores_returns_scores_filtred_by_section()
        {
            const int expectedScoreOnes = 12;
            SetupRollCalculationFor(expectedScoreOnes, CategoryOnesId);
            const string sectionId = "lower";
            const int expectedScoreTwoes = 3;
            SetupRollCalculationFor(expectedScoreTwoes, CategoryTwoesId, sectionId);

            var scores = _scoreCard.GetScores(sectionId);

            Assert.AreEqual(1, scores.Count());
        }

        #endregion

        private void SetupRollCalculationFor(
            int expectedScore, string categoryId, string sectionId = null)
        {
            var mockCategory = new Mock<ICategory>();
            
            mockCategory.Setup(x => x.Calculate(_someTestDices))
                .Returns(expectedScore);
            
            mockCategory.Setup(x => x.SectionId)
                .Returns(sectionId);

            _mockCategoryProvider.Setup(x => x.GetCategory(categoryId))
                .Returns(mockCategory.Object);
            
            _scoreCard.AddTurnRoll(categoryId, _someTestDices);
        }
    }
}
