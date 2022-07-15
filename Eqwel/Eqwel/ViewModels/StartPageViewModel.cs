using Eqwel.Enums;
using Eqwel.Extensions;
using Eqwel.ViewModels.Data;
using Eqwel.Views.Pages;
using MvvmHelpers;
using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Eqwel.ViewModels
{
    public class StartPageViewModel : BaseViewModel
    {
        private ObservableRangeCollection<ModeOptionViewModel> _modeOptions = new ObservableRangeCollection<ModeOptionViewModel>();
        public ObservableRangeCollection<ModeOptionViewModel> ModeOptions
        {
            get => _modeOptions;
            set
            {
                _modeOptions = value;
                OnPropertyChanged();
            }
        }

        private ObservableRangeCollection<MenuViewModel> _menu = new ObservableRangeCollection<MenuViewModel>();
        public ObservableRangeCollection<MenuViewModel> Menu
        {
            get => _menu;
            set 
            {
                _menu = value;
                OnPropertyChanged();
            }
        }

        private MenuViewModel _selectedMenuItem;
        public MenuViewModel SelectedMenuItem 
        {
            get => _selectedMenuItem;
            set 
            {
                _selectedMenuItem = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectedMenuItemCommand { get; set; }

        public StartPageViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            SelectedMenuItemCommand = new Command<MenuViewModel>(menuItem => SelectedMenuItemCommandHandler(menuItem));

            GetMenu();
        }

        private void GetModeOptions()
        {
            var enumModeOptions = Enum.GetValues(typeof(ModeOption)).Cast<ModeOption>();

            foreach (var enumModeOption in enumModeOptions)
            {
                ModeOptions.Add(new ModeOptionViewModel
                {
                    Title = enumModeOption.DisplayName(),
                    ModeOption = enumModeOption
                });
            }
        }

        private void GetMenu()
        {
            var menu = Enum.GetValues(typeof(Enums.Menu)).Cast<Enums.Menu>();

            foreach (var menuItem in menu)
            {
                string title = menuItem.DisplayName();

                Menu.Add(new MenuViewModel
                {
                    Title = title,
                    MenuItem = menuItem,
                    Icon = $"{title.ToLower()}.svg"
                });
            }
        }

        public void SelectedMenuItemCommandHandler(MenuViewModel selectedMenuItem)
        {
            bool isSelectedMenuItem(MenuViewModel menuItem) => menuItem.Equals(selectedMenuItem);

            var menu = Menu.FirstOrDefault(predicate: menuItem => isSelectedMenuItem(menuItem));

            if (menu != null)
            {
                Menu.ForEach((test) => { test.IsActive = false; });

                menu.IsActive = !menu.IsActive;

                SelectedMenuItem = menu;

                MessagingCenter.Send("MyApp", "NotifyMsg", SelectedMenuItem);
            }
        }
    }
}