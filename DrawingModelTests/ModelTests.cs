using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model _model;
        IGraphics _graphics;

        // Initialize the object
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _graphics = new GraphicsAdaptor();
        }

        // Test Model.GetLine()
        [TestMethod()]
        public void GetLineTest()
        {
            _model.GetLine();
            Assert.IsTrue(_model.IsLine());
            Assert.IsFalse(_model.IsRectangle());
            Assert.IsFalse(_model.IsEllipse());
            Assert.IsFalse(_model.IsArrow());
            Assert.IsFalse(_model.IsSelected());
        }

        // Test Model.GetRectangle()
        [TestMethod()]
        public void GetRectangleTest()
        {
            _model.GetRectangle();
            Assert.IsFalse(_model.IsLine());
            Assert.IsTrue(_model.IsRectangle());
            Assert.IsFalse(_model.IsEllipse());
            Assert.IsFalse(_model.IsArrow());
            Assert.IsFalse(_model.IsSelected());
        }

        // Test Model.GetEllipse()
        [TestMethod()]
        public void GetEllipseTest()
        {
            _model.GetEllipse();
            Assert.IsFalse(_model.IsLine());
            Assert.IsFalse(_model.IsRectangle());
            Assert.IsTrue(_model.IsEllipse());
            Assert.IsFalse(_model.IsArrow());
            Assert.IsFalse(_model.IsSelected());
        }

        // Test Model.GetArrow()
        [TestMethod()]
        public void GetArrowTest()
        {
            _model.GetArrow();
            Assert.IsFalse(_model.IsLine());
            Assert.IsFalse(_model.IsRectangle());
            Assert.IsFalse(_model.IsEllipse());
            Assert.IsTrue(_model.IsArrow());
            Assert.IsFalse(_model.IsSelected());
        }

        // Test Model.GetSelected()
        [TestMethod()]
        public void GetSelectedTest()
        {
            _model.GetSelected();
            Assert.IsFalse(_model.IsLine());
            Assert.IsFalse(_model.IsRectangle());
            Assert.IsFalse(_model.IsEllipse());
            Assert.IsFalse(_model.IsArrow());
            Assert.IsTrue(_model.IsSelected());
        }

        // Test Model.GetPointerMoved(double movingX, double movingY)
        [TestMethod()]
        public void GetPointerMovedTest()
        {
            _model.GetPointerPressed(-100, -100);
            _model.GetPointerPressed(100, 100);
            _model.GetPointerMoved(300, 300);
            Assert.AreEqual(100, _model.GetLineX1());
            Assert.AreEqual(100, _model.GetLineY1());
            Assert.AreEqual(300, _model.GetLineX2());
            Assert.AreEqual(300, _model.GetLineY2());
            Assert.AreEqual(100, _model.GetRectangleX());
            Assert.AreEqual(100, _model.GetRectangleY());
            Assert.AreEqual(200, _model.GetRectangleWidth());
            Assert.AreEqual(200, _model.GetRectangleHeight());
            Initialize();
            _model.GetRectangle();
            _model.GetPointerPressed(1, 1);
            _model.GetPointerReleased(200, 200);
            _model.GetPointerPressed(100, 100);
            _model.GetPointerMoved(200, 200);
            Assert.AreEqual(100, _model.GetRectangleX());
            Assert.AreEqual(100, _model.GetRectangleY());
            Assert.AreEqual(100, _model.GetRectangleWidth());
            Assert.AreEqual(100, _model.GetRectangleHeight());
        }

        // Test Model.GetPointerReleased(double x2, double y2)
        [TestMethod()]
        public void GetPointerReleasedTest()
        {
            _model.GetPointerPressed(100, 100);
            _model.GetPointerReleased(200, 200);
            Assert.AreEqual(100, _model.GetLineX1());
            Assert.AreEqual(100, _model.GetLineY1());
            Assert.AreEqual(100, _model.GetRectangleX());
            Assert.AreEqual(100, _model.GetRectangleY());
            Initialize();
            _model.GetLine();
            _model.GetPointerPressed(100, 100);
            _model.GetPointerReleased(200, 200);
            _model.GetPointerPressed(100, 100);
            _model.GetPointerMoved(200, 200);
            Assert.IsTrue(_model.IsSelected());
            _model.GetPointerReleased(300, 300);
            Assert.IsFalse(_model.IsSelected());
            _model.GetPointerPressed(400, 400);
        }

        // Test Model.AddShape(double x2, double y2)
        [TestMethod()]
        public void AddShapeTest()
        {
            _model.GetPointerPressed(100, 100);
            _model.AddShape(200, 200);
            Assert.AreEqual(100, _model.GetRectangleX());
            Assert.AreEqual(100, _model.GetRectangleY());
        }

        // Test Model.Delete()
        [TestMethod()]
        public void DeleteTest()
        {
            _model.GetRectangle();
            _model.GetPointerPressed(100, 100);
            _model.GetPointerReleased(300, 300);
            _model.GetPointerPressed(200, 200);
            _model.GetPointerReleased(200, 200);
            Assert.IsTrue(_model.IsDelete());
            _model.Delete();
            Assert.IsFalse(_model.IsDelete());
            _model.Undo();
        }

        // Test Model.Draw(IGraphics graphics)
        [TestMethod()]
        public void DrawTest()
        {
            Line line = new Line();
            Rectangle rectangle = new Rectangle();
            Ellipse ellipse = new Ellipse();
            Arrow arrow = new Arrow();
            _model.DrawShape(line);
            _model.DrawShape(rectangle);
            _model.DrawShape(ellipse);
            _model.GetLine();
            _model.GetPointerPressed(100, 100);
            _model.Draw(_graphics);
            _model.GetRectangle();
            _model.GetPointerPressed(100, 100);
            _model.Draw(_graphics);
            _model.GetEllipse();
            _model.GetPointerPressed(100, 100);
            _model.Draw(_graphics);
            _model.GetArrow();
            _model.GetPointerPressed(100, 100);
            _model.Draw(_graphics);
            _model.GetPointerPressed(100, 100);
            _model.GetPointerReleased(300, 300);
            _model.GetPointerPressed(200, 200);
            _model.Draw(_graphics);
        }

        // Test Model.DrawShape(Shape shape)
        [TestMethod()]
        public void DrawShapeTest1()
        {
            Line line = new Line();
            _model.DrawShape(line);
            Assert.AreEqual(line, _model.GetShapeList()[0]);
            _model.Clear();
            Rectangle rectangle = new Rectangle();
            _model.DrawShape(rectangle);
            Assert.AreNotEqual(line, _model.GetShapeList()[0]);
            Assert.AreEqual(rectangle, _model.GetShapeList()[0]);
        }

        // Test Model.DrawShape(List<Shape> shapes)
        [TestMethod()]
        public void DrawShapeTest2()
        {
            Line line = new Line();
            Rectangle rectangle = new Rectangle();
            Ellipse ellipse = new Ellipse();
            List<Shape> shapes = new List<Shape>();
            shapes.Add(line);
            shapes.Add(rectangle);
            shapes.Add(ellipse);
            _model.DrawShape(shapes);
            Assert.AreEqual(line, _model.GetShapeList()[0]);
            Assert.AreEqual(rectangle, _model.GetShapeList()[1]);
            Assert.AreEqual(ellipse, _model.GetShapeList()[2]);
        }

        // Test Model.DeleteShape()
        [TestMethod()]
        public void DeleteShapeTest()
        {
            Line line = new Line();
            Rectangle rectangle = new Rectangle();
            Ellipse ellipse = new Ellipse();
            List<Shape> shapes = new List<Shape>();
            shapes.Add(line);
            shapes.Add(rectangle);
            shapes.Add(ellipse);
            _model.DrawShape(shapes);
            _model.DeleteShape();
            _model.DrawShape(line);
            Assert.AreNotEqual(ellipse, _model.GetShapeList()[2]);
            Assert.AreEqual(line, _model.GetShapeList()[2]);
        }

        // Test Model.DeleteShapes()
        [TestMethod()]
        public void DeleteShapesTest()
        {
            Line line = new Line();
            Rectangle rectangle = new Rectangle();
            Ellipse ellipse = new Ellipse();
            _model.DrawShape(line);
            _model.DrawShape(rectangle);
            _model.DrawShape(ellipse);
            _model.DeleteShapes();
            _model.DrawShape(rectangle);
            Assert.AreNotEqual(line, _model.GetShapeList()[0]);
            Assert.AreEqual(rectangle, _model.GetShapeList()[0]);
        }

        // Test Model.Undo()
        [TestMethod()]
        public void UndoTest()
        {
            try
            {
                _model.Undo();
            }
            catch (Exception)
            {
            }
            _model.GetLine();
            _model.GetPointerPressed(100, 100);
            _model.GetPointerReleased(200, 200);
            _model.GetRectangle();
            _model.GetPointerPressed(10, 10);
            _model.GetPointerReleased(20, 20);
            Assert.AreEqual(2, _model.GetShapeList().Count);
            _model.Undo();
            Assert.AreEqual(1, _model.GetShapeList().Count);
            _model.GetEllipse();
            _model.GetPointerPressed(1, 1);
            _model.GetPointerReleased(2, 2);
            Assert.AreEqual(2, _model.GetShapeList().Count);
        }

        // Test Model.Redo()
        [TestMethod()]
        public void RedoTest()
        {
            try
            {
                _model.Redo();
            }
            catch (Exception)
            {
            }
            Assert.IsFalse(_model.IsUndoEnabled);
            Assert.IsFalse(_model.IsRedoEnabled);
            _model.GetLine();
            _model.GetPointerPressed(100, 100);
            _model.GetPointerReleased(200, 200);
            _model.GetRectangle();
            _model.GetPointerPressed(10, 10);
            _model.GetPointerReleased(20, 20);
            Assert.AreEqual(2, _model.GetShapeList().Count);
            Assert.IsTrue(_model.IsUndoEnabled);
            _model.Undo();
            Assert.AreEqual(1, _model.GetShapeList().Count);
            Assert.IsTrue(_model.IsRedoEnabled);
            _model.Redo();
            Assert.AreEqual(2, _model.GetShapeList().Count);
            Assert.IsFalse(_model.IsRedoEnabled);
            _model.Clear();
            _model.Undo();
            Assert.AreEqual(2, _model.GetShapeList().Count);
        }
    }

    public class GraphicsAdaptor : IGraphics
    {
        // Clear all things on canvas
        public void ClearAll()
        {
        }

        // Draw line
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
        }

        // Draw rectangle
        public void DrawRectangle(double x1, double y1, double width, double height)
        {
        }

        // Draw ellipse
        public void DrawEllipse(double x1, double y1, double width, double height)
        {
        }

        // Draw arrow
        public void DrawArrow(double x1, double y1, double width, double height)
        {
        }

        // Draw arrow
        public void DrawDashRectangle(double x1, double y1, double width, double height)
        {
        }

        // Draw dash line
        public void DrawDashLine(double x1, double y1, double x2, double y2)
        {
        }
    }
}