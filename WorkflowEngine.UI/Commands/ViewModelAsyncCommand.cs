using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WorkflowEngine.UI.Commands
{
    public class ViewModelAsyncCommand : ICommand
    {
        private Action m_action;
        private Boolean m_canExecute;

        public ViewModelAsyncCommand(Action action, Boolean canExecute)
        {
            m_action = action;
            m_canExecute = canExecute;
        }

        public Boolean CanExecute(Object parameter)
        {
            return m_canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public async void Execute(Object parameter)
        {
            await Task.Run(() =>
            {
                m_action();
            });
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
