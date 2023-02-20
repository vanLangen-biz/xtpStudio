using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication1
{
    public class Connector : UserControl
    {
        public Connector()
        {
            InitializeComponent();
            PointerMoved += Connector_PointerMoved;
            PointerPressed += Connector_PointerPressed;
            PointerReleased += Connector_PointerReleased;
        }

        private void Connector_PointerReleased(object? sender, Avalonia.Input.PointerReleasedEventArgs e)
        {
        }

        private void Connector_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            e.Handled = true;
        }

        private void Connector_PointerMoved(object? sender, Avalonia.Input.PointerEventArgs e)
        {
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
