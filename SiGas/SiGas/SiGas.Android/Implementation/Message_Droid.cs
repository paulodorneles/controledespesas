using Android.App;
using Android.Widget;
using SiGas.Interfaces;
using SiGas.Droid.Implementation;

[assembly: Xamarin.Forms.Dependency(typeof(Message_Droid))]
namespace SiGas.Droid.Implementation
{
    public class Message_Droid : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message,
            ToastLength.Long).Show();
        }
        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message,
            ToastLength.Short).Show();
        }
    }
}