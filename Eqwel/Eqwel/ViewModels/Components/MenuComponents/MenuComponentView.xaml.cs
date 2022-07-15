using Eqwel.ViewModels.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eqwel.ViewModels.Components.MenuComponents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuComponentView : ContentView
    {
        private MenuViewModel _bindingContext = null;

        public MenuComponentView()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            icon.SvgSource = null;

            _bindingContext = BindingContext as MenuViewModel;

            icon.SvgSource = $"Eqwel.Resources.Icons.{_bindingContext.Icon}";

            _bindingContext.PropertyChanged += _bindingContextPropertyChanged;
        }

        private void _bindingContextPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var activeColor = Color.FromHex("#84F73E");
            var disableColor = Color.FromHex("#040615");

            icon.TintColor = _bindingContext.IsActive ? activeColor : disableColor;
        }

        private void MenuItemTapped(object sender, System.EventArgs e)
        {
            App.ViewModelLocator.StartPageViewModel.SelectedMenuItem.Execute(_bindingContext);
        }
    }
}