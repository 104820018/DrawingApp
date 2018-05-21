namespace DrawingModel
{
    public abstract class Shape
    {
        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;
        private double _x;
        private double _y;
        private double _width;
        private double _height;

        // Draw shape
        public abstract void Draw(IGraphics graphics);

        public double GetX1
        {
            get
            {
                return _x1;
            }
            set
            {
                _x1 = value;
            }
        }
        public double GetY1
        {
            get
            {
                return _y1;
            }
            set
            {
                _y1 = value;
            }
        }
        public double GetX2
        {
            get
            {
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }
        public double GetY2
        {
            get
            {
                return _y2;
            }
            set
            {
                _y2 = value;
            }
        }
        public double GetX
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public double GetY
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public double GetWidth
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public double GetHeight
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
    }
}
