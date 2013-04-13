using Caliburn.Micro;
using Windows.UI.Xaml.Controls;

namespace Ui.Metro.ViewModels
{
    public class MainPageViewModel : PageViewModelBase
    {
        public BindableCollection<GameViewModel> Games { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Games = new BindableCollection<GameViewModel>();
        }

        public void OnSampleSelected(ItemClickEventArgs eventArgs)
        {
            var sample = (GameViewModel)eventArgs.ClickedItem;

            NavigationService.NavigateToViewModel(sample.ViewModelType);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            AddGame<YahtzeePageViewModel>("Yahtzee", "A clasic 5 dice Poker game.");
        }

        private void AddGame<TGame>(string title, string subTitle)
        {
            var yahtzeeGame = new GameViewModel
            {
                Title = title,
                Subtitle = subTitle,
                ViewModelType = typeof(TGame),
            };

            Games.Add(yahtzeeGame);
        }
    }
}