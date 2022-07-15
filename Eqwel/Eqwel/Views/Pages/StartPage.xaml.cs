using Eqwel.Animations;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eqwel.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        private AnimationStateMachine _animationState;
        private enum State
        {
            Start,
            End
        }

        public StartPage()
        {
            InitializeComponent();

            BindingContext = App.ViewModelLocator.StartPageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SizeChanged += StartPageSizeChanged;
        }

        private void StartPageSizeChanged(object sender, EventArgs e)
        {
            #region start frame position + menu frame

            var startFrameRect = new Rectangle(0, Height / 2, Width, 100);
            var endFrameRect = new Rectangle(0, 100, Width, 100);

            var startMenuComponentRect = new Rectangle(0, Height, Width, Height / 2);
            var endMenuComponentRect = new Rectangle(0, Height / 2, Width, Height / 2);

            #endregion

            #region animate

            _animationState = new AnimationStateMachine();

            _animationState.Add(State.Start, new ViewTransition[]
            {
                new ViewTransition(startFrame, Enums.AnimationType.Layout, startFrameRect),
                new ViewTransition(menuItemFrame, Enums.AnimationType.Layout, startMenuComponentRect)
            });

            _animationState.Add(State.End, new ViewTransition[] 
            {
                new ViewTransition(startFrame, Enums.AnimationType.Layout, endFrameRect),
                new ViewTransition(menuItemFrame, Enums.AnimationType.Layout, endMenuComponentRect)
            });

            _animationState.Go(State.Start, false);

            #endregion
        }

        private void SwitchAnimateMenuFrame()
        {
            switch (_animationState.CurrentState)
            {
                case State.Start:
                    _animationState.Go(State.End);
                    break;
                case State.End:
                    _animationState.Go(State.Start);
                    break;
            }
        }

        private async void RussianModeTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void EnglishModeTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        public void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SwitchAnimateMenuFrame();
        }
    }
}