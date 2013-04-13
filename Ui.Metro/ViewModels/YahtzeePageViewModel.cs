using System.Linq;
using Caliburn.Micro;

namespace Ui.Metro.ViewModels
{
    public class YahtzeePageViewModel : PageViewModelBase
    {
        public YahtzeeScoreCardViewModel ScoreCard { get; private set; }

        public YahtzeeDiceRollerViewModel DiceRoller { get; private set; }

        public bool CanSaveScore
        {
            get
            {
                var cathegory = ScoreCard.SelectedCategory;
                
                return (cathegory != null) &&
                       !cathegory.IsScratched;
            }
        }

        public YahtzeePageViewModel(
                INavigationService navigationService,
                YahtzeeScoreCardViewModel scoreCardViewModel,
                YahtzeeDiceRollerViewModel diceRollerViewModel)
            : base(navigationService)
        {
            ScoreCard = scoreCardViewModel;
            DiceRoller = diceRollerViewModel;
        }

        public void OnCathegorySelected()
        {
            NotifyOfPropertyChange(() => CanSaveScore);
        }

        public void SaveScore()
        {
            var dices = DiceRoller.Dices.Select(x => x.Value);
            ScoreCard.AddTurnRoll(ScoreCard.SelectedCategory.Id, dices.ToArray());

            DiceRoller.ResetRollCount();

            NotifyOfPropertyChange(() => CanSaveScore);
        }
    }
}