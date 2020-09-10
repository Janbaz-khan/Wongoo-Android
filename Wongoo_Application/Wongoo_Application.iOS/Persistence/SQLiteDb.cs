using SQLite;
using System.IO;
using Wongoo_Application.iOS.Persistence;
using Wongoo_Application.Shared.Persistence;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace Wongoo_Application.iOS.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "MySqlite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}