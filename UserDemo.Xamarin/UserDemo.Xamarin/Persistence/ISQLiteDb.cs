using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserDemo.Xamarin.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
