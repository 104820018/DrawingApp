using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel;

namespace DrawingApp.PresentationModel
{
    public class PresentationModel
    {
        Model _model;
        IGraphics _graphics;

        public PresentationModel(Model model, Canvas canvas)
        {
            this._model = model;
            _graphics = new WindowsStoreGraphicsAdaptor(canvas);
        }

        // Draw the shape
        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_graphics);
        }

        // Check if line botton is enabled
        public bool IsLineEnabled()
        {
            if (_model.IsLine())
                return false;
            else
                return true;
        }

        // Check if rectangle botton is enabled
        public bool IsRectangleEnabled()
        {
            if (_model.IsRectangle())
                return false;
            else
                return true;
        }

        // Check if ellipse botton is enabled
        public bool IsEllipseEnabled()
        {
            if (_model.IsEllipse())
                return false;
            else
                return true;
        }

        // Check if arrow botton is enabled
        public bool IsArrowEnabled()
        {
            if (_model.IsArrow())
                return false;
            else
                return true;
        }

        // Check if arrow botton is enabled
        public bool IsDeleteEnabled()
        {
            if (_model.IsDelete())
                return true;
            else
                return false;
        }
    }
}