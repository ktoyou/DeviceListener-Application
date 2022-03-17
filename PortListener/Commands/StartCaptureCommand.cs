using PortListener.ViewModels;
using SharpPcap;
using System;

namespace PortListener.Commands
{
    internal class StartCaptureCommand : BaseCommand
    {
        public StartCaptureCommand(bool canExecute)
        {
            CanExecuteCommand = canExecute;
        }

        public override void ExecuteCommand(object parameter)
        {
            MainWindowViewModel viewModel = parameter as MainWindowViewModel;
            viewModel.Capturer.ToogleCapture(viewModel.SelectedDevice);
            CanExecuteCommand = !viewModel.Capturer.Capturing;
            (viewModel.StopCaptureCommand as StopCaptureCommand).CanExecuteCommand = true;
        }
    }
}
