using System.Linq;
using Common.Categories;
using NUnit.Framework;

namespace Common.Tests.Categories
{
    [TestFixture]
    public class SumAllCategoryTests : CathegoryBaseTests<SumAllCategory>
    {
        protected override SumAllCategory BuildCathegory(string[] rules)
        {
            return new SumAllCategory(rules);
        }

        [Test]
        public void Calculate_returns_sum_of_all_dices_when_one_from_two_rules_matches_dices_collection()
        {
            // ones and twoes
            var rules = new[] { "^(?=(.*1){1,5})[1-6]{5}$", "^(?=(.*2){1,5})[1-6]{5}$" };
            var category = new SumAllCategory(rules);
            var dices = new[] { 2, 3, 4, 2, 6 };

            var result = category.Calculate(dices);

            Assert.AreEqual(dices.Sum(), result);
        }
    }
}