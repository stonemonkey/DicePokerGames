using System;
using NUnit.Framework;

namespace Common.Tests.Categories
{
    public abstract class CathegoryBaseTests<TCathegory>
        where TCathegory : ICategory
    {
        private const string ExceptionFormat = "Value cannot be null.\r\nParameter name: {0}";
        
        protected string GetArgumentNullExceptionMessage(string paramName)
        {
            return string.Format(ExceptionFormat, paramName);
        }

        protected abstract TCathegory BuildCathegory(string[] rules);

        [Test]
        public void Ctor_throws_when_rules_collection_is_null()
        {
            Assert.Throws<ArgumentNullException>(
                () => BuildCathegory(null),
                GetArgumentNullExceptionMessage("rules"));
        }

        [Test]
        public void Calculate_throws_when_dices_collection_is_null()
        {
            var category = BuildCathegory(new[] { "^22222$" });

            Assert.Throws<ArgumentNullException>(
                () => category.Calculate(null),
                GetArgumentNullExceptionMessage("dices"));
        }

        [Test]
        public void Calculate_returns_0_when_rule_does_not_match_dices_collection()
        {
            var category = BuildCathegory(new[] { "^22222$" });

            var result = category.Calculate(new[] { 1, 1, 1, 1, 1 });

            Assert.AreEqual(0, result);
        }
    }
}