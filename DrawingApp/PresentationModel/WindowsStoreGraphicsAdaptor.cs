using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;
using Windows.UI.Xaml.Media.Imaging;

namespace DrawingApp.PresentationModel
{
    public class WindowsStoreGraphicsAdaptor : IGraphics
    {
        Canvas _canvas;

        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        // Clear all things on canvas
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        // Draw line
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        // Draw Rectangle
        public void DrawRectangle(double x1, double y1, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Margin = new Windows.UI.Xaml.Thickness(x1, y1, x1 + width, y1 + height);
            rectangle.Fill = new SolidColorBrush(Colors.Yellow);
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(rectangle);
        }

        // Draw Ellipse
        public void DrawEllipse(double x1, double y1, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Width = width;
            ellipse.Height = height;
            ellipse.Margin = new Windows.UI.Xaml.Thickness(x1, y1, x1 + width, y1 + height);
            ellipse.Fill = new SolidColorBrush(Colors.Gold);
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(ellipse);
        }

        // Draw Arrow
        public void DrawArrow(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Fill = new SolidColorBrush(Colors.DeepSkyBlue);
            line.Stroke = new SolidColorBrush(Colors.Black);
            line.StrokeEndLineCap = PenLineCap.Triangle;
            _canvas.Children.Add(line);
        }

        // Draw Ellipse
        public void DrawDashRectangle(double x1, double y1, double width, double height)
        {
            const int DASH = 10;
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Margin = new Windows.UI.Xaml.Thickness(x1, y1, x1 + width, y1 + height);
            rectangle.Stroke = new SolidColorBrush(Colors.Red);
            rectangle.StrokeDashArray = new DoubleCollection()
            {
                DASH
            };
            _canvas.Children.Add(rectangle);
        }

        // Draw Dash line
        public void DrawDashLine(double x1, double y1, double x2, double y2)
        {
            const int DASH = 10;
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Red);
            line.StrokeDashArray = new DoubleCollection()
            {
                DASH
            };
            _canvas.Children.Add(line);
        }

    }
}