namespace DrawingModel
{
    public class DashLine : Shape
    {
        // Draw line
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawDashLine(GetX1, GetY1, GetX2, GetY2);
        }
    }
}
