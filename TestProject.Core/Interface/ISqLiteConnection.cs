﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TestProject.Core.Interface
{
    public interface ISqLiteConnection
    {
        SQLiteConnection GetDatebaseConnection();
    }
}
