using PortListener.Services;
using Microsoft.Extensions.DependencyInjection;

namespace PortListener.ViewModels
{
    internal class ViewModelLocator
    {
        public static ViewModelLocator Instance = new ViewModelLocator();

        public MainWindowViewModel MainWindowViewModel { get; set; } = ContainerService.Provider.GetService<MainWindowViewModel>();
    }
}
