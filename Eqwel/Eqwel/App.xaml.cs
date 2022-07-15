using Eqwel.Interfaces;
using Eqwel.Service;
using Eqwel.Views.Pages;
using Xamarin.Forms;

[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Medium")]
[assembly: ExportFont("Prompt-Black.ttf", Alias = "Black")]
[assembly: ExportFont("Prompt-Bold.ttf", Alias = "Bold")]
namespace Eqwel
{
    public partial class App : Application
    {
        private static IViewModelLocator _viewModelLocator;
        public static IViewModelLocator ViewModelLocator => _viewModelLocator ?? (_viewModelLocator = new ViewModelLocatorService());

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
