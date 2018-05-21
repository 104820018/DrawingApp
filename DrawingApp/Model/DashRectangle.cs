namespace DrawingModel
{
    public class DashRectangle : Shape
    {
        // Draw Rectangle
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawDashRectangle(GetX, GetY, GetWidth, GetHeight);
        }
    }
}