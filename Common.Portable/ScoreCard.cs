using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class ScoreCard
    {
        private readonly IDictionary<string, int[]> _rolls;

        public ICategoryProvider CategoryProvider { get; private set; }

        public ScoreCard(ICategoryProvider categoryProvider)
        {
            _rolls = new Dictionary<string, int[]>();
            
            CategoryProvider = categoryProvider;
        }

        public int GetTotalScore()
        {
            return GetScores()
                .Sum(x => x.Value);
        }

        public IEnumerable<Score> GetScores(string sectionId = null)
        {
            var scores = _rolls.Select(CreateScore);

            if (ReferenceEquals(null, sectionId))
                return scores;

            return scores.Where(x => sectionId.Equals(x.SectionId));
        }

        public void AddTurnRoll(string categoryId, int[] dices)
        {
            _rolls.Add(categoryId, dices);
        }

        private Score CreateScore(KeyValuePair<string, int[]> roll)
        {
            var dices = roll.Value;
            var categoryId = roll.Key;

            var category = CategoryProvider.GetCategory(categoryId);

            return new Score(category.Calculate(dices), categoryId, category.SectionId);
        }
    }
}