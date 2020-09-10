using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wongoo_Application.Shared.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
