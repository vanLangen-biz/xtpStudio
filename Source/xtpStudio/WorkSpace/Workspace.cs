using Avalonia;
using Avalonia.Animation;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1
{
    public class Workspace : Border
    {
        private double _scaleXTranslation = 0;
        private double _scaleYTranslation = 0;
        private double _translationX = 0;
        private double _translationY = 0;
        private Point _deltaPosition;
        private readonly ScaleTransform _scaleTransform = new ScaleTransform();
        private readonly TranslateTransform _translateTransform = new TranslateTransform(1, 1);

        private readonly WorkspaceCanvas _canvas = new WorkspaceCanvas();

        public Workspace()
        {
            Background = new SolidColorBrush(0); // transparent/clickable

            var transformGroup = new TransformGroup();
            transformGroup.Children.Add(_scaleTransform);
            transformGroup.Children.Add(_translateTransform);

            PointerWheelChanged += Workspace_PointerWheelChanged;
            this.Child = _canvas;

            _canvas.RenderTransform = transformGroup;
        }

        public void AddControl(Control control)
        {
            control.PointerPressed += Control_PointerPressed;
            control.PointerReleased += Control_PointerReleased;
            control.PointerMoved += Control_PointerMoved;
            _canvas.Children.Add(control);
        }

        public void RemoveControl(Control control)
        {
            _canvas.Children.Remove(control);
            control.PointerPressed -= Control_PointerPressed;
            control.PointerReleased -= Control_PointerReleased;
            control.PointerMoved -= Control_PointerMoved;
        }

        private void Control_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            if (sender == default)
                return;

            var clickPositionCanvas = e.GetPosition(_canvas);
            _deltaPosition = e.GetPosition((IInputElement)sender);
            e.Pointer.Capture((IInputElement)sender);
        }

        private void Control_PointerMoved(object? sender, PointerEventArgs e)
        {
            if (e.Pointer.Captured != sender)
                return;

            if (sender is not AvaloniaObject control)
                return;

            var pos = e.GetPosition(_canvas) - (_deltaPosition);

            Canvas.SetLeft(control, pos.X);
            Canvas.SetTop(control, pos.Y);
        }

        private void Control_PointerReleased(object? sender, PointerReleasedEventArgs e)
        {
            e.Pointer.Capture(null);
        }

        public void Workspace_PointerWheelChanged(object? sender, Avalonia.Input.PointerWheelEventArgs e)
        {
            // zoom
            if (e.KeyModifiers.HasFlag(Avalonia.Input.KeyModifiers.Control))
            {
                var pos = e.GetPosition(_canvas);

                var oldScale = _scaleTransform.ScaleX;

                var newScale = _scaleTransform.ScaleX + (e.Delta.Y / 10.0);
                if (newScale < 0.1)
                    newScale = 0.1;

                _scaleXTranslation -= (pos.X * (newScale - oldScale));
                _scaleYTranslation -= (pos.Y * (newScale - oldScale));

                _canvas.RenderTransformOrigin = new RelativePoint(
                    new Point(0, 0),
                    RelativeUnit.Relative);

                _scaleTransform.ScaleX = newScale;
                _scaleTransform.ScaleY = newScale;
            }
            else if (e.KeyModifiers.HasFlag(Avalonia.Input.KeyModifiers.Shift))
            {
                // Scroll horizontally
                _translationX += (e.Delta.Y * _scaleTransform.ScaleX * 100);
            }
            else
            {
                // Scroll vertically
                _translationY += (e.Delta.Y * _scaleTransform.ScaleY * 100);
            }
            _translateTransform.X = _scaleXTranslation + _translationX;
            _translateTransform.Y = _scaleYTranslation + _translationY;
        }
    }
}