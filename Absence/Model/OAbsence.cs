using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Model
{
    public class OAbsence
    {
        public int id;
        public string motif;
        public string dateDebut;
        public string dateFin;
        public bool prolongation;
        public int idPersonne;
        public int idTypeAbsence;

        public OAbsence(string motif, string dateDebut, string dateFin, bool prolongation, int idPersonne, int idTypeAbsence, int id = 0)
        {
            this.id = id;
            this.motif = motif;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            this.prolongation = prolongation;
            this.idPersonne = idPersonne;
            this.idTypeAbsence = idTypeAbsence;
        }
    }
}
