namespace DrawingModel
{
    public interface IGraphics
    {
        // Clear all things on canvas
        void ClearAll();
        // Draw line
        void DrawLine(double x1, double y1, double x2, double y2);
        // Draw rectangle
        void DrawRectangle(double x1, double y1, double width, double height);
        // Draw ellipse
        void DrawEllipse(double x1, double y1, double width, double height);
        // Draw arrow
        void DrawArrow(double x1, double y1, double x2, double y2);
        // Draw dash rectangle
        void DrawDashRectangle(double x1, double y1, double width, double height);
        // Draw dash line
        void DrawDashLine(double x1, double y1, double x2, double y2);
    }
}