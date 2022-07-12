using Eqwel.ViewModels.Data;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

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

        private bool _mode;
        public bool DictinoryMode
        {
            get => _mode;
            set
            {
                _mode = value;
                OnPropertyChanged();
            }
        }

        public MainModel()
        {
            Items = new ObservableRangeCollection<DictoinaryViewModel>();

            IsBusy = true;
            DictinoryMode = false;
        }
    }
}
