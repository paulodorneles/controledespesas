using SiGas.Droid.Implementation;
using SiGas.Interfaces;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteConnection_Droid))]
namespace SiGas.Droid.Implementation
{
    public class SQLiteConnection_Droid : ISQLiteConnection
    {
        public SQLiteConnection DBConnection()
        {
            var path = Path.Combine(System.Environment.
            GetFolderPath(System.Environment.
           SpecialFolder.Personal), "mostrarota.db3");
            return new SQLiteConnection(path);
        }
    }
}