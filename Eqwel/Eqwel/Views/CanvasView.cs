using SkiaSharp;
using SkiaSharp.Elements;
using SkiaSharp.Elements.Collections;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eqwel.Views
{
    public class CanvasView : SKCanvasView
    {
        private readonly ElementsController _controller;

        public ElementsController Controller => _controller;
        public ElementsCollection Elements => _controller.Elements;

        public CanvasView()
        {
            _controller = new ElementsController();

            _controller.BackgroundColor = SKColor.Parse("#efefef");

            _controller.OnInvalidate += delegate (object sender, EventArgs e)
            {
                InvalidateSurface();
            };
        }

        public Element GetElementAtPoint(SKPoint point)
        {
            return Elements.GetElementAtPoint(point);
        }

        public void SuspendLayout() 
        {
            _controller.SuspendLayout();
        }

        public void ResumeLayout(bool invalidate = false)
        {
            _controller.ResumeLayout(invalidate);
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            _controller.Clear(e.Surface.Canvas);

            base.OnPaintSurface(e);

            _controller.Draw(e.Surface.Canvas);

            PaintSurfaceAfter?.Invoke(this, e);
        }

        public event EventHandler<SKPaintSurfaceEventArgs> PaintSurfaceAfter;
    }
}
