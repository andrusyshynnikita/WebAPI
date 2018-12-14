using System;
using TestProject.Core.Interface;
using SQLite;
using SQLitePCL;

//namespace TestProject.Core.services
//{
//    public class SqLiteConnection : ISqLiteConnection
//    {
//        private readonly SqLiteConnection _datebaseConnection;

//        public SqLiteConnection(ISqLiteDbPath sqLiteDbPath)
//        {

//            var path = sqLiteDbPath;

//            _datebaseConnection = new SqLiteConnection(path); ;
//        }

//       public SqLiteConnection GetDatebaseConnection()
//        {
//            return _datebaseConnection;
//        }

//        SQLiteConnection ISqLiteConnection.GetDatebaseConnection()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
