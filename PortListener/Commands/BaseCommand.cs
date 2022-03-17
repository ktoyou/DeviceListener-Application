using System;
using System.Windows.Input;

namespace PortListener.Commands
{
    internal abstract class BaseCommand : ICommand
    {
        public bool CanExecuteCommand
        {
            get => _canExecuteCommand;
            set
            {
                _canExecuteCommand = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => CanExecuteCommand;

        public void Execute(object parameter)
        {
            CanExecuteCommand = true;
            ExecuteCommand(parameter);
            CanExecuteCommand = false;
        }

        public abstract void ExecuteCommand(object parameter);

        private bool _canExecuteCommand;
    }
}
