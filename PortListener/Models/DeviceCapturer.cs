using SharpPcap;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using PortListener.Converters;
using System.Windows;

namespace PortListener.Models
{
    internal class DeviceCapturer : IDeviceCapturer
    {
        public bool Capturing { get; set; }

        public DeviceCapturer(IPacketConverter converter, ObservableCollection<PacketInfo> packets)
        {
            if(packets == null) throw new ArgumentNullException("Packets must be not null");

            _devices = CaptureDeviceList.Instance;
            _packetConverter = converter;
            _packets = packets;
            Capturing = false;
        }

        public void ToogleCapture(ILiveDevice device)
        {
            if(Capturing == false)
            {
                device.Open(DeviceModes.Promiscuous, 100);
                device.OnPacketArrival += PacketArrival;
                device.StartCapture();
                Capturing = true;
            } else
            {
                device.StopCapture();
                device.Close();
                device.OnPacketArrival -= PacketArrival;
                Capturing = false;
            }
        }

        public void PacketArrival(object sender, PacketCapture e)
        {
            PacketInfo packet = _packetConverter.Convert(e);
            if (packet == null) return;
            Application.Current.Dispatcher.Invoke(() => _packets.Add(packet));
        }

        public IEnumerable<ILiveDevice> GetDevices() => _devices;

        private CaptureDeviceList _devices;

        private IPacketConverter _packetConverter;

        private ObservableCollection<PacketInfo> _packets;
    }
}
