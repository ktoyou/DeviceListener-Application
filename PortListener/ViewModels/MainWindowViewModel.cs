using PacketDotNet;
using PortListener.Commands;
using PortListener.Converters;
using PortListener.Models;
using SharpPcap;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PortListener.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public ILiveDevice SelectedDevice
        {
            get => _selectedDevice;
            set
            {
                _selectedDevice = value;
                (StartCaptureCommand as StartCaptureCommand).CanExecuteCommand = Capturer.Capturing == false;
                OnPropertyChanged(nameof(SelectedDevice));
            }
        }

        public PacketInfo SelectedPacket
        {
            get => _selectedPacket;
            set
            {
                _selectedPacket = value;
                OnPropertyChanged(nameof(SelectedPacket));
            }
        }

        public ObservableCollection<ILiveDevice> Devices { get; set; }

        public ObservableCollection<PacketInfo> Packets { get; set; }

        public ICommand StartCaptureCommand { get; set; }

        public ICommand StopCaptureCommand { get; set; }

        public DeviceCapturer Capturer { get; set; }

        public MainWindowViewModel()
        {
            StartCaptureCommand = new StartCaptureCommand(false);
            StopCaptureCommand = new StopCaptureCommand(false);
            Packets = new ObservableCollection<PacketInfo>();
            Capturer = new DeviceCapturer(new PacketConverter(), Packets);
            Devices = new ObservableCollection<ILiveDevice>(Capturer.GetDevices());
        }

        private ILiveDevice _selectedDevice;

        private PacketInfo _selectedPacket;
    }
}
