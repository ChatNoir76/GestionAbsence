using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Absence.Model.SQLite.DAO
{
    interface IDAO<T>
    {
        void Insert(T value);
        List<T> GetAll();
        bool Delete(T value);
        void Update(T value);
        T GetObjectFromReader(SQLiteDataReader value);
    }
}
