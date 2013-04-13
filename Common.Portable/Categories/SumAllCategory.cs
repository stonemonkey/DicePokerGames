using System.Linq;

namespace Common.Categories
{
    public class SumAllCategory : CategoryBase
    {
        public SumAllCategory(string[] rules)
            : base(rules)
        {
        }

        protected override int GetScore(int[] dices)
        {
            return dices.Sum();
        }
    }
}