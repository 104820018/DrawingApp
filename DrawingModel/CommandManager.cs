using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class CommandManager
    {
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();

        // Execute the action
        public void Execute(ICommand command)
        {
            command.Execute();
            // push command 進 undo stack
            _undo.Push(command);
            // 清除redo stack
            _redo.Clear();
        }

        // Do undo action
        public void Undo()
        {
            const string UNDO_EXCEPTION = "Cannot Undo exception\n";
            if (_undo.Count <= 0)
                throw new Exception(UNDO_EXCEPTION);
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.UnExecute();
        }

        // Do redo action
        public void Redo()
        {
            const string REDO_EXCEPTION = "Cannot Redo exception\n";
            if (_redo.Count <= 0)
                throw new Exception(REDO_EXCEPTION);
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        // Check if undo is enabled
        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }

        // Check if redo is enabled
        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }
    }
}
