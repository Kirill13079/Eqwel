using MvvmHelpers;

namespace Eqwel.ViewModels.Data
{
    public class DictoinaryViewModel : ObservableObject
    {
        private string _english;
        public string English
        {
            get => _english;
            set
            {
                _english = value;
                OnPropertyChanged();
            }
        }

        private string _russian;
        public string Russian
        {
            get => _russian;
            set
            {
                _russian = value;
                OnPropertyChanged();
            }
        }

        private bool _isUse = true;
        public bool IsUse
        {
            get => _isUse;
            set
            {
                _isUse = value;
                OnPropertyChanged();
            }
        }
    }
}
