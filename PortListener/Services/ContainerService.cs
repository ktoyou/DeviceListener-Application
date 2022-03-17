using Microsoft.Extensions.DependencyInjection;
using PortListener.ViewModels;
using System;

namespace PortListener.Services
{
    internal static class ContainerService
    {
        public static IServiceProvider Provider;

        static ContainerService()
        {
            ServiceCollection collection = new ServiceCollection();

            collection.AddSingleton<MainWindowViewModel>();

            Provider = collection.BuildServiceProvider();
        }
    }
}
