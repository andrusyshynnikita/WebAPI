using TestProject.Core.Interface;
using SQLite;


//namespace testproject.core.services
//{
//    public class sqliteconnection : ISqLiteConnection
//    {
//        private readonly sqliteconnection _datebaseconnection;

//        public sqliteconnection(ISqLiteDbPath sqlitedbpath)
//        {

//            var path = sqlitedbpath.getdatebasepath("datebase.db");

//            _datebaseconnection = new sqliteconnection(path, sqliteopenflags.readwrite | sqliteopenflags.create | sqliteopenflags.fullmutex | sqliteopenflags.sharedcache); ;
//        }

//        public sqliteconnection getdatebaseconnection()
//        {
//            return _datebaseconnection;
//        }


//    }
//}
