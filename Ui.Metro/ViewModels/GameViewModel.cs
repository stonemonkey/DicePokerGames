using System;
using Caliburn.Micro;

namespace Ui.Metro.ViewModels
{
    public class GameViewModel : PropertyChangedBase
    {
        private string _title;
        private string _subtitle;
        private Type _viewModelType;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                NotifyOfPropertyChange();
            }
        }

        public Type ViewModelType
        {
            get
            {
                return _viewModelType;
            }
            set
            {
                _viewModelType = value;
                NotifyOfPropertyChange();
            }
        }

        public string Subtitle
        {
            get
            {
                return _subtitle;
            }
            set
            {
                _subtitle = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
