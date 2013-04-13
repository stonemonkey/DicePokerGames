using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Common;

namespace Ui.Metro.ViewModels
{
    public class YahtzeeScoreCardViewModel : Screen
    {
        private CategoryViewModel _selectedCathegory;

        public ScoreCard ScoreCardEngine { get; private set; }
        
        public BindableCollection<CategoryViewModel> Categories { get; private set; }

        public CategoryViewModel SelectedCategory
        {
            get
            {
                return _selectedCathegory;
            }

            set
            {
                _selectedCathegory = value;
                NotifyOfPropertyChange(() => SelectedCategory);
            }
        }

        public int TotalScore { get { return ScoreCardEngine.GetTotalScore(); } }

        public YahtzeeScoreCardViewModel(ScoreCard scoreCard)
        {
            ScoreCardEngine = scoreCard;

            var categories = GetCategories();
            Categories = new BindableCollection<CategoryViewModel>(categories);
        }

        public void AddTurnRoll(string cathegoryId, int [] dices)
        {
            ScoreCardEngine.AddTurnRoll(cathegoryId, dices);
            
            foreach (var score in ScoreCardEngine.GetScores())
                SetCategoryScore(score);
            
            RefreshScoreBindings();
        }

        #region Private methods

        private void RefreshScoreBindings()
        {
            NotifyOfPropertyChange(() => Categories);
            NotifyOfPropertyChange(() => TotalScore);
        }

        private void SetCategoryScore(Score score)
        {
            var cathegory = Categories.Single(x => x.Id == score.CategoryId);
            cathegory.Score = score.Value;
            cathegory.IsScratched = true;
        }

        private IEnumerable<CategoryViewModel> GetCategories()
        {
            var cathegoryIds = ScoreCardEngine.CategoryProvider.GetIds();

            return cathegoryIds.Select(id =>
                new CategoryViewModel
                {
                    Id = id,
                    Name = id,
                    IsScratched = false,
                });
        }

        #endregion
    }
}