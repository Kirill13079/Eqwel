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
        public MainPage()
        {
            InitializeComponent();

            Task.Run(AnimateBackground);
        }

        protected override void OnAppearing()
        {
            base.OnDisappearing();

            SizeChanged += MainPage_SizeChanged;
        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            var startRect = new Rectangle(0, 0, Width, 100)
            {
                Location = new Point(0, 100)
            };

            AbsoluteLayout.SetLayoutBounds(StartFrame, startRect);
        }

        private async void AnimateBackground()
        {
            Action<double> tealMovement = tInput => tealGrad.Offset = (float)tInput;
            Action<double> orangeMovement = oInput => orangeGrad.Offset = (float)oInput;

            Action<double> radius = oInput => StartFrame.CornerRadius = new CornerRadius(0, 0, oInput, oInput);
            Action<double> radius2 = oInput => StartFrame.CornerRadius = new CornerRadius(oInput, oInput, 0, 0);

            while (true)
            {
                mainRect.Animate(name: "forward", callback: tealMovement, start: 0, end: 1, length: 5000, easing: Easing.SinIn);

                mainRect.Animate(name: "test", callback: radius, start: 100, end: 1, length: 5000, easing: Easing.SinIn);

                await Task.Delay(5000);
                mainRect.Animate(name: "backward", callback: tealMovement, start: 1, end: 0, length: 5000, easing: Easing.SinIn);
                mainRect.Animate(name: "test", callback: radius2, start: 1, end: 100, length: 5000, easing: Easing.SinIn);
                await Task.Delay(5000);

                StartFrame.CornerRadius = new CornerRadius(0, 0, 100, 100);

                //mainRect.Animate(name: "forward2", callback: orangeMovement, start: 1, end: 0, length: 1000, easing: Easing.SinIn);
                //await Task.Delay(1000);
                //mainRect.Animate(name: "backward2", callback: orangeMovement, start: 0, end: 1, length: 1000, easing: Easing.SinIn);
                //await Task.Delay(1000);
            }
        }
    }
}