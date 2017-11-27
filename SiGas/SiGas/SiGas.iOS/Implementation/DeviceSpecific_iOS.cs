using Xamarin.Forms;
using SiGas.iOS.Implementation;
using CoreLocation;
using SiGas.Interfaces;
using System.Threading;



namespace SiGas.iOS.Implementation
{
    public class DeviceSpecific_iOS : IDeviceSpecific
    {
        public void CloseApplication()
        {
            Thread.CurrentThread.Abort();
        }
    }
}
