using PortListener.Models;
using SharpPcap;

namespace PortListener.Converters
{
    internal interface IPacketConverter
    {
        PacketInfo Convert(PacketCapture capture);
    }
}
