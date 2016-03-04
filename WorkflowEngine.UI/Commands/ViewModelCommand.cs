using System;
using System.Windows.Input;

namespace WorkflowEngine.UI.Commands
{
    public class ViewModelCommand : ICommand
    {
        private Action m_action;
        private Boolean m_canExecute;

        public ViewModelCommand(Action action, Boolean canExecute)
        {
            m_action = action;
            m_canExecute = canExecute;
        }

        public Boolean CanExecute(Object parameter)
        {
            return m_canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(Object parameter)
        {
            m_action();
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
