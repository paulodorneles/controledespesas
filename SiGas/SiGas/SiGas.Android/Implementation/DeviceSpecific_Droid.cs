using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SiGas.Interfaces;
using SiGas.Droid.Implementation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceSpecific_Droid))]
namespace SiGas.Droid.Implementation
{
    public class DeviceSpecific_Droid : IDeviceSpecific
    {
        public void CloseApplication()
        {
            Process.KillProcess(Process.MyPid());
        }
    }
}