namespace DrawingModel
{
    public interface ICommand
    {
        // Execute the action
        void Execute();
        // Unexecute the action
        void UnExecute();
    }
}
