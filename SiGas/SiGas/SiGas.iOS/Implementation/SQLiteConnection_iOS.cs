using SiGas.Interfaces;
using SiGas.iOS.Implementation;
using SQLite;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteConnection_iOS))]
namespace SiGas.iOS.Implementation
{
    public class SQLiteConnection_iOS : ISQLiteConnection
    {
        public SQLiteConnection DBConnection()
        {
            string personalFolder = System.Environment.GetFolderPath(
            Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, "mostrarota.db3");
            return new SQLiteConnection(path);
        }
    }

}
