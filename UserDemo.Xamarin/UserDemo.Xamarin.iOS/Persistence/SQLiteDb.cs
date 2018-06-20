using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Foundation;
using SQLite;
using UIKit;
using UserDemo.Xamarin.iOS.Persistence;
using UserDemo.Xamarin.Persistence;

//[assembly: Dependency(typeof(SQLiteDb))]

namespace UserDemo.Xamarin.iOS.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}