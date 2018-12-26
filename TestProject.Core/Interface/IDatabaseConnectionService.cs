using SQLite;

namespace TestProject.Core.Interface
{
    public interface IDatabaseConnectionService
    {
        SQLiteConnection GetDatebaseConnection();
    }
}
