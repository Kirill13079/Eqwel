using Eqwel.AppSettings;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eqwel.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private async void RussianModeTapped(object sender, EventArgs e)
        {
            Setting.AddSetting(prefrence: Setting.AppPrefrences.Mode, setting: "russian");

            await Navigation.PushAsync(new MainPage());
        }

        private async void EnglishModeTapped(object sender, EventArgs e)
        {
            Setting.AddSetting(prefrence: Setting.AppPrefrences.Mode, setting: "english");

            await Navigation.PushAsync(new MainPage());
        }
    }
}