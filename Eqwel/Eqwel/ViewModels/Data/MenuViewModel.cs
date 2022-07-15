using Eqwel.Enums;
using MvvmHelpers;

namespace Eqwel.ViewModels.Data
{
    public class MenuViewModel : ObservableObject
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

        private Menu _menuItem;
        public Menu MenuItem
        {
            get => _menuItem;
            set
            {
                _menuItem = value;
                OnPropertyChanged();
            }
        }

        private bool _isAvtive;
        public bool IsActive
        {
            get => _isAvtive;
            set
            {
                _isAvtive = value;
                OnPropertyChanged();
            }
        }

        private string _icon;
        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged();
            }
        }

        public MenuViewModel()
        {
            IsActive = false;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }

        protected static bool EqualsHelper(MenuViewModel first, MenuViewModel second)
        {
            return first.Title == second.Title;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            var other = obj as MenuViewModel;

            if (other == null)
            {
                return false;
            }

            return EqualsHelper(this, other);
        }
    }
}
