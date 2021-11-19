using Absence.Model.DAO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Model.SQLite.DAO
{
    class DAOPersonne : AbstractDAO, IDAO_Table<OPersonne>
    {

        private const string R_GETBYID = "select * from Personne where id_personne = ?";
        private const string R_GETBYALL = "select * from Personne";
        private const string R_DELETE = "DELETE FROM Personne WHERE id_personne=?";
        private const string R_UPDATE = "UPDATE Personne SET nom_personne=?, prenom_personne=? WHERE id_personne=?";
        private const string R_INSERT = "INSERT INTO Personne values (null,?,?)";

        public bool Delete(OPersonne value)
        {
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = value.id;
            int ligne = this.ExecuteNonQuery(R_DELETE, p1);
            return ligne != 0;
        }

        public List<OPersonne> GetAll()
        {
            List<OPersonne> liste = new List<OPersonne>();
            using (SQLiteDataReader reader = this.ExecuteReader(R_GETBYALL))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        liste.Add(GetObjectFromReader(reader));
                    }
                }
                return liste;
            } 
        }

        public OPersonne GetById(int id)
        {
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = id;
            using (SQLiteDataReader reader = this.ExecuteReader(R_GETBYID, p1))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        return GetObjectFromReader(reader);
                    }
                }
            }
            return null;
        }

        public void Insert(OPersonne value)
        {
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = value.nom;
            SQLiteParameter p2 = new SQLiteParameter();
            p2.Value = value.prenom;

            value.id = this.ExecuteScalar(R_INSERT, p1, p2);
        }

        public void Update(OPersonne value)
        {
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = value.nom;
            SQLiteParameter p2 = new SQLiteParameter();
            p2.Value = value.prenom;
            SQLiteParameter p3 = new SQLiteParameter();
            p3.Value = value.id;
            this.ExecuteNonQuery(R_UPDATE, p1, p2, p3);
        }

        public OPersonne GetObjectFromReader(SQLiteDataReader value)
        {
            return new OPersonne(value.GetString(1), value.GetString(2), value.GetInt32(0));
        }
    }
}
