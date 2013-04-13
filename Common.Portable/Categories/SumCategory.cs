using System.Linq;

namespace Common.Categories
{
    public class SumCategory : CategoryBase
    {
        private readonly int _diceToCount;

        public SumCategory(string[] rules, int diceToCount)
            : base(rules)
        {
            _diceToCount = diceToCount;
        }

        protected override int GetScore(int[] dices)
        {
            var dicesWithSameValue = dices.Where(d => d == _diceToCount);

            return dicesWithSameValue.Sum();
        }
    }
}