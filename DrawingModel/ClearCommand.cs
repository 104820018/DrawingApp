using System;
using System.Collections.Generic;

namespace DrawingModel
{
    public class ClearCommand : ICommand
    {
        List<Shape> _shapes;
        Model _model;
        public ClearCommand(Model model, List<Shape> shapes)
        {
            _shapes = shapes;
            _model = model;
        }

        // Execute the action
        public void Execute()
        {
            _model.DeleteShapes();
        }

        // Unexecute the action
        public void UnExecute()
        {
            _model.DrawShape(_shapes);
        }
    }
}
