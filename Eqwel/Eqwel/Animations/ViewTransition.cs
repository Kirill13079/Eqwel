using Eqwel.Enums;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Eqwel.Animations
{
    public class ViewTransition
    {
        private readonly AnimationType _animationType;
        private readonly int _delay;
        private readonly uint _length;
        private readonly Easing _easing;
        private readonly double _endValue;
        private readonly Rectangle _rectangle;
        private readonly WeakReference<VisualElement> _targetElementReference;

        public ViewTransition(VisualElement targetElement, AnimationType animationType, double endValue, uint length = 250, Easing easing = null, int delay = 0)
        {
            _targetElementReference = new WeakReference<VisualElement>(targetElement);
            _animationType = animationType;
            _length = length;
            _endValue = endValue;
            _delay = delay;
            _easing = easing;
        }

        public ViewTransition(VisualElement targetElement, AnimationType animationType, Rectangle endLayout, uint length = 250, Easing easing = null, int delay = 0)
        {
            _targetElementReference = new WeakReference<VisualElement>(targetElement);
            _animationType = animationType;
            _length = length;
            _rectangle = endLayout;
            _delay = delay;
            _easing = easing;
        }

        public async Task GetTransition(bool withAnimation)
        {
            VisualElement targetElement;

            if (!_targetElementReference.TryGetTarget(out targetElement))
                throw new ObjectDisposedException("Target VisualElement was disposed");

            if (_delay > 0)
                await Task.Delay(_delay);

            withAnimation &= _length > 0;

            switch (_animationType)
            {
                case AnimationType.Layout:
                    if (withAnimation)
                        await targetElement.LayoutTo(_rectangle, _length, _easing);
                    else
                        await targetElement.LayoutTo(_rectangle, 0, null);

                    AbsoluteLayout.SetLayoutBounds(targetElement, _rectangle);
                    break;
                case AnimationType.Scale:
                    if (withAnimation)
                        await targetElement.ScaleTo(_endValue, _length, _easing);
                    else
                        targetElement.Scale = _endValue;
                    break;

                case AnimationType.Opacity:
                    if (withAnimation)
                    {
                        if (!targetElement.IsVisible && _endValue <= 0)
                            break;

                        if (targetElement.IsVisible && _endValue < targetElement.Opacity)
                        {
                            await targetElement.FadeTo(_endValue, _length, _easing);
                            targetElement.IsVisible = _endValue > 0;
                        }
                        else if (targetElement.IsVisible && _endValue > targetElement.Opacity)
                        {
                            await targetElement.FadeTo(_endValue, _length, _easing);
                        }
                        else if (!targetElement.IsVisible && _endValue > targetElement.Opacity)
                        {
                            targetElement.Opacity = 0;
                            targetElement.IsVisible = true;

                            await targetElement.FadeTo(_endValue, _length, _easing);
                        }
                    }
                    else
                    {
                        targetElement.Opacity = _endValue;
                        targetElement.IsVisible = _endValue > 0;
                    }
                    break;

                case AnimationType.TranslationX:
                    if (withAnimation)
                        await targetElement.TranslateTo(_endValue, targetElement.TranslationY, _length, _easing);
                    else
                        targetElement.TranslationX = _endValue;
                    break;

                case AnimationType.TranslationY:
                    if (withAnimation)
                        await targetElement.TranslateTo(targetElement.TranslationX, _endValue, _length, _easing);
                    else
                        targetElement.TranslationY = _endValue;
                    break;

                case AnimationType.Rotation:
                    if (withAnimation)
                        await targetElement.RotateTo(_endValue, _length, _easing);
                    else
                        targetElement.Rotation = _endValue;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
