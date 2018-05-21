namespace DrawingModel
{
    public class Ellipse : Shape
    {
        // Draw Ellipse
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(GetX, GetY, GetWidth, GetHeight);
        }
    }
}
