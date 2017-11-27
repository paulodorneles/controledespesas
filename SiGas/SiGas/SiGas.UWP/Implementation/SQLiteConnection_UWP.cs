using SiGas.Interfaces;
using SiGas.UWP.Implementation;
using SQLite;
using System.IO;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteConnection_UWP))]
namespace SiGas.UWP.Implementation
{
    public class SQLiteConnection_UWP : ISQLiteConnection
    {
        public SQLiteConnection DBConnection()
        {
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sigas.db3");
            return new SQLiteConnection(path);
        }
    }
}
