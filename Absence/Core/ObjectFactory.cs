using Absence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Core
{
    public sealed class ObjectFactory
    {
        private static ObjectFactory _instance;

        public static ObjectFactory eInstance()
        {
            if (_instance == null)
            {
                _instance = new ObjectFactory();
            }
            return _instance;
        }

        public OPersonne createPersonne(string nom, string prenom)
        {
            return new OPersonne(nom, prenom);
        }

        public OAbsence createAbsence(string motif, string dateDebut, string dateFin, bool prolongation, int idPersonne, int idAbsence, int id = 0)
        {
            return new OAbsence(motif, dateDebut, dateFin, prolongation, idPersonne, idAbsence);
        }

        public ViewListObject createViewListObject(OPersonne personne)
        {
            return new ViewListObject(personne);
        }
    }
}
