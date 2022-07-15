using Eqwel.Enums;
using MvvmHelpers;

namespace Eqwel.ViewModels.Data
{
    public class ModeOptionViewModel : ObservableObject
    {
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private ModeOption _modeOption;
        public ModeOption ModeOption
        {
            get => _modeOption;
            set
            {
                _modeOption = value;
                OnPropertyChanged();
            }
        }
    }
}
