using Eqwel.Models;
using Eqwel.ViewModels;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eqwel.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _bindingContext;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();

            _bindingContext = BindingContext as MainViewModel;

            //var bindingObject = new List<MainModel>();

            //bindingObject.Add(_bindingContext.Model);

            //carouselView.ItemsSource = bindingObject;
        }

        protected override void OnAppearing()
        {
            base.OnDisappearing();
        }
    }
}