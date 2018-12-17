using System.IO;
using TestProject.Core;
using TestProject.Core.Interface;
using SQLite;

namespace TestProject.Droid
{
    class SqliteDbPath : ISqLiteDbPath
    {
        public string GetDatebasePath(string sqliteFilename)
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            return Path.Combine(documentPath, sqliteFilename);

        }
    }
}