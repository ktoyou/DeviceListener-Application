using PortListener.ViewModels;
using SharpPcap;

namespace PortListener.Commands
{
    internal class StopCaptureCommand : BaseCommand
    {
        public StopCaptureCommand(bool canExecute)
        {
            CanExecuteCommand = canExecute;
        }

        public override void ExecuteCommand(object parameter)
        {
            MainWindowViewModel viewModel = parameter as MainWindowViewModel;
            viewModel.Capturer.ToogleCapture(viewModel.SelectedDevice);
            CanExecuteCommand = viewModel.Capturer.Capturing;
            (viewModel.StartCaptureCommand as StartCaptureCommand).CanExecuteCommand = true;
        }
    }
}
