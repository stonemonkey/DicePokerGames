using Common.Categories;
using NUnit.Framework;

namespace Common.Tests.Categories
{
    [TestFixture]
    public class FixedScoreCategoryTests : CathegoryBaseTests<FixedScoreCategory>
    {
        protected override FixedScoreCategory BuildCathegory(string[] rules)
        {
            return new FixedScoreCategory(rules, 50);
        }

        [Test]
        public void Calculate_returns_score_when_one_rule_from_two_matches_dice_collection()
        {
            var rules = new[] { "^11111$", "^22222$" };
            const int score = 35;
            var category = new FixedScoreCategory(rules, score);

            var result = category.Calculate(new[] { 1, 1, 1, 1, 1 });

            Assert.AreEqual(score, result);
        }
    }
}