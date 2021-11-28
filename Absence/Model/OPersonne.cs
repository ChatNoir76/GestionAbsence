using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Model
{
    public class OPersonne
    {

        public int id;
        public string nom;
        public string prenom;

        public OPersonne(string nom, string prenom, int id = 0)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
        }

        public override string ToString()
        {
            return this.nom.ToUpper() + " " + this.prenom.ToLower();
        }
    }
}
