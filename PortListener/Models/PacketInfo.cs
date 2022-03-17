using PacketDotNet;

namespace PortListener.Models
{
    internal class PacketInfo
    {
        public string SourceAddress { get; set; }

        public string DestinationAddress { get; set; }

        public string SourcePort { get; set; }

        public string DestinationPort { get; set; }

        public string Data { get; set; }

        public string Hex { get; set; }

        public ProtocolType Protocol { get; set; }

        public int Size { get; set; }
    }
}
