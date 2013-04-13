using Caliburn.Micro;

namespace Ui.Metro.ViewModels
{
    /// <summary>
    /// Base view model for all our main screens, the method GoBack will be bound via convention
    /// to the back button and only display when it can go back due to the template of the back 
    /// button (Collapsed when Disabled)
    /// </summary>
    public abstract class PageViewModelBase : Screen
    {
        protected INavigationService NavigationService { get; private set; }

        protected PageViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public void GoBack()
        {
            NavigationService.GoBack();
        }

        public bool CanGoBack
        {
            get
            {
                return NavigationService.CanGoBack;
            }
        }
    }
}
