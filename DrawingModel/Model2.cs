using System;
using System.Collections.Generic;

namespace DrawingModel
{
    public partial class Model
    {
        // Add shape to canvas
        public void AddShape(double x2, double y2)
        {
            Shape line = _shapeFactory.CreateShape(LINE);
            Shape rectangle = _shapeFactory.CreateShape(RECTANGLE);
            Shape ellipse = _shapeFactory.CreateShape(ELLIPSE);
            Shape arrow = _shapeFactory.CreateShape(ARROW);
            GetLineInformation(line, x2, y2);
            GetShapeInformation(rectangle, x2, y2);
            GetShapeInformation(ellipse, x2, y2);
            GetLineInformation(arrow, x2, y2);
            if (_isLine)
                _commandManager.Execute(new DrawCommand(this, line));
            if (_isRectangle)
                _commandManager.Execute(new DrawCommand(this, rectangle));
            if (_isEllipse)
                _commandManager.Execute(new DrawCommand(this, ellipse));
            if (_isArrow)
                _commandManager.Execute(new DrawCommand(this, arrow));
            AddSelectedShape();
        }

        // Get line and arrow's value
        public void GetLineInformation(Shape shape, double x2, double y2)
        {
            shape.GetX1 = _firstPointX;
            shape.GetY1 = _firstPointY;
            shape.GetX2 = x2;
            shape.GetY2 = y2;
        }

        // Get rectangle and ellipse's value
        public void GetShapeInformation(Shape shape, double x2, double y2)
        {
            shape.GetX = Math.Min(_firstPointX, x2);
            shape.GetY = Math.Min(_firstPointY, y2);
            shape.GetWidth = Math.Abs(x2 - _firstPointX);
            shape.GetHeight = Math.Abs(y2 - _firstPointY);
        }

        // Add selected shape to canvas
        public void AddSelectedShape()
        {
            if (_isSelected)
            {
                _commandManager.Execute(new DrawCommand(this, _shape));
                _commandManager.Execute(new DrawCommand(this, _dashRectangle));
                _commandManager.Execute(new DrawCommand(this, _dashLine));
            }
        }

        // Delete selected shape
        public void Delete()
        {
            DeleteShape();
            DeleteShape();
            _commandManager.Execute(new DeleteCommand(this, _shapes[_shapes.Count - 1]));
            _isSelected = _isSelectedLast = _isDelete = false;
            NotifyModelChanged();
        }

        // Clear the canvas
        public void Clear()
        {
            _isPressed = false;
            List<Shape> list = new List<Shape>();
            for (int i = 0; i < _shapes.Count; i++)
                list.Add(_shapes[i]);
            _commandManager.Execute(new ClearCommand(this, list));
            _shapes.Clear();
            _isDelete = false;
            NotifyModelChanged();
        }

        // Draw the shape
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics);
            if (_isPressed)
                DrawTheShape(graphics);
        }

        // Draw the direct shape
        public void DrawTheShape(IGraphics graphics)
        {
            if (_isLine)
                _line.Draw(graphics);
            if (_isRectangle)
                _rectangle.Draw(graphics);
            if (_isEllipse)
                _ellipse.Draw(graphics);
            if (_isArrow)
                _arrow.Draw(graphics);
            if (_isSelected)
            {
                _dashLine.Draw(graphics);
                _dashRectangle.Draw(graphics);
                _shape.Draw(graphics);
            }
        }

        // Check if the model has changed or not
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        // Add shape on list
        public void DrawShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        // Add shapes on list
        public void DrawShape(List<Shape> shapes)
        {
            for (int i = 0; i < shapes.Count; i++)
                _shapes.Add(shapes[i]);
        }

        // Delete last shape on list
        public void DeleteShape()
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }

        // Delete all shapes on list
        public void DeleteShapes()
        {
            _shapes.Clear();
        }

        // Undo the action
        public void Undo()
        {
            _commandManager.Undo();
            NotifyModelChanged();
        }

        // Redo the action
        public void Redo()
        {
            _commandManager.Redo();
            NotifyModelChanged();
        }

        // Check if undo is enabled
        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }

        // Check if redo is enabled
        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        // Get line's x1 value
        public double GetLineX1()
        {
            return _line.GetX1;
        }

        // Get line's y1 value
        public double GetLineY1()
        {
            return _line.GetY1;
        }

        // Get line's x2 value
        public double GetLineX2()
        {
            return _line.GetX2;
        }

        // Get line's y2 value
        public double GetLineY2()
        {
            return _line.GetY2;
        }

        // Get rectangle's value
        public double GetRectangleX()
        {
            return _rectangle.GetX;
        }

        // Get rectangle's value
        public double GetRectangleY()
        {
            return _rectangle.GetY;
        }

        // Get rectangle's value
        public double GetRectangleWidth()
        {
            return _rectangle.GetWidth;
        }

        // Get rectangle's value
        public double GetRectangleHeight()
        {
            return _rectangle.GetHeight;
        }

        // Get shape list
        public List<Shape> GetShapeList()
        {
            return _shapes;
        }
    }
}