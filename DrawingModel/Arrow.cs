namespace DrawingModel
{
    public class Arrow : Shape
    {
        // Draw Ellipse
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawArrow(GetX1, GetY1, GetX2, GetY2);
        }
    }
}
