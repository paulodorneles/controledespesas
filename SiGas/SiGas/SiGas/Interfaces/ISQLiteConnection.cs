using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SiGas.Interfaces
{
    public interface ISQLiteConnection
    {
        SQLiteConnection DBConnection();
    }
}
