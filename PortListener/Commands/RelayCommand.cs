using System;

namespace PortListener.Commands
{
    internal class RelayCommand : BaseCommand
    {
        public RelayCommand(Action<object> action)
        {
            _action = action;
        }

        public override void ExecuteCommand(object parameter) => _action.Invoke(parameter);

        private Action<object> _action;
    }
}
