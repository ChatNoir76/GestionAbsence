using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Model.SQLite.DAO
{
    interface IDAO_Relation<T, A, B>
    {
        T[] getAllByReference(A valueA, B valueB);
    }
}
