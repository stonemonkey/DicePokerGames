using Caliburn.Micro;

namespace Ui.Metro.ViewModels
{
    public class DiceViewModel : PropertyChangedBase
    {
        private int _value;
        private bool _isOnHold;

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                NotifyOfPropertyChange();
            }
        }
        
        public bool IsOnHold
        {
            get
            {
                return _isOnHold;
            }
            set
            {
                _isOnHold = value;
                NotifyOfPropertyChange();
            }
        }
    }
}