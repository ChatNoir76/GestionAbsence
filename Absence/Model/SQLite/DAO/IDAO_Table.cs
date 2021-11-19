using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Model.SQLite.DAO
{
    interface IDAO_Table<T> : IDAO<T>
    {
        T GetById(int id);
    }
}
