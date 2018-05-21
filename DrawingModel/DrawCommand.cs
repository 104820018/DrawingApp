namespace DrawingModel
{
    public class DrawCommand : ICommand
    {
        Shape _shape;
        Model _model;
        public DrawCommand(Model model, Shape shape)
        {
            _shape = shape;
            _model = model;
        }

        // Execute the action
        public void Execute()
        {
            _model.DrawShape(_shape);
        }

        // Unexecute the action
        public void UnExecute()
        {
            _model.DeleteShape();
        }
    }
}
