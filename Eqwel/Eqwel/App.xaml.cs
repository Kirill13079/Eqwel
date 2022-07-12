using Eqwel.Views.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Medium")]
[assembly: ExportFont("Prompt-Black.ttf", Alias = "Black")]
[assembly: ExportFont("Prompt-Bold.ttf", Alias = "Bold")]
namespace Eqwel
{
    public partial class App : Application
    {
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
