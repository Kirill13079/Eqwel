using Eqwel.Enums;
using Eqwel.ViewModels.Data;
using MvvmHelpers;

namespace Eqwel.Models
{
    public class MainModel : BaseViewModel
    {
        private ObservableRangeCollection<DictoinaryViewModel> _items;
        public ObservableRangeCollection<DictoinaryViewModel> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        private ModeOption _dictinoryMode;
        public ModeOption DictinoryMode
        {
            get => _dictinoryMode;
            set 
            {
                _dictinoryMode = value;
                OnPropertyChanged();
            }
        }

        public MainModel()
        {
            Items = new ObservableRangeCollection<DictoinaryViewModel>();

            IsBusy = true;
        }
    }
}
