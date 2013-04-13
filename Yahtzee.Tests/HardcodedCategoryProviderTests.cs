using System;
using System.Linq;
using Common.Categories;
using NUnit.Framework;

namespace Yahtzee.Tests
{
    [TestFixture]
    public class HardcodedCategoryProviderTests
    {
        #region Consts

        private const string CategoryOnesId = "ones";
        private const string CategoryTwoesId = "twoes";
        private const string CategoryThreesId = "threes";
        private const string CategoryFoursId = "fours";
        private const string CategoryFivesId = "fives";
        private const string CategorySixesId = "sixes";
        private const string CategoryThreeOfAKindId = "three of a kind";
        private const string CategoryFourOfAKindId = "four of a kind";
        private const string CategoryFullHouseId = "full house";
        private const string CategorySmallStraightId = "small straight";
        private const string CategoryLargeStraightId = "large straight";
        private const string CategoryYahtzeeId = "yahtzee";
        private const string CategoryChanceId = "chance";

        #endregion

        private HardcodedCategoryProvider _provider;

        [SetUp]
        public void TestInitialize()
        {
            _provider = new HardcodedCategoryProvider();
        }

        [Test]
        public void GetCategory_throws_when_category_id_is_null()
        {
            var message = Assert.Throws<ArgumentNullException>(() => 
                _provider.GetCategory(null)).Message;

            Assert.AreEqual("Value cannot be null.\r\nParameter name: categoryId", message);
        }

        [Test]
        public void GetCategory_throws_when_coud_not_find_a_category_for_specified_id()
        {
            var inexistentCategoryId = Guid.NewGuid().ToString();

            var message = Assert.Throws<ArgumentException>(() => 
                _provider.GetCategory(inexistentCategoryId)).Message;

            Assert.AreEqual(string.Format("Category with id '{0}' not found.", inexistentCategoryId), message);
        }

        [Test]
        public void GetIds_returns_13_icategories()
        {
            var ids = _provider.GetIds();

            Assert.AreEqual(13, ids.Count());
        }

        [Test]
        public void Provider_knows_ones_category()
        {
            var category = _provider.GetCategory(CategoryOnesId);

            Assert.IsInstanceOf<SumCategory>(category);
        }

        [Test]
        public void Ones_category_adds_dices_of_1()
        {
            var category = _provider.GetCategory(CategoryOnesId);

            Assert.AreEqual(2, category.Calculate(new[] { 1, 2, 1, 3, 4 }));
        }
        
        [Test]
        public void Provider_knows_twoes_category()
        {
            var category = _provider.GetCategory(CategoryTwoesId);

            Assert.IsInstanceOf<SumCategory>(category);
        }

        [Test]
        public void Twoes_category_adds_dices_of_2()
        {
            var category = _provider.GetCategory(CategoryTwoesId);

            Assert.AreEqual(4, category.Calculate(new[] { 1, 2, 1, 3, 2 }));
        }

        [Test]
        public void Provider_knows_threes_category()
        {
            var category = _provider.GetCategory(CategoryThreesId);

            Assert.IsInstanceOf<SumCategory>(category);
        }

        [Test]
        public void Threes_category_adds_dices_of_3()
        {
            var category = _provider.GetCategory(CategoryThreesId);

            Assert.AreEqual(6, category.Calculate(new[] { 3, 2, 1, 3, 2 }));
        }
        
        [Test]
        public void Provider_knows_fours_category()
        {
            var category = _provider.GetCategory(CategoryFoursId);

            Assert.IsInstanceOf<SumCategory>(category);
        }

        [Test]
        public void Fours_category_adds_dices_of_4()
        {
            var category = _provider.GetCategory(CategoryFoursId);

            Assert.AreEqual(8, category.Calculate(new[] { 4, 2, 1, 3, 4 }));
        }
        
        [Test]
        public void Provider_knows_fives_category()
        {
            var category = _provider.GetCategory(CategoryFivesId);

            Assert.IsInstanceOf<SumCategory>(category);
        }

        [Test]
        public void Fives_category_adds_dices_of_5()
        {
            var category = _provider.GetCategory(CategoryFivesId);

            Assert.AreEqual(10, category.Calculate(new[] { 4, 5, 1, 3, 5 }));
        }        

        [Test]
        public void Provider_knows_sixs_category()
        {
            var category = _provider.GetCategory(CategorySixesId);

            Assert.IsInstanceOf<SumCategory>(category);
        }

        [Test]
        public void Sixes_category_adds_dices_of_6()
        {
            var category = _provider.GetCategory(CategorySixesId);

            Assert.AreEqual(12, category.Calculate(new[] { 6, 5, 6, 3, 5 }));
        }

        [Test]
        public void Provider_knows_three_of_a_kind_category()
        {
            var category = _provider.GetCategory(CategoryThreeOfAKindId);

            Assert.IsInstanceOf<SumAllCategory>(category);
        }

        [Test]
        public void Three_of_a_kind_category_adds_all_dices()
        {
            var category = _provider.GetCategory(CategoryThreeOfAKindId);

            Assert.AreEqual(26, category.Calculate(new[] { 6, 5, 6, 3, 6 }));
        }

        [Test]
        public void Provider_knows_four_of_a_kind_category()
        {
            var category = _provider.GetCategory(CategoryFourOfAKindId);

            Assert.IsInstanceOf<SumAllCategory>(category);
        }

        [Test]
        public void Four_of_a_kind_category_adds_all_dices()
        {
            var category = _provider.GetCategory(CategoryFourOfAKindId);

            Assert.AreEqual(22, category.Calculate(new[] { 4, 4, 6, 4, 4 }));
        }

        [Test]
        public void Provider_knows_full_house_category()
        {
            var category = _provider.GetCategory(CategoryFullHouseId);

            Assert.IsInstanceOf<FixedScoreCategory>(category);
        }

        [Test]
        public void Full_house_category_returns_fixed_score()
        {
            var category = _provider.GetCategory(CategoryFullHouseId);

            Assert.AreEqual(25, category.Calculate(new[] { 3, 5, 5, 3, 5 }));
        }

        [Test]
        public void Provider_knows_small_straight_category()
        {
            var category = _provider.GetCategory(CategorySmallStraightId);

            Assert.IsInstanceOf<FixedScoreCategory>(category);
        }

        [Test]
        public void Small_straight_returns_fixed_scores()
        {
            var category = _provider.GetCategory(CategorySmallStraightId);
            
            Assert.AreEqual(30, category.Calculate(new[] { 4, 5, 5, 3, 6 }));
        }

        [Test]
        public void Provider_knows_large_straight_category()
        {
            var category = _provider.GetCategory(CategoryLargeStraightId);

            Assert.IsInstanceOf<FixedScoreCategory>(category);
        }

        [Test]
        public void Large_straight_returns_fixed_scores()
        {
            var category = _provider.GetCategory(CategoryLargeStraightId);

            Assert.AreEqual(40, category.Calculate(new[] { 4, 1, 5, 2, 3 }));
        }

        [Test]
        public void Provider_knows_yahtzee_category()
        {
            var category = _provider.GetCategory(CategoryYahtzeeId);

            Assert.IsInstanceOf<FixedScoreCategory>(category);
        }

        [Test]
        public void Yahtzee_returns_fixed_scores()
        {
            var category = _provider.GetCategory(CategoryYahtzeeId);

            Assert.AreEqual(50, category.Calculate(new[] { 4, 4, 4, 4, 4 }));
        }

        [Test]
        public void Provider_knows_chance_category()
        {
            var category = _provider.GetCategory(CategoryChanceId);

            Assert.IsInstanceOf<SumAllCategory>(category);
        }

        [Test]
        public void Chance_adds_all_dices()
        {
            var category = _provider.GetCategory(CategoryChanceId);

            Assert.AreEqual(11, category.Calculate(new[] { 2, 2, 3, 2, 2 }));
        }
    }
}