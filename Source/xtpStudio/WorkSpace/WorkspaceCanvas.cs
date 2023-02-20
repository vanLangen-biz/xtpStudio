using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaApplication1
{
    public class WorkspaceCanvas : Canvas
    {
        Pen pen = new Pen(Brushes.Red);

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            context.DrawLine(pen, new Point(50, 50), new Point(300, 400));
            context.DrawRectangle(pen, new Rect(10, 10, 420, 300));
        }
    }
}