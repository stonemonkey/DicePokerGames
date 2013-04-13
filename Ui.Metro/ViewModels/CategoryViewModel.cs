using Caliburn.Micro;

namespace Ui.Metro.ViewModels
{
    public class CategoryViewModel : PropertyChangedBase
    {
        private string _name;
        private int _score;

        public bool IsScratched { get; set; }

        public string Id { get; set; }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyOfPropertyChange();
            }
        }
        
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                NotifyOfPropertyChange();
            }
        }
    }
}