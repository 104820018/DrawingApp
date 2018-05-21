using System;
using System.Collections.Generic;

namespace DrawingModel
{
    public class DeleteCommand : ICommand
    {
        Shape _shape;
        Model _model;
        public DeleteCommand(Model model, Shape shape)
        {
            _shape = shape;
            _model = model;
        }

        // Execute the action
        public void Execute()
        {
            _model.DeleteShape();
        }

        // Unexecute the action
        public void UnExecute()
        {
            _model.DrawShape(_shape);
        }
    }
}
