using NUnit.Framework;

namespace Common.Tests
{
    [TestFixture]
    public class ScoreTests
    {
        [Test]
        public void Ctor_initializes_Value_field()
        {
            const int scoreValue = 78;

            var score = new Score(scoreValue, null, null);

            Assert.AreEqual(scoreValue, score.Value);
        }

        [Test]
        public void Ctor_initializes_CategoryId_field()
        {
            const string categoryId = "ones";

            var score = new Score(0, categoryId, null);

            Assert.AreEqual(categoryId, score.CategoryId);
        }

        [Test]
        public void Ctor_initializes_SectionId_field()
        {
            const string sectionId = "lower";

            var score = new Score(0, null, sectionId);

            Assert.AreEqual(sectionId, score.SectionId);
        }
    }
}