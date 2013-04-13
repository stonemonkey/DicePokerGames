namespace Common.Categories
{
    public class FixedScoreCategory : CategoryBase
    {
        private readonly int _score;

        public FixedScoreCategory(string[] rules, int score) 
            : base(rules)
        {
            _score = score;
        }

        protected override int GetScore(int[] dices)
        {
            return _score;
        }
    }
}