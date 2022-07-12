using Eqwel.AppSettings;
using Eqwel.Models;
using Eqwel.Service;
using Eqwel.ViewModels.Data;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eqwel.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ApiManagerService _apiManagerService = new ApiManagerService();

        private MainModel _model = new MainModel();
        public MainModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        private DictoinaryViewModel _currentItem = new DictoinaryViewModel();
        public DictoinaryViewModel CurrentItem
        {
            get => _currentItem;
            set
            {
                _currentItem = value;
                OnPropertyChanged();
            }
        }

        private string _str = string.Empty;
        public string Str
        {
            get => _str;
            set
            {
                _str = value;
                OnPropertyChanged();
            }
        }

        private int _correctly = 0;
        public int Correctly
        {
            get => _correctly;
            set
            {
                _correctly = value;
                OnPropertyChanged();
            }
        }

        private int _currentIndex = 0;
        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                if (value < Model.Items.Count)
                {
                    _currentIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _wrong = 0;
        public int Wrong
        {
            get => _wrong;
            set
            {
                _wrong = value;
                OnPropertyChanged();
            }
        }

        public ICommand AcceptCommand { get; set; }

        public MainViewModel()
        {
            AcceptCommand = new Command((obj) => AcceptCommandHandler(obj));

               _ = GetDataAsync().ConfigureAwait(false);
        }

        public async Task GetDataAsync()
        {
            Correctly = 0;
            Wrong = 0;

            Model.DictinoryMode = Setting.GetSetting(Setting.AppPrefrences.Mode) != "english";

            if (Model.Items.Any())
            {
                Model.Items.Clear();
            }

            var dictionary = await _apiManagerService.GetDictionaryAsync();

            if (dictionary != null)
            {
                Model.Items.AddRange(dictionary.OrderBy(a => Guid.NewGuid()));

                CurrentItem = Model.Items[0];
            }
        }

        private void AcceptCommandHandler(object value)
        {
            if (value != null)
            {
                if (!Model.DictinoryMode)
                {
                    var item = Model.Items.Where(x => x.Russian.Contains((string)value) && x.IsUse).FirstOrDefault();

                    if (item != null)
                    {
                        item.IsUse = false;

                        Correctly++;
                        CurrentIndex++;
                    }
                    else 
                    {
                        CurrentIndex++;
                        Wrong++;
                    }
                }
                else 
                {
                    var item = Model.Items.Where(x => x.English.Contains((string)value) && x.IsUse).FirstOrDefault();

                    if (item != null)
                    {
                        item.IsUse = false;

                        Correctly++;
                        CurrentIndex++;
                    }
                    else
                    {
                        CurrentIndex++;
                        Wrong++;
                    }
                }
            }
        }
    }
}
