using TestProject.Core.Interface;
using System.IO;
using SQLite;

namespace TestProject.IOS.Services
{
    public class DatabaseConnectionService
          : IDatabaseConnectionService
    {
        public DatabaseConnectionService()
        {
            var database = GetDatebaseConnection();
        }

        public SQLiteConnection GetDatebaseConnection()
        {
            var dbName = "TaskyDB.db3";
            var path = Path.Combine(System.Environment.
              GetFolderPath(System.Environment.
              SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}