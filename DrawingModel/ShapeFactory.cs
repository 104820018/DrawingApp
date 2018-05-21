namespace DrawingModel
{
    class ShapeFactory
    {
        Shape _shape;
        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string ELLIPSE = "Ellipse";

        // Create new shape by string
        public Shape CreateShape(string shapeType)
        {
            if (shapeType == LINE)
                return _shape = new Line();
            else if (shapeType == RECTANGLE)
                return _shape = new Rectangle();
            else if (shapeType == ELLIPSE)
                return _shape = new Ellipse();
            else
                return _shape = new Arrow();
        }
    }
}
