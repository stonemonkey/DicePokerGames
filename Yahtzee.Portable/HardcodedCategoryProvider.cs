using System;
using System.Collections.Generic;
using Common;
using Common.Categories;

namespace Yahtzee
{
    public class HardcodedCategoryProvider : ICategoryProvider
    {
        private const string UpperSectionId = "upper";
        private const string LowerSectionId = "lower";

        #region _cathegories

        private readonly Dictionary<string, ICategory> _cathegories = new Dictionary<string, ICategory>
        {
            {"ones", new SumCategory(new[] { "^(?=(.*1){1,5})[1-6]{5}$" }, 1) {SectionId = UpperSectionId}},
            {"twoes", new SumCategory(new[] { "^(?=(.*2){1,5})[1-6]{5}$" }, 2) {SectionId = UpperSectionId}},
            {"threes", new SumCategory(new[] { "^(?=(.*3){1,5})[1-6]{5}$" }, 3) {SectionId = UpperSectionId}},
            {"fours", new SumCategory(new[] { "^(?=(.*4){1,5})[1-6]{5}$" }, 4) {SectionId = UpperSectionId}},
            {"fives", new SumCategory(new[] { "^(?=(.*5){1,5})[1-6]{5}$" }, 5) {SectionId = UpperSectionId}},
            {"sixes", new SumCategory(new[] { "^(?=(.*6){1,5})[1-6]{5}$" }, 6) {SectionId = UpperSectionId}},

            {"three of a kind", new SumAllCategory(new[]
                {
                    "^(?=(.*1){3})[1-6]{5}$", "^(?=(.*2){3})[1-6]{5}$", "^(?=(.*3){3})[1-6]{5}$", 
                    "^(?=(.*4){3})[1-6]{5}$", "^(?=(.*5){3})[1-6]{5}$", "^(?=(.*6){3})[1-6]{5}$"
                }) {SectionId = LowerSectionId}},
            {"four of a kind", new SumAllCategory(new[]
                {
                    "^(?=(.*1){4})[1-6]{5}$", "^(?=(.*2){4})[1-6]{5}$", "^(?=(.*3){4})[1-6]{5}$", 
                    "^(?=(.*4){4})[1-6]{5}$", "^(?=(.*5){4})[1-6]{5}$", "^(?=(.*6){4})[1-6]{5}$"
                }) {SectionId = LowerSectionId}},
            {"full house", new FixedScoreCategory(new[]
                {
	                "^(?=(.*1){2})(?=(.*2){3})[1,2]{5}$", "^(?=(.*1){2})(?=(.*3){3})[1,3]{5}$", 
                    "^(?=(.*1){2})(?=(.*4){3})[1,4]{5}$", "^(?=(.*1){2})(?=(.*5){3})[1,5]{5}$", 
                    "^(?=(.*1){2})(?=(.*6){3})[1,6]{5}$",
	                "^(?=(.*2){2})(?=(.*1){3})[1,2]{5}$", "^(?=(.*2){2})(?=(.*3){3})[2,3]{5}$", 
                    "^(?=(.*2){2})(?=(.*4){3})[2,4]{5}$", "^(?=(.*2){2})(?=(.*5){3})[2,5]{5}$", 
                    "^(?=(.*2){2})(?=(.*6){3})[2,6]{5}$",
	                "^(?=(.*3){2})(?=(.*1){3})[1,3]{5}$", "^(?=(.*3){2})(?=(.*2){3})[2,3]{5}$", 
                    "^(?=(.*3){2})(?=(.*4){3})[3,4]{5}$", "^(?=(.*3){2})(?=(.*5){3})[3,5]{5}$", 
                    "^(?=(.*3){2})(?=(.*6){3})[3,6]{5}$",
	                "^(?=(.*4){2})(?=(.*1){3})[1,4]{5}$", "^(?=(.*4){2})(?=(.*2){3})[2,4]{5}$", 
                    "^(?=(.*4){2})(?=(.*3){3})[3,4]{5}$", "^(?=(.*4){2})(?=(.*5){3})[4,5]{5}$", 
                    "^(?=(.*4){2})(?=(.*6){3})[4,6]{5}$",
	                "^(?=(.*5){2})(?=(.*1){3})[1,5]{5}$", "^(?=(.*5){2})(?=(.*2){3})[2,5]{5}$", 
                    "^(?=(.*5){2})(?=(.*3){3})[3,5]{5}$", "^(?=(.*5){2})(?=(.*4){3})[4,5]{5}$", 
                    "^(?=(.*5){2})(?=(.*6){3})[5,6]{5}$",
	                "^(?=(.*6){2})(?=(.*1){3})[1,6]{5}$", "^(?=(.*6){2})(?=(.*2){3})[2,6]{5}$", 
                    "^(?=(.*6){2})(?=(.*3){3})[3,6]{5}$", "^(?=(.*6){2})(?=(.*4){3})[4,6]{5}$", 
                    "^(?=(.*6){2})(?=(.*5){3})[5,6]{5}$"
                }, 25) {SectionId = LowerSectionId}},
            {"small straight", new FixedScoreCategory(new[]
                {
	                "^(?=(.*1){1})(?=(.*2){1})(?=(.*3){1})(?=(.*4){1})[1-6]{5}$", 
	                "^(?=(.*2){1})(?=(.*3){1})(?=(.*4){1})(?=(.*5){1})[1-6]{5}$", 
	                "^(?=(.*3){1})(?=(.*4){1})(?=(.*5){1})(?=(.*6){1})[1-6]{5}$"
                }, 30) {SectionId = LowerSectionId}},
            {"large straight", new FixedScoreCategory(new[]
                {
                    "^(?=(.*1){1})(?=(.*2){1})(?=(.*3){1})(?=(.*4){1})(?=(.*5){1})[1-6]{5}$", 
                    "^(?=(.*2){1})(?=(.*3){1})(?=(.*4){1})(?=(.*5){1})(?=(.*6){1})[1-6]{5}$"
                }, 40) {SectionId = LowerSectionId}},
            {"yahtzee", new FixedScoreCategory(new[]
                {
                    "^11111$", "^22222$", "^33333$", "^44444$", "^55555$", "^66666$"
                }, 50) {SectionId = LowerSectionId}},
            {"chance", new SumAllCategory(new[] {"^[1-6]{5}$"}) {SectionId = LowerSectionId}},
        };

        #endregion

        public IEnumerable<string> GetIds()
        {
            return _cathegories.Keys;
        }

        public ICategory GetCategory(string categoryId)
        {
            if (ReferenceEquals(null, categoryId))
                throw new ArgumentNullException("categoryId");

            ICategory category;
            if(!_cathegories.TryGetValue(categoryId, out category))
                throw new ArgumentException(
                    string.Format("Category with id '{0}' not found.", categoryId));

            return category;
        }
    }
}