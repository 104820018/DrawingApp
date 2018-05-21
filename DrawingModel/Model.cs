using System;
using System.Collections.Generic;

namespace DrawingModel
{
    public partial class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        double _shapeX1;
        double _shapeY1;
        double _shapeX2;
        double _shapeY2;
        double _shapeX;
        double _shapeY;
        bool _isPressed = false;
        bool _isLine = true;
        bool _isRectangle = false;
        bool _isEllipse = false;
        bool _isArrow = false;
        bool _isSelected = false;
        bool _isSelectedLast = false;
        bool _isDelete = false;
        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string ELLIPSE = "Ellipse";
        const string ARROW = "Arrow";
        List<Shape> _shapes = new List<Shape>();
        Shape _line = new Line();
        Shape _rectangle = new Rectangle();
        Shape _ellipse = new Ellipse();
        Shape _arrow = new Arrow();
        Shape _dashLine = new DashLine();
        Shape _dashRectangle = new DashRectangle();
        Shape _shape;
        CommandManager _commandManager = new CommandManager();
        ShapeFactory _shapeFactory = new ShapeFactory();

        // Prepare to draw line
        public void GetLine()
        {
            _isLine = true;
            _isRectangle = _isEllipse = _isArrow = _isSelected = _isDelete = false;
        }

        // Prepare to draw rectangle
        public void GetRectangle()
        {
            _isRectangle = true;
            _isLine = _isEllipse = _isArrow = _isSelected = _isDelete = false;
        }

        // Prepare to draw ellipse
        public void GetEllipse()
        {
            _isEllipse = true;
            _isLine = _isRectangle = _isArrow = _isSelected = _isDelete = false;
        }

        // Prepare to draw arrow
        public void GetArrow()
        {
            _isArrow = true;
            _isLine = _isRectangle = _isEllipse = _isSelected = _isDelete = false;
        }

        // Prepare to select shape
        public void GetSelected()
        {
            _isSelected = _isDelete = true;
            _isLine = _isRectangle = _isEllipse = _isArrow = false;
        }

        // Check if the shape is line or not
        public bool IsLine()
        {
            return _isLine;
        }

        // Check if the shape is rectangle or not
        public bool IsRectangle()
        {
            return _isRectangle;
        }

        // Check if the shape is ellipse or not
        public bool IsEllipse()
        {
            return _isEllipse;
        }

        // Check if the shape is arrow or not
        public bool IsArrow()
        {
            return _isArrow;
        }

        // Check if the shape is selected or not
        public bool IsSelected()
        {
            return _isSelected;
        }

        // Check if the shape can be deleted or not
        public bool IsDelete()
        {
            return _isDelete;
        }

        // Get the first point of the shape
        public void GetPointerPressed(double x1, double y1)
        {
            if (x1 > 0 && y1 > 0)
            {
                _line.GetX1 = _rectangle.GetX = _ellipse.GetX = _arrow.GetX1 = _firstPointX = x1;
                _line.GetY1 = _rectangle.GetY = _ellipse.GetY = _arrow.GetY1 = _firstPointY = y1;
                _isPressed = true;
                if (_isSelectedLast)
                    DeleteDashShapes();
                for (int i = 0; i < _shapes.Count; i++)
                {
                    if ((x1 >= _shapes[i].GetX && y1 >= _shapes[i].GetY && x1 <= _shapes[i].GetX + _shapes[i].GetWidth && y1 <= _shapes[i].GetY + _shapes[i].GetHeight) || (x1 >= Math.Min(_shapes[i].GetX1, _shapes[i].GetX2) && y1 >= Math.Min(_shapes[i].GetY1, _shapes[i].GetY2) && x1 <= Math.Max(_shapes[i].GetX1, _shapes[i].GetX2) && y1 <= Math.Max(_shapes[i].GetY1, _shapes[i].GetY2)))
                        GetSelectedShape(i);
                    else
                        _isDelete = false;
                }
            }
        }

        // Delete dash line and dash rectangle
        public void DeleteDashShapes()
        {
            DeleteShape();
            DeleteShape();
            _isSelectedLast = false;
        }

        // Get selected shape's information
        public void GetSelectedShape(int selectedShapeNumber)
        {
            GetSelected();
            _shape = _shapes[selectedShapeNumber];
            _shapes.RemoveAt(selectedShapeNumber);
            _shapeX1 = _shape.GetX1;
            _shapeY1 = _shape.GetY1;
            _shapeX2 = _shape.GetX2;
            _shapeY2 = _shape.GetY2;
            _shapeX = _shape.GetX;
            _shapeY = _shape.GetY;
            _dashLine.GetX1 = _shape.GetX1;
            _dashLine.GetY1 = _shape.GetY1;
            _dashLine.GetX2 = _shape.GetX2;
            _dashLine.GetY2 = _shape.GetY2;
            _dashRectangle.GetX = _shape.GetX;
            _dashRectangle.GetY = _shape.GetY;
            _dashRectangle.GetWidth = _shape.GetWidth;
            _dashRectangle.GetHeight = _shape.GetHeight;
        }

        // Get the point of the shape when mouse is moving
        public void GetPointerMoved(double movingX, double movingY)
        {
            if (_isPressed)
            {
                _line.GetX2 = _arrow.GetX2 = movingX;
                _line.GetY2 = _arrow.GetY2 = movingY;
                _rectangle.GetX = _ellipse.GetX = Math.Min(_firstPointX, movingX);
                _rectangle.GetY = _ellipse.GetY = Math.Min(_firstPointY, movingY);
                _rectangle.GetWidth = _ellipse.GetWidth = Math.Abs(movingX - _firstPointX);
                _rectangle.GetHeight = _ellipse.GetHeight = Math.Abs(movingY - _firstPointY);
                if (_isSelected)
                    GetMovingShape(movingX, movingY);
                NotifyModelChanged();
            }
        }

        // Moved selected shape
        public void GetMovingShape(double movingX, double movingY)
        {
            _shape.GetX1 = _shapeX1 + movingX - _firstPointX;
            _shape.GetY1 = _shapeY1 + movingY - _firstPointY;
            _shape.GetX2 = _shapeX2 + movingX - _firstPointX;
            _shape.GetY2 = _shapeY2 + movingY - _firstPointY;
            _shape.GetX = _shapeX + movingX - _firstPointX;
            _shape.GetY = _shapeY + movingY - _firstPointY;
            _dashLine.GetX1 = _shapeX1 + movingX - _firstPointX;
            _dashLine.GetY1 = _shapeY1 + movingY - _firstPointY;
            _dashLine.GetX2 = _shapeX2 + movingX - _firstPointX;
            _dashLine.GetY2 = _shapeY2 + movingY - _firstPointY;
            _dashRectangle.GetX = _shapeX + movingX - _firstPointX;
            _dashRectangle.GetY = _shapeY + movingY - _firstPointY;
        }

        // Get the last point of the shape
        public void GetPointerReleased(double x2, double y2)
        {
            if (_isPressed)
            {
                _isPressed = false;
                AddShape(x2, y2);
                if (_isSelected)
                {
                    _isSelectedLast = true;
                    _isDelete = true;
                }
                _isSelected = false;
                NotifyModelChanged();
            }
        }
    }
}