using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Categories
{
    public abstract class CategoryBase : ICategory
    {
        private readonly string[] _rules;

        protected CategoryBase(string[] rules)
        {
            if (ReferenceEquals(null, rules))
                throw new ArgumentNullException("rules");

            _rules = rules;
        }

        public string SectionId { get; set; }

        public int Calculate(int[] dices)
        {
            if (ReferenceEquals(null, dices))
                throw new ArgumentNullException("dices");

            if (IsMatch(dices))
                return GetScore(dices);

            return 0;
        }

        protected abstract int GetScore(int[] dices);

        private bool IsMatch(IEnumerable<int> dices)
        {
            var sequence = dices.Aggregate(
                    new StringBuilder(),
                    (current, dice) => current.Append(dice.ToString(CultureInfo.InvariantCulture)))
                .ToString();

            return _rules.Any(r => Regex.IsMatch(sequence, r));
        }
    }
}