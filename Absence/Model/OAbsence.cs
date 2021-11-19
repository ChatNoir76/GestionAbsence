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
        public DateTime dateDebut;
        public DateTime dateFin;
        public bool prolongation;
        public int idPersonne;
        public int idAbsence;

        public OAbsence(string motif, DateTime dateDebut, DateTime dateFin, bool prolongation, int idPersonne, int idAbsence, int id = 0)
        {
            this.id = id;
            this.motif = motif;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            this.prolongation = prolongation;
            this.idPersonne = idPersonne;
            this.idAbsence = idAbsence;
        }
    }
}
