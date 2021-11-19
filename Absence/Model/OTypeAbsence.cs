using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Model
{
    class OTypeAbsence
    {

        public int id;
        public string typeAbsence;

        public OTypeAbsence(string typeAbsence, int id = 0)
        {
            this.id = id;
            this.typeAbsence = typeAbsence;
        }
    }
}
