using System;
using System.Collections.Generic;
using Caliburn.Micro;
using Common;
using Ui.Metro.ViewModels;
using Ui.Metro.Views;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using Yahtzee;

namespace Ui.Metro
{
    sealed partial class App
    {
        private WinRTContainer _container;

        public App()
        {
            InitializeComponent();
        }

        protected override void Configure()
        {
            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            _container.PerRequest<ScoreCard>();
            _container.RegisterPerRequest(
                typeof(ICategoryProvider), null, typeof(HardcodedCategoryProvider));

            _container.PerRequest<GameViewModel>();
            _container.PerRequest<MainPageViewModel>();
            _container.PerRequest<YahtzeeDiceRollerViewModel>();
            _container.PerRequest<YahtzeeScoreCardViewModel>();
            _container.PerRequest<YahtzeePageViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            _container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            DisplayRootView<MainPageView>();
        }
    }
}
