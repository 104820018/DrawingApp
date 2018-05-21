using System.Drawing;
using DrawingModel;

namespace DrawingForm.PresentationModel
{
    public class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;

        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        // Clear all shape on canvas
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        // Draw Line
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // Draw Rectangle
        public void DrawRectangle(double x1, double y1, double width, double height)
        {
            _graphics.FillRectangle(Brushes.Yellow, (float)x1, (float)y1, (float)width, (float)height);
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)width, (float)height);
        }

        // Draw Ellipse
        public void DrawEllipse(double x1, double y1, double width, double height)
        {
            _graphics.FillEllipse(Brushes.Gold, (float)x1, (float)y1, (float)width, (float)height);
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)width, (float)height);
        }

        // Draw Arrow
        public void DrawArrow(double x1, double y1, double x2, double y2)
        {
            const int PEN_WIDTH = 40;
            const int PEN_ALPHA = 128;
            const int PEN_RED = 0;
            const int PEN_GREEN = 128;
            const int PEN_BLUE = 255;
            Pen pen = new Pen(Color.FromArgb(PEN_ALPHA, PEN_RED, PEN_GREEN, PEN_BLUE), PEN_WIDTH);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            _graphics.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // Draw Dash Rectangle
        public void DrawDashRectangle(double x1, double y1, double width, double height)
        {
            const int PEN_WIDTH = 5;
            const float DASH = 3.0f;
            const float BLANK = 3.0f;
            Pen dashPen = new Pen(Color.Red, PEN_WIDTH);
            dashPen.DashPattern = new float[] { DASH, BLANK };
            _graphics.DrawRectangle(dashPen, (float)x1, (float)y1, (float)width, (float)height);
        }

        // Draw Dash Line
        public void DrawDashLine(double x1, double y1, double x2, double y2)
        {
            const int PEN_WIDTH = 5;
            const float DASH = 3.0f;
            const float BLANK = 3.0f;
            Pen dashPen = new Pen(Color.Red, PEN_WIDTH);
            dashPen.DashPattern = new float[] { DASH, BLANK };
            _graphics.DrawLine(dashPen, (float)x1, (float)y1, (float)x2, (float)y2);
        }
    }
}