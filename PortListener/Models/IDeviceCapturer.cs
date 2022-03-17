using SharpPcap;
using System.Collections.Generic;

namespace PortListener.Models
{
    internal interface IDeviceCapturer
    {
        IEnumerable<ILiveDevice> GetDevices();
    }
}
