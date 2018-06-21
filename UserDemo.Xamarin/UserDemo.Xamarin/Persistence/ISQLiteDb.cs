using SQLite;

namespace UserDemo.Xamarin.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
