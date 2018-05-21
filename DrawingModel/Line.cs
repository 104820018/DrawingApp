namespace DrawingModel
{
    public class Line : Shape
    {
        // Draw line
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(GetX1, GetY1, GetX2, GetY2);
        }
    }
}
