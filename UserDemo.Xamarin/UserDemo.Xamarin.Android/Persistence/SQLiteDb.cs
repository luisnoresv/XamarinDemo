using System;
using System.IO;
using SQLite;
using UserDemo.Xamarin.Droid.Persistence;
using UserDemo.Xamarin.Persistence;
using Xamarin.Forms;


[assembly: Dependency(typeof(SQLiteDb))]

namespace UserDemo.Xamarin.Droid.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //var documentsPath = @"D:/lnores/Documents/belatrix/Projects/Xamarin/UserDemo.Xamarin/";
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}