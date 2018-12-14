using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Core
{
    public interface ISqLiteDbPath
    {
        string  GetDatebasePath(string sqliteFilename);
    }
}
