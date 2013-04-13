using System.Linq;
using Common.Categories;
using NUnit.Framework;

namespace Common.Tests.Categories
{
    [TestFixture]
    public class SumCategoryTests : CathegoryBaseTests<SumCategory>
    {
        protected override SumCategory BuildCathegory(string[] rules)
        {
            return new SumCategory(rules, 1);
        }

        [Test]
        public void Calculate_returns_sum_of_twoes_dices_when_twoes_rule_matches_dices_collection()
        {
            const int diceToCount = 2;
            // ones and twoes
            var rules = new[] { "^(?=(.*1){1,5})[1-6]{5}$", "^(?=(.*2){1,5})[1-6]{5}$" };
            var category = new SumCategory(rules, diceToCount);
            var dices = new[] { 2, 3, 4, 2, 6 };

            var result = category.Calculate(dices);

            Assert.AreEqual(dices.Where(d => d == diceToCount).Sum(), result);
        }
    }
}