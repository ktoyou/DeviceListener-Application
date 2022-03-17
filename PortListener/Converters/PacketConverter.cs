using PacketDotNet;
using PortListener.Models;
using SharpPcap;
using System;
using System.Linq;
using System.Text;

namespace PortListener.Converters
{
    internal class PacketConverter : IPacketConverter
    {
        public PacketInfo Convert(PacketCapture capture)
        {
            RawCapture rawCapture = capture.GetPacket();
            Packet packet = Packet.ParsePacket(rawCapture.LinkLayerType, rawCapture.Data);

            TcpPacket tcpPacket;
            IPv4Packet ipv4Packet;

            try
            {
                tcpPacket = new TcpPacket(packet.BytesSegment);
                ipv4Packet = new IPv4Packet(packet.BytesSegment);
            }
            catch (Exception ex)
            {
                return null;
            }

            return new PacketInfo()
            {
                DestinationAddress = ipv4Packet.DestinationAddress.ToString(),
                SourceAddress = ipv4Packet.SourceAddress.ToString(),
                DestinationPort = tcpPacket.DestinationPort.ToString(),
                SourcePort = tcpPacket.SourcePort.ToString(),
                Data = Encoding.ASCII.GetString(packet.Bytes),
                Hex = packet.PrintHex(),
                Size = packet.Bytes.Length
            };
        }
    }
}
