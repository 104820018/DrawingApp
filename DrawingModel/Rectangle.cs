namespace DrawingModel
{
    public class Rectangle : Shape
    {
        // Draw Rectangle
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(GetX, GetY, GetWidth, GetHeight);
        }
    }
}
