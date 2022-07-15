using Eqwel.Animations;
using Eqwel.ViewModels.Data;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eqwel.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        private SkiaSharp.Elements.Rectangle _rectangle;
        private SKPoint _startLocation;
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

            MessagingCenter.Subscribe<string, MenuViewModel>("MyApp", "NotifyMsg", (sender, arg) =>
            {
                titleMenuItem.Text = arg.Title.ToLower();
                SwitchAnimateMenuFrame();
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SizeChanged += StartPageSizeChanged;

            AddRectangle();

            Play();
        }

        private void StartPageSizeChanged(object sender, EventArgs e)
        {
            #region start frame position + menu frame

            var startFrameRect = new Rectangle(0, 0, Width, 100);
            var endFrameRect = new Rectangle(0, 100, Width, 100);

            var startMenuComponentRect = new Rectangle(0, Height, Width, Height / 2);
            var endMenuComponentRect = new Rectangle(0, Height / 2, Width, Height / 2);

            #endregion

            #region animate

            State currentState = State.Start;

            if (_animationState != null)
            {
                currentState = (State)_animationState.CurrentState;
            }

            _animationState = new AnimationStateMachine();

            _animationState.Add(State.Start, new ViewTransition[]
            {
                new ViewTransition(canvas, Enums.AnimationType.Layout, startFrameRect),
                new ViewTransition(menuItemFrame, Enums.AnimationType.Layout, startMenuComponentRect)
            });

            _animationState.Add(State.End, new ViewTransition[] 
            {
                new ViewTransition(canvas, Enums.AnimationType.Layout, endFrameRect),
                new ViewTransition(menuItemFrame, Enums.AnimationType.Layout, endMenuComponentRect)
            });

            _animationState.Go(currentState, false);

            #endregion
        }

        private void SwitchAnimateMenuFrame()
        {
            switch (_animationState.CurrentState)
            {
                case State.Start:
                    _animationState.Go(State.End);
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

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            switch (_animationState.CurrentState)
            {
                case State.End:
                    _animationState.Go(State.Start);
                    break;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            switch (_animationState.CurrentState)
            {
                case State.End:
                    _animationState.Go(State.Start);
                    break;
            }

            return base.OnBackButtonPressed();
        }

        private void Play()
        {
            new Animation((value) =>
            {
                canvas.SuspendLayout();

                _rectangle.Transformation = SKMatrix.CreateRotationDegrees(360 * (float)value);

                _rectangle.Location = new SKPoint(_startLocation.X + (100 * (float)value),
                                                  _startLocation.Y + (100 * (float)value));

                canvas.ResumeLayout(true);

            })
            .Commit(this, "Anim", length: 2000, easing: Easing.SpringOut, repeat: () => true);
        }

        private void AddRectangle()
        {
            _startLocation = new SKPoint(0, 0);
           

            _rectangle = new SkiaSharp.Elements.Rectangle(SKRect.Create(_startLocation, new SKSize(Convert.ToInt32(600), 200)))
            {
                FillColor = SKColors.SpringGreen,
                BorderWidth = 0
            };
            canvas.Elements.Add(_rectangle);
        }

        private void Canvas_Touch(object sender, SkiaSharp.Views.Forms.SKTouchEventArgs e)
        {
            if (e.ActionType == SkiaSharp.Views.Forms.SKTouchAction.Pressed)
            {
                Play();
            }
        }
    }
}